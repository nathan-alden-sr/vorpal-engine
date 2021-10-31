// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Diagnostics;

namespace VorpalEngine.Common;

/// <summary>Tracks a counter and executes delegates when the counter changes.</summary>
[DebuggerDisplay($"{{{nameof(DebuggerDisplay)},nq}}")]
public sealed class Counter : IDisposable
{
    private readonly Action<uint>? _decrementedDelegate;
    private readonly bool _decrementOnDispose;
    private readonly Action<uint>? _incrementedDelegate;
    private readonly Action? _nonZeroedDelegate;
    private readonly Action? _zeroedDelegate;
    private uint _counter;

    /// <summary>Initializes a new instance of the <see cref="Counter" /> class.</summary>
    /// <param name="zeroedDelegate">A delegate invoked when the counter is decremented to zero.</param>
    /// <param name="nonZeroedDelegate">A delegate invoked when the counter is incremented to one.</param>
    /// <param name="incrementedDelegate">A delegate invoked when the counter is incremented.</param>
    /// <param name="decrementedDelegate">A delegate invoked when the counter is decremented.</param>
    /// <param name="decrementOnDispose">A value indicating whether to decrement the counter when the counter is disposed.</param>
    public Counter(
        Action? zeroedDelegate = null,
        Action? nonZeroedDelegate = null,
        Action<uint>? incrementedDelegate = null,
        Action<uint>? decrementedDelegate = null,
        bool decrementOnDispose = true)
    {
        _zeroedDelegate = zeroedDelegate;
        _nonZeroedDelegate = nonZeroedDelegate;
        _incrementedDelegate = incrementedDelegate;
        _decrementedDelegate = decrementedDelegate;
        _decrementOnDispose = decrementOnDispose;
    }

    /// <summary>Gets a value indicating whether the counter is zero.</summary>
    public bool IsZero => _counter == 0;

    /// <summary>Gets a value indicating whether the counter is one.</summary>
    public bool IsOne => _counter == 1;

    /// <summary>Gets a value indicating whether the counter is non-zero.</summary>
    public bool IsNonZero => _counter > 0;

    private string DebuggerDisplay => $"Counter = {_counter}";

    /// <summary>Decrements the counter if the counter is configured to decrement on dispose; otherwise, does nothing.</summary>
    public void Dispose()
    {
        if (_decrementOnDispose)
        {
            Decrement();
        }
    }

    /// <summary>Increments the counter.</summary>
    /// <returns>This object.</returns>
    public Counter Increment()
    {
        _counter++;
        _incrementedDelegate?.Invoke(_counter);

        if (IsOne)
        {
            _nonZeroedDelegate?.Invoke();
        }

        return this;
    }

    /// <summary>Decrements the counter if it is non-zero; otherwise, a no-op.</summary>
    /// <returns>This object.</returns>
    public Counter Decrement()
    {
        // ReSharper disable once InvertIf
        if (IsNonZero)
        {
            _counter--;
            _decrementedDelegate?.Invoke(_counter);
            if (IsZero)
            {
                _zeroedDelegate?.Invoke();
            }
        }

        return this;
    }
}