// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

namespace VorpalEngine.Input.Controller.XInput;

/// <summary>Defines the state of an XInput controller.</summary>
public struct XInputControllerState
{
    /// <summary>Initializes a new instance of the <see cref="XInputControllerState" /> struct.</summary>
    /// <param name="index">The index of the XInput controller.</param>
    public XInputControllerState(byte index)
    {
        Index = index;
        UpdateCounter = 0;
        HasChanged = false;
        DownButtonStates = 0;
        PressedButtonStates = 0;
        ReleasedButtonStates = 0;
        LeftThumbXAxis = (0, 0);
        LeftThumbYAxis = (0, 0);
        RightThumbXAxis = (0, 0);
        RightThumbYAxis = (0, 0);
        LeftTrigger = (0, 0);
        RightTrigger = (0, 0);
    }

    /// <summary>Gets the index of the XInput controller.</summary>
    public byte Index { get; }

    /// <summary>Gets the number of times the XInput controller state has been updated.</summary>
    public ulong UpdateCounter { get; internal set; }

    /// <summary>Gets a value indicating if the XInput controller state changed since the last state check.</summary>
    public bool HasChanged { get; internal set; }

    /// <summary>Gets a tuple containing the old and new left thumb x-axis values.</summary>
    public (short OldValue, short NewValue) LeftThumbXAxis { get; internal set; }

    /// <summary>Gets a tuple containing the old and new left thumb y-axis values.</summary>
    public (short OldValue, short NewValue) LeftThumbYAxis { get; internal set; }

    /// <summary>Gets a tuple containing the old and new right thumb x-axis values.</summary>
    public (short OldValue, short NewValue) RightThumbXAxis { get; internal set; }

    /// <summary>Gets a tuple containing the old and new right thumb y-axis values.</summary>
    public (short OldValue, short NewValue) RightThumbYAxis { get; internal set; }

    /// <summary>Gets a tuple containing the old and new left trigger values.</summary>
    public (byte OldValue, byte NewValue) LeftTrigger { get; internal set; }

    /// <summary>Gets a tuple containing the old and new right trigger values.</summary>
    public (byte OldValue, byte NewValue) RightTrigger { get; internal set; }

    internal ushort DownButtonStates { get; set; }

    internal ushort PressedButtonStates { get; set; }

    internal ushort ReleasedButtonStates { get; set; }

    /// <summary>Determines if a button is down.</summary>
    /// <param name="button">The button to test.</param>
    /// <returns><see langword="true" /> if the button is down; otherwise, <see langword="false" />.</returns>
    public readonly bool IsButtonDown(XInputControllerButton button)
        => (DownButtonStates & (ushort)button) != 0;

    /// <summary>Determines if a button is up.</summary>
    /// <param name="button">The button to test.</param>
    /// <returns><see langword="true" /> if the button is up; otherwise, <see langword="false" />.</returns>
    public readonly bool IsButtonUp(XInputControllerButton button)
        => !IsButtonDown(button);

    /// <summary>Determines if a button was pressed.</summary>
    /// <param name="button">The button to test.</param>
    /// <returns><see langword="true" /> if the button was pressed; otherwise, <see langword="false" />.</returns>
    public readonly bool WasButtonPressed(XInputControllerButton button)
        => (PressedButtonStates & (ushort)button) != 0;

    /// <summary>Determines if a button was released.</summary>
    /// <param name="button">The button to test.</param>
    /// <returns><see langword="true" /> if the button was released; otherwise, <see langword="false" />.</returns>
    public readonly bool WasButtonReleased(XInputControllerButton button)
        => (ReleasedButtonStates & (ushort)button) != 0;
}
