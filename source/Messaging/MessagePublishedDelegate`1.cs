using NathanAldenSr.VorpalEngine.Common;

namespace NathanAldenSr.VorpalEngine.Messaging
{
    /// <summary>A delegate that is invoked after a message is published.</summary>
    /// <typeparam name="TMessage">The type of message that was published.</typeparam>
    /// <param name="message">The message that was published.</param>
    /// <param name="subscriberCount">The number of subscribers to the <typeparamref name="TMessage" /> type.</param>
    /// <param name="publisherContext">The publisher's nested context.</param>
    public delegate void MessagePublishedDelegate<in TMessage>(TMessage message, int subscriberCount, NestedContext publisherContext);
}