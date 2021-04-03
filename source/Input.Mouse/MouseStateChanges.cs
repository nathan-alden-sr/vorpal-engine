using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace NathanAldenSr.VorpalEngine.Input.Mouse
{
    /// <summary>Represents mouse state changes since the last time the mouse state was calculated.</summary>
    [SuppressMessage("ReSharper", "ConvertToAutoProperty")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Roslyn is over-aggressive")]
    public struct MouseStateChanges
    {
        private int _relativeLocationXDelta;
        private int _relativeLocationYDelta;
        private int _relativeWheelDelta;
        private int _relativeHorizontalWheelDelta;
        private byte _buttonDownStates;
        private byte _buttonPressedStates;
        private byte _buttonReleasedStates;

        /// <summary>Gets the relative location x-dimension delta.</summary>
        public int RelativeLocationXDelta
        {
            get => _relativeLocationXDelta;
            internal set => _relativeLocationXDelta = value;
        }

        /// <summary>Gets the relative location y-dimension delta.</summary>
        public int RelativeLocationYDelta
        {
            get => _relativeLocationYDelta;
            internal set => _relativeLocationYDelta = value;
        }

        /// <summary>Gets the relative wheel delta.</summary>
        public int RelativeWheelDelta
        {
            get => _relativeWheelDelta;
            internal set => _relativeWheelDelta = value;
        }

        /// <summary>Gets the relative horizontal wheel delta.</summary>
        public int RelativeHorizontalWheelDelta
        {
            get => _relativeHorizontalWheelDelta;
            internal set => _relativeHorizontalWheelDelta = value;
        }

        internal byte ButtonDownStates
        {
            get => _buttonDownStates;
            set => _buttonDownStates = value;
        }

        internal byte ButtonPressedStates
        {
            get => _buttonPressedStates;
            set => _buttonPressedStates = value;
        }

        internal byte ButtonReleasedStates
        {
            get => _buttonReleasedStates;
            set => _buttonReleasedStates = value;
        }

        /// <summary>Determines whether a button is down.</summary>
        /// <param name="button">The button to test.</param>
        /// <returns><see langword="true" /> if the button is down; otherwise, <see langword="false" />.</returns>
        [Pure]
        public bool IsButtonDown(Button button) => (ButtonDownStates & (1 << (byte)button)) != 0;

        /// <summary>Determines whether a button is down.</summary>
        /// <param name="button">The button to test.</param>
        /// <returns><see langword="true" /> if the button is down; otherwise, <see langword="false" />.</returns>
        [Pure]
        public bool IsButtonUp(Button button) => !IsButtonDown(button);

        /// <summary>Determines whether a button was pressed.</summary>
        /// <param name="button">The button to test.</param>
        /// <returns><see langword="true" /> if the button was pressed; otherwise, <see langword="false" />.</returns>
        [Pure]
        public bool WasButtonPressed(Button button) => (ButtonPressedStates & (1 << (byte)button)) != 0;

        /// <summary>Determines whether a button was released.</summary>
        /// <param name="button">The button to test.</param>
        /// <returns><see langword="true" /> if the button was released; otherwise, <see langword="false" />.</returns>
        [Pure]
        public bool WasButtonReleased(Button button) => (ButtonReleasedStates & (1 << (byte)button)) != 0;
    }
}