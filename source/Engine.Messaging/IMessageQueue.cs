using NathanAldenSr.VorpalEngine.Common;
using NathanAldenSr.VorpalEngine.Engine.Common;
using NathanAldenSr.VorpalEngine.Messaging;

namespace NathanAldenSr.VorpalEngine.Engine.Messaging
{
    /// <inheritdoc cref="IConcurrentMessageQueue{TMessageBase,TThread}" />
    public interface IMessageQueue : IConcurrentMessageQueue<IMessage, EngineThread>, IMessagePublisher, IMessageSubscriber
    {
    }
}