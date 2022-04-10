// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using VorpalEngine.Common.Messaging;

namespace VorpalEngine.Common.Windows.Messages;

/// <summary>Indicates the render window is closing.</summary>
public readonly struct RenderWindowClosingMessage : IMessage
{
    /// <inheritdoc />
    public string Description => "Render window is closing";
}
