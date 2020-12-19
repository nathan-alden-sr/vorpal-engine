using NathanAldenSr.VorpalEngine.Common;

namespace NathanAldenSr.VorpalEngine.Input.Controller.Hid
{
    /// <summary>A factory for creating <see cref="IHidControllerManager" /> objects.</summary>
    public interface IHidControllerManagerFactory
    {
        /// <summary>Creates an <see cref="IHidControllerManager" /> object.</summary>
        /// <param name="context">A nested context.</param>
        /// <returns>The new <see cref="IHidControllerManager" /> object.</returns>
        IHidControllerManager Create(NestedContext context = default);
    }
}