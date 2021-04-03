using System;
using System.Runtime.CompilerServices;
using System.Threading;
using static System.Runtime.InteropServices.MemoryMarshal;
using static NathanAldenSr.VorpalEngine.Common.AssertHelper;
using static NathanAldenSr.VorpalEngine.Common.State;

namespace NathanAldenSr.VorpalEngine.Common
{
    /// <summary>Provides support for lazily initializing values.</summary>
    /// <typeparam name="T">The type of the value being lazily initialized.</typeparam>
    /// <remarks>Inspired by <a href="https://github.com/terrafx">TerraFX</a>.</remarks>
    public struct ValueLazy<T> : IDisposable
    {
        private const int Creating = Initialized + 1;
        private const int Created = Creating + 1;
        private Func<T>? _valueFactory;
        private T _value;
        private State _state;

        /// <summary>Initializes a new instance of the <see cref="ValueLazy{T}" /> struct.</summary>
        /// <param name="valueFactoryDelegate">A delegate that creates the value when invoked.</param>
        public ValueLazy(Func<T> valueFactoryDelegate)
        {
            Unsafe.SkipInit(out this);
            Reset(valueFactoryDelegate);
        }

        /// <summary>Gets a value indicating whether the value has been created.</summary>
        public bool IsCreated => _state == Created;

        /// <summary>Gets a reference to the underyling value for the object.</summary>
        /// <remarks>This property is unsafe as it returns a reference to a struct field.</remarks>
        public ref T RefValue
        {
            get
            {
                _state.AssertNeitherDisposingNorDisposed();

                if (!IsCreated)
                {
                    CreateValue();
                }

                return ref GetReference(CreateSpan(ref _value, 1));
            }
        }

        /// <summary>Gets the value for the object.</summary>
        public T Value
        {
            get
            {
                _state.AssertNeitherDisposingNorDisposed();

                if (!IsCreated)
                {
                    CreateValue();
                }

                return _value;
            }
        }

        /// <summary>Disposes the value if it was created and if it implements <see cref="IDisposable" />.</summary>
        public void Dispose()
        {
            if (_state.BeginDispose() == Created && _value is IDisposable disposable)
            {
                disposable.Dispose();
            }

            _state.EndDispose();
        }

        /// <summary>Uses the supplied delegate to dispose the value if it was created.</summary>
        /// <param name="disposeDelegate">A delegate that will be invoked if the value was created. The delegate should dispose the value.</param>
        public void Dispose(Action<T> disposeDelegate)
        {
            if (_state.BeginDispose() == Created)
            {
                disposeDelegate(_value);
            }

            _state.EndDispose();
        }

        /// <summary>Resets the instance so the value can be recreated.</summary>
        /// <param name="valueFactoryDelegate">A delegate that creates the value when invoked.</param>
        public void Reset(Func<T> valueFactoryDelegate)
        {
            _state.ThrowIfDisposingOrDisposed();

            _valueFactory = valueFactoryDelegate;
            _state.Transition(Initialized);
        }

        private void CreateValue()
        {
            _state.ThrowIfDisposingOrDisposed();

            var spinWait = new SpinWait();

            while (!IsCreated)
            {
                int previousState = _state.TryTransition(Initialized, Creating);

                if (previousState == Initialized)
                {
                    AssertNotNull(_valueFactory, nameof(_valueFactory));

                    _value = _valueFactory!();
                    _state.Transition(Creating, Created);

                    _valueFactory = null;
                }
                else
                {
                    spinWait.SpinOnce();
                }
            }
        }
    }
}