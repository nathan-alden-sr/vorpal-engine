// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using VorpalEngine.Common.Messaging;
using VorpalEngine.Engine.Common;
using VorpalEngine.Messaging;

namespace VorpalEngine.Engine.Messaging;

/// <inheritdoc cref="IMessageSubscriber{TMessageBase,TThread}" />
public interface IMessageSubscriber : IMessageSubscriber<IMessage, EngineThread>
{
}