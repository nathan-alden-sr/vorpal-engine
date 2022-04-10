// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using VorpalEngine.Common.Messaging;
using VorpalEngine.Messaging;

namespace VorpalEngine.Engine.Messaging;

/// <inheritdoc cref="IMessagePublisher{TMessageBase}" />
public interface IMessagePublisher : IMessagePublisher<IMessage>
{
}
