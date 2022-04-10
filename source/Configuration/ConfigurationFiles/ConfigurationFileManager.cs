// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using VorpalEngine.Common;
using VorpalEngine.Configuration.Paths;

namespace VorpalEngine.Configuration.ConfigurationFiles;

/// <summary>Loads and saves configuration files.</summary>
public sealed class ConfigurationFileManager : IConfigurationFileManager
{
    /// <summary>Default JSON serializer options.</summary>
    public static readonly JsonSerializerOptions DefaultJsonSerializerOptions =
        new()
        {
            Converters = { new JsonStringEnumConverter() },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            IgnoreReadOnlyProperties = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

    private readonly IIdentifierPaths _identifierPaths;

    /// <summary>Initializes a new instance of the <see cref="ConfigurationFileManager" /> class.</summary>
    /// <param name="identifierPaths">A <see cref="IIdentifierPaths" /> implementation.</param>
    /// <param name="options">
    ///     JSON serializer options. <see cref="DefaultJsonSerializerOptions" /> will be used if
    ///     <paramref name="options" /> is <see langword="null" />.
    /// </param>
    public ConfigurationFileManager(IIdentifierPaths identifierPaths, JsonSerializerOptions? options = null)
    {
        ThrowIfNull(identifierPaths);

        _identifierPaths = identifierPaths;
        JsonSerializerOptions = options ?? new JsonSerializerOptions(DefaultJsonSerializerOptions);
    }

    /// <inheritdoc />
    public JsonSerializerOptions JsonSerializerOptions { get; }

    /// <inheritdoc />
    public T LoadConfiguration<T>(Identifier identifier, Func<T> defaultConfigurationFactoryDelegate)
        where T : class
    {
        ThrowIfNull(identifier);
        ThrowIfNull(defaultConfigurationFactoryDelegate);

        T SaveDefaultConfiguration()
        {
            var defaultConfiguration = defaultConfigurationFactoryDelegate();

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
                var json = File.ReadAllText(_identifierPaths.ConfigurationFilePath);

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
        => LoadConfiguration(identifier, () => new T());

    /// <inheritdoc />
    public void SaveConfiguration<T>(Identifier identifier, T configuration)
        where T : class
    {
        ThrowIfNull(identifier);
        ThrowIfNull(configuration);

        var json = JsonSerializer.Serialize(configuration, JsonSerializerOptions);

        File.WriteAllText(_identifierPaths.ConfigurationFilePath, json, Encoding.UTF8);
    }
}
