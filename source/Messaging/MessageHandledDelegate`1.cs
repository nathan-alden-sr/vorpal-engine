using NathanAldenSr.VorpalEngine.Common;

namespace NathanAldenSr.VorpalEngine.Messaging
{
    /// <summary>A delegate that is invoked after a message is handled.</summary>
    /// <typeparam name="TMessage">The type of message that was handled.</typeparam>
    /// <param name="message">The message that was handled.</param>
    /// <param name="subscriberContext">The subscriber's nested context.</param>
    public delegate void MessageHandledDelegate<in TMessage>(TMessage message, NestedContext subscriberContext);
}