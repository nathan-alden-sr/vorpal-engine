using NathanAldenSr.VorpalEngine.Common;
using NathanAldenSr.VorpalEngine.Engine.Common;
using NathanAldenSr.VorpalEngine.Messaging;

namespace NathanAldenSr.VorpalEngine.Engine.Messaging
{
    /// <inheritdoc cref="IMessageSubscriber{TMessageBase,TThread}" />
    public interface IMessageSubscriber : IMessageSubscriber<IMessage, EngineThread>
    {
    }
}