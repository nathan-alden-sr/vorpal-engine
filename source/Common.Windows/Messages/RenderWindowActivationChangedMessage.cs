// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using VorpalEngine.Common.Messaging;

namespace VorpalEngine.Common.Windows.Messages;

/// <summary>Indicates the render window's activation state has changed.</summary>
public readonly struct RenderWindowActivationChangedMessage : IMessage
{
    /// <summary>Initializes a new instance of the <see cref="RenderWindowActivationChangedMessage" /> struct.</summary>
    /// <param name="oldIsActive">The old activation status. A <see langword="null" /> value means the old activation status is unknown.</param>
    /// <param name="newIsActive">The new activation status.</param>
    public RenderWindowActivationChangedMessage(bool oldIsActive, bool newIsActive)
    {
        OldIsActive = oldIsActive;
        NewIsActive = newIsActive;
    }

    /// <summary>Gets the old activation status.</summary>
    public bool OldIsActive { get; }

    /// <summary>Gets the new activation status.</summary>
    public bool NewIsActive { get; }

    /// <inheritdoc />
    public string Description => $"Render window is {(!NewIsActive ? "de" : "")}activated";
}
