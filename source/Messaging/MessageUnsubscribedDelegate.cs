using System;
using NathanAldenSr.VorpalEngine.Common;

namespace NathanAldenSr.VorpalEngine.Messaging
{
    /// <summary>A delegate that is invoked after a message is unsubscribed from.</summary>
    /// <param name="messageType">The type of message to unsubscribe from.</param>
    /// <param name="subscriberContext">The subscriber's nested context.</param>
    public delegate void MessageUnsubscribedDelegate(Type messageType, NestedContext subscriberContext);
}