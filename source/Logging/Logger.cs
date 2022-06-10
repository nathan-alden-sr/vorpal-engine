// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Runtime.CompilerServices;
using Serilog;
using Serilog.Events;
using TerraFX.Threading;

namespace VorpalEngine.Logging;

/// <summary>Logs messages using Serilog.</summary>
public sealed class Logger : ILogger
{
    private static readonly Dictionary<LogLevel, LogEventLevel> LogEventLevelsByLogLevel =
        new()
        {
            [LogLevel.Verbose] = LogEventLevel.Verbose,
            [LogLevel.Debug] = LogEventLevel.Debug,
            [LogLevel.Information] = LogEventLevel.Information,
            [LogLevel.Warning] = LogEventLevel.Warning,
            [LogLevel.Error] = LogEventLevel.Error,
            [LogLevel.Fatal] = LogEventLevel.Fatal
        };

    private readonly Serilog.Core.Logger? _logger;
    private VolatileState _state;

    /// <summary>Initializes a new instance of the <see cref="Logger" /> class.</summary>
    /// <param name="configuration">A Serilog logger configuration.</param>
    public Logger(LoggerConfiguration configuration)
    {
        ThrowIfNull(configuration);

        _logger = configuration.CreateLogger();

        _ = _state.Transition(VolatileState.Initialized);
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(LogLevel level, Exception? exception, string messageTemplate, params object?[] propertyValues)
    {
        AssertNotDisposedOrDisposing(_state);

        _logger?.Write(LogEventLevelsByLogLevel[level], exception, messageTemplate, propertyValues);
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(LogLevel level, string messageTemplate, params object?[] propertyValues)
    {
        AssertNotDisposedOrDisposing(_state);

        _logger?.Write(LogEventLevelsByLogLevel[level], messageTemplate, propertyValues);
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Verbose(Exception? exception, string messageTemplate, params object?[] propertyValues)
    {
        AssertNotDisposedOrDisposing(_state);

        _logger?.Verbose(exception, messageTemplate, propertyValues);
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Verbose(string messageTemplate, params object?[] propertyValues)
    {
        AssertNotDisposedOrDisposing(_state);

        _logger?.Verbose(messageTemplate, propertyValues);
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, string messageTemplate, params object?[] propertyValues)
    {
        AssertNotDisposedOrDisposing(_state);

        _logger?.Debug(exception, messageTemplate, propertyValues);
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(string messageTemplate, params object?[] propertyValues)
    {
        AssertNotDisposedOrDisposing(_state);

        _logger?.Debug(messageTemplate, propertyValues);
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Information(Exception? exception, string messageTemplate, params object?[] propertyValues)
    {
        AssertNotDisposedOrDisposing(_state);

        _logger?.Information(exception, messageTemplate, propertyValues);
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Information(string messageTemplate, params object?[] propertyValues)
    {
        AssertNotDisposedOrDisposing(_state);

        _logger?.Information(messageTemplate, propertyValues);
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warning(Exception? exception, string messageTemplate, params object?[] propertyValues)
    {
        AssertNotDisposedOrDisposing(_state);

        _logger?.Warning(exception, messageTemplate, propertyValues);
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warning(string messageTemplate, params object?[] propertyValues)
    {
        AssertNotDisposedOrDisposing(_state);

        _logger?.Warning(messageTemplate, propertyValues);
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Error(Exception? exception, string messageTemplate, params object?[] propertyValues)
    {
        AssertNotDisposedOrDisposing(_state);

        _logger?.Error(exception, messageTemplate, propertyValues);
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Error(string messageTemplate, params object?[] propertyValues)
    {
        AssertNotDisposedOrDisposing(_state);

        _logger?.Error(messageTemplate, propertyValues);
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Fatal(Exception? exception, string messageTemplate, params object?[] propertyValues)
    {
        AssertNotDisposedOrDisposing(_state);

        _logger?.Fatal(exception, messageTemplate, propertyValues);
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Fatal(string messageTemplate, params object?[] propertyValues)
    {
        AssertNotDisposedOrDisposing(_state);

        _logger?.Fatal(messageTemplate, propertyValues);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        if (_state.BeginDispose() < VolatileState.Disposing)
        {
            _logger?.Dispose();
        }

        _state.EndDispose();
    }
}
