// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Runtime.CompilerServices;

namespace VorpalEngine.Input.Controller.Hid;

/// <summary>Defines the state of a HID controller.</summary>
public struct HidControllerState
{
    /// <summary>The maximum valid button index.</summary>
    public const byte MaximumButtonIndex = 31;

    internal HidControllerStateValue HatSwitchStateValue;
    internal HidControllerStateValue DirectionalPadUpStateValue;
    internal HidControllerStateValue DirectionalPadDownStateValue;
    internal HidControllerStateValue DirectionalPadLeftStateValue;
    internal HidControllerStateValue DirectionalPadRightStateValue;
    internal HidControllerStateValue XAxisStateValue;
    internal HidControllerStateValue YAxisStateValue;
    internal HidControllerStateValue ZAxisStateValue;
    internal HidControllerStateValue XAxisRotationStateValue;
    internal HidControllerStateValue YAxisRotationStateValue;
    internal HidControllerStateValue ZAxisRotationStateValue;

    /// <summary>Initializes a new instance of the <see cref="HidControllerState" /> struct.</summary>
    /// <param name="index">The index of the HID controller.</param>
    public HidControllerState(uint index)
    {
        HatSwitchStateValue = default;
        DirectionalPadUpStateValue = default;
        DirectionalPadDownStateValue = default;
        DirectionalPadLeftStateValue = default;
        DirectionalPadRightStateValue = default;
        XAxisStateValue = default;
        YAxisStateValue = default;
        ZAxisStateValue = default;
        XAxisRotationStateValue = default;
        YAxisRotationStateValue = default;
        ZAxisRotationStateValue = default;
        Index = index;
        UpdateCounter = 0;
        HasChanged = false;
        DownButtonStates = 0;
        PressedButtonStates = 0;
        ReleasedButtonStates = 0;
        HatSwitch = default;
        DirectionalPadUp = default;
        DirectionalPadDown = default;
        DirectionalPadLeft = default;
        DirectionalPadRight = default;
        XAxis = default;
        YAxis = default;
        ZAxis = default;
        XAxisRotation = default;
        YAxisRotation = default;
        ZAxisRotation = default;
    }

    /// <summary>Gets the index of the HID controller.</summary>
    public uint Index { get; }

    /// <summary>Gets the number of times the HID controller state has been updated.</summary>
    public ulong UpdateCounter { get; internal set; }

    /// <summary>Gets a value indicating if the HID controller state changed since the last state check.</summary>
    public bool HasChanged { get; internal set; }

    /// <summary>Gets a tuple containing the old and new hat switch values.</summary>
    public (HidControllerStateValue OldValue, HidControllerStateValue NewValue) HatSwitch { get; internal set; }

    /// <summary>Gets a tuple containing the old and new directional pad up values.</summary>
    public (HidControllerStateValue OldValue, HidControllerStateValue NewValue) DirectionalPadUp { get; internal set; }

    /// <summary>Gets a tuple containing the old and new directional pad down values.</summary>
    public (HidControllerStateValue OldValue, HidControllerStateValue NewValue) DirectionalPadDown { get; internal set; }

    /// <summary>Gets a tuple containing the old and new directional pad left values.</summary>
    public (HidControllerStateValue OldValue, HidControllerStateValue NewValue) DirectionalPadLeft { get; internal set; }

    /// <summary>Gets a tuple containing the old and new directional pad right values.</summary>
    public (HidControllerStateValue OldValue, HidControllerStateValue NewValue) DirectionalPadRight { get; internal set; }

    /// <summary>Gets a tuple containing the old and new x-axis values.</summary>
    public (HidControllerStateValue OldValue, HidControllerStateValue NewValue) XAxis { get; internal set; }

    /// <summary>Gets a tuple containing the old and new y-axis values.</summary>
    public (HidControllerStateValue OldValue, HidControllerStateValue NewValue) YAxis { get; internal set; }

    /// <summary>Gets a tuple containing the old and new z-axis values.</summary>
    public (HidControllerStateValue OldValue, HidControllerStateValue NewValue) ZAxis { get; internal set; }

    /// <summary>Gets a tuple containing the old and new x-axis rotation values.</summary>
    public (HidControllerStateValue OldValue, HidControllerStateValue NewValue) XAxisRotation { get; internal set; }

    /// <summary>Gets a tuple containing the old and new y-axis rotation values.</summary>
    public (HidControllerStateValue OldValue, HidControllerStateValue NewValue) YAxisRotation { get; internal set; }

    /// <summary>Gets a tuple containing the old and new z-axis rotation values.</summary>
    public (HidControllerStateValue OldValue, HidControllerStateValue NewValue) ZAxisRotation { get; internal set; }

    internal uint DownButtonStates { get; set; }

    internal uint PressedButtonStates { get; set; }

    internal uint ReleasedButtonStates { get; set; }

    /// <summary>Determines if a button is down.</summary>
    /// <param name="buttonIndex">The button index to test. Valid indexes range from 0 to 31.</param>
    /// <returns><see langword="true" /> if the button is down; otherwise, <see langword="false" />.</returns>
    public readonly bool IsButtonDown(byte buttonIndex)
    {
        ValidateButtonIndex(buttonIndex);

        return (DownButtonStates & (1 << buttonIndex)) != 0;
    }

    /// <summary>Determines if a button is up.</summary>
    /// <param name="buttonIndex">The button index to test. Valid indexes range from 0 to 31.</param>
    /// <returns><see langword="true" /> if the button is up; otherwise, <see langword="false" />.</returns>
    public readonly bool IsButtonUp(byte buttonIndex)
    {
        ValidateButtonIndex(buttonIndex);

        return (DownButtonStates & (1 << buttonIndex)) == 0;
    }

    /// <summary>Determines if a button was pressed.</summary>
    /// <param name="buttonIndex">The button index to test. Valid indexes range from 0 to 31.</param>
    /// <returns><see langword="true" /> if the button was pressed; otherwise, <see langword="false" />.</returns>
    public readonly bool WasButtonPressed(byte buttonIndex)
    {
        ValidateButtonIndex(buttonIndex);

        return (PressedButtonStates & (1 << buttonIndex)) != 0;
    }

    /// <summary>Determines if a button was released.</summary>
    /// <param name="buttonIndex">The button index to test. Valid indexes range from 0 to 31.</param>
    /// <returns><see langword="true" /> if the button was released; otherwise, <see langword="false" />.</returns>
    public readonly bool WasButtonReleased(byte buttonIndex)
    {
        ValidateButtonIndex(buttonIndex);

        return (ReleasedButtonStates & (1 << buttonIndex)) != 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void ValidateButtonIndex(byte buttonIndex)
    {
        if (buttonIndex > MaximumButtonIndex)
        {
            ThrowArgumentOutOfRangeException(nameof(buttonIndex), buttonIndex, "Invalid button index.");
        }
    }
}
