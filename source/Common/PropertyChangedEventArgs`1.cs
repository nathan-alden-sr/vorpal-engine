using System;

namespace NathanAldenSr.VorpalEngine.Common
{
    /// <summary>Provides data for a property changed event.</summary>
    /// <typeparam name="T">The type of the property that was changed.</typeparam>
    public class PropertyChangedEventArgs<T> : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="PropertyChangedEventArgs{T}" /> class.</summary>
        /// <param name="oldValue">The old value of the property that was changed.</param>
        /// <param name="newValue">The new value of the property that was changed.</param>
        public PropertyChangedEventArgs(T oldValue, T newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

        /// <summary>Gets the previous value of the property that was changed.</summary>
        public T OldValue { get; }

        /// <summary>Gets the current value of the property that was changed.</summary>
        public T NewValue { get; }
    }
}