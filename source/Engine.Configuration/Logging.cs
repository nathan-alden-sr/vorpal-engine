// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace VorpalEngine.Engine.Configuration;

/// <summary>Logging configuration.</summary>
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("Style", "IDE1006:Naming Styles")]
public sealed class Logging
{
    /// <summary>Gets or sets a value determining whether logging is enabled.</summary>
    public bool? Enabled { get; set; }

    /// <summary>
    ///     Gets the value of the <see cref="Enabled" /> property assuming a particular default if <see cref="Enabled" /> is
    ///     <see langword="null" />.
    /// </summary>
    public bool EnabledDefault => Enabled ?? false;

    /// <summary>Gets or sets debug logging configuration. Use <see cref="Debug" /> for finer-grained control over this property.</summary>
    [JsonInclude]
    public LoggingDestination? _Debug { get; private set; }

    /// <summary>Gets or sets file logging configuration. Use <see cref="File" /> for finer-grained control over this property.</summary>
    [JsonInclude]
    public LoggingDestination? _File { get; private set; }

    /// <summary>
    ///     Gets the debug logging configuration, optionally initializing the <see cref="_Debug" /> property to an instance of
    ///     <see cref="LoggingDestination" />.
    /// </summary>
    /// <param name="initialize">
    ///     A value determining whether to initialize a <see langword="null" /> <see cref="_Debug" /> property value
    ///     with an instance of <see cref="LoggingDestination" />.
    /// </param>
    /// <returns>
    ///     An <see cref="LoggingDestination" /> object. If <paramref name="initialize" /> is <see langword="true" />, the
    ///     <see cref="_Debug" /> property value was set to the returned object; otherwise, the returned reference should be considered
    ///     temporary.
    /// </returns>
    public LoggingDestination Debug(bool initialize = false)
        => initialize ? _Debug ??= new LoggingDestination() : _Debug ?? new LoggingDestination();

    /// <summary>
    ///     Gets the file logging configuration, optionally initializing the <see cref="_File" /> property to an instance of
    ///     <see cref="LoggingDestination" />.
    /// </summary>
    /// <param name="initialize">
    ///     A value determining whether to initialize a <see langword="null" /> <see cref="_File" /> property value
    ///     with an instance of <see cref="LoggingDestination" />.
    /// </param>
    /// <returns>
    ///     An <see cref="LoggingDestination" /> object. If <paramref name="initialize" /> is <see langword="true" />, the
    ///     <see cref="_File" /> property value was set to the returned object; otherwise, the returned reference should be considered
    ///     temporary.
    /// </returns>
    public LoggingDestination File(bool initialize = false)
        => initialize ? _File ??= new LoggingDestination() : _File ?? new LoggingDestination();
}
