// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

namespace VorpalEngine.Input.Controller.Hid;

/// <summary>Represents a repository of HID controllers.</summary>
public interface IHidControllerRepository
{
    /// <summary>Adds a HID controller to the repository if it has not already been added.</summary>
    /// <param name="manufacturer">
    ///     The manufacturer of the HID controller. A <see langword="null" /> value means the manufacturer is
    ///     unknown.
    /// </param>
    /// <param name="productName">
    ///     The product name of the HID controller. A <see langword="null" /> value means the product name is
    ///     unknown.
    /// </param>
    /// <param name="serialNumber">
    ///     The serial number of the HID controller. A <see langword="null" /> value means the serial number is
    ///     unknown.
    /// </param>
    /// <returns>A tuple containing the index of the HID controller and values indicating whether the controller is enabled.</returns>
    (uint index, bool? enabled, bool enabledDefault) AddHidController(string? manufacturer, string? productName, string? serialNumber);
}