using TerraFX.Interop;
using static NathanAldenSr.VorpalEngine.Common.Windows.ExceptionHelper;
using static TerraFX.Interop.Windows;

namespace NathanAldenSr.VorpalEngine.Input.Controller.XInput
{
    internal class XInputController
    {
        private XINPUT_STATE? _oldState;
        private uint? _previousPacketNumber;
        private XInputControllerStateChanges _stateChanges;

        public XInputController(byte index)
        {
            Index = index;
        }

        public byte Index { get; }

        public unsafe bool TryCalculateStateChanges(out XInputControllerStateChanges stateChanges)
        {
            XINPUT_STATE newState;
            uint result = XInputGetState(Index, &newState);

            switch (result)
            {
                case ERROR_SUCCESS:
                    _stateChanges.IsConnected = true;
                    break;
                case ERROR_DEVICE_NOT_CONNECTED:
                    _stateChanges.IsConnected = false;
                    stateChanges = _stateChanges;
                    return false;
                default:
                    ThrowExternalException(result, nameof(XInputGetState));
                    _stateChanges.IsConnected = false;
                    stateChanges = _stateChanges;
                    return false;
            }

            // Calculations can be skipped if there were no changes since the last time CalculateStateChanges was called
            if (_oldState is null || _previousPacketNumber == newState.dwPacketNumber)
            {
                _oldState = newState;
                stateChanges = _stateChanges;
                return false;
            }

            _previousPacketNumber = newState.dwPacketNumber;

            _stateChanges.DownButtonStates = newState.Gamepad.wButtons;
            _stateChanges.PressedButtonStates = (ushort)(~_oldState.Value.Gamepad.wButtons & newState.Gamepad.wButtons);
            _stateChanges.ReleasedButtonStates = (ushort)(~_oldState.Value.Gamepad.wButtons & newState.Gamepad.wButtons);
            _stateChanges.LeftThumbXAxis = (_oldState.Value.Gamepad.sThumbLX, newState.Gamepad.sThumbLX);
            _stateChanges.LeftThumbYAxis = (_oldState.Value.Gamepad.sThumbLY, newState.Gamepad.sThumbLY);
            _stateChanges.RightThumbXAxis = (_oldState.Value.Gamepad.sThumbRX, newState.Gamepad.sThumbRX);
            _stateChanges.RightThumbYAxis = (_oldState.Value.Gamepad.sThumbRY, newState.Gamepad.sThumbRY);
            _stateChanges.LeftTrigger = (_oldState.Value.Gamepad.bLeftTrigger, newState.Gamepad.bLeftTrigger);
            _stateChanges.RightTrigger = (_oldState.Value.Gamepad.bRightTrigger, newState.Gamepad.bRightTrigger);

            // The new state becomes the old state

            _oldState = newState;

            stateChanges = _stateChanges;

            return true;
        }
    }
}