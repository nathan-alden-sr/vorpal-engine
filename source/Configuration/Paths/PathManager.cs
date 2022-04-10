// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using VorpalEngine.Common;
using static System.IO.Path;

namespace VorpalEngine.Configuration.Paths;

/// <summary>Resolves paths.</summary>
public sealed class PathManager : IPathManager
{
    /// <inheritdoc />
    public IIdentifierPaths GetIdentifierPaths(Identifier identifier)
    {
        ThrowIfNull(identifier);

        var invalidPathCharacters = GetInvalidPathChars();
        var folderName =
            string.Create(
                identifier.Name.Length,
                identifier.Name,
                (span, name) =>
                {
                    for (var i = 0; i < span.Length; i++)
                    {
                        span[i] = Array.IndexOf(invalidPathCharacters, name[i]) > -1 ? '_' : name[i];
                    }
                });
        var applicationDataDirectory =
            Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.Create),
                folderName);
        var configurationFilePath = Combine(applicationDataDirectory, "config.json");
        var logFileDirectory = Combine(applicationDataDirectory, "logs");

        _ = Directory.CreateDirectory(applicationDataDirectory);
        _ = Directory.CreateDirectory(logFileDirectory);

        return new IdentifierPaths(applicationDataDirectory, configurationFilePath, logFileDirectory);
    }

    private sealed class IdentifierPaths : IIdentifierPaths
    {
        public IdentifierPaths(string dataDirectory, string configurationFilePath, string logFileDirectory)
        {
            DataDirectory = dataDirectory;
            ConfigurationFilePath = configurationFilePath;
            LogFileDirectory = logFileDirectory;
        }

        public string DataDirectory { get; }

        public string ConfigurationFilePath { get; }

        public string LogFileDirectory { get; }
    }
}
