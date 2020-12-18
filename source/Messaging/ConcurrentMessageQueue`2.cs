using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using NathanAldenSr.VorpalEngine.Common;
using static NathanAldenSr.VorpalEngine.Common.AssertHelper;

namespace NathanAldenSr.VorpalEngine.Messaging
{
    /// <summary>A concurrent message queue that implements a one-publisher, many-subscribers model.</summary>
    public class ConcurrentMessageQueue<TMessageBase, TThread> : IConcurrentMessageQueue<TMessageBase, TThread>
        where TThread : struct, Enum
    {
        private readonly ConcurrentDictionary<TThread, ConcurrentQueue<Action>> _queuedHandlerDelegatesByTThread = new();
        private readonly ConcurrentDictionary<Type, ConcurrentDictionary<Subscription, byte>> _subscriptionReceiptsByMessageType = new();

        /// <summary>Initializes a new instance of the <see cref="ConcurrentMessageQueue{TMessageBase,TThread}" /> class.</summary>
        public ConcurrentMessageQueue()
        {
            foreach (TThread thread in Enum.GetValues<TThread>())
            {
                _queuedHandlerDelegatesByTThread.TryAdd(thread, new ConcurrentQueue<Action>());
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
        public void Publish<TMessage>(TMessage message, NestedContext context = default)
            where TMessage : TMessageBase
        {
            Type messageType = typeof(TMessage);
            bool hasSubscribers = _subscriptionReceiptsByMessageType.TryGetValue(messageType, out ConcurrentDictionary<Subscription, byte>? subscriptions);

            // Notify observers that a message is about to be published
            MessagePublishing?.Invoke(message, subscriptions?.Count ?? 0, context);

            if (!hasSubscribers)
            {
                return;
            }

            AssertNotNull(subscriptions, nameof(subscriptions));

            // Enqueue the message for each subscription
            foreach (Subscription subscription in subscriptions.Keys)
            {
                _queuedHandlerDelegatesByTThread[subscription.Thread]
                    .Enqueue(
                        () =>
                        {
                            // Notify observers that a message is being handled
                            MessageHandling?.Invoke(message, subscription.Context);

                            ((MessageHandlerDelegate<TMessage>)subscription.HandlerDelegate)(message);

                            // Notify observers that a message was handled
                            MessageHandled?.Invoke(message, subscription.Context);
                        });
            }

            // Notify observers that a message was published
            MessagePublished?.Invoke(message, subscriptions.Count, context);
        }

        /// <inheritdoc />
        public void Publish<TMessage>(NestedContext context = default)
            where TMessage : TMessageBase, new()
        {
            Publish(new TMessage(), context);
        }

        /// <inheritdoc />
        public ISubscriptionReceipt Subscribe<TMessage>(MessageHandlerDelegate<TMessage> handlerDelegate, TThread thread, NestedContext context = default)
            where TMessage : TMessageBase
        {
            Type messageType = typeof(TMessage);
            var subscription = new Subscription(messageType, thread, handlerDelegate, context);
            ConcurrentDictionary<Subscription, byte> subscriptions =
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
            IEnumerable<IGrouping<Type, Subscription>> groupings = subscriptionReceipts.OfType<Subscription>().GroupBy(a => a.MessageType, a => a);

            foreach (IGrouping<Type, Subscription> grouping in groupings)
            {
                ConcurrentDictionary<Subscription, byte> subscriptions = _subscriptionReceiptsByMessageType[grouping.Key];

                foreach (Subscription subscription in grouping)
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
        {
            Unsubscribe(subscriptionReceipts.ToImmutableHashSet());
        }

        /// <inheritdoc />
        public void DispatchQueued(TThread thread)
        {
            ConcurrentQueue<Action> queue = _queuedHandlerDelegatesByTThread[thread];

            // Process all queued messages in publish order
            while (queue.TryDequeue(out Action? handlerDelegate))
            {
                handlerDelegate();
            }
        }

        private class Subscription : ISubscriptionReceipt
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
}