using System;
using System.Runtime.CompilerServices;
using BouncyBox.VorpalEngine.Common;

namespace BouncyBox.VorpalEngine.Logging
{
    public class ContextLogger : ILogger
    {
        private readonly NestedContext _context;

        public ContextLogger(NestedContext context)
        {
            _context = context;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Write(LogLevel level, Exception? exception, string? messageTemplate = null, params object?[] propertyValues) =>
            Log.Logger?.Write(level, exception, FormatMessageTemplate(messageTemplate), propertyValues);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Write(LogLevel level, string? messageTemplate = null, params object?[] propertyValues) =>
            Log.Logger?.Write(level, FormatMessageTemplate(messageTemplate), propertyValues);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Fatal(Exception? exception, string? messageTemplate = null, params object?[] propertyValues) =>
            Log.Logger?.Fatal(exception, FormatMessageTemplate(messageTemplate), propertyValues);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Fatal(string? messageTemplate = null, params object?[] propertyValues) =>
            Log.Logger?.Fatal(FormatMessageTemplate(messageTemplate), propertyValues);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Error(Exception? exception, string? messageTemplate = null, params object?[] propertyValues) =>
            Log.Logger?.Error(exception, FormatMessageTemplate(messageTemplate), propertyValues);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Error(string? messageTemplate = null, params object?[] propertyValues) =>
            Log.Logger?.Error(FormatMessageTemplate(messageTemplate), propertyValues);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Warning(Exception? exception, string? messageTemplate = null, params object?[] propertyValues) =>
            Log.Logger?.Warning(exception, FormatMessageTemplate(messageTemplate), propertyValues);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Warning(string? messageTemplate = null, params object?[] propertyValues) =>
            Log.Logger?.Warning(FormatMessageTemplate(messageTemplate), propertyValues);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Information(Exception? exception, string? messageTemplate = null, params object?[] propertyValues) =>
            Log.Logger?.Information(exception, FormatMessageTemplate(messageTemplate), propertyValues);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Information(string? messageTemplate = null, params object?[] propertyValues) =>
            Log.Logger?.Information(FormatMessageTemplate(messageTemplate), propertyValues);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Debug(Exception? exception, string? messageTemplate = null, params object?[] propertyValues) =>
            Log.Logger?.Debug(exception, FormatMessageTemplate(messageTemplate), propertyValues);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Debug(string? messageTemplate = null, params object?[] propertyValues) =>
            Log.Logger?.Debug(FormatMessageTemplate(messageTemplate), propertyValues);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Verbose(Exception? exception, string? messageTemplate = null, params object?[] propertyValues) =>
            Log.Logger?.Verbose(exception, FormatMessageTemplate(messageTemplate), propertyValues);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Verbose(string? messageTemplate = null, params object?[] propertyValues) =>
            Log.Logger?.Verbose(FormatMessageTemplate(messageTemplate), propertyValues);

        public void Dispose()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private string? FormatMessageTemplate(string? messageTemplate) => _context.IsEmpty ? messageTemplate : $"[{_context.Description}] {messageTemplate}";
    }
}