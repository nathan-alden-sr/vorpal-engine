// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Diagnostics.CodeAnalysis;
using TerraFX.Interop.Windows;
using TerraFX.Utilities;
using VorpalEngine.Common;
using VorpalEngine.Logging;
using static TerraFX.Interop.Windows.FILE;
using static TerraFX.Interop.Windows.HIDP;
using static TerraFX.Interop.Windows.OPEN;
using static TerraFX.Interop.Windows.Windows;

namespace VorpalEngine.Input.Controller.Hid;

/// <summary>Manages HID controller input.</summary>
public sealed class HidControllerManager : IHidControllerManager
{
    private const int InitialCapacity = 4;
    private readonly IHidControllerRepository _hidControllerRepository;
    private readonly Dictionary<IntPtr, HidController?> _hidControllersByHandle = new(InitialCapacity);
    private readonly Dictionary<uint, HidController> _hidControllersByIndex = new(InitialCapacity);
    private readonly ContextLogger? _logger;

    /// <summary>Initializes a new instance of the <see cref="HidControllerManager" /> class.</summary>
    /// <param name="hidControllerRepository">An <see cref="IHidControllerRepository" /> implementation.</param>
    /// <param name="context">A nested context.</param>
    public HidControllerManager(IHidControllerRepository hidControllerRepository, NestedContext context = default)
    {
        ThrowIfNull(hidControllerRepository);

        context = context.Push<HidControllerManager>();

        _hidControllerRepository = hidControllerRepository;
        _logger = new ContextLogger(context);
    }

    /// <inheritdoc />
    public unsafe void UpdateState(RAWINPUT* rawInput)
    {
        ThrowIfNull(rawInput);

        var deviceHandle = rawInput->header.hDevice;

        if (!_hidControllersByHandle.TryGetValue(deviceHandle, out var controller))
        {
            /*
             * The user can plug in and unplug devices at any time, causing device handles
             * to change unpredictably. Detecting a new device handle is a good time to validate
             * that configured HID controllers are still connected.
             */

            RemoveDisconnectedControllers();

            var fileHandle = OpenRawInputDevice(deviceHandle);

            controller = ConfigureController(deviceHandle, fileHandle);
        }

        controller?.UpdateState(rawInput);
    }

    /// <inheritdoc />
    public IReadOnlyCollection<uint> StateChangeIndexes => _hidControllersByIndex.Keys;

    /// <inheritdoc />
    public bool TryGetState(uint index, [NotNullWhen(true)] out IHidController? controller, out HidControllerState state)
    {
        if (_hidControllersByIndex.TryGetValue(index, out var hidController))
        {
            controller = hidController;

            return hidController.TryGetState(out state);
        }

        controller = null;
        state = default;

        return false;
    }

    /// <inheritdoc />
    public void InvalidateController(uint index)
    {
        if (_hidControllersByIndex.Remove(index, out var controller))
        {
            _ = _hidControllersByHandle.Remove(controller.DeviceHandle);
        }
    }

    private unsafe void RemoveDisconnectedControllers()
    {
        // Retrieve the current list of HID devices

        uint rawInputDeviceCount;
        var result = GetRawInputDeviceList(null, &rawInputDeviceCount, (uint)sizeof(RAWINPUTDEVICELIST));

        if (result == unchecked((uint)-1))
        {
            ExceptionUtilities.ThrowExternalException(nameof(GetRawInputDeviceList), unchecked((int)result));
        }

        var pRawInputDeviceList = stackalloc RAWINPUTDEVICELIST[(int)rawInputDeviceCount];

        result = GetRawInputDeviceList(pRawInputDeviceList, &rawInputDeviceCount, (uint)sizeof(RAWINPUTDEVICELIST));

        if (result == unchecked((uint)-1))
        {
            ExceptionUtilities.ThrowExternalException(nameof(GetRawInputDeviceList), unchecked((int)result));
        }

        // Remove any cached HID controllers that are no longer valid

        var validDeviceHandles = new HashSet<HANDLE>();

        for (var i = 0; i < rawInputDeviceCount; i++)
        {
            _ = validDeviceHandles.Add(pRawInputDeviceList[i].hDevice);
        }

        // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
        foreach (var controller in _hidControllersByHandle.Values)
        {
            if (controller is null || validDeviceHandles.Contains(controller.DeviceHandle))
            {
                continue;
            }

            _logger?.Verbose(
                "Removing disconnected HID controller {Index} with manufacturer {Manufacturer}, product name {ProductName}, and serial number {SerialNumber}",
                controller.Index,
                controller.Manufacturer,
                controller.ProductName,
                controller.SerialNumber);

            InvalidateController(controller.Index);
        }
    }

    private unsafe HANDLE OpenRawInputDevice(HANDLE deviceHandle)
    {
        uint size;

        ThrowIfNotZero(GetRawInputDeviceInfoW(deviceHandle, RIDI_DEVICENAME, null, &size));

        var pDeviceName = stackalloc ushort[(int)size];
        var result = GetRawInputDeviceInfoW(deviceHandle, RIDI_DEVICENAME, pDeviceName, &size);

        if (result == unchecked((uint)-1) || result != size)
        {
            ExceptionUtilities.ThrowExternalException(nameof(GetRawInputDeviceInfoW), unchecked((int)result));
        }

        var fileHandle = CreateFileW(
            pDeviceName,
            GENERIC_READ,
            FILE_SHARE_READ | FILE_SHARE_WRITE,
            null,
            OPEN_EXISTING,
            0,
            HANDLE.NULL);

        if (fileHandle != HANDLE.INVALID_VALUE)
        {
            return fileHandle;
        }

        _logger?.Warning("Failed to determine Raw Input device name for device handle {@DeviceHandle}", deviceHandle);

        return HANDLE.NULL;
    }

