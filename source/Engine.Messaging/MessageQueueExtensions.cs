// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using VorpalEngine.Common;

namespace VorpalEngine.Engine.Messaging;

/// <summary>Extensions for the <see cref="IMessageQueue" /> interface.</summary>
public static class MessageQueueExtensions
{
    /// <summary>Creates a <see cref="MessageQueueHelper" /> for <paramref name="messageQueue" />.</summary>
    /// <param name="messageQueue">The message queue to create a helper for.</param>
    /// <param name="context">A nested context.</param>
    /// <returns>The new <see cref="MessageQueueHelper" />.</returns>
    public static MessageQueueHelper ToHelper(this IMessageQueue messageQueue, NestedContext context = default)
        => new(messageQueue, context);
}