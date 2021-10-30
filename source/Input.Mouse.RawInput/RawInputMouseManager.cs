// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using TerraFX.Interop;
using static TerraFX.Interop.Windows;
using static TerraFX.Utilities.ExceptionUtilities;

namespace VorpalEngine.Input.Mouse.RawInput;

/// <summary>Manages mouse input based on Raw Input.</summary>
public sealed class RawInputMouseManager : MouseManager, IRawInputMouseManager
{
    /// <inheritdoc />
    public unsafe void UpdateState(RAWINPUT* rawInput)
    {
        ThrowIfNull(rawInput, nameof(rawInput));

        RAWMOUSE rawMouse = rawInput->data.mouse;

        if (rawMouse.usFlags != MOUSE_MOVE_RELATIVE)
        {
            ThrowArgumentOutOfRangeException("Invalid flags.", rawMouse.usFlags, nameof(RAWMOUSE.usFlags));
        }

        RelativeLocationXDelta += rawMouse.lLastX;
        RelativeLocationYDelta += rawMouse.lLastY;

        ushort buttonFlags = rawMouse.Anonymous.Anonymous.usButtonFlags;

        if ((buttonFlags & RI_MOUSE_LEFT_BUTTON_DOWN) != 0)
        {
            SetButtonDown(Button.Left, true);
        }
        if ((buttonFlags & RI_MOUSE_LEFT_BUTTON_UP) != 0)
        {
            SetButtonDown(Button.Left, false);
        }
        if ((buttonFlags & RI_MOUSE_MIDDLE_BUTTON_DOWN) != 0)
        {
            SetButtonDown(Button.Middle, true);
        }
        if ((buttonFlags & RI_MOUSE_MIDDLE_BUTTON_UP) != 0)
        {
            SetButtonDown(Button.Middle, false);
        }
        if ((buttonFlags & RI_MOUSE_RIGHT_BUTTON_DOWN) != 0)
        {
            SetButtonDown(Button.Right, true);
        }
        if ((buttonFlags & RI_MOUSE_RIGHT_BUTTON_UP) != 0)
        {
            SetButtonDown(Button.Right, false);
        }
        if ((buttonFlags & RI_MOUSE_BUTTON_4_DOWN) != 0)
        {
            SetButtonDown(Button.Four, true);
        }
        if ((buttonFlags & RI_MOUSE_BUTTON_4_UP) != 0)
        {
            SetButtonDown(Button.Four, false);
        }
        if ((buttonFlags & RI_MOUSE_BUTTON_5_DOWN) != 0)
        {
            SetButtonDown(Button.Five, true);
        }
        if ((buttonFlags & RI_MOUSE_BUTTON_5_UP) != 0)
        {
            SetButtonDown(Button.Five, false);
        }
        if ((buttonFlags & RI_MOUSE_WHEEL) != 0)
        {
            RelativeWheelDelta += unchecked((short)rawMouse.Anonymous.Anonymous.usButtonData);
        }
        if ((buttonFlags & RI_MOUSE_HWHEEL) != 0)
        {
            RelativeHorizontalWheelDelta += unchecked((short)rawMouse.Anonymous.Anonymous.usButtonData);
        }
    }
}