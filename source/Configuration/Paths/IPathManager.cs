// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using VorpalEngine.Common;

namespace VorpalEngine.Configuration.Paths;

/// <summary>Represents path resolution.</summary>
public interface IPathManager
{
    /// <summary>Gets paths for a particular identifier.</summary>
    /// <param name="identifier">An identifier.</param>
    /// <returns>An interface that represents paths for the specified identifier.</returns>
    IIdentifierPaths GetIdentifierPaths(Identifier identifier);
}