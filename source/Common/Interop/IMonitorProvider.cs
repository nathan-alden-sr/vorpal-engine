using System.Collections.Generic;

namespace NathanAldenSr.VorpalEngine.Common.Interop
{
    /// <summary>Represents a way to query the operating system for monitors currently attached to the primary graphics device.</summary>
    public interface IMonitorProvider
    {
        /// <summary>Get a set of monitors currently attached to the primary graphics device.</summary>
        IReadOnlySet<Monitor> Monitors { get; }

        /// <summary>Gets the primary monitor.</summary>
        Monitor? PrimaryMonitor { get; }

        /// <summary>Refreshes the collection of monitors currently attached to the primary graphics device.</summary>
        void Refresh();
    }
}