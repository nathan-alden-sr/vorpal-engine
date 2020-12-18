using System;
using System.Collections.Generic;
using NathanAldenSr.VorpalEngine.Common;
using static NathanAldenSr.VorpalEngine.Common.ExceptionHelper;
using static NathanAldenSr.VorpalEngine.Common.State;

namespace NathanAldenSr.VorpalEngine.Messaging
{
    /// <summary>
    ///     A helpful wrapper that simplifies publishing and subscribing with an
    ///     <see cref="IConcurrentMessageQueue{TMessageBase,TThread}" />.
    /// </summary>
    /// <typeparam name="TMessageBase">The base type for all messages.</typeparam>
    /// <typeparam name="TThread">The type representing logical threads that handle messages.</typeparam>
    public class ConcurrentMessageQueueHelper<TMessageBase, TThread> : IDisposable
        where TThread : struct, Enum
    {
        private readonly IConcurrentMessageQueue<TMessageBase, TThread> _concurrentMessageQueue;
        private readonly NestedContext _context;
        private readonly HashSet<ISubscriptionReceipt> _subscriptionReceipts = new();
        private State _state;
        private TThread? _thread;

        /// <summary>Initializes a new instance of the <see cref="ConcurrentMessageQueueHelper{TMessageBase,TThread}" /> class.</summary>
        /// <param name="concurrentMessageQueue">An <see cref="IConcurrentMessageQueue{TMessageBase,TThread}" /> implementation.</param>
        /// <param name="context">A nested context.</param>
        public ConcurrentMessageQueueHelper(IConcurrentMessageQueue<TMessageBase, TThread> concurrentMessageQueue, NestedContext context = default)
        {
            _concurrentMessageQueue = concurrentMessageQueue;
            _context = context;

            _state.Transition(Initialized);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            if (_state.BeginDispose() < Disposing)
            {
                _concurrentMessageQueue.Unsubscribe(_subscriptionReceipts);
                _subscriptionReceipts.Clear();
            }

            _state.EndDispose();

            GC.SuppressFinalize(this);
        }

        /// <summary>Subsequent subscriptions will be associated with the logical thread <paramref name="thread" />.</summary>
        /// <param name="thread">A logical thread that the subscription will be assoociated with.</param>
        /// <returns>This object.</returns>
        public ConcurrentMessageQueueHelper<TMessageBase, TThread> WithThread(TThread thread)
        {
            _state.ThrowIfDisposingOrDisposed();

            _thread = thread;

            return this;
        }

        /// <summary>Publishes a message.</summary>
        /// <typeparam name="TMessage">The type of message to publish.</typeparam>
        /// <returns>This object.</returns>
        public ConcurrentMessageQueueHelper<TMessageBase, TThread> Publish<TMessage>(TMessage message)
            where TMessage : TMessageBase
        {
            _state.ThrowIfDisposingOrDisposed();

            _concurrentMessageQueue.Publish(message, _context);

            return this;
        }

        /// <summary>Publishes a message.</summary>
        /// <typeparam name="TMessage">The type of message to publish.</typeparam>
        /// <returns>This object.</returns>
        public ConcurrentMessageQueueHelper<TMessageBase, TThread> Publish<TMessage>()
            where TMessage : TMessageBase, new()
        {
            _state.ThrowIfDisposingOrDisposed();

            _concurrentMessageQueue.Publish<TMessage>(_context);

            return this;
        }

        /// <summary>Subscribes to a message.</summary>
        /// <typeparam name="TMessage">The type of message to subscribe to.</typeparam>
        /// <param name="handlerDelegate">A delegate to invoke when handling messages.</param>
        /// <returns>This object.</returns>
        public ConcurrentMessageQueueHelper<TMessageBase, TThread> Subscribe<TMessage>(MessageHandlerDelegate<TMessage> handlerDelegate)
            where TMessage : TMessageBase
        {
            _state.ThrowIfDisposingOrDisposed();

            if (_thread is null)
            {
                ThrowInvalidOperationException("No thread was specified.");
            }

            ISubscriptionReceipt subscriptionReceipt = _concurrentMessageQueue.Subscribe(handlerDelegate, _thread.Value, _context);

            _subscriptionReceipts.Add(subscriptionReceipt);

            return this;
        }

        /// <inheritdoc cref="IConcurrentMessageQueue{TMessageBase,TThread}.DispatchQueued" />
        public void DispatchQueued(TThread thread)
        {
            _state.ThrowIfDisposingOrDisposed();

            _concurrentMessageQueue.DispatchQueued(thread);
        }
    }
}