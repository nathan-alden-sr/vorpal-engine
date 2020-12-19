using TerraFX.Interop;

namespace NathanAldenSr.VorpalEngine.Input.Keyboard
{
    /// <summary>Represents keyboard input management.</summary>
    public interface IKeyboardManager
    {
        /// <summary>Updates the keyboard state with data from Raw Input.</summary>
        /// <param name="rawInput">The new Raw Input data with which the keyboard state will be updated.</param>
        unsafe void UpdateState(RAWINPUT* rawInput);

        /// <summary>Calculates state changes for the keyboard since the last time this method was called.</summary>
        /// <param name="stateChanges">An <see cref="KeyboardStateChanges" /> object that will contain the changes in keyboard state.</param>
        void CalculateStateChanges(out KeyboardStateChanges stateChanges);

        /// <summary>Resets the keyboard state as if the user released all keys.</summary>
        void Reset();
    }
}