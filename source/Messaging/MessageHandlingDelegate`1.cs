using NathanAldenSr.VorpalEngine.Common;

namespace NathanAldenSr.VorpalEngine.Messaging
{
    /// <summary>A delegate that is invoked before a message is handled.</summary>
    /// <typeparam name="TMessage">The type of message being handled.</typeparam>
    /// <param name="message">The message that is about to be handled.</param>
    /// <param name="subscriberContext">The subscriber's nested context.</param>
    public delegate void MessageHandlingDelegate<in TMessage>(TMessage message, NestedContext subscriberContext);
}