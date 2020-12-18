using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NathanAldenSr.VorpalEngine.Common;
using Serilog;
using Serilog.Events;
using static NathanAldenSr.VorpalEngine.Common.State;

namespace NathanAldenSr.VorpalEngine.Logging
{
    /// <summary>Logs messages using Serilog.</summary>
    /// <remarks>
    ///     The class is sealed to improve the chances of devirtualization.
    ///     See <a href="https://github.com/dotnet/runtime/issues/7541">this GitHub issue</a>.
    /// </remarks>
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
        private State _state;

        /// <summary>Initializes a new instance of the <see cref="Logger" /> type.</summary>
        /// <param name="configuration">A Serilog logger configuration.</param>
        public Logger(LoggerConfiguration configuration)
        {
            _logger = configuration.CreateLogger();

            _state.Transition(Initialized);
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Write(LogLevel level, Exception? exception, string? messageTemplate = null, params object?[] propertyValues)
        {
            _state.ThrowIfDisposingOrDisposed();

            _logger?.Write(LogEventLevelsByLogLevel[level], exception, messageTemplate, propertyValues);
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Write(LogLevel level, string? messageTemplate = null, params object?[] propertyValues)
        {
            _state.ThrowIfDisposingOrDisposed();

            _logger?.Write(LogEventLevelsByLogLevel[level], messageTemplate, propertyValues);
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Verbose(Exception? exception, string? messageTemplate = null, params object?[] propertyValues)
        {
            _state.ThrowIfDisposingOrDisposed();

            _logger?.Verbose(exception, messageTemplate, propertyValues);
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Verbose(string? messageTemplate = null, params object?[] propertyValues)
        {
            _state.ThrowIfDisposingOrDisposed();

            _logger?.Verbose(messageTemplate, propertyValues);
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Debug(Exception? exception, string? messageTemplate = null, params object?[] propertyValues)
        {
            _state.ThrowIfDisposingOrDisposed();

            _logger?.Debug(exception, messageTemplate, propertyValues);
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Debug(string? messageTemplate = null, params object?[] propertyValues)
        {
            _state.ThrowIfDisposingOrDisposed();

            _logger?.Debug(messageTemplate, propertyValues);
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Information(Exception? exception, string? messageTemplate = null, params object?[] propertyValues)
        {
            _state.ThrowIfDisposingOrDisposed();

            _logger?.Information(exception, messageTemplate, propertyValues);
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Information(string? messageTemplate = null, params object?[] propertyValues)
        {
            _state.ThrowIfDisposingOrDisposed();

            _logger?.Information(messageTemplate, propertyValues);
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Warning(Exception? exception, string? messageTemplate = null, params object?[] propertyValues)
        {
            _state.ThrowIfDisposingOrDisposed();

            _logger?.Warning(exception, messageTemplate, propertyValues);
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Warning(string? messageTemplate = null, params object?[] propertyValues)
        {
            _state.ThrowIfDisposingOrDisposed();

            _logger?.Warning(messageTemplate, propertyValues);
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Error(Exception? exception, string? messageTemplate = null, params object?[] propertyValues)
        {
            _state.ThrowIfDisposingOrDisposed();

            _logger?.Error(exception, messageTemplate, propertyValues);
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Error(string? messageTemplate = null, params object?[] propertyValues)
        {
            _state.ThrowIfDisposingOrDisposed();

            _logger?.Error(messageTemplate, propertyValues);
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Fatal(Exception? exception, string? messageTemplate = null, params object?[] propertyValues)
        {
            _state.ThrowIfDisposingOrDisposed();

            _logger?.Fatal(exception, messageTemplate, propertyValues);
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Fatal(string? messageTemplate = null, params object?[] propertyValues)
        {
            _state.ThrowIfDisposingOrDisposed();

            _logger?.Fatal(messageTemplate, propertyValues);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            if (_state.BeginDispose() < Disposing)
            {
                _logger?.Dispose();
            }

            _state.EndDispose();
        }
    }
}