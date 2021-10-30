// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using static TerraFX.Interop.Windows;

namespace VorpalEngine.Input.Controller.XInput;

/// <summary>XInput controller buttons.</summary>
public enum XInputControllerButton : ushort
{
    /// <summary>Directional pad up. <see cref="XINPUT_GAMEPAD_DPAD_UP" />.</summary>
    DirectionalPadUp = XINPUT_GAMEPAD_DPAD_UP,

    /// <summary>Directional pad down. <see cref="XINPUT_GAMEPAD_DPAD_DOWN" />.</summary>
    DirectionalPadDown = XINPUT_GAMEPAD_DPAD_DOWN,

    /// <summary>Directional pad left. <see cref="XINPUT_GAMEPAD_DPAD_LEFT" />.</summary>
    DirectionalPadLeft = XINPUT_GAMEPAD_DPAD_LEFT,

    /// <summary>Directional pad right. <see cref="XINPUT_GAMEPAD_DPAD_RIGHT" />.</summary>
    DirectionalPadRight = XINPUT_GAMEPAD_DPAD_RIGHT,

    /// <summary>Start. <see cref="XINPUT_GAMEPAD_START" />.</summary>
    Start = XINPUT_GAMEPAD_START,

    /// <summary>Back. <see cref="XINPUT_GAMEPAD_BACK" />.</summary>
    Back = XINPUT_GAMEPAD_BACK,

    /// <summary>Left thumb. <see cref="XINPUT_GAMEPAD_LEFT_THUMB" />.</summary>
    LeftThumb = XINPUT_GAMEPAD_LEFT_THUMB,

    /// <summary>Right thumb. <see cref="XINPUT_GAMEPAD_RIGHT_THUMB" />.</summary>
    RightThumb = XINPUT_GAMEPAD_RIGHT_THUMB,

    /// <summary>Left shoulder. <see cref="XINPUT_GAMEPAD_LEFT_SHOULDER" />.</summary>
    LeftShoulder = XINPUT_GAMEPAD_LEFT_SHOULDER,

    /// <summary>Right shoulder. <see cref="XINPUT_GAMEPAD_RIGHT_SHOULDER" />.</summary>
    RightShoulder = XINPUT_GAMEPAD_RIGHT_SHOULDER,

    /// <summary>A. <see cref="XINPUT_GAMEPAD_A" />.</summary>
    A = XINPUT_GAMEPAD_A,

    /// <summary>B. <see cref="XINPUT_GAMEPAD_B" />.</summary>
    B = XINPUT_GAMEPAD_B,

    /// <summary>X. <see cref="XINPUT_GAMEPAD_X" />.</summary>
    X = XINPUT_GAMEPAD_X,

    /// <summary>Y. <see cref="XINPUT_GAMEPAD_Y" />.</summary>
    Y = XINPUT_GAMEPAD_Y
}