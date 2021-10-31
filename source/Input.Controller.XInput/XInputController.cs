// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using TerraFX.Interop;
using static TerraFX.Interop.Windows;

namespace VorpalEngine.Input.Controller.XInput;

internal sealed class XInputController
{
    private XINPUT_STATE? _oldState;
    private XInputControllerState _state;

    public XInputController(byte index)
    {
        Index = index;
        _state = new XInputControllerState(index);
    }

    public byte Index { get; }

    public unsafe bool TryGetState(out XInputControllerState state)
    {
        XINPUT_STATE newState;
        uint result = XInputGetState(Index, &newState);

        switch (result)
        {
            case ERROR_SUCCESS:
                break;
            case ERROR_DEVICE_NOT_CONNECTED:
                state = default;

                return false;
            default:
                ThrowExternalException(nameof(XInputGetState), unchecked((int)result));
                state = default;

                return false;
        }

        // Recalculate fields if there were updates since the last state retrieval
        if (_oldState is not null && newState.dwPacketNumber > _oldState.Value.dwPacketNumber)
        {
            _state.UpdateCounter++;
            _state.HasChanged = true;
            _state.DownButtonStates = newState.Gamepad.wButtons;
            _state.PressedButtonStates = (ushort)(~_oldState.Value.Gamepad.wButtons & newState.Gamepad.wButtons);
            _state.ReleasedButtonStates = (ushort)(~_oldState.Value.Gamepad.wButtons & newState.Gamepad.wButtons);
            _state.LeftThumbXAxis = (_oldState.Value.Gamepad.sThumbLX, newState.Gamepad.sThumbLX);
            _state.LeftThumbYAxis = (_oldState.Value.Gamepad.sThumbLY, newState.Gamepad.sThumbLY);
            _state.RightThumbXAxis = (_oldState.Value.Gamepad.sThumbRX, newState.Gamepad.sThumbRX);
            _state.RightThumbYAxis = (_oldState.Value.Gamepad.sThumbRY, newState.Gamepad.sThumbRY);
            _state.LeftTrigger = (_oldState.Value.Gamepad.bLeftTrigger, newState.Gamepad.bLeftTrigger);
            _state.RightTrigger = (_oldState.Value.Gamepad.bRightTrigger, newState.Gamepad.bRightTrigger);
        }
        // Default state values are unreliable, so fail if the state has never been updated
        else if (_oldState is null)
        {
            _oldState = newState;
            state = default;

            return false;
        }
        // The state has not changed since the last state retrieval
        else
        {
            _oldState = newState;
            _state.HasChanged = false;
        }

        state = _state;

        return true;
    }
}