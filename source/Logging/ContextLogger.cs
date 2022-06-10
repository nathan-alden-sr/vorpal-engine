// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Runtime.CompilerServices;
using VorpalEngine.Common;

namespace VorpalEngine.Logging;

/// <summary>Logs contextual messages using Serilog</summary>
public sealed class ContextLogger : ILogger
{
    private readonly NestedContext _context;

    /// <summary>Initializes a new instance of the <see cref="ContextLogger" /> class.</summary>
    /// <param name="context">A nested context.</param>
    public ContextLogger(NestedContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(LogLevel level, Exception? exception, string messageTemplate, params object?[] propertyValues)
        => Log.Logger?.Write(level, exception, FormatMessageTemplate(messageTemplate), propertyValues);

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(LogLevel level, string messageTemplate, params object?[] propertyValues)
        => Log.Logger?.Write(level, FormatMessageTemplate(messageTemplate), propertyValues);

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Fatal(Exception? exception, string messageTemplate, params object?[] propertyValues)
        => Log.Logger?.Fatal(exception, FormatMessageTemplate(messageTemplate), propertyValues);

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Fatal(string messageTemplate, params object?[] propertyValues)
        => Log.Logger?.Fatal(FormatMessageTemplate(messageTemplate), propertyValues);

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Error(Exception? exception, string messageTemplate, params object?[] propertyValues)
        => Log.Logger?.Error(exception, FormatMessageTemplate(messageTemplate), propertyValues);

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Error(string messageTemplate, params object?[] propertyValues)
        => Log.Logger?.Error(FormatMessageTemplate(messageTemplate), propertyValues);

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warning(Exception? exception, string messageTemplate, params object?[] propertyValues)
        => Log.Logger?.Warning(exception, FormatMessageTemplate(messageTemplate), propertyValues);

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warning(string messageTemplate, params object?[] propertyValues)
        => Log.Logger?.Warning(FormatMessageTemplate(messageTemplate), propertyValues);

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Information(Exception? exception, string messageTemplate, params object?[] propertyValues)
        => Log.Logger?.Information(exception, FormatMessageTemplate(messageTemplate), propertyValues);

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Information(string messageTemplate, params object?[] propertyValues)
        => Log.Logger?.Information(FormatMessageTemplate(messageTemplate), propertyValues);

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, string messageTemplate, params object?[] propertyValues)
        => Log.Logger?.Debug(exception, FormatMessageTemplate(messageTemplate), propertyValues);

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(string messageTemplate, params object?[] propertyValues)
        => Log.Logger?.Debug(FormatMessageTemplate(messageTemplate), propertyValues);

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Verbose(Exception? exception, string messageTemplate, params object?[] propertyValues)
        => Log.Logger?.Verbose(exception, FormatMessageTemplate(messageTemplate), propertyValues);

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Verbose(string messageTemplate, params object?[] propertyValues)
        => Log.Logger?.Verbose(FormatMessageTemplate(messageTemplate), propertyValues);

    /// <inheritdoc />
    public void Dispose()
    {
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private string FormatMessageTemplate(string messageTemplate)
        => _context.IsEmpty ? messageTemplate : $"[{_context.Description}] {messageTemplate}";
}
