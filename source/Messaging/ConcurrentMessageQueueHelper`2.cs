// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System;
using System.Collections.Generic;
using TerraFX.Threading;
using VorpalEngine.Common;
using static TerraFX.Utilities.AssertionUtilities;
using static TerraFX.Utilities.ExceptionUtilities;

namespace VorpalEngine.Messaging;

/// <summary>
///     A helpful wrapper that simplifies publishing and subscribing with an
///     <see cref="IConcurrentMessageQueue{TMessageBase,TThread}" />.
/// </summary>
/// <typeparam name="TMessageBase">The base type for all messages.</typeparam>
/// <typeparam name="TThread">The type representing logical threads that handle messages.</typeparam>
public sealed class ConcurrentMessageQueueHelper<TMessageBase, TThread> : IDisposable
    where TThread : struct, Enum
{
    private readonly IConcurrentMessageQueue<TMessageBase, TThread> _concurrentMessageQueue;
    private readonly NestedContext _context;
    private readonly HashSet<ISubscriptionReceipt> _subscriptionReceipts = new();
    private VolatileState _state;
    private TThread? _thread;

    /// <summary>Initializes a new instance of the <see cref="ConcurrentMessageQueueHelper{TMessageBase,TThread}" /> class.</summary>
    /// <param name="concurrentMessageQueue">An <see cref="IConcurrentMessageQueue{TMessageBase,TThread}" /> implementation.</param>
    /// <param name="context">A nested context.</param>
    public ConcurrentMessageQueueHelper(IConcurrentMessageQueue<TMessageBase, TThread> concurrentMessageQueue, NestedContext context = default)
    {
        ThrowIfNull(concurrentMessageQueue, nameof(concurrentMessageQueue));

        _concurrentMessageQueue = concurrentMessageQueue;
        _context = context;

        _state.Transition(VolatileState.Initialized);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        if (_state.BeginDispose() < VolatileState.Disposing)
        {
            _concurrentMessageQueue.Unsubscribe(_subscriptionReceipts);
            _subscriptionReceipts.Clear();
        }

        _state.EndDispose();
    }

    /// <summary>Subsequent subscriptions will be associated with the logical thread <paramref name="thread" />.</summary>
    /// <param name="thread">A logical thread that the subscription will be assoociated with.</param>
    /// <returns>This object.</returns>
    public ConcurrentMessageQueueHelper<TMessageBase, TThread> WithThread(TThread thread)
    {
        AssertNotDisposedOrDisposing(_state);

        _thread = thread;

        return this;
    }

    /// <summary>Publishes a message.</summary>
    /// <typeparam name="TMessage">The type of message to publish.</typeparam>
    /// <returns>This object.</returns>
    public ConcurrentMessageQueueHelper<TMessageBase, TThread> Publish<TMessage>(TMessage message)
        where TMessage : TMessageBase
    {
        AssertNotDisposedOrDisposing(_state);

        _concurrentMessageQueue.Publish(message, _context);

        return this;
    }

    /// <summary>Publishes a message.</summary>
    /// <typeparam name="T">The type of message to publish.</typeparam>
    /// <returns>This object.</returns>
    public ConcurrentMessageQueueHelper<TMessageBase, TThread> Publish<T>()
        where T : TMessageBase, new()
    {
        AssertNotDisposedOrDisposing(_state);

        _concurrentMessageQueue.Publish<T>(_context);

        return this;
    }

    /// <summary>Subscribes to a message.</summary>
    /// <typeparam name="TMessage">The type of message to subscribe to.</typeparam>
    /// <param name="handlerDelegate">A delegate to invoke when handling messages.</param>
    /// <returns>This object.</returns>
    public ConcurrentMessageQueueHelper<TMessageBase, TThread> Subscribe<TMessage>(MessageHandlerDelegate<TMessage> handlerDelegate)
        where TMessage : TMessageBase
    {
        ThrowIfNull(handlerDelegate, nameof(handlerDelegate));

        AssertNotDisposedOrDisposing(_state);

        if (_thread is null)
        {
            ThrowInvalidOperationException("No thread was specified.");
        }

        ISubscriptionReceipt subscriptionReceipt = _concurrentMessageQueue.Subscribe(handlerDelegate, _thread.Value, _context);

        _subscriptionReceipts.Add(subscriptionReceipt);

        return this;
    }

    /// <inheritdoc cref="IConcurrentMessageQueue{TMessageBase,TThread}.DispatchQueued" />
    public void DispatchQueued(TThread thread)
    {
        AssertNotDisposedOrDisposing(_state);

        _concurrentMessageQueue.DispatchQueued(thread);
    }
}