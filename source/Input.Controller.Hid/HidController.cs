// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Collections.ObjectModel;
using TerraFX.Interop;
using static TerraFX.Interop.Windows;

namespace VorpalEngine.Input.Controller.Hid;

internal sealed class HidController : IHidController
{
    private const int MaximumButtonCount = 32;
    private HidControllerState _newState;
    private HidControllerState _oldState;

    public HidController(
        IntPtr deviceHandle,
        uint index,
        HIDP_BUTTON_CAPS buttonCapabilities,
        ReadOnlySpan<HIDP_VALUE_CAPS> valueCapabilities,
        string? manufacturer,
        string? productName,
        string? serialNumber,
        ushort minimumButtonNumber,
        ushort maximumButtonNumber)
    {
        ThrowIfZero(deviceHandle, nameof(deviceHandle));

        DeviceHandle = deviceHandle;
        Index = index;
        ButtonCapabilities = buttonCapabilities;
        ValueCapabilities = valueCapabilities.ToArray().ToImmutableArray();
        Manufacturer = manufacturer;
        ProductName = productName;
        SerialNumber = serialNumber;
        ButtonCount = (byte)(maximumButtonNumber - minimumButtonNumber + 1);
        ButtonMask = (1u << ButtonCount) - 1;
        ValueCount = (byte)valueCapabilities.Length;
        _oldState = new HidControllerState(index);
        _newState = new HidControllerState(index);

        Dictionary<ushort, byte> buttonIndexesByButtonNumber = new();
        Dictionary<byte, ushort> buttonNumbersByButtonIndex = new();

        for (ushort buttonNumber = minimumButtonNumber; buttonNumber <= maximumButtonNumber; buttonNumber++)
        {
            var buttonIndex = (byte)(buttonNumber - minimumButtonNumber);

            buttonIndexesByButtonNumber.Add(buttonNumber, buttonIndex);
            buttonNumbersByButtonIndex.Add(buttonIndex, buttonNumber);
        }

        ButtonIndexesByButtonNumber = new ReadOnlyDictionary<ushort, byte>(buttonIndexesByButtonNumber);
        ButtonNumbersByButtonIndex = new ReadOnlyDictionary<byte, ushort>(buttonNumbersByButtonIndex);

        if (ButtonCount > MaximumButtonCount)
        {
            ThrowArgumentException($"The maximum number of buttons supported is {MaximumButtonCount}.", nameof(maximumButtonNumber));
        }
    }

    public IntPtr DeviceHandle { get; }
    public HIDP_BUTTON_CAPS ButtonCapabilities { get; }
    public IReadOnlyList<HIDP_VALUE_CAPS> ValueCapabilities { get; }
    public uint ButtonMask { get; }
    public IReadOnlyDictionary<ushort, byte> ButtonIndexesByButtonNumber { get; }
    public IReadOnlyDictionary<byte, ushort> ButtonNumbersByButtonIndex { get; }
    public uint Index { get; }
    public string? Manufacturer { get; }
    public string? ProductName { get; }
    public string? SerialNumber { get; }
    public byte ButtonCount { get; }
    public byte ValueCount { get; }

