using System;
using NathanAldenSr.VorpalEngine.Common;
using NathanAldenSr.VorpalEngine.Engine.Common;
using NathanAldenSr.VorpalEngine.Messaging;
using static NathanAldenSr.VorpalEngine.Common.State;

namespace NathanAldenSr.VorpalEngine.Engine.Messaging
{
    /// <summary>A helpful wrapper that simplifies publishing and subscribing with an <see cref="IMessageQueue" />.</summary>
    public class MessageQueueHelper : IMessagePublisherHelper, IDisposable
    {
        private readonly ConcurrentMessageQueueHelper<IMessage, EngineThread> _concurrentMessageQueueHelper;
        private State _state;

        /// <summary>Initializes a new instance of the <see cref="MessageQueueHelper" /> class.</summary>
        /// <param name="messageQueue">An <see cref="IMessageQueue" /> implementation.</param>
        /// <param name="context">A nested context.</param>
        public MessageQueueHelper(IMessageQueue messageQueue, NestedContext context = default)
        {
            _concurrentMessageQueueHelper = new ConcurrentMessageQueueHelper<IMessage, EngineThread>(messageQueue, context);

            _state.Transition(Initialized);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            if (_state.BeginDispose() < Disposing)
            {
                _concurrentMessageQueueHelper.Dispose();
            }

            _state.EndDispose();

            GC.SuppressFinalize(this);
        }

        /// <inheritdoc />
        public MessageQueueHelper Publish<T>(T message)
            where T : IMessage
        {
            _state.ThrowIfDisposingOrDisposed();

            _concurrentMessageQueueHelper.Publish(message);

            return this;
        }

        /// <inheritdoc />
        public MessageQueueHelper Publish<T>()
            where T : IMessage, new()
        {
            _state.ThrowIfDisposingOrDisposed();

            _concurrentMessageQueueHelper.Publish<T>();

            return this;
        }

        /// <summary>Subsequent subscriptions will be associated with the logical thread <paramref name="thread" />.</summary>
        /// <param name="thread">A logical thread that the subscription will be assoociated with.</param>
        /// <returns>This object.</returns>
        public MessageQueueHelper WithThread(EngineThread thread)
        {
            _state.ThrowIfDisposingOrDisposed();

            _concurrentMessageQueueHelper.WithThread(thread);

            return this;
        }

        /// <summary>Subscribes to a message.</summary>
        /// <typeparam name="T">The type of message to subscribe to.</typeparam>
        /// <param name="handlerDelegate">A delegate to invoke when handling messages.</param>
        /// <returns>This object.</returns>
        public MessageQueueHelper Subscribe<T>(MessageHandlerDelegate<T> handlerDelegate)
            where T : IMessage
        {
            _state.ThrowIfDisposingOrDisposed();

            _concurrentMessageQueueHelper.Subscribe(handlerDelegate);

            return this;
        }

        /// <inheritdoc cref="IConcurrentMessageQueue{TMessageBase,TThread}.DispatchQueued" />
        public void DispatchQueued(EngineThread thread)
        {
            _state.ThrowIfDisposingOrDisposed();

            _concurrentMessageQueueHelper.DispatchQueued(thread);
        }
    }
}