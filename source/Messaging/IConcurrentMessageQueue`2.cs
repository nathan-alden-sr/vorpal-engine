// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System;

namespace VorpalEngine.Messaging;

/// <summary>Represents a concurrent message queue that implements a one-publisher, many-subscribers model.</summary>
/// <typeparam name="TMessageBase">The base type for all messages.</typeparam>
/// <typeparam name="TThread">The type representing logical threads that handle messages.</typeparam>
public interface IConcurrentMessageQueue<TMessageBase, in TThread> : IMessagePublisher<TMessageBase>, IMessageSubscriber<TMessageBase, TThread>
    where TThread : struct, Enum
{
    /// <summary>Invoked before a message is published.</summary>
    event MessagePublishingDelegate<TMessageBase>? MessagePublishing;

    /// <summary>Invoked after a message is published.</summary>
    event MessagePublishedDelegate<TMessageBase>? MessagePublished;

    /// <summary>Invoked before a message is handled.</summary>
    event MessageHandlingDelegate<TMessageBase>? MessageHandling;

    /// <summary>Invoked after a message is handled.</summary>
    event MessageHandledDelegate<TMessageBase>? MessageHandled;

    /// <summary>Invoked after a message is subscribed to.</summary>
    event MessageSubscribedDelegate? MessageSubscribed;

    /// <summary>Invoked after a message is unsubscribed from.</summary>
    event MessageUnsubscribedDelegate? MessageUnsubscribed;

    /// <summary>
    ///     Dispatches messages queued for the logical thread represented by <paramref name="thread" />. It is intended that the
    ///     thread executing this method represents the logical thread <paramref name="thread" />.
    /// </summary>
    /// <param name="thread">Messages dispatched are those destined for this logical thread.</param>
    void DispatchQueued(TThread thread);
}