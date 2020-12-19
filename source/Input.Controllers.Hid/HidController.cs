using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using TerraFX.Interop;
using static NathanAldenSr.VorpalEngine.Common.ExceptionHelper;
using static NathanAldenSr.VorpalEngine.Common.Windows.ExceptionHelper;
using static TerraFX.Interop.Windows;

namespace NathanAldenSr.VorpalEngine.Input.Controllers.Hid
{
    internal class HidController
    {
        private const int MaximumButtonCount = 32;
        private HidControllerState _newState;
        private HidControllerState _oldState;
        private HidControllerStateChanges _stateChanges;

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
            _stateChanges = new HidControllerStateChanges(index);
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

            var buttonIndexesByButtonNumber = new Dictionary<ushort, byte>();
            var buttonNumbersByButtonIndex = new Dictionary<byte, ushort>();

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
        public uint Index { get; }
        public HIDP_BUTTON_CAPS ButtonCapabilities { get; }
        public IReadOnlyList<HIDP_VALUE_CAPS> ValueCapabilities { get; }
        public string? Manufacturer { get; }
        public string? ProductName { get; }
        public string? SerialNumber { get; }
        public byte ButtonCount { get; }
        public uint ButtonMask { get; }
        public byte ValueCount { get; }
        public IReadOnlyDictionary<ushort, byte> ButtonIndexesByButtonNumber { get; }
        public IReadOnlyDictionary<byte, ushort> ButtonNumbersByButtonIndex { get; }

        public unsafe void UpdateState(RAWINPUT* rawInput)
        {
            // https://www.codeproject.com/articles/185522/using-the-raw-input-api-to-process-joystick-input

            // Get preparsed data

            IntPtr deviceHandle = rawInput->header.hDevice;
            uint size;

            ThrowExternalExceptionIfNonZero(
                GetRawInputDeviceInfoW(deviceHandle, RIDI_PREPARSEDDATA, null, &size),
                nameof(GetRawInputDeviceInfoW));

            byte* pPreparsedDataBuffer = stackalloc byte[(int)size];
            var pPreparsedData = (IntPtr)pPreparsedDataBuffer;

            uint result = GetRawInputDeviceInfoW(deviceHandle, RIDI_PREPARSEDDATA, pPreparsedDataBuffer, &size);

            if (result == unchecked((uint)-1) || result != size)
            {
                ThrowExternalException(result, nameof(GetRawInputDeviceInfoW));
            }

            // Get button states

            ushort* pUsages = stackalloc ushort[ButtonCount];
            uint usageCount = ButtonCount;

            ThrowExternalExceptionIf(
                HidP_GetUsages(
                    HIDP_REPORT_TYPE.HidP_Input,
                    ButtonCapabilities.UsagePage,
                    0,
                    pUsages,
                    &usageCount,
                    pPreparsedData,
                    (sbyte*)rawInput->data.hid.bRawData,
                    rawInput->data.hid.dwSizeHid),
                a => a != HIDP_STATUS_SUCCESS,
                nameof(HidP_GetUsages));

            _newState.ButtonStates = 0;

            for (var i = 0; i < usageCount; i++)
            {
                _newState.ButtonStates |= (uint)(1 << (pUsages[i] - ButtonCapabilities.Anonymous.Range.UsageMin));
            }

            _newState.HatSwitch.IsValid = false;
            _newState.DirectionalPadUp.IsValid = false;
            _newState.DirectionalPadDown.IsValid = false;
            _newState.DirectionalPadLeft.IsValid = false;
            _newState.DirectionalPadRight.IsValid = false;
            _newState.XAxis.IsValid = false;
            _newState.YAxis.IsValid = false;
            _newState.ZAxis.IsValid = false;
            _newState.XAxisRotation.IsValid = false;
            _newState.YAxisRotation.IsValid = false;
            _newState.ZAxisRotation.IsValid = false;

            // Get value states

            for (var i = 0; i < ValueCount; i++)
            {
                uint value;

                HIDP_VALUE_CAPS valueCapability = ValueCapabilities[i];

                ThrowExternalExceptionIf(
                    HidP_GetUsageValue(
                        HIDP_REPORT_TYPE.HidP_Input,
                        valueCapability.UsagePage,
                        0,
                        valueCapability.Anonymous.Range.UsageMin,
                        &value,
                        pPreparsedData,
                        (sbyte*)rawInput->data.hid.bRawData,
                        rawInput->data.hid.dwSizeHid),
                    a => a != HIDP_STATUS_SUCCESS,
                    nameof(HidP_GetUsageValue));

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                void SetStateValue(ref HidControllerStateValue stateValueField, uint newValue)
                {
                    stateValueField =
                        new HidControllerStateValue(
                            valueCapability.LogicalMin,
                            valueCapability.LogicalMax,
                            // It's not clear what to do for relative values if there is no previous value, so assume adding to zero is okay
                            unchecked((int)(valueCapability.IsAbsolute == TRUE ? newValue : stateValueField.Value + newValue)));
                }

                switch (valueCapability.Anonymous.Range.UsageMin)
                {
                    case HID_USAGE_GENERIC_HATSWITCH:
                        SetStateValue(ref _newState.HatSwitch, value);
                        break;
                    case HID_USAGE_GENERIC_DPAD_UP:
                        SetStateValue(ref _newState.DirectionalPadUp, value);
                        break;
                    case HID_USAGE_GENERIC_DPAD_DOWN:
                        SetStateValue(ref _newState.DirectionalPadDown, value);
                        break;
                    case HID_USAGE_GENERIC_DPAD_LEFT:
                        SetStateValue(ref _newState.DirectionalPadLeft, value);
                        break;
                    case HID_USAGE_GENERIC_DPAD_RIGHT:
                        SetStateValue(ref _newState.DirectionalPadRight, value);
                        break;
                    case HID_USAGE_GENERIC_X:
                        SetStateValue(ref _newState.XAxis, value);
                        break;
                    case HID_USAGE_GENERIC_Y:
                        SetStateValue(ref _newState.YAxis, value);
                        break;
                    case HID_USAGE_GENERIC_Z:
                        SetStateValue(ref _newState.ZAxis, value);
                        break;
                    case HID_USAGE_GENERIC_RX:
                        SetStateValue(ref _newState.XAxisRotation, value);
                        break;
                    case HID_USAGE_GENERIC_RY:
                        SetStateValue(ref _newState.YAxisRotation, value);
                        break;
                    case HID_USAGE_GENERIC_RZ:
                        SetStateValue(ref _newState.ZAxisRotation, value);
                        break;
                }
            }

            _newState.IsValid = true;
        }

