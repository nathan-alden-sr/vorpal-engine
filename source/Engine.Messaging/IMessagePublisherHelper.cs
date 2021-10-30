// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using VorpalEngine.Common.Messaging;

namespace VorpalEngine.Engine.Messaging;

/// <summary>Represents a way to publish messages.</summary>
public interface IMessagePublisherHelper
{
    /// <summary>Publishes a message.</summary>
    /// <typeparam name="T">The type of message to publish.</typeparam>
    /// <param name="message">The message to publish.</param>
    MessageQueueHelper Publish<T>(T message)
        where T : IMessage;

    /// <summary>Publishes a message.</summary>
    /// <typeparam name="T">The type of message to publish.</typeparam>
    MessageQueueHelper Publish<T>()
        where T : IMessage, new();
}