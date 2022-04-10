// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Diagnostics;

namespace VorpalEngine.Input.Controller.Hid;

/// <summary>The value of A HID value.</summary>
[DebuggerDisplay($"{{{nameof(DebuggerDisplay)},nq}}")]
public readonly struct HidControllerStateValue
{
    /// <summary>Initializes a new instance of the <see cref="HidControllerStateValue" /> struct.</summary>
    /// <param name="isValid">Indicates whether the value is valid.</param>
    /// <param name="logicalMinimum">The logical minimum value.</param>
    /// <param name="logicalMaximum">The logical maximum value.</param>
    /// <param name="value">The value of the HID value.</param>
    public HidControllerStateValue(bool isValid, int logicalMinimum, int logicalMaximum, int value)
    {
        IsValid = isValid;
        LogicalMinimum = logicalMinimum;
        LogicalMaximum = logicalMaximum;
        Value = value;
    }

    /// <summary>Gets a value indicating if this value is valid.</summary>
    public bool IsValid { get; }

    /// <summary>The logical minimum value.</summary>
    public int LogicalMinimum { get; }

    /// <summary>The logical maximum value.</summary>
    public int LogicalMaximum { get; }

    /// <summary>Gets the value of the HID value.</summary>
    public int Value { get; }

    private string DebuggerDisplay
        => $"IsValid = {IsValid}; Minimum = {LogicalMinimum}; Maximum = {LogicalMaximum}; Value = {Value}";
}
