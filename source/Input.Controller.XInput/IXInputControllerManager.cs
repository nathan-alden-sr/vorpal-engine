using System.Collections.Generic;

namespace NathanAldenSr.VorpalEngine.Input.Controller.XInput
{
    /// <summary>Represents the management of XInput controller input.</summary>
    public interface IXInputControllerManager
    {
        /// <summary>Gets a collection of XInput controller indexes that can have their states changes queried.</summary>
        IReadOnlyCollection<byte> StateChangeIndexes { get; }

        /// <summary>Calculates state changes for all tracked XInput controllers since the last time this method was called.</summary>
        /// <param name="index">The index of the XInput controller to query state changes for.</param>
        /// <param name="stateChanges">
        ///     An <see cref="XInputControllerStateChanges" /> object that will contain the changes in XInput
        ///     controller state.
        /// </param>
        /// <returns><see langword="true" /> if the state changes are valid; otherwise, <see langword="false" />.</returns>
        bool TryCalculateStateChanges(byte index, out XInputControllerStateChanges stateChanges);

        /// <summary>Detects and configures all XInput controllers.</summary>
        void ConfigureControllers();

        /// <summary>Removes an XInput controller from the cache.</summary>
        /// <param name="index">The index of the XInput Input controller to remove from the cache.</param>
        void InvalidateController(byte index);
    }
}