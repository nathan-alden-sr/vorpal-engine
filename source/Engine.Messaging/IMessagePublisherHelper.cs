using NathanAldenSr.VorpalEngine.Common;

namespace NathanAldenSr.VorpalEngine.Engine.Messaging
{
    /// <summary>Represents a way to publish messages.</summary>
    public interface IMessagePublisherHelper
    {
        /// <summary>Publishes a message.</summary>
        /// <typeparam name="TMessage">The type of message to publish.</typeparam>
        /// <param name="message">The message to publish.</param>
        MessageQueueHelper Publish<TMessage>(TMessage message)
            where TMessage : IMessage;

        /// <summary>Publishes a message.</summary>
        /// <typeparam name="TMessage">The type of message to publish.</typeparam>
        MessageQueueHelper Publish<TMessage>()
            where TMessage : IMessage, new();
    }
}