// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

namespace VorpalEngine.Logging;

/// <summary>Represents a way to log messages.</summary>
public interface ILogger : IDisposable
{
    /// <summary>Writes a log message.</summary>
    /// <param name="level">The level of the message.</param>
    /// <param name="exception">An exception that caused this log message to be written.</param>
    /// <param name="messageTemplate">A Serilog message template.</param>
    /// <param name="propertyValues">Property values that map to the Serilog message template.</param>
    void Write(LogLevel level, Exception? exception, string? messageTemplate = null, params object?[] propertyValues);

    /// <summary>Writes a log message.</summary>
    /// <param name="level">The level of the message.</param>
    /// <param name="messageTemplate">A Serilog message template.</param>
    /// <param name="propertyValues">Property values that map to the Serilog message template.</param>
    void Write(LogLevel level, string? messageTemplate = null, params object?[] propertyValues);

    /// <summary>Writes a verbose log message.</summary>
    /// <param name="exception">An exception that caused this log message to be written.</param>
    /// <param name="messageTemplate">A Serilog message template.</param>
    /// <param name="propertyValues">Property values that map to the Serilog message template.</param>
    void Verbose(Exception? exception, string? messageTemplate = null, params object?[] propertyValues);

    /// <summary>Writes a verbose log message.</summary>
    /// <param name="messageTemplate">A Serilog message template.</param>
    /// <param name="propertyValues">Property values that map to the Serilog message template.</param>
    void Verbose(string? messageTemplate = null, params object?[] propertyValues);

    /// <summary>Writes a debug log message.</summary>
    /// <param name="exception">An exception that caused this log message to be written.</param>
    /// <param name="messageTemplate">A Serilog message template.</param>
    /// <param name="propertyValues">Property values that map to the Serilog message template.</param>
    void Debug(Exception? exception, string? messageTemplate = null, params object?[] propertyValues);

    /// <summary>Writes a debug log message.</summary>
    /// <param name="messageTemplate">A Serilog message template.</param>
    /// <param name="propertyValues">Property values that map to the Serilog message template.</param>
    void Debug(string? messageTemplate = null, params object?[] propertyValues);

    /// <summary>Writes an information log message.</summary>
    /// <param name="exception">An exception that caused this log message to be written.</param>
    /// <param name="messageTemplate">A Serilog message template.</param>
    /// <param name="propertyValues">Property values that map to the Serilog message template.</param>
    void Information(Exception? exception, string? messageTemplate = null, params object?[] propertyValues);

    /// <summary>Writes an information log message.</summary>
    /// <param name="messageTemplate">A Serilog message template.</param>
    /// <param name="propertyValues">Property values that map to the Serilog message template.</param>
    void Information(string? messageTemplate = null, params object?[] propertyValues);

    /// <summary>Writes a warning log message.</summary>
    /// <param name="exception">An exception that caused this log message to be written.</param>
    /// <param name="messageTemplate">A Serilog message template.</param>
    /// <param name="propertyValues">Property values that map to the Serilog message template.</param>
    void Warning(Exception? exception, string? messageTemplate = null, params object?[] propertyValues);

    /// <summary>Writes a warning log message.</summary>
    /// <param name="messageTemplate">A Serilog message template.</param>
    /// <param name="propertyValues">Property values that map to the Serilog message template.</param>
    void Warning(string? messageTemplate = null, params object?[] propertyValues);

    /// <summary>Writes an error log message.</summary>
    /// <param name="exception">An exception that caused this log message to be written.</param>
    /// <param name="messageTemplate">A Serilog message template.</param>
    /// <param name="propertyValues">Property values that map to the Serilog message template.</param>
    void Error(Exception? exception, string? messageTemplate = null, params object?[] propertyValues);

    /// <summary>Writes an error log message.</summary>
    /// <param name="messageTemplate">A Serilog message template.</param>
    /// <param name="propertyValues">Property values that map to the Serilog message template.</param>
    void Error(string? messageTemplate = null, params object?[] propertyValues);

    /// <summary>Writes a fatal log message.</summary>
    /// <param name="exception">An exception that caused this log message to be written.</param>
    /// <param name="messageTemplate">A Serilog message template.</param>
    /// <param name="propertyValues">Property values that map to the Serilog message template.</param>
    void Fatal(Exception? exception, string? messageTemplate = null, params object?[] propertyValues);

    /// <summary>Writes a fatal log message.</summary>
    /// <param name="messageTemplate">A Serilog message template.</param>
    /// <param name="propertyValues">Property values that map to the Serilog message template.</param>
    void Fatal(string? messageTemplate = null, params object?[] propertyValues);
}
