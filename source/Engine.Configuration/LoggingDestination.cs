// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using VorpalEngine.Logging;

namespace VorpalEngine.Engine.Configuration;

/// <summary>Log destination configuration.</summary>
public sealed class LoggingDestination
{
    /// <summary>Gets or sets a value determining whether logging to the destination is enabled.</summary>
    public bool? Enabled { get; set; }

    /// <summary>
    ///     Gets the value of the <see cref="Enabled" /> property assuming a particular default if <see cref="Enabled" /> is
    ///     <see langword="null" />.
    /// </summary>
    public bool EnabledDefault => Enabled ?? false;

    /// <summary>Gets or sets the minimum level of log messages to log to the destination.</summary>
    public LogLevel? MinimumLevel { get; set; }

    /// <summary>
    ///     Gets the value of the <see cref="MinimumLevel" /> property assuming a particular default if <see cref="MinimumLevel" />
    ///     is <see langword="null" />.
    /// </summary>
    public LogLevel MinimumLevelDefault => MinimumLevel ?? LogLevel.Information;
}
