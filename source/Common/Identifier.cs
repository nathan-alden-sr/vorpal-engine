// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Diagnostics;

namespace VorpalEngine.Common;

/// <summary>An identifier used to uniquely identify a game across all games.</summary>
[DebuggerDisplay($"{{{nameof(DebuggerDisplay)},nq}}")]
public sealed class Identifier
{
    /// <summary>Initializes a new instance of the <see cref="Identifier" /> class.</summary>
    /// <param name="id">The ID of the game. This ID should be unique across all games.</param>
    /// <param name="name">The name of the game. The name does not have to be unique across all games.</param>
    public Identifier(Guid id, string name)
    {
        ThrowIfNull(name, nameof(name));

        Id = id;
        Name = name;
    }

    /// <summary>Gets the ID of of the game.</summary>
    public Guid Id { get; }

    /// <summary>Gets the name of the game.</summary>
    public string Name { get; }

    private string DebuggerDisplay => $"Id = {Id:D}; Name = {Name}";
}