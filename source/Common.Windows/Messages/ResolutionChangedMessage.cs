// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using Silk.NET.Maths;
using VorpalEngine.Common.Messaging;

namespace VorpalEngine.Common.Windows.Messages;

/// <summary>Indicates the resolution has changed.</summary>
public readonly struct ResolutionChangedMessage : IMessage
{
    /// <summary>Initializes a new instance of the <see cref="ResolutionChangedMessage" /> struct.</summary>
    /// <param name="oldResolution">The old resolution. A <see langword="null" /> value means the old resolution is unknown.</param>
    /// <param name="newResolution">The new resolution.</param>
    public ResolutionChangedMessage(Vector2D<int>? oldResolution, Vector2D<int> newResolution)
    {
        OldResolution = oldResolution;
        NewResolution = newResolution;
    }

    /// <summary>Gets the old resolution. A <see langword="null" /> value means the old resolution is unknown.</summary>
    public Vector2D<int>? OldResolution { get; }

    /// <summary>Gets the new resolution.</summary>
    public Vector2D<int> NewResolution { get; }

    /// <inheritdoc />
    public string Description
        => OldResolution is not null
               ? $"Resolution changed from {GetDescription(OldResolution.Value)} to {GetDescription(NewResolution)}"
               : $"Resolution changed to {GetDescription(NewResolution)}";

    private static string GetDescription(Vector2D<int> resolution)
        => $"{resolution.X}w {resolution.Y}h";
}