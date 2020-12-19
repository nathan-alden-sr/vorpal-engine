using NathanAldenSr.VorpalEngine.Common;

namespace NathanAldenSr.VorpalEngine.Messaging
{
    /// <summary>Represents a way to publish messages.</summary>
    /// <typeparam name="TMessageBase">The base type for all messages.</typeparam>
    public interface IMessagePublisher<in TMessageBase>
    {
        /// <summary>Publishes a message.</summary>
        /// <typeparam name="T">The type of message to publish.</typeparam>
        /// <param name="message">The message to publish.</param>
        /// <param name="context">The publisher's nested context.</param>
        void Publish<T>(T message, NestedContext context = default)
            where T : TMessageBase;

        /// <summary>Publishes a message.</summary>
        /// <typeparam name="T">The type of message to publish.</typeparam>
        /// <param name="context">The publisher's nested context.</param>
        void Publish<T>(NestedContext context = default)
            where T : TMessageBase, new();
    }
}