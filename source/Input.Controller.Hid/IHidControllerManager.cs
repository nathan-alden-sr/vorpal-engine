using System.Collections.Generic;
using TerraFX.Interop;

namespace NathanAldenSr.VorpalEngine.Input.Controller.Hid
{
    /// <summary>Represents the management of HID controller input.</summary>
    public interface IHidControllerManager
    {
        /// <summary>Gets a collection of HID controller indexes that can have their states changes queried.</summary>
        IReadOnlyCollection<uint> StateChangeIndexes { get; }

        /// <summary>Updates the HID controller state with data from Raw Input.</summary>
        /// <param name="rawInput">The new Raw Input data with which the HID controller state will be updated.</param>
        unsafe void UpdateState(RAWINPUT* rawInput);

        /// <summary>Calculates state changes for a HID controller since the last time this method was called.</summary>
        /// <param name="index">The index of the HID controller to query state changes for.</param>
        /// <param name="stateChanges">
        ///     An <see cref="HidControllerStateChanges" /> object that will contain the changes in HID controller
        ///     state.
        /// </param>
        /// <returns><see langword="true" /> if state changes were successfully calculated; otherwise, <see langword="false" />.</returns>
        bool TryCalculateStateChanges(uint index, out HidControllerStateChanges stateChanges);

        /// <summary>Removes a HID controller from the cache.</summary>
        /// <param name="index">The index of the HID Input controller to remove from the cache.</param>
        void InvalidateController(uint index);
    }
}