using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Threading.Interlocked;
using static NathanAldenSr.VorpalEngine.Common.AssertHelper;
using static NathanAldenSr.VorpalEngine.Common.ExceptionHelper;

namespace NathanAldenSr.VorpalEngine.Common
{
    /// <summary>Defines an object's state.</summary>
    /// <remarks>Inspired by <a href="https://github.com/terrafx">TerraFX</a>.</remarks>
    public struct State
    {
        /// <summary>The object is uninitialized.</summary>
        public const int Uninitialized = 0;

        /// <summary>The object is initialized.</summary>
        public const int Initialized = 1;

        /// <summary>The object is disposing.</summary>
        public const int Disposing = Disposed - 1;

        /// <summary>The object is disposed.</summary>
        public const int Disposed = int.MaxValue;

        private volatile int _value;

        /// <summary>Gets a value indicating whether the object is disposing or disposed.</summary>
        public bool IsDisposingOrDisposed => _value >= Disposing;

        /// <summary>Gets a value indicating whether the object is neither disposing nor disposed.</summary>
        public bool IsNeitherDisposingNorDisposed => _value < Disposing;

        /// <summary>Implicitly converts the <see cref="State" /> to <see cref="int" />.</summary>
        /// <param name="state">The <see cref="State" /> to convert.</param>
        public static implicit operator int(State state) => state._value;

        /// <summary>Asserts that the object is disposing.</summary>
        [Conditional("DEBUG")]
        public void AssertDisposing() =>
            Assert(_value == Disposing, new AssertMessageBuilder().Message("The object is not being disposed.").Parameter(nameof(State), _value));

        /// <summary>Asserts that the object is neither disposing nor disposed.</summary>
        [Conditional("DEBUG")]
        public void AssertNeitherDisposingNorDisposed() =>
            Assert(
                IsNeitherDisposingNorDisposed,
                new AssertMessageBuilder().Message("The object is neither disposing nor disposed.").Parameter(nameof(State), _value));

        /// <summary>Begins a dispose operation.</summary>
        /// <returns>The state prior to beginning the dispose operation.</returns>
        public int BeginDispose() => Transition(Disposing);

        /// <summary>Ends a dispose operation.</summary>
        public void EndDispose()
        {
            int previousState = Transition(Disposed);

            Assert(
                previousState == Disposing,
                new AssertMessageBuilder().Message("The object did not transition from a disposing state.").Parameter(nameof(State), _value));
        }

        /// <summary>Throws an <see cref="ObjectDisposedException" /> if the object is being disposed or is already disposed.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ThrowIfDisposingOrDisposed()
        {
            if (IsDisposingOrDisposed)
            {
                ThrowObjectDisposedException(nameof(State));
            }
        }

        /// <summary>Transititions the object to a new state.</summary>
        /// <param name="to">The state to transition to.</param>
        /// <returns>The previous state of the object.</returns>
        public int Transition(int to) => Exchange(ref _value, to);

        /// <summary>Transititions the object to a new state.</summary>
        /// <param name="from">The state to transition from.</param>
        /// <param name="to">The state to transition to.</param>
        public void Transition(int from, int to)
        {
            int state = TryTransition(from, to);

            if (state != from)
            {
                ThrowInvalidOperationException($"A transition from {from} to {to} failed.");
            }
        }

        /// <summary>Attempts to transition the object to a new state.</summary>
        /// <param name="from">The state to transition from.</param>
        /// <param name="to">The state to transition to.</param>
        /// <returns>The state of the object prior to the attempted transition.</returns>
        public int TryTransition(int from, int to) => CompareExchange(ref _value, to, from);
    }
}