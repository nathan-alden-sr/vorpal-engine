// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

namespace VorpalEngine.Input.Controller.Hid;

/// <summary>Represents a HID controller.</summary>
public interface IHidController
{
    /// <summary>Gets the index.</summary>
    uint Index { get; }

    /// <summary>Gets the manufacturer.</summary>
    string? Manufacturer { get; }

    /// <summary>Gets the product name.</summary>
    string? ProductName { get; }

    /// <summary>Gets the serial number.</summary>
    string? SerialNumber { get; }

    /// <summary>Gets the number of buttons defined by the device.</summary>
    byte ButtonCount { get; }

    /// <summary>Gets the number of values defined by the device.</summary>
    byte ValueCount { get; }
}
