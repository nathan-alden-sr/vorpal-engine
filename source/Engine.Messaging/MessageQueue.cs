using NathanAldenSr.VorpalEngine.Common;
using NathanAldenSr.VorpalEngine.Engine.Common;
using NathanAldenSr.VorpalEngine.Messaging;

namespace NathanAldenSr.VorpalEngine.Engine.Messaging
{
    /// <inheritdoc cref="ConcurrentMessageQueue{TMessageBase,TThread}" />
    public class MessageQueue : ConcurrentMessageQueue<IMessage, EngineThread>, IMessageQueue
    {
    }
}