// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Text.Json;
using VorpalEngine.Common;

namespace VorpalEngine.Configuration.ConfigurationFiles;

/// <summary>Represents the loading and saving of configuration files.</summary>
public interface IConfigurationFileManager
{
    /// <summary>Gets the JSON serializer options used when serializing and deserializing configuration files.</summary>
    JsonSerializerOptions JsonSerializerOptions { get; }

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
