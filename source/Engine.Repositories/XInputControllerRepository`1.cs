using NathanAldenSr.VorpalEngine.Engine.Configuration;
using NathanAldenSr.VorpalEngine.Input.Controller.XInput;

namespace NathanAldenSr.VorpalEngine.Engine.Repositories
{
    /// <summary>A repository of XInput controllers.</summary>
    /// <typeparam name="T">The type of configuration</typeparam>
    public class XInputControllerRepository<T> : IXInputControllerRepository
        where T : Configuration.Configuration
    {
        private readonly IConfigurationManager<T> _configurationManager;

        /// <summary>Initializes a new instance of the <see cref="XInputControllerRepository{T}" /> class.</summary>
        /// <param name="configurationManager">An <see cref="IConfigurationManager{T}" /> implementation.</param>
        public XInputControllerRepository(IConfigurationManager<T> configurationManager)
        {
            _configurationManager = configurationManager;
        }

        /// <inheritdoc />
        public (bool? enabled, bool enabledDefault) AddXInputController(byte index)
        {
            (bool? enabled, bool enabledDefault) result = default;

            _configurationManager.ModifyConfiguration((configuration, _) => result = configuration.Input(true).XInputControllers(true).Add(index));

            return result;
        }
    }
}