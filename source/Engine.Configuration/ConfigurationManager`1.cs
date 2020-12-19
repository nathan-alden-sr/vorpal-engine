using System;
using System.Text.Json;
using NathanAldenSr.VorpalEngine.Common;
using NathanAldenSr.VorpalEngine.Configuration.ConfigurationFiles;

namespace NathanAldenSr.VorpalEngine.Engine.Configuration
{
    /// <summary>Loads and saves configurations.</summary>
    /// <typeparam name="T">The type of configuration.</typeparam>
    public class ConfigurationManager<T> : IConfigurationManager<T>
        where T : Configuration
    {
        private readonly IConfigurationFileManager _configurationFileManager;
        private readonly Func<T> _defaultConfigurationFactoryDelegate;
        private readonly Identifier _gameIdentifier;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly object _lockObject = new();
        private ulong _counter;

        /// <summary>Initializes a new instance of the <see cref="ConfigurationManager{T}" /> class.</summary>
        /// <param name="configurationFileManager">An <see cref="IConfigurationFileManager" /> implementation.</param>
        /// <param name="gameIdentifier">A game identifier.</param>
        /// <param name="defaultConfigurationFactoryDelegate">A delegate that returns a default configuration when invoked.</param>
        public ConfigurationManager(
            IConfigurationFileManager configurationFileManager,
            Identifier gameIdentifier,
            Func<T> defaultConfigurationFactoryDelegate)
        {
            _configurationFileManager = configurationFileManager;
            _gameIdentifier = gameIdentifier;
            _defaultConfigurationFactoryDelegate = defaultConfigurationFactoryDelegate;
            _jsonSerializerOptions = _configurationFileManager.GetJsonSerializerOptions();
            _jsonSerializerOptions.WriteIndented = false;
        }

        /// <inheritdoc />
        public T GetConfiguration()
        {
            lock (_lockObject)
            {
                return LoadConfiguration();
            }
        }

        /// <inheritdoc />
        public event ConfigurationChangedDelegate<T>? ConfigurationChanged;

        /// <inheritdoc />
        public void ModifyConfiguration(ModifyConfigurationDelegate<T> modifyConfigurationDelegate)
        {
            T oldConfiguration;
            T newConfiguration;
            bool configurationChanged;

            lock (_lockObject)
            {
                oldConfiguration = LoadConfiguration();
                newConfiguration = LoadConfiguration();

                // The caller is given the configuration object to modify and the new counter value
                modifyConfigurationDelegate(newConfiguration, ++_counter);

                // Determine if the configuration actually changed

                string oldJson = JsonSerializer.Serialize(oldConfiguration, _jsonSerializerOptions);
                string newJson = JsonSerializer.Serialize(newConfiguration, _jsonSerializerOptions);

                configurationChanged = !oldJson.Equals(newJson, StringComparison.Ordinal);

                if (configurationChanged)
                {
                    _configurationFileManager.SaveConfiguration(_gameIdentifier, newConfiguration);
                }
            }

            if (configurationChanged)
            {
                ConfigurationChanged?.Invoke(oldConfiguration, newConfiguration, _counter);
            }
        }

        private T LoadConfiguration() => _configurationFileManager.LoadConfiguration(_gameIdentifier, _defaultConfigurationFactoryDelegate);
    }
}