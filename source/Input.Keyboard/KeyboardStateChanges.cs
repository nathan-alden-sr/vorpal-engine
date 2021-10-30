// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using VorpalEngine.Common;

namespace VorpalEngine.Input.Keyboard;

/// <summary>Represents keyboard state changes since the last time the keyboard state was calculated.</summary>
public struct KeyboardStateChanges
{
    private Bitmap256GroupsWith4StateBits _stateBitmap;

    /// <summary>Determines whether a key is down.</summary>
    /// <param name="key">The key to test.</param>
    /// <returns><see langword="true" /> if the key is down; otherwise, <see langword="false" />.</returns>
    public bool IsKeyDown(Key key) => (_stateBitmap.Get((byte)key) & KeyboardManager.KeyDownStateMask) != 0;

    /// <summary>Determines whether a key is down.</summary>
    /// <param name="key">The key to test.</param>
    /// <returns><see langword="true" /> if the key is down; otherwise, <see langword="false" />.</returns>
    public bool IsKeyUp(Key key) => !IsKeyDown(key);

    /// <summary>Determines whether a key was pressed.</summary>
    /// <param name="key">The key to test.</param>
    /// <returns><see langword="true" /> if the key was pressed; otherwise, <see langword="false" />.</returns>
    public bool WasKeyPressed(Key key) => (_stateBitmap.Get((byte)key) & KeyboardManager.KeyPressedStateMask) != 0;

    /// <summary>Determines whether a key was released.</summary>
    /// <param name="key">The key to test.</param>
    /// <returns><see langword="true" /> if the key was released; otherwise, <see langword="false" />.</returns>
    public bool WasKeyReleased(Key key) => (_stateBitmap.Get((byte)key) & KeyboardManager.KeyReleasedStateMask) != 0;

    internal byte Get(byte groupIndex) => _stateBitmap.Get(groupIndex);
    internal void Set(byte groupIndex, byte value) => _stateBitmap.Set(groupIndex, value);
    internal void LogicalAnd(byte groupIndex, byte value) => _stateBitmap.LogicalAnd(groupIndex, value);
}