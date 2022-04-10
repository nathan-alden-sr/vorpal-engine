// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

namespace VorpalEngine.Common.Windows;

/// <summary>Represents a way to query Windows for monitors currently attached to the primary graphics device.</summary>
public interface IMonitorProvider
{
    /// <summary>Get a set of monitors currently attached to the primary graphics device.</summary>
    IReadOnlySet<Monitor> Monitors { get; }

    /// <summary>Gets the primary monitor.</summary>
    Monitor? PrimaryMonitor { get; }

    /// <summary>Refreshes the collection of monitors currently attached to the primary graphics device.</summary>
    void Refresh();
}
