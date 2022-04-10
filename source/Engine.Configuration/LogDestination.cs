// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

namespace VorpalEngine.Engine.Configuration;

/// <summary>Log message destinations.</summary>
public enum LogDestination
{
    /// <summary>Log messages to files.</summary>
    File,

    /// <summary>Log messages to the debugger.</summary>
    Debug
}
