// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

namespace VorpalEngine.Logging;

/// <summary>Levels at which log messages may be logged.</summary>
public enum LogLevel
{
    /// <summary>Verbose.</summary>
    Verbose,

    /// <summary>Debug.</summary>
    Debug,

    /// <summary>Information.</summary>
    Information,

    /// <summary>Warning.</summary>
    Warning,

    /// <summary>Error.</summary>
    Error,

    /// <summary>Fatal.</summary>
    Fatal
}