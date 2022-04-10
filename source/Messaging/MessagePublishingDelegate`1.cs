using VorpalEngine.Common;

namespace VorpalEngine.Messaging;

/// <summary>A delegate that is invoked before a message is published.</summary>
/// <typeparam name="TMessage">The type of message being published.</typeparam>
/// <param name="message">The message that is about to be published.</param>
/// <param name="subscriberCount">The number of subscribers to the <typeparamref name="TMessage" /> type.</param>
/// <param name="publisherContext">The publisher's nested context.</param>
public delegate void MessagePublishingDelegate<in TMessage>(
    TMessage message,
    int subscriberCount,
    NestedContext publisherContext);
