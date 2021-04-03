using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace NathanAldenSr.VorpalEngine.Input.Controller.XInput
{
    /// <summary>Defines the state of an XInput controller.</summary>
    [SuppressMessage("ReSharper", "ConvertToAutoProperty")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Roslyn is over-aggressive")]
    public struct XInputControllerState
    {
        /// <summary>Initializes a new instance of the <see cref="XInputControllerState" /> struct.</summary>
        /// <param name="index">The index of the XInput controller.</param>
        public XInputControllerState(byte index)
        {
            _index = index;
            _updateCounter = 0;
            _hasChanged = false;
            _downButtonStates = 0;
            _pressedButtonStates = 0;
            _releasedButtonStates = 0;
            _leftThumbXAxis = (0, 0);
            _leftThumbYAxis = (0, 0);
            _rightThumbXAxis = (0, 0);
            _rightThumbYAxis = (0, 0);
            _leftTrigger = (0, 0);
            _rightTrigger = (0, 0);
        }

        private ushort _downButtonStates;
        private ushort _pressedButtonStates;
        private ushort _releasedButtonStates;
        private readonly byte _index;
        private ulong _updateCounter;
        private bool _hasChanged;
        private (short OldValue, short NewValue) _leftThumbXAxis;
        private (short OldValue, short NewValue) _leftThumbYAxis;
        private (short OldValue, short NewValue) _rightThumbXAxis;
        private (short OldValue, short NewValue) _rightThumbYAxis;
        private (byte OldValue, byte NewValue) _leftTrigger;
        private (byte OldValue, byte NewValue) _rightTrigger;

        /// <summary>Gets the index of the XInput controller.</summary>
        public byte Index => _index;

        /// <summary>Gets the number of times the XInput controller state has been updated.</summary>
        public ulong UpdateCounter
        {
            get => _updateCounter;
            internal set => _updateCounter = value;
        }

        /// <summary>Gets a value indicating if the XInput controller state changed since the last state check.</summary>
        public bool HasChanged
        {
            get => _hasChanged;
            internal set => _hasChanged = value;
        }

        /// <summary>Gets a tuple containing the old and new left thumb x-axis values.</summary>
        public (short OldValue, short NewValue) LeftThumbXAxis
        {
            get => _leftThumbXAxis;
            internal set => _leftThumbXAxis = value;
        }

        /// <summary>Gets a tuple containing the old and new left thumb y-axis values.</summary>
        public (short OldValue, short NewValue) LeftThumbYAxis
        {
            get => _leftThumbYAxis;
            internal set => _leftThumbYAxis = value;
        }

        /// <summary>Gets a tuple containing the old and new right thumb x-axis values.</summary>
        public (short OldValue, short NewValue) RightThumbXAxis
        {
            get => _rightThumbXAxis;
            internal set => _rightThumbXAxis = value;
        }

        /// <summary>Gets a tuple containing the old and new right thumb y-axis values.</summary>
        public (short OldValue, short NewValue) RightThumbYAxis
        {
            get => _rightThumbYAxis;
            internal set => _rightThumbYAxis = value;
        }

        /// <summary>Gets a tuple containing the old and new left trigger values.</summary>
        public (byte OldValue, byte NewValue) LeftTrigger
        {
            get => _leftTrigger;
            internal set => _leftTrigger = value;
        }

        /// <summary>Gets a tuple containing the old and new right trigger values.</summary>
        public (byte OldValue, byte NewValue) RightTrigger
        {
            get => _rightTrigger;
            internal set => _rightTrigger = value;
        }

        internal ushort DownButtonStates
        {
            get => _downButtonStates;
            set => _downButtonStates = value;
        }

        internal ushort PressedButtonStates
        {
            get => _pressedButtonStates;
            set => _pressedButtonStates = value;
        }

        internal ushort ReleasedButtonStates
        {
            get => _releasedButtonStates;
            set => _releasedButtonStates = value;
        }

        /// <summary>Determines if a button is down.</summary>
        /// <param name="button">The button to test.</param>
        /// <returns><see langword="true" /> if the button is down; otherwise, <see langword="false" />.</returns>
        [Pure]
        public bool IsButtonDown(XInputControllerButton button) => (DownButtonStates & (ushort)button) != 0;

        /// <summary>Determines if a button is up.</summary>
        /// <param name="button">The button to test.</param>
        /// <returns><see langword="true" /> if the button is up; otherwise, <see langword="false" />.</returns>
        [Pure]
        public bool IsButtonUp(XInputControllerButton button) => !IsButtonDown(button);

        /// <summary>Determines if a button was pressed.</summary>
        /// <param name="button">The button to test.</param>
        /// <returns><see langword="true" /> if the button was pressed; otherwise, <see langword="false" />.</returns>
        [Pure]
        public bool WasButtonPressed(XInputControllerButton button) => (PressedButtonStates & (ushort)button) != 0;

        /// <summary>Determines if a button was released.</summary>
        /// <param name="button">The button to test.</param>
        /// <returns><see langword="true" /> if the button was released; otherwise, <see langword="false" />.</returns>
        [Pure]
        public bool WasButtonReleased(XInputControllerButton button) => (ReleasedButtonStates & (ushort)button) != 0;
    }
}