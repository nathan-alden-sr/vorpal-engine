// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TerraFX.Interop;
using VorpalEngine.Common;
using VorpalEngine.Logging;
using static TerraFX.Interop.Windows;
using static TerraFX.Utilities.ExceptionUtilities;

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
        ThrowIfNull(hidControllerRepository, nameof(hidControllerRepository));

        context = context.Push<HidControllerManager>();

        _hidControllerRepository = hidControllerRepository;
        _logger = new ContextLogger(context);
    }

    /// <inheritdoc />
    public unsafe void UpdateState(RAWINPUT* rawInput)
    {
        ThrowIfNull(rawInput, nameof(rawInput));

        IntPtr deviceHandle = rawInput->header.hDevice;

        if (!_hidControllersByHandle.TryGetValue(deviceHandle, out HidController? controller))
        {
            /*
             * The user can plug in and unplug devices at any time, causing device handles
             * to change unpredictably. Detecting a new device handle is a good time to validate
             * that configured HID controllers are still connected.
             */

            RemoveDisconnectedControllers();

            IntPtr fileHandle = OpenRawInputDevice(deviceHandle);

            controller = ConfigureController(deviceHandle, fileHandle);
        }

        controller?.UpdateState(rawInput);
    }

    /// <inheritdoc />
    public IReadOnlyCollection<uint> StateChangeIndexes => _hidControllersByIndex.Keys;

    /// <inheritdoc />
    public bool TryGetState(uint index, [NotNullWhen(true)] out IHidController? controller, out HidControllerState state)
    {
        if (_hidControllersByIndex.TryGetValue(index, out HidController? hidController))
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
        if (_hidControllersByIndex.Remove(index, out HidController? controller))
        {
            _hidControllersByHandle.Remove(controller.DeviceHandle);
        }
    }

    private unsafe void RemoveDisconnectedControllers()
    {
        // Retrieve the current list of HID devices

        uint rawInputDeviceCount;
        uint result = GetRawInputDeviceList(null, &rawInputDeviceCount, (uint)sizeof(RAWINPUTDEVICELIST));

        if (result == unchecked((uint)-1))
        {
            ThrowExternalException(nameof(GetRawInputDeviceList), unchecked((int)result));
        }

        RAWINPUTDEVICELIST* pRawInputDeviceList = stackalloc RAWINPUTDEVICELIST[(int)rawInputDeviceCount];

        result = GetRawInputDeviceList(pRawInputDeviceList, &rawInputDeviceCount, (uint)sizeof(RAWINPUTDEVICELIST));

        if (result == unchecked((uint)-1))
        {
            ThrowExternalException(nameof(GetRawInputDeviceList), unchecked((int)result));
        }

        // Remove any cached HID controllers that are no longer valid

        HashSet<IntPtr> validDeviceHandles = new();

        for (var i = 0; i < rawInputDeviceCount; i++)
        {
            validDeviceHandles.Add(pRawInputDeviceList[i].hDevice);
        }

        // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
        foreach (HidController? controller in _hidControllersByHandle.Values)
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

    private unsafe IntPtr OpenRawInputDevice(IntPtr deviceHandle)
    {
        uint size;

        ThrowIfNotZero(
            GetRawInputDeviceInfoW(deviceHandle, RIDI_DEVICENAME, null, &size),
            nameof(GetRawInputDeviceInfoW));

        ushort* pDeviceName = stackalloc ushort[(int)size];
        uint result = GetRawInputDeviceInfoW(deviceHandle, RIDI_DEVICENAME, pDeviceName, &size);

        if (result == unchecked((uint)-1) || result != size)
        {
            ThrowExternalException(nameof(GetRawInputDeviceInfoW), unchecked((int)result));
        }

        IntPtr fileHandle = CreateFileW(pDeviceName, GENERIC_READ, FILE_SHARE_READ | FILE_SHARE_WRITE, null, OPEN_EXISTING, 0, IntPtr.Zero);

        if (fileHandle != INVALID_HANDLE_VALUE)
        {
            return fileHandle;
        }

        _logger?.Warning("Failed to determine Raw Input device name for device handle {@DeviceHandle}", deviceHandle);

        return IntPtr.Zero;
    }

    private unsafe HidController? ConfigureController(IntPtr deviceHandle, IntPtr fileHandle)
    {
        ThrowIfZero(deviceHandle, nameof(deviceHandle));

        HidController? controller = null;

        if (fileHandle == IntPtr.Zero)
        {
            _hidControllersByHandle.Add(deviceHandle, null);
            return null;
        }

        try
        {
            // Get preparsed data

            IntPtr pPreparsedData;

            if (HidD_GetPreparsedData(fileHandle, &pPreparsedData) != TRUE)
            {
                _logger?.Warning("Failed to retrieve HID controller preparsed data for device handle @{DeviceHandle}", deviceHandle);
                return null;
            }

            // Get capabilities

            HIDP_CAPS capabilities;

            if (HidP_GetCaps(pPreparsedData, &capabilities) != HIDP_STATUS_SUCCESS)
            {
                _logger?.Warning("Failed to retrieve HID controller capabilities for device handle @{DeviceHandle}", deviceHandle);
                return null;
            }

            // Get button capabilities

            if (capabilities.NumberInputButtonCaps == 0)
            {
                _logger?.Warning("Failed to retrieve HID controller button capabilities for device handle @{DeviceHandle}", deviceHandle);
                return null;
            }

            ushort inputButtonCapabilityCount = capabilities.NumberInputButtonCaps;
            HIDP_BUTTON_CAPS* pButtonCapabilities = stackalloc HIDP_BUTTON_CAPS[inputButtonCapabilityCount];

            if (HidP_GetButtonCaps(HIDP_REPORT_TYPE.HidP_Input, pButtonCapabilities, &inputButtonCapabilityCount, pPreparsedData) !=
                HIDP_STATUS_SUCCESS)
            {
                _logger?.Warning("Failed to retrieve HID controller button capabilities for device handle @{DeviceHandle}", deviceHandle);
                return null;
            }

            ushort minimumButtonNumber = pButtonCapabilities->Anonymous.Range.UsageMin;
            ushort maximumButtonNumber = pButtonCapabilities->Anonymous.Range.UsageMax;

            // Get value capabilities

            if (capabilities.NumberInputValueCaps == 0)
            {
                _logger?.Warning("Failed to retrieve HID controller button capabilities for device handle @{DeviceHandle}", deviceHandle);
                return null;
            }

            ushort inputValueCapabilityCount = capabilities.NumberInputValueCaps;
            HIDP_VALUE_CAPS* pValueCapabilities = stackalloc HIDP_VALUE_CAPS[inputValueCapabilityCount];

            if (HidP_GetValueCaps(HIDP_REPORT_TYPE.HidP_Input, pValueCapabilities, &inputValueCapabilityCount, pPreparsedData) !=
                HIDP_STATUS_SUCCESS)
            {
                _logger?.Warning("Failed to retrieve HID controller value capabilities for device handle {@DeviceHandle}", deviceHandle);
                return null;
            }

            // Get identifying information

            const int bufferLength = 127;
            ushort* pBuffer = stackalloc ushort[bufferLength];

            string? manufacturer =
                HidD_GetManufacturerString(fileHandle, pBuffer, sizeof(ushort) * bufferLength) == TRUE
                    ? new string((char*)pBuffer).Trim()
                    : null;
            string? product =
                HidD_GetProductString(fileHandle, pBuffer, sizeof(ushort) * bufferLength) == TRUE
                    ? new string((char*)pBuffer).Trim()
                    : null;
            string? serialNumber =
                HidD_GetSerialNumberString(fileHandle, pBuffer, sizeof(ushort) * bufferLength) == TRUE
                    ? new string((char*)pBuffer).Trim()
                    : null;
            ushort valueCapabilityCount = inputValueCapabilityCount;
            ReadOnlySpan<HIDP_VALUE_CAPS> valueCapabilities = new(pValueCapabilities, valueCapabilityCount);
            (uint index, bool? _, bool enabledDefault) = _hidControllerRepository.AddHidController(manufacturer, product, serialNumber);

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