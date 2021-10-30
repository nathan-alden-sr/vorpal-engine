// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

namespace VorpalEngine.Input.Controller.Hid;

/// <summary>HID controller value types.</summary>
public enum HidControllerValueType : uint
{
    /// <summary>Hat switch.</summary>
    HatSwitch = 1 << 0,

    /// <summary>Directional pad up.</summary>
    DirectionalPadUp = 1 << 1,

    /// <summary>Directional pad down.</summary>
    DirectionalPadDown = 1 << 2,

    /// <summary>Directional pad left.</summary>
    DirectionalPadLeft = 1 << 3,

    /// <summary>Directional pad right.</summary>
    DirectionalPadRight = 1 << 4,

    /// <summary>X-axis.</summary>
    XAxis = 1 << 5,

    /// <summary>Y-axis.</summary>
    YAxis = 1 << 6,

    /// <summary>Z-axis.</summary>
    ZAxis = 1 << 7,

    /// <summary>X-axis rotation.</summary>
    XAxisRotation = 1 << 8,

    /// <summary>Y-axis rotation.</summary>
    YAxisRotation = 1 << 9,

    /// <summary>Z-axis rotation.</summary>
    ZAxisRotation = 1 << 10
}