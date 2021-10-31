// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using VorpalEngine.Common;

namespace VorpalEngine.Messaging;

/// <summary>Represents a way to subscribe and unsubscribe from messages.</summary>
/// <typeparam name="TMessageBase">The base type for all messages.</typeparam>
/// <typeparam name="TThread">The type representing logical threads that handle messages.</typeparam>
public interface IMessageSubscriber<in TMessageBase, in TThread>
    where TThread : struct, Enum
{
    /// <summary>Subscribes to messages.</summary>
    /// <param name="handlerDelegate">A delegate that will handle messages of type <typeparamref name="T" />.</param>
    /// <param name="thread">The logical thread that will handle messages of type <typeparamref name="T" />.</param>
    /// <param name="context">The subscriber's nested context.</param>
    /// <returns>A subscription receipt that can be used to unsubscribe later.</returns>
    ISubscriptionReceipt Subscribe<T>(MessageHandlerDelegate<T> handlerDelegate, TThread thread, NestedContext context = default)
        where T : TMessageBase;

    /// <summary>Unsubscribes from subscriptions.</summary>
    /// <param name="subscriptionReceipts">A set of subscription receipts.</param>
    void Unsubscribe(IReadOnlySet<ISubscriptionReceipt> subscriptionReceipts);

    /// <summary>Unsubscribes from subscriptions.</summary>
    /// <param name="subscriptionReceipts">An array of subscription receipts.</param>
    void Unsubscribe(params ISubscriptionReceipt[] subscriptionReceipts);
}