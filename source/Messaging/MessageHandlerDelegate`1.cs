// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

namespace VorpalEngine.Messaging;

/// <summary>A delegate that handles messages of type <typeparamref name="TMessage" />.</summary>
/// <typeparam name="TMessage">The type of message to be handled.</typeparam>
/// <param name="message">The message being handled.</param>
public delegate void MessageHandlerDelegate<in TMessage>(TMessage message);