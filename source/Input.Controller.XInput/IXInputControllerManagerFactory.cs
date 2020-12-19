using NathanAldenSr.VorpalEngine.Common;

namespace NathanAldenSr.VorpalEngine.Input.Controller.XInput
{
    /// <summary>Represents a factory for creating <see cref="IXInputControllerManager" /> objects.</summary>
    public interface IXInputControllerManagerFactory
    {
        /// <summary>Creates an <see cref="IXInputControllerManager" /> object.</summary>
        /// <param name="context">A nested context.</param>
        /// <returns>The new <see cref="IXInputControllerManager" /> object.</returns>
        IXInputControllerManager Create(NestedContext context = default);
    }
}