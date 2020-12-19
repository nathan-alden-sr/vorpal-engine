using System.Diagnostics.Contracts;
using TerraFX.Interop;

namespace NathanAldenSr.VorpalEngine.Input.Controller.XInput
{
    /// <summary>Defines changes in state between two <see cref="XINPUT_STATE" /> objects.</summary>
    public struct XInputControllerStateChanges
    {
        /// <summary>Initializes a new instance of the <see cref="XInputControllerStateChanges" /> struct.</summary>
        /// <param name="index">The index of the XInput controller.</param>
        public XInputControllerStateChanges(byte index)
        {
            Index = index;
            DownButtonStates = 0;
            PressedButtonStates = 0;
            ReleasedButtonStates = 0;
            LeftThumbXAxis = (0, 0);
            LeftThumbYAxis = (0, 0);
            RightThumbXAxis = (0, 0);
            RightThumbYAxis = (0, 0);
            LeftTrigger = (0, 0);
            RightTrigger = (0, 0);
        }

        /// <summary>Gets the index of the controller.</summary>
        public byte Index { get; }

        internal ushort DownButtonStates { get; set; }
        internal ushort PressedButtonStates { get; set; }
        internal ushort ReleasedButtonStates { get; set; }

        /// <summary>Gets a tuple containing the old and new left thumb x-axis values.</summary>
        public (short OldValue, short NewValue) LeftThumbXAxis { get; internal set; }

        /// <summary>Gets a tuple containing the old and new left thumb y-axis values.</summary>
        public (short OldValue, short NewValue) LeftThumbYAxis { get; internal set; }

        /// <summary>Gets a tuple containing the old and new right thumb x-axis values.</summary>
        public (short OldValue, short NewValue) RightThumbXAxis { get; internal set; }

        /// <summary>Gets a tuple containing the old and new right thumb y-axis values.</summary>
        public (short OldValue, short NewValue) RightThumbYAxis { get; internal set; }

        /// <summary>Gets a tuple containing the old and new left trigger values.</summary>
        public (byte OldValue, byte NewValue) LeftTrigger { get; internal set; }

        /// <summary>Gets a tuple containing the old and new right trigger values.</summary>
        public (byte OldValue, byte NewValue) RightTrigger { get; internal set; }

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