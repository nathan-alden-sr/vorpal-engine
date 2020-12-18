using System;
using System.Text.Json;
using NathanAldenSr.VorpalEngine.Common;

namespace NathanAldenSr.VorpalEngine.Configuration.ConfigurationFiles
{
    /// <summary>Represents the loading and saving of configuration files.</summary>
    public interface IConfigurationFileManager
    {
        /// <summary>Gets a copy of the JSON serializer options used when serializing and deserializin configuration files.</summary>
        /// <returns>A copy of the JSON serializer options used when serializing and deserializin configuration files.</returns>
        JsonSerializerOptions GetJsonSerializerOptions();

        /// <summary>Loads a configuration.</summary>
        /// <typeparam name="T">The type of the configuration.</typeparam>
        /// <param name="identifier">A game identifier.</param>
        /// <param name="defaultConfigurationFactoryDelegate">
        ///     A delegate that returns a default configuration if the requested configuration
        ///     file doesn't exist.
        /// </param>
        /// <returns>The configuration.</returns>
        T LoadConfiguration<T>(Identifier identifier, Func<T> defaultConfigurationFactoryDelegate)
            where T : class;

        /// <summary>Loads a configuration.</summary>
        /// <typeparam name="T">The type of the configuration.</typeparam>
        /// <param name="identifier">A game identifier.</param>
        /// <returns>The configuration.</returns>
        T LoadConfiguration<T>(Identifier identifier)
            where T : class, new();

        /// <summary>Save a configuration.</summary>
        /// <typeparam name="T">The type of the configuration.</typeparam>
        /// <param name="identifier">A game identifier.</param>
        /// <param name="configuration">The configuration to save.</param>
        void SaveConfiguration<T>(Identifier identifier, T configuration)
            where T : class;
    }
}