    public unsafe void UpdateState(RAWINPUT* rawInput)
    {
        ThrowIfNull(rawInput, nameof(rawInput));

        // https://www.codeproject.com/articles/185522/using-the-raw-input-api-to-process-joystick-input

        // Get preparsed data

        IntPtr deviceHandle = rawInput->header.hDevice;
        uint size;

        ThrowForLastErrorIfNotZero(
            GetRawInputDeviceInfoW(deviceHandle, RIDI_PREPARSEDDATA, null, &size),
            nameof(GetRawInputDeviceInfoW));

        byte* pPreparsedDataBuffer = stackalloc byte[(int)size];
        var pPreparsedData = (IntPtr)pPreparsedDataBuffer;

        {
            uint result = GetRawInputDeviceInfoW(deviceHandle, RIDI_PREPARSEDDATA, pPreparsedDataBuffer, &size);

            if (result == unchecked((uint)-1) || result != size)
            {
                ThrowExternalException(nameof(GetRawInputDeviceInfoW), unchecked((int)result));
            }
        }
        {
            // Get button states

            ushort* pUsages = stackalloc ushort[ButtonCount];
            uint usageCount = ButtonCount;
            int result =
                HidP_GetUsages(
                    HIDP_REPORT_TYPE.HidP_Input,
                    ButtonCapabilities.UsagePage,
                    0,
                    pUsages,
                    &usageCount,
                    pPreparsedData,
                    (sbyte*)rawInput->data.hid.bRawData,
                    rawInput->data.hid.dwSizeHid);

            if (result != HIDP_STATUS_SUCCESS)
            {
                ThrowExternalException(nameof(HidP_GetUsages), result);
            }

            _newState.DownButtonStates = 0;

            for (var i = 0; i < usageCount; i++)
            {
                _newState.DownButtonStates |= (uint)(1 << (pUsages[i] - ButtonCapabilities.Anonymous.Range.UsageMin));
            }

            // Get value states

            for (var i = 0; i < ValueCount; i++)
            {
                HIDP_VALUE_CAPS valueCapability = ValueCapabilities[i];
                uint value;

                result =
                    HidP_GetUsageValue(
                        HIDP_REPORT_TYPE.HidP_Input,
                        valueCapability.UsagePage,
                        0,
                        valueCapability.Anonymous.Range.UsageMin,
                        &value,
                        pPreparsedData,
                        (sbyte*)rawInput->data.hid.bRawData,
                        rawInput->data.hid.dwSizeHid);

                if (result != HIDP_STATUS_SUCCESS)
                {
                    ThrowExternalException(nameof(HidP_GetUsageValue), result);
                }

                static HidControllerStateValue CalculateState(in HIDP_VALUE_CAPS valueCapability, uint value, in HidControllerStateValue stateValue)
                    => new(
                        // Handles so-called "null" HID values
                        value >= valueCapability.LogicalMin && value <= valueCapability.LogicalMax,
                        valueCapability.LogicalMin,
                        valueCapability.LogicalMax,
                        // It's not clear what to do for relative values if there is no previous value, so assume adding to zero is okay
                        (int)(valueCapability.IsAbsolute == TRUE ? value : stateValue.Value + value));

                switch (valueCapability.Anonymous.Range.UsageMin)
                {
                    case HID_USAGE_GENERIC_HATSWITCH:
                        _newState.HatSwitchStateValue = CalculateState(in valueCapability, value, in _newState.HatSwitchStateValue);
                        break;
                    case HID_USAGE_GENERIC_DPAD_UP:
                        _newState.DirectionalPadUpStateValue = CalculateState(in valueCapability, value, in _newState.DirectionalPadUpStateValue);
                        break;
                    case HID_USAGE_GENERIC_DPAD_DOWN:
                        _newState.DirectionalPadDownStateValue = CalculateState(in valueCapability, value, in _newState.DirectionalPadDownStateValue);
                        break;
                    case HID_USAGE_GENERIC_DPAD_LEFT:
                        _newState.DirectionalPadLeftStateValue = CalculateState(in valueCapability, value, in _newState.DirectionalPadLeftStateValue);
                        break;
                    case HID_USAGE_GENERIC_DPAD_RIGHT:
                        _newState.DirectionalPadRightStateValue = CalculateState(in valueCapability, value, in _newState.DirectionalPadRightStateValue);
                        break;
                    case HID_USAGE_GENERIC_X:
                        _newState.XAxisStateValue = CalculateState(in valueCapability, value, in _newState.XAxisStateValue);
                        break;
                    case HID_USAGE_GENERIC_Y:
                        _newState.YAxisStateValue = CalculateState(in valueCapability, value, in _newState.YAxisStateValue);
                        break;
                    case HID_USAGE_GENERIC_Z:
                        _newState.ZAxisStateValue = CalculateState(in valueCapability, value, in _newState.ZAxisStateValue);
                        break;
                    case HID_USAGE_GENERIC_RX:
                        _newState.XAxisRotationStateValue = CalculateState(in valueCapability, value, in _newState.XAxisRotationStateValue);
                        break;
                    case HID_USAGE_GENERIC_RY:
                        _newState.YAxisRotationStateValue = CalculateState(in valueCapability, value, in _newState.YAxisRotationStateValue);
                        break;
                    case HID_USAGE_GENERIC_RZ:
                        _newState.ZAxisRotationStateValue = CalculateState(in valueCapability, value, in _newState.ZAxisRotationStateValue);
                        break;
                }
            }
        }

        _newState.UpdateCounter++;
        _newState.HasChanged = true;
    }

    public bool TryGetState(out HidControllerState state)
    {
        // Default state values are unreliable, so fail if the state has never been updated
        if (_newState.UpdateCounter == 0)
        {
            state = default;

            return false;
        }

        // Recalculate fields if there were updates since the last state retrieval
        if (_newState.UpdateCounter > _oldState.UpdateCounter)
        {
            _newState.PressedButtonStates = ~_oldState.PressedButtonStates & _newState.PressedButtonStates;
            _newState.ReleasedButtonStates = _oldState.ReleasedButtonStates & ~_newState.ReleasedButtonStates & ButtonMask;
            _newState.HatSwitch = (_oldState.HatSwitchStateValue, _newState.HatSwitchStateValue);
            _newState.DirectionalPadUp = (_oldState.DirectionalPadUpStateValue, _newState.DirectionalPadUpStateValue);
            _newState.DirectionalPadDown = (_oldState.DirectionalPadDownStateValue, _newState.DirectionalPadDownStateValue);
            _newState.DirectionalPadLeft = (_oldState.DirectionalPadLeftStateValue, _newState.DirectionalPadLeftStateValue);
            _newState.DirectionalPadRight = (_oldState.DirectionalPadRightStateValue, _newState.DirectionalPadRightStateValue);
            _newState.XAxis = (_oldState.XAxisStateValue, _newState.XAxisStateValue);
            _newState.YAxis = (_oldState.YAxisStateValue, _newState.YAxisStateValue);
            _newState.ZAxis = (_oldState.ZAxisStateValue, _newState.ZAxisStateValue);
            _newState.XAxisRotation = (_oldState.XAxisRotationStateValue, _newState.XAxisRotationStateValue);
            _newState.YAxisRotation = (_oldState.YAxisRotationStateValue, _newState.YAxisRotationStateValue);
            _newState.ZAxisRotation = (_oldState.ZAxisRotationStateValue, _newState.ZAxisRotationStateValue);
        }

        _newState.HasChanged = _oldState.UpdateCounter != _newState.UpdateCounter;
        _oldState = _newState;
        state = _newState;

        return true;
    }
}