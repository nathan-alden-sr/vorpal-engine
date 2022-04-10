// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

namespace VorpalEngine.Input.Mouse;

/// <summary>Mouse buttons.</summary>
public enum Button : byte
{
    /// <summary>The left mouse button. This value is the same as <see cref="One" />.</summary>
    Left,

    /// <summary>The right mouse button. This value is the same as <see cref="Two" />.</summary>
    Right,

    /// <summary>The middle mouse button. This value is the same as <see cref="Three" />.</summary>
    Middle,

    /// <summary>The X1 button. This value is the same as <see cref="Four" />.</summary>
    X1,

    /// <summary>The X2 button. This value is the same as <see cref="Five" />.</summary>
    X2,

    /// <summary>The first mouse button. This value is the same as <see cref="Left" />.</summary>
    One = Left,

    /// <summary>The second mouse button. This value is the same as <see cref="Right" />.</summary>
    Two = Right,

    /// <summary>The third mouse button. This value is the same as <see cref="Middle" />.</summary>
    Three = Middle,

    /// <summary>The fourth mouse button. This value is the same as <see cref="X1" />.</summary>
    Four = X1,

    /// <summary>The fifth mouse button. This value is the same as <see cref="X2" />.</summary>
    Five = X2
}
