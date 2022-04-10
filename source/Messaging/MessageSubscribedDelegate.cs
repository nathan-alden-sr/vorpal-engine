using VorpalEngine.Common;

namespace VorpalEngine.Messaging;

/// <summary>A delegate that is invoked after a message is subscribed to.</summary>
/// <param name="messageType">The type of message to subscribe to.</param>
/// <param name="subscriberContext">The subscriber's nested context.</param>
public delegate void MessageSubscribedDelegate(Type messageType, NestedContext subscriberContext);
