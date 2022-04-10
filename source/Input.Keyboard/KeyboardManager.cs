// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using TerraFX.Interop.Windows;
using static TerraFX.Interop.Windows.RI;
using static TerraFX.Interop.Windows.VK;
using static TerraFX.Interop.Windows.Windows;
using static TerraFX.Interop.Windows.WM;

namespace VorpalEngine.Input.Keyboard;

/// <summary>Manages keyboard input.</summary>
public sealed class KeyboardManager : IKeyboardManager
{
    internal const byte KeyDownStateMask = 1 << 0;
    internal const byte KeyPressedStateMask = 1 << 1;
    internal const byte KeyReleasedStateMask = 1 << 2;
    private static readonly HashSet<Key> AllKeys = new(Enum.GetValues<Key>());
    private readonly HashSet<Key> _newDownKeys = new(AllKeys.Count);
    private readonly HashSet<Key> _oldDownKeys = new(AllKeys.Count);
    private KeyboardStateChanges _stateChanges;

    /// <inheritdoc />
    public unsafe void UpdateState(RAWINPUT* rawInput)
    {
        ThrowIfNull(rawInput);

        // https://github.com/hrydgard/ppsspp/blob/master/Windows/RawInput.cpp

        var rawKeyboard = rawInput->data.keyboard;

        // Translate modifier keys to their left or right equivalents
        var translatedKey =
            rawKeyboard.VKey switch
            {
                VK_SHIFT => (Key)MapVirtualKeyW(rawKeyboard.MakeCode, MAPVK_VSC_TO_VK_EX),
                VK_CONTROL => (Key)((rawKeyboard.Flags & RI_KEY_E0) == 0 ? VK_LCONTROL : VK_RCONTROL),
                VK_MENU => (Key)((rawKeyboard.Flags & RI_KEY_E0) == 0 ? VK_LMENU : VK_RMENU),
                _ => (Key)rawKeyboard.VKey
            };

        // Do not support unknown keys
        if (!AllKeys.Contains(translatedKey))
        {
            return;
        }

        // Detect whether the key was pressed or released

        switch (rawKeyboard.Message)
        {
            case WM_KEYDOWN:
            case WM_SYSKEYDOWN:
                _ = _newDownKeys.Add(translatedKey);
                break;
            case WM_KEYUP:
            case WM_SYSKEYUP:
                _ = _newDownKeys.Remove(translatedKey);
                break;
        }
    }

    /// <inheritdoc />
    public void CalculateStateChanges(out KeyboardStateChanges stateChanges)
    {
        foreach (var key in AllKeys)
        {
            var oldDownKey = _oldDownKeys.Contains(key);
            var newDownKey = _newDownKeys.Contains(key);
            byte state = 0;

            if (newDownKey)
            {
                // The key is down
                state |= KeyDownStateMask;

                if (!oldDownKey)
                {
                    // The key was not down before but now it is
                    state |= KeyPressedStateMask;
                }
            }
            else if (oldDownKey)
            {
                // The key was down before but now it isn't
                state |= KeyReleasedStateMask;
            }

            _stateChanges.Set((byte)key, state);

            _ = newDownKey ? _oldDownKeys.Add(key) : _oldDownKeys.Remove(key);
        }

        stateChanges = _stateChanges;
    }

    /// <inheritdoc />
    public void Reset()
        => _newDownKeys.Clear();
}
