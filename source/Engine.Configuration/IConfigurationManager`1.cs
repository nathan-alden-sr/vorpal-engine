// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

namespace VorpalEngine.Engine.Configuration;

/// <summary>Represents the loading and saving of configuration.</summary>
/// <typeparam name="T">The type of configuration.</typeparam>
public interface IConfigurationManager<out T>
    where T : Configuration
{
    /// <summary>Invoked when configuration changes.</summary>
    event ConfigurationChangedDelegate<T>? ConfigurationChanged;

    /// <summary>Gets the current configuration.</summary>
    /// <returns>The current configuration.</returns>
    T GetConfiguration();

    /// <summary>Modifies the configuration.</summary>
    /// <param name="modifyConfigurationDelegate">A delegate that should be used to modify configuration.</param>
    void ModifyConfiguration(ModifyConfigurationDelegate<T> modifyConfigurationDelegate);
}