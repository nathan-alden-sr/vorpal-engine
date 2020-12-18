using NathanAldenSr.VorpalEngine.Common;

namespace NathanAldenSr.VorpalEngine.Configuration.Paths
{
    /// <summary>Represents various paths for a specific <see cref="Identifier" />.</summary>
    public interface IIdentifierPaths
    {
        /// <summary>Gets the directory that stores arbitrary identifier data.</summary>
        string DataDirectory { get; }

        /// <summary>Gets the configuration file path.</summary>
        string ConfigurationFilePath { get; }

        /// <summary>Gets the log file directory.</summary>
        string LogFileDirectory { get; }
    }
}