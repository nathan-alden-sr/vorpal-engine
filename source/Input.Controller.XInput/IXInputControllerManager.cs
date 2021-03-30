using System.Collections.Generic;

namespace NathanAldenSr.VorpalEngine.Input.Controller.XInput
{
    /// <summary>Represents the management of XInput controller input.</summary>
    public interface IXInputControllerManager
    {
        /// <summary>Gets a collection of XInput controller indexes.</summary>
        IReadOnlyCollection<byte> ControllerIndexes { get; }

        /// <summary>Attempts to retrieve the state of an XInput controller.</summary>
        /// <param name="index">The index of an XInput controller.</param>
        /// <param name="state">An <see cref="XInputControllerState" /> object that represents the state of the XInput controller.</param>
        /// <returns><see langword="true" /> if the state was successfully retrieved; otherwise, <see langword="false" />.</returns>
        bool TryGetState(byte index, out XInputControllerState state);

        /// <summary>Detects and configures all XInput controllers.</summary>
        void ConfigureControllers();

        /// <summary>Removes an XInput controller from the cache.</summary>
        /// <param name="index">The index of the XInput Input controller to remove from the cache.</param>
        void InvalidateController(byte index);
    }
}