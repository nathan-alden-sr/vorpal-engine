using System.Runtime.CompilerServices;
using static NathanAldenSr.VorpalEngine.Common.ExceptionHelper;

namespace NathanAldenSr.VorpalEngine.Input.Controller.Hid
{
    /// <summary>Defines changes in state between two <see cref="HidControllerState" /> objects.</summary>
    public struct HidControllerStateChanges
    {
        /// <summary>The maximum valid button index.</summary>
        public const byte MaximumButtonIndex = 31;

        internal uint DownButtonStates;
        internal uint PressedButtonStates;
        internal uint ReleasedButtonStates;

        /// <summary>Initializes a new instance of the <see cref="HidControllerStateChanges" /> struct.</summary>
        /// <param name="index">The index of the HID controller.</param>
        public HidControllerStateChanges(uint index)
        {
            Index = index;
            DownButtonStates = 0;
            PressedButtonStates = 0;
            ReleasedButtonStates = 0;
            HatSwitch = default;
            DirectionalPadUp = default;
            DirectionalPadDown = default;
            DirectionalPadLeft = default;
            DirectionalPadRight = default;
            XAxis = default;
            YAxis = default;
            ZAxis = default;
            XAxisRotation = default;
            YAxisRotation = default;
            ZAxisRotation = default;
        }

        /// <summary>Gets the index of the controller.</summary>
        public uint Index { get; }

        /// <summary>Gets a tuple containing the old and new hat switch values.</summary>
        public (HidControllerValue OldValue, HidControllerValue NewValue) HatSwitch { get; internal set; }

        /// <summary>Gets a tuple containing the old and new directional pad up values.</summary>
        public (HidControllerValue OldValue, HidControllerValue NewValue) DirectionalPadUp { get; internal set; }

        /// <summary>Gets a tuple containing the old and new directional pad down values.</summary>
        public (HidControllerValue OldValue, HidControllerValue NewValue) DirectionalPadDown { get; internal set; }

        /// <summary>Gets a tuple containing the old and new directional pad left values.</summary>
        public (HidControllerValue OldValue, HidControllerValue NewValue) DirectionalPadLeft { get; internal set; }

        /// <summary>Gets a tuple containing the old and new directional pad right values.</summary>
        public (HidControllerValue OldValue, HidControllerValue NewValue) DirectionalPadRight { get; internal set; }

        /// <summary>Gets a tuple containing the old and new x-axis values.</summary>
        public (HidControllerValue OldValue, HidControllerValue NewValue) XAxis { get; internal set; }

        /// <summary>Gets a tuple containing the old and new y-axis values.</summary>
        public (HidControllerValue OldValue, HidControllerValue NewValue) YAxis { get; internal set; }

        /// <summary>Gets a tuple containing the old and new z-axis values.</summary>
        public (HidControllerValue OldValue, HidControllerValue NewValue) ZAxis { get; internal set; }

        /// <summary>Gets a tuple containing the old and new x-axis rotation values.</summary>
        public (HidControllerValue OldValue, HidControllerValue NewValue) XAxisRotation { get; internal set; }

        /// <summary>Gets a tuple containing the old and new y-axis rotation values.</summary>
        public (HidControllerValue OldValue, HidControllerValue NewValue) YAxisRotation { get; internal set; }

        /// <summary>Gets a tuple containing the old and new z-axis rotation values.</summary>
        public (HidControllerValue OldValue, HidControllerValue NewValue) ZAxisRotation { get; internal set; }

        /// <summary>Determines if a button is down.</summary>
        /// <param name="buttonIndex">The button index to test. Valid indexes range from 0 to 31.</param>
        /// <returns><see langword="true" /> if the button is down; otherwise, <see langword="false" />.</returns>
        public bool IsButtonDown(byte buttonIndex)
        {
            ValidateButtonIndex(buttonIndex);

            return (DownButtonStates & (1 << buttonIndex)) != 0;
        }

        /// <summary>Determines if a button is up.</summary>
        /// <param name="buttonIndex">The button index to test. Valid indexes range from 0 to 31.</param>
        /// <returns><see langword="true" /> if the button is up; otherwise, <see langword="false" />.</returns>
        public bool IsButtonUp(byte buttonIndex)
        {
            ValidateButtonIndex(buttonIndex);

            return (DownButtonStates & (1 << buttonIndex)) == 0;
        }

        /// <summary>Determines if a button was pressed.</summary>
        /// <param name="buttonIndex">The button index to test. Valid indexes range from 0 to 31.</param>
        /// <returns><see langword="true" /> if the button was pressed; otherwise, <see langword="false" />.</returns>
        public bool WasButtonPressed(byte buttonIndex)
        {
            ValidateButtonIndex(buttonIndex);

            return (PressedButtonStates & (1 << buttonIndex)) != 0;
        }

        /// <summary>Determines if a button was released.</summary>
        /// <param name="buttonIndex">The button index to test. Valid indexes range from 0 to 31.</param>
        /// <returns><see langword="true" /> if the button was released; otherwise, <see langword="false" />.</returns>
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