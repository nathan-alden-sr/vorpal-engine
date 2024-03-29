// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

namespace VorpalEngine.Input.Mouse;

/// <summary>Base class for mouse input management.</summary>
public abstract class MouseManager : IMouseManager
{
    private static readonly ImmutableHashSet<Button> AllButtons =
        [Button.Left, Button.Right, Button.Middle, Button.X1, Button.X2];

    private readonly HashSet<Button> _newDownButtons = new(AllButtons.Count);
    private readonly HashSet<Button> _oldDownButtons = new(AllButtons.Count);
    private MouseStateChanges _stateChanges;

    /// <summary>Gets or sets the relative location x-dimension delta.</summary>
    protected int RelativeLocationXDelta { get; set; }

    /// <summary>Gets or sets the relative location y-dimension delta.</summary>
    protected int RelativeLocationYDelta { get; set; }

    /// <summary>Gets or sets the relative horizontal wheel delta.</summary>
    protected int RelativeHorizontalWheelDelta { get; set; }

    /// <summary>Gets or sets the relative wheel delta.</summary>
    protected int RelativeWheelDelta { get; set; }

    /// <inheritdoc />
    public void CalculateStateChanges(out MouseStateChanges stateChanges)
    {
        _stateChanges.ButtonPressedStates = 0;
        _stateChanges.ButtonReleasedStates = 0;

        foreach (var button in AllButtons)
        {
            var oldDownButton = _oldDownButtons.Contains(button);
            var newDownButton = _newDownButtons.Contains(button);

            if (newDownButton)
            {
                // The button is down
                _stateChanges.ButtonDownStates |= (byte)(1 << (byte)button);

                if (!oldDownButton)
                {
                    // The button was not down before but now it is
                    _stateChanges.ButtonPressedStates |= (byte)(1 << (byte)button);
                }
            }
            else if (oldDownButton)
            {
                // The button was down before but now it isn't

                _stateChanges.ButtonDownStates &= (byte)((1 << (byte)button) ^ byte.MaxValue);
                _stateChanges.ButtonReleasedStates |= (byte)(1 << (byte)button);
            }

            _ = newDownButton ? _oldDownButtons.Add(button) : _oldDownButtons.Remove(button);
        }

        _stateChanges.RelativeLocationXDelta = RelativeLocationXDelta;
        _stateChanges.RelativeLocationYDelta = RelativeLocationYDelta;
        _stateChanges.RelativeWheelDelta = RelativeWheelDelta;
        _stateChanges.RelativeHorizontalWheelDelta = RelativeHorizontalWheelDelta;

        // Reset deltas

        RelativeLocationXDelta = 0;
        RelativeLocationYDelta = 0;
        RelativeWheelDelta = 0;
        RelativeHorizontalWheelDelta = 0;

        stateChanges = _stateChanges;
    }

    /// <inheritdoc />
    public void Reset()
    {
        _newDownButtons.Clear();

        RelativeLocationXDelta = 0;
        RelativeLocationYDelta = 0;
        RelativeWheelDelta = 0;
        RelativeHorizontalWheelDelta = 0;
    }

    /// <summary>Sets the down state of a button.</summary>
    /// <param name="button">The button for which the down state will be set.</param>
    /// <param name="state">The down state of the button.</param>
    protected void SetButtonDown(Button button, bool state)
        => _ = state ? _newDownButtons.Add(button) : _newDownButtons.Remove(button);
}
