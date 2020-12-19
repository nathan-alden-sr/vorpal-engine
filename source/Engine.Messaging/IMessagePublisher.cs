using NathanAldenSr.VorpalEngine.Common;
using NathanAldenSr.VorpalEngine.Messaging;

namespace NathanAldenSr.VorpalEngine.Engine.Messaging
{
    /// <inheritdoc cref="IMessagePublisher{TMessageBase}" />
    public interface IMessagePublisher : IMessagePublisher<IMessage>
    {
    }
}