    private unsafe HidController? ConfigureController(HANDLE deviceHandle, HANDLE fileHandle)
    {
        ThrowIfNull(deviceHandle);

        HidController? controller = null;

        if (fileHandle == HANDLE.NULL)
        {
            _hidControllersByHandle.Add(deviceHandle, null);
            return null;
        }

        try
        {
            // Get preparsed data

            PHIDP_PREPARSED_DATA pPreparsedData;

            if (HidD_GetPreparsedData(fileHandle, &pPreparsedData) != TRUE)
            {
                _logger?.Warning(
                    "Failed to retrieve HID controller preparsed data for device handle @{DeviceHandle}",
                    deviceHandle);
                return null;
            }

            // Get capabilities

            HIDP_CAPS capabilities;

            if (HidP_GetCaps(pPreparsedData, &capabilities) != HIDP_STATUS_SUCCESS)
            {
                _logger?.Warning(
                    "Failed to retrieve HID controller capabilities for device handle @{DeviceHandle}",
                    deviceHandle);
                return null;
            }

            // Get button capabilities

            if (capabilities.NumberInputButtonCaps == 0)
            {
                _logger?.Warning(
                    "Failed to retrieve HID controller button capabilities for device handle @{DeviceHandle}",
                    deviceHandle);
                return null;
            }

            var inputButtonCapabilityCount = capabilities.NumberInputButtonCaps;
            var pButtonCapabilities = stackalloc HIDP_BUTTON_CAPS[inputButtonCapabilityCount];

            if (HidP_GetButtonCaps(
                    HIDP_REPORT_TYPE.HidP_Input,
                    pButtonCapabilities,
                    &inputButtonCapabilityCount,
                    pPreparsedData) !=
                HIDP_STATUS_SUCCESS)
            {
                _logger?.Warning(
                    "Failed to retrieve HID controller button capabilities for device handle @{DeviceHandle}",
                    deviceHandle);
                return null;
            }

            var minimumButtonNumber = pButtonCapabilities->Anonymous.Range.UsageMin;
            var maximumButtonNumber = pButtonCapabilities->Anonymous.Range.UsageMax;

            // Get value capabilities

            if (capabilities.NumberInputValueCaps == 0)
            {
                _logger?.Warning(
                    "Failed to retrieve HID controller button capabilities for device handle @{DeviceHandle}",
                    deviceHandle);
                return null;
            }

            var inputValueCapabilityCount = capabilities.NumberInputValueCaps;
            var pValueCapabilities = stackalloc HIDP_VALUE_CAPS[inputValueCapabilityCount];

            if (HidP_GetValueCaps(HIDP_REPORT_TYPE.HidP_Input, pValueCapabilities, &inputValueCapabilityCount, pPreparsedData) !=
                HIDP_STATUS_SUCCESS)
            {
                _logger?.Warning(
                    "Failed to retrieve HID controller value capabilities for device handle {@DeviceHandle}",
                    deviceHandle);
                return null;
            }

            // Get identifying information

            const int bufferLength = 127;
            var pBuffer = stackalloc ushort[bufferLength];

            var manufacturer =
                HidD_GetManufacturerString(fileHandle, pBuffer, sizeof(ushort) * bufferLength) == TRUE
                    ? new string((char*)pBuffer).Trim()
                    : null;
            var product =
                HidD_GetProductString(fileHandle, pBuffer, sizeof(ushort) * bufferLength) == TRUE
                    ? new string((char*)pBuffer).Trim()
                    : null;
            var serialNumber =
                HidD_GetSerialNumberString(fileHandle, pBuffer, sizeof(ushort) * bufferLength) == TRUE
                    ? new string((char*)pBuffer).Trim()
                    : null;
            var valueCapabilityCount = inputValueCapabilityCount;
            var valueCapabilities = new ReadOnlySpan<HIDP_VALUE_CAPS>(pValueCapabilities, valueCapabilityCount);
            var (index, _, enabledDefault) = _hidControllerRepository.AddHidController(manufacturer, product, serialNumber);

            // Do not configure disabled controllers
            if (enabledDefault)
            {
                _logger?.Debug(
                    @"HID controller {Index} with manufacturer ""{Manufacturer}"", product name ""{ProductName}"", and serial number ""{SerialNumber}"" is connected and enabled",
                    index,
                    manufacturer ?? "",
                    product ?? "",
                    serialNumber ?? "");

                controller = new HidController(
                    deviceHandle,
                    index,
                    *pButtonCapabilities,
                    valueCapabilities,
                    manufacturer,
                    product,
                    serialNumber,
                    minimumButtonNumber,
                    maximumButtonNumber);

                _hidControllersByIndex.Add(index, controller);
            }
            else
            {
                _logger?.Debug(
                    @"HID controller {Index} with manufacturer ""{Manufacturer}"", product name ""{ProductName}"", and serial number ""{SerialNumber}"" is connected but disabled",
                    index,
                    manufacturer ?? "",
                    product ?? "",
                    serialNumber ?? "");
            }

            _hidControllersByHandle.Add(deviceHandle, controller);

            return controller;
        }
        finally
        {
            _ = CloseHandle(fileHandle);
        }
    }
}
