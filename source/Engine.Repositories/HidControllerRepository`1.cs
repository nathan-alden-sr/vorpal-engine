using NathanAldenSr.VorpalEngine.Engine.Configuration;
using NathanAldenSr.VorpalEngine.Input.Controller.Hid;

namespace NathanAldenSr.VorpalEngine.Engine.Repositories
{
    /// <summary>A repository of HID controllers.</summary>
    /// <typeparam name="T">The type of configuration.</typeparam>
    public class HidControllerRepository<T> : IHidControllerRepository
        where T : Configuration.Configuration
    {
        private readonly IConfigurationManager<T> _configurationManager;

        /// <summary>Initializes a new instance of the <see cref="HidControllerRepository{T}" /> class.</summary>
        /// <param name="configurationManager">An <see cref="IConfigurationManager{T}" /> implementation.</param>
        public HidControllerRepository(IConfigurationManager<T> configurationManager)
        {
            _configurationManager = configurationManager;
        }

        /// <inheritdoc />
        public (uint index, bool? enabled, bool enabledDefault) AddHidController(string? manufacturer, string? productName, string? serialNumber)
        {
            (uint index, bool? enabled, bool enabledDefault) result = default;

            _configurationManager.ModifyConfiguration(
                (configuration, counter) => { result = configuration.Input(true).HidControllers(true).Add(manufacturer, productName, serialNumber); });

            return result;
        }
    }
}