        public bool TryCalculateStateChanges(out HidControllerStateChanges stateChanges)
        {
            bool isValid = _oldState.IsValid && _newState.IsValid;

            if (isValid)
            {
                static (HidControllerValue oldValue, HidControllerValue newValue) GetHidControllerValues(
                    in HidControllerStateValue oldStateValue,
                    in HidControllerStateValue newStateValue) =>
                    (new HidControllerValue(oldStateValue.LogicalMinimum, oldStateValue.LogicalMaximum, oldStateValue.Value),
                     new HidControllerValue(newStateValue.LogicalMinimum, newStateValue.LogicalMaximum, newStateValue.Value));

                // Calculate state changes

                _stateChanges.DownButtonStates = _newState.ButtonStates;
                _stateChanges.PressedButtonStates = ~_oldState.ButtonStates & _newState.ButtonStates;
                _stateChanges.ReleasedButtonStates = _oldState.ButtonStates & ~_newState.ButtonStates & ButtonMask;
                _stateChanges.HatSwitch = GetHidControllerValues(in _oldState.HatSwitch, in _newState.HatSwitch);
                _stateChanges.DirectionalPadUp = GetHidControllerValues(in _oldState.DirectionalPadUp, in _newState.DirectionalPadUp);
                _stateChanges.DirectionalPadDown = GetHidControllerValues(in _oldState.DirectionalPadDown, in _newState.DirectionalPadDown);
                _stateChanges.DirectionalPadLeft = GetHidControllerValues(in _oldState.DirectionalPadLeft, in _newState.DirectionalPadLeft);
                _stateChanges.DirectionalPadRight = GetHidControllerValues(in _oldState.DirectionalPadRight, in _newState.DirectionalPadRight);
                _stateChanges.XAxis = GetHidControllerValues(in _oldState.XAxis, in _newState.XAxis);
                _stateChanges.YAxis = GetHidControllerValues(in _oldState.YAxis, in _newState.YAxis);
                _stateChanges.ZAxis = GetHidControllerValues(in _oldState.ZAxis, in _newState.ZAxis);
                _stateChanges.XAxisRotation = GetHidControllerValues(in _oldState.XAxisRotation, in _newState.XAxisRotation);
                _stateChanges.YAxisRotation = GetHidControllerValues(in _oldState.YAxisRotation, in _newState.YAxisRotation);
                _stateChanges.ZAxisRotation = GetHidControllerValues(in _oldState.ZAxisRotation, in _newState.ZAxisRotation);
            }
            if (_newState.IsValid)
            {
                // The new state becomes the old state and the new state is reset

                _oldState = _newState;
                _newState.Reset();
            }

            stateChanges = isValid ? _stateChanges : default;

            return isValid;
        }
    }
}