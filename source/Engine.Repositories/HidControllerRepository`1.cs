// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using VorpalEngine.Engine.Configuration;
using VorpalEngine.Input.Controller.Hid;

namespace VorpalEngine.Engine.Repositories;

/// <summary>A repository of HID controllers.</summary>
/// <typeparam name="T">The type of configuration.</typeparam>
public sealed class HidControllerRepository<T> : IHidControllerRepository
    where T : Configuration.Configuration
{
    private readonly IConfigurationManager<T> _configurationManager;

    /// <summary>Initializes a new instance of the <see cref="HidControllerRepository{T}" /> class.</summary>
    /// <param name="configurationManager">An <see cref="IConfigurationManager{T}" /> implementation.</param>
    public HidControllerRepository(IConfigurationManager<T> configurationManager)
    {
        ThrowIfNull(configurationManager);

        _configurationManager = configurationManager;
    }

    /// <inheritdoc />
    public (uint index, bool? enabled, bool enabledDefault) AddHidController(
        string? manufacturer,
        string? productName,
        string? serialNumber)
    {
        (uint index, bool? enabled, bool enabledDefault) result = default;

        _configurationManager.ModifyConfiguration(
            (configuration, _) =>
                result = configuration.Input(true).HidControllers(true).Add(manufacturer, productName, serialNumber));

        return result;
    }
}
