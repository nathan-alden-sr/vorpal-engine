using NathanAldenSr.VorpalEngine.Common;

namespace NathanAldenSr.VorpalEngine.Input.Controller.XInput
{
    /// <summary>A factory for creating <see cref="IXInputControllerManager" /> objects.</summary>
    public class XInputControllerManagerFactory : IXInputControllerManagerFactory
    {
        private readonly IXInputControllerRepository _xInputControllerRepository;

        /// <summary>Initializes a new instance of the <see cref="XInputControllerManagerFactory" /> class.</summary>
        /// <param name="xInputControllerRepository">An <see cref="IXInputControllerRepository" /> implementation.</param>
        public XInputControllerManagerFactory(IXInputControllerRepository xInputControllerRepository)
        {
            _xInputControllerRepository = xInputControllerRepository;
        }

        /// <inheritdoc />
        public IXInputControllerManager Create(NestedContext context = default) => new XInputControllerManager(_xInputControllerRepository, context);
    }
}