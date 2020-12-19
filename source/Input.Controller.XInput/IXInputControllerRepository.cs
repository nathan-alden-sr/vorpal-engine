namespace NathanAldenSr.VorpalEngine.Input.Controller.XInput
{
    /// <summary>Represents a repository of XInput controllers.</summary>
    public interface IXInputControllerRepository
    {
        /// <summary>Adds an XInput controller to the repository if it has not already been added.</summary>
        /// <returns>Returns a tuple containing values indicating whether the controller is enabled.</returns>
        (bool? enabled, bool enabledDefault) AddXInputController(byte index);
    }
}