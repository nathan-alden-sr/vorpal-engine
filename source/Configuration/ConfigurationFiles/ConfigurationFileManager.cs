using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using NathanAldenSr.VorpalEngine.Common;
using NathanAldenSr.VorpalEngine.Configuration.Paths;

namespace NathanAldenSr.VorpalEngine.Configuration.ConfigurationFiles
{
    /// <summary>Loads and saves configuration files.</summary>
    public class ConfigurationFileManager : IConfigurationFileManager
    {
        private static readonly JsonSerializerOptions JsonSerializerOptions =
            new()
            {
                Converters =
                {
                    new JsonStringEnumConverter()
                },
                IgnoreNullValues = true,
                IgnoreReadOnlyProperties = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

        private readonly IIdentifierPaths _identifierPaths;

        /// <summary>Initializes a new instance of the <see cref="ConfigurationFileManager" /> class.</summary>
        /// <param name="identifierPaths">A <see cref="IIdentifierPaths" /> implementation.</param>
        public ConfigurationFileManager(IIdentifierPaths identifierPaths)
        {
            _identifierPaths = identifierPaths;
        }

        /// <inheritdoc />
        public JsonSerializerOptions GetJsonSerializerOptions() => new(JsonSerializerOptions);

        /// <inheritdoc />
        public T LoadConfiguration<T>(Identifier identifier, Func<T> defaultConfigurationFactoryDelegate)
            where T : class
        {
            T SaveDefaultConfiguration()
            {
                T defaultConfiguration = defaultConfigurationFactoryDelegate();

                SaveConfiguration(identifier, defaultConfiguration);

                return defaultConfiguration;
            }

            T configuration;

            if (!File.Exists(_identifierPaths.ConfigurationFilePath))
            {
                configuration = SaveDefaultConfiguration();
            }
            else
            {
                try
                {
                    string json = File.ReadAllText(_identifierPaths.ConfigurationFilePath);

                    configuration = JsonSerializer.Deserialize<T>(json, JsonSerializerOptions) ?? SaveDefaultConfiguration();
                }
                catch
                {
                    configuration = SaveDefaultConfiguration();
                }
            }

            return configuration;
        }

        /// <inheritdoc />
        public T LoadConfiguration<T>(Identifier identifier)
            where T : class, new()
        {
            return LoadConfiguration(identifier, () => new T());
        }

        /// <inheritdoc />
        public void SaveConfiguration<T>(Identifier identifier, T configuration)
            where T : class
        {
            string json = JsonSerializer.Serialize(configuration, JsonSerializerOptions);

            File.WriteAllText(_identifierPaths.ConfigurationFilePath, json, Encoding.UTF8);
        }
    }
}