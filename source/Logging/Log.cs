// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Runtime.CompilerServices;

namespace VorpalEngine.Logging;

/// <summary>Logs messages.</summary>
public static class Log
{
    private static ILogger? _logger;
    private static readonly object LockObject = new();

    /// <summary>Gets or sets the <see cref="ILogger" /> to use to log messages.</summary>
    public static ILogger? Logger
    {
        get
        {
            lock (LockObject)
            {
                return _logger;
            }
        }
        set
        {
            lock (LockObject)
            {
                _logger = value;
            }
        }
    }

    /// <inheritdoc cref="ILogger.Write(LogLevel,System.Exception?,string?,object?[])" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(
        LogLevel level,
        Exception? exception,
        string? messageTemplate = null,
        params object?[] propertyValues)
        => Logger?.Write(level, exception, messageTemplate, propertyValues);

    /// <inheritdoc cref="ILogger.Write(LogLevel,string?,object?[])" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(LogLevel level, string? messageTemplate = null, params object?[] propertyValues)
        => Logger?.Write(level, messageTemplate, propertyValues);

    /// <inheritdoc cref="ILogger.Verbose(System.Exception?,string?,object?[])" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Verbose(Exception? exception, string? messageTemplate = null, params object?[] propertyValues)
        => Logger?.Verbose(exception, messageTemplate, propertyValues);

    /// <inheritdoc cref="ILogger.Verbose(string?,object?[])" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Verbose(string? messageTemplate = null, params object?[] propertyValues)
        => Logger?.Verbose(messageTemplate, propertyValues);

    /// <inheritdoc cref="ILogger.Debug(System.Exception?,string?,object?[])" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Debug(Exception? exception, string? messageTemplate = null, params object?[] propertyValues)
        => Logger?.Debug(exception, messageTemplate, propertyValues);

    /// <inheritdoc cref="ILogger.Debug(string?,object?[])" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Debug(string? messageTemplate = null, params object?[] propertyValues)
        => Logger?.Debug(messageTemplate, propertyValues);

    /// <inheritdoc cref="ILogger.Information(System.Exception?,string?,object?[])" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Information(Exception? exception, string? messageTemplate = null, params object?[] propertyValues)
        => Logger?.Information(exception, messageTemplate, propertyValues);

    /// <inheritdoc cref="ILogger.Information(string?,object?[])" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Information(string? messageTemplate = null, params object?[] propertyValues)
        => Logger?.Information(messageTemplate, propertyValues);

    /// <inheritdoc cref="ILogger.Warning(System.Exception?,string?,object?[])" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Warning(Exception? exception, string? messageTemplate = null, params object?[] propertyValues)
        => Logger?.Warning(exception, messageTemplate, propertyValues);

    /// <inheritdoc cref="ILogger.Warning(string?,object?[])" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Warning(string? messageTemplate = null, params object?[] propertyValues)
        => Logger?.Warning(messageTemplate, propertyValues);

    /// <inheritdoc cref="ILogger.Error(System.Exception?,string?,object?[])" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Error(Exception? exception, string? messageTemplate = null, params object?[] propertyValues)
        => Logger?.Error(exception, messageTemplate, propertyValues);

    /// <inheritdoc cref="ILogger.Error(string?,object?[])" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Error(string? messageTemplate = null, params object?[] propertyValues)
        => Logger?.Error(messageTemplate, propertyValues);

    /// <inheritdoc cref="ILogger.Fatal(System.Exception?,string?,object?[])" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Fatal(Exception? exception, string? messageTemplate = null, params object?[] propertyValues)
        => Logger?.Fatal(exception, messageTemplate, propertyValues);

    /// <inheritdoc cref="ILogger.Fatal(string?,object?[])" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Fatal(string? messageTemplate = null, params object?[] propertyValues)
        => Logger?.Fatal(messageTemplate, propertyValues);
}
