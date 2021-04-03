using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using static NathanAldenSr.VorpalEngine.Common.ExceptionHelper;

namespace NathanAldenSr.VorpalEngine.Input.Controller.Hid
{
    /// <summary>Defines the state of a HID controller.</summary>
    [SuppressMessage("ReSharper", "ConvertToAutoProperty")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Roslyn is over-aggressive")]
    public struct HidControllerState
    {
        /// <summary>The maximum valid button index.</summary>
        public const byte MaximumButtonIndex = 31;

        internal HidControllerStateValue HatSwitchStateValue;
        internal HidControllerStateValue DirectionalPadUpStateValue;
        internal HidControllerStateValue DirectionalPadDownStateValue;
        internal HidControllerStateValue DirectionalPadLeftStateValue;
        internal HidControllerStateValue DirectionalPadRightStateValue;
        internal HidControllerStateValue XAxisStateValue;
        internal HidControllerStateValue YAxisStateValue;
        internal HidControllerStateValue ZAxisStateValue;
        internal HidControllerStateValue XAxisRotationStateValue;
        internal HidControllerStateValue YAxisRotationStateValue;
        internal HidControllerStateValue ZAxisRotationStateValue;

        private readonly uint _index;
        private ulong _updateCounter;
        private bool _hasChanged;
        private uint _downButtonStates;
        private uint _pressedButtonStates;
        private uint _releasedButtonStates;
        private (HidControllerStateValue OldValue, HidControllerStateValue NewValue) _hatSwitch;
        private (HidControllerStateValue OldValue, HidControllerStateValue NewValue) _directionalPadUp;
        private (HidControllerStateValue OldValue, HidControllerStateValue NewValue) _directionalPadDown;
        private (HidControllerStateValue OldValue, HidControllerStateValue NewValue) _directionalPadLeft;
        private (HidControllerStateValue OldValue, HidControllerStateValue NewValue) _directionalPadRight;
        private (HidControllerStateValue OldValue, HidControllerStateValue NewValue) _xAxis;
        private (HidControllerStateValue OldValue, HidControllerStateValue NewValue) _yAxis;
        private (HidControllerStateValue OldValue, HidControllerStateValue NewValue) _zAxis;
        private (HidControllerStateValue OldValue, HidControllerStateValue NewValue) _xAxisRotation;
        private (HidControllerStateValue OldValue, HidControllerStateValue NewValue) _yAxisRotation;
        private (HidControllerStateValue OldValue, HidControllerStateValue NewValue) _zAxisRotation;

        /// <summary>Initializes a new instance of the <see cref="HidControllerState" /> struct.</summary>
        /// <param name="index">The index of the HID controller.</param>
        public HidControllerState(uint index)
        {
            HatSwitchStateValue = default;
            DirectionalPadUpStateValue = default;
            DirectionalPadDownStateValue = default;
            DirectionalPadLeftStateValue = default;
            DirectionalPadRightStateValue = default;
            XAxisStateValue = default;
            YAxisStateValue = default;
            ZAxisStateValue = default;
            XAxisRotationStateValue = default;
            YAxisRotationStateValue = default;
            ZAxisRotationStateValue = default;
            _index = index;
            _updateCounter = 0;
            _hasChanged = false;
            _downButtonStates = 0;
            _pressedButtonStates = 0;
            _releasedButtonStates = 0;
            _hatSwitch = default;
            _directionalPadUp = default;
            _directionalPadDown = default;
            _directionalPadLeft = default;
            _directionalPadRight = default;
            _xAxis = default;
            _yAxis = default;
            _zAxis = default;
            _xAxisRotation = default;
            _yAxisRotation = default;
            _zAxisRotation = default;
        }

        /// <summary>Gets the index of the HID controller.</summary>
        public uint Index => _index;

        /// <summary>Gets the number of times the HID controller state has been updated.</summary>
        public ulong UpdateCounter
        {
            get => _updateCounter;
            internal set => _updateCounter = value;
        }

        /// <summary>Gets a value indicating if the HID controller state changed since the last state check.</summary>
        public bool HasChanged
        {
            get => _hasChanged;
            internal set => _hasChanged = value;
        }

        /// <summary>Gets a tuple containing the old and new hat switch values.</summary>
        public (HidControllerStateValue OldValue, HidControllerStateValue NewValue) HatSwitch
        {
            get => _hatSwitch;
            internal set => _hatSwitch = value;
        }

        /// <summary>Gets a tuple containing the old and new directional pad up values.</summary>
        public (HidControllerStateValue OldValue, HidControllerStateValue NewValue) DirectionalPadUp
        {
            get => _directionalPadUp;
            internal set => _directionalPadUp = value;
        }

        /// <summary>Gets a tuple containing the old and new directional pad down values.</summary>
        public (HidControllerStateValue OldValue, HidControllerStateValue NewValue) DirectionalPadDown
        {
            get => _directionalPadDown;
            internal set => _directionalPadDown = value;
        }

        /// <summary>Gets a tuple containing the old and new directional pad left values.</summary>
        public (HidControllerStateValue OldValue, HidControllerStateValue NewValue) DirectionalPadLeft
        {
            get => _directionalPadLeft;
            internal set => _directionalPadLeft = value;
        }

        /// <summary>Gets a tuple containing the old and new directional pad right values.</summary>
        public (HidControllerStateValue OldValue, HidControllerStateValue NewValue) DirectionalPadRight
        {
            get => _directionalPadRight;
            internal set => _directionalPadRight = value;
        }

        /// <summary>Gets a tuple containing the old and new x-axis values.</summary>
        public (HidControllerStateValue OldValue, HidControllerStateValue NewValue) XAxis
        {
            get => _xAxis;
            internal set => _xAxis = value;
        }

        /// <summary>Gets a tuple containing the old and new y-axis values.</summary>
        public (HidControllerStateValue OldValue, HidControllerStateValue NewValue) YAxis
        {
            get => _yAxis;
            internal set => _yAxis = value;
        }

        /// <summary>Gets a tuple containing the old and new z-axis values.</summary>
        public (HidControllerStateValue OldValue, HidControllerStateValue NewValue) ZAxis
        {
            get => _zAxis;
            internal set => _zAxis = value;
        }

        /// <summary>Gets a tuple containing the old and new x-axis rotation values.</summary>
        public (HidControllerStateValue OldValue, HidControllerStateValue NewValue) XAxisRotation
        {
            get => _xAxisRotation;
            internal set => _xAxisRotation = value;
        }

        /// <summary>Gets a tuple containing the old and new y-axis rotation values.</summary>
        public (HidControllerStateValue OldValue, HidControllerStateValue NewValue) YAxisRotation
        {
            get => _yAxisRotation;
            internal set => _yAxisRotation = value;
        }

        /// <summary>Gets a tuple containing the old and new z-axis rotation values.</summary>
        public (HidControllerStateValue OldValue, HidControllerStateValue NewValue) ZAxisRotation
        {
            get => _zAxisRotation;
            internal set => _zAxisRotation = value;
        }

        internal uint DownButtonStates
        {
            get => _downButtonStates;
            set => _downButtonStates = value;
        }

        internal uint PressedButtonStates
        {
            get => _pressedButtonStates;
            set => _pressedButtonStates = value;
        }

        internal uint ReleasedButtonStates
        {
            get => _releasedButtonStates;
            set => _releasedButtonStates = value;
        }

        /// <summary>Determines if a button is down.</summary>
        /// <param name="buttonIndex">The button index to test. Valid indexes range from 0 to 31.</param>
        /// <returns><see langword="true" /> if the button is down; otherwise, <see langword="false" />.</returns>
        [Pure]
        public bool IsButtonDown(byte buttonIndex)
        {
            ValidateButtonIndex(buttonIndex);

            return (DownButtonStates & (1 << buttonIndex)) != 0;
        }

        /// <summary>Determines if a button is up.</summary>
        /// <param name="buttonIndex">The button index to test. Valid indexes range from 0 to 31.</param>
        /// <returns><see langword="true" /> if the button is up; otherwise, <see langword="false" />.</returns>
        [Pure]
        public bool IsButtonUp(byte buttonIndex)
        {
            ValidateButtonIndex(buttonIndex);

            return (DownButtonStates & (1 << buttonIndex)) == 0;
        }

        /// <summary>Determines if a button was pressed.</summary>
        /// <param name="buttonIndex">The button index to test. Valid indexes range from 0 to 31.</param>
        /// <returns><see langword="true" /> if the button was pressed; otherwise, <see langword="false" />.</returns>
        [Pure]
        public bool WasButtonPressed(byte buttonIndex)
        {
            ValidateButtonIndex(buttonIndex);

            return (PressedButtonStates & (1 << buttonIndex)) != 0;
        }

        /// <summary>Determines if a button was released.</summary>
        /// <param name="buttonIndex">The button index to test. Valid indexes range from 0 to 31.</param>
        /// <returns><see langword="true" /> if the button was released; otherwise, <see langword="false" />.</returns>
        [Pure]
        public bool WasButtonReleased(byte buttonIndex)
        {
            ValidateButtonIndex(buttonIndex);

            return (ReleasedButtonStates & (1 << buttonIndex)) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ValidateButtonIndex(byte buttonIndex)
        {
            if (buttonIndex > MaximumButtonIndex)
            {
                ThrowArgumentOutOfRangeException(nameof(buttonIndex), buttonIndex);
            }
        }
    }
}