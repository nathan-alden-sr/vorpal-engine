// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Diagnostics.CodeAnalysis;

namespace VorpalEngine.Input.Mouse;

/// <summary>Represents mouse state changes since the last time the mouse state was calculated.</summary>
[SuppressMessage("ReSharper", "ConvertToAutoProperty")]
[SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Roslyn is over-aggressive")]
public struct MouseStateChanges
{
    /// <summary>Gets the relative location x-dimension delta.</summary>
    public int RelativeLocationXDelta { get; internal set; }

    /// <summary>Gets the relative location y-dimension delta.</summary>
    public int RelativeLocationYDelta { get; internal set; }

    /// <summary>Gets the relative wheel delta.</summary>
    public int RelativeWheelDelta { get; internal set; }

    /// <summary>Gets the relative horizontal wheel delta.</summary>
    public int RelativeHorizontalWheelDelta { get; internal set; }

    internal byte ButtonDownStates { get; set; }
    internal byte ButtonPressedStates { get; set; }
    internal byte ButtonReleasedStates { get; set; }

    /// <summary>Determines whether a button is down.</summary>
    /// <param name="button">The button to test.</param>
    /// <returns><see langword="true" /> if the button is down; otherwise, <see langword="false" />.</returns>
    public bool IsButtonDown(Button button)
        => (ButtonDownStates & (1 << (byte)button)) != 0;

    /// <summary>Determines whether a button is down.</summary>
    /// <param name="button">The button to test.</param>
    /// <returns><see langword="true" /> if the button is down; otherwise, <see langword="false" />.</returns>
    public bool IsButtonUp(Button button)
        => !IsButtonDown(button);

    /// <summary>Determines whether a button was pressed.</summary>
    /// <param name="button">The button to test.</param>
    /// <returns><see langword="true" /> if the button was pressed; otherwise, <see langword="false" />.</returns>
    public bool WasButtonPressed(Button button)
        => (ButtonPressedStates & (1 << (byte)button)) != 0;

    /// <summary>Determines whether a button was released.</summary>
    /// <param name="button">The button to test.</param>
    /// <returns><see langword="true" /> if the button was released; otherwise, <see langword="false" />.</returns>
    public bool WasButtonReleased(Button button)
        => (ButtonReleasedStates & (1 << (byte)button)) != 0;
}