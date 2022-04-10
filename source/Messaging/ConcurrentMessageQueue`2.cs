// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Collections.Concurrent;
using VorpalEngine.Common;

namespace VorpalEngine.Messaging;

/// <summary>A concurrent message queue that implements a one-publisher, many-subscribers model.</summary>
public class ConcurrentMessageQueue<TMessageBase, TThread> : IConcurrentMessageQueue<TMessageBase, TThread>
    where TThread : struct, Enum
{
    private readonly ConcurrentDictionary<TThread, ConcurrentQueue<Action>> _queuedHandlerDelegatesByTThread = new();

    private readonly ConcurrentDictionary<Type, ConcurrentDictionary<Subscription, byte>> _subscriptionReceiptsByMessageType =
        new();

    /// <summary>Initializes a new instance of the <see cref="ConcurrentMessageQueue{TMessageBase,TThread}" /> class.</summary>
    public ConcurrentMessageQueue()
    {
        foreach (var thread in Enum.GetValues<TThread>())
        {
            _ = _queuedHandlerDelegatesByTThread.TryAdd(thread, new ConcurrentQueue<Action>());
        }
    }

    /// <inheritdoc />
    public event MessagePublishingDelegate<TMessageBase>? MessagePublishing;

    /// <inheritdoc />
    public event MessagePublishedDelegate<TMessageBase>? MessagePublished;

    /// <inheritdoc />
    public event MessageHandlingDelegate<TMessageBase>? MessageHandling;

    /// <inheritdoc />
    public event MessageHandledDelegate<TMessageBase>? MessageHandled;

    /// <inheritdoc />
    public event MessageSubscribedDelegate? MessageSubscribed;

    /// <inheritdoc />
    public event MessageUnsubscribedDelegate? MessageUnsubscribed;

    /// <inheritdoc />
    public void Publish<T>(T message, NestedContext context = default)
        where T : TMessageBase
    {
        var messageType = typeof(T);
        var hasSubscribers = _subscriptionReceiptsByMessageType.TryGetValue(messageType, out var subscriptions);

        // Notify observers that a message is about to be published
        MessagePublishing?.Invoke(message, subscriptions?.Count ?? 0, context);

        if (!hasSubscribers)
        {
            return;
        }

        AssertNotNull(subscriptions);

        // Enqueue the message for each subscription
        foreach (var subscription in subscriptions.Keys)
        {
            _queuedHandlerDelegatesByTThread[subscription.Thread]
                .Enqueue(
                    () =>
                    {
                        // Notify observers that a message is being handled
                        MessageHandling?.Invoke(message, subscription.Context);

                        ((MessageHandlerDelegate<T>)subscription.HandlerDelegate)(message);

                        // Notify observers that a message was handled
                        MessageHandled?.Invoke(message, subscription.Context);
                    });
        }

        // Notify observers that a message was published
        MessagePublished?.Invoke(message, subscriptions.Count, context);
    }

    /// <inheritdoc />
    public void Publish<T>(NestedContext context = default)
        where T : TMessageBase, new()
        => Publish(new T(), context);

    /// <inheritdoc />
    public ISubscriptionReceipt Subscribe<TMessage>(
        MessageHandlerDelegate<TMessage> handlerDelegate,
        TThread thread,
        NestedContext context = default)
        where TMessage : TMessageBase
    {
        ThrowIfNull(handlerDelegate);

        var messageType = typeof(TMessage);
        var subscription = new Subscription(messageType, thread, handlerDelegate, context);
        var subscriptions = 
            _subscriptionReceiptsByMessageType.GetOrAdd(messageType, _ => new ConcurrentDictionary<Subscription, byte>());

        if (subscriptions.TryAdd(subscription, 0))
        {
            // Notify observers that a message was subscribed to
            MessageSubscribed?.Invoke(messageType, context);
        }

        return subscription;
    }

    /// <inheritdoc />
    public void Unsubscribe(IReadOnlySet<ISubscriptionReceipt> subscriptionReceipts)
    {
        ThrowIfNull(subscriptionReceipts);

        var groupings = subscriptionReceipts.OfType<Subscription>().GroupBy(a => a.MessageType, a => a);

        foreach (var grouping in groupings)
        {
            var subscriptions = _subscriptionReceiptsByMessageType[grouping.Key];

            foreach (var subscription in grouping)
            {
                if (subscriptions.TryRemove(subscription, out _))
                {
                    // Notify observers that a message was unsubscribed from
                    MessageUnsubscribed?.Invoke(subscription.MessageType, subscription.Context);
                }
            }
        }
    }

    /// <inheritdoc />
    public void Unsubscribe(params ISubscriptionReceipt[] subscriptionReceipts)
        => Unsubscribe(subscriptionReceipts.ToImmutableHashSet());

    /// <inheritdoc />
    public void DispatchQueued(TThread thread)
    {
        var queue = _queuedHandlerDelegatesByTThread[thread];

        // Process all queued messages in publish order
        while (queue.TryDequeue(out var handlerDelegate))
        {
            handlerDelegate();
        }
    }

    private sealed class Subscription : ISubscriptionReceipt
    {
        public Subscription(Type messageType, TThread thread, Delegate handlerDelegate, NestedContext context)
        {
            MessageType = messageType;
            Thread = thread;
            HandlerDelegate = handlerDelegate;
            Context = context;
        }

        public Type MessageType { get; }

        public TThread Thread { get; }

        public Delegate HandlerDelegate { get; }

        public NestedContext Context { get; }
    }
}
