using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace NathanAldenSr.VorpalEngine.Configuration
{
    /// <summary>
    ///     Wraps a list property in a JSON POCO so the underlying property value is serialized to <see langword="null" /> when the list
    ///     is empty.
    /// </summary>
    /// <typeparam name="T">The type of object stored by the list.</typeparam>
    public class ListWrapper<T> : IList<T>
    {
        private readonly Func<IList<T>?> _getPropertyDelegate;
        private readonly Action<IList<T>?> _setPropertyDelegate;

        /// <summary>Initializes a new instance of the <see cref="ListWrapper{T}" /> class.</summary>
        /// <param name="getPropertyDelegate">A delegate to call when the value of the underlying list property is needed.</param>
        /// <param name="setPropertyDelegate">A delegate to call when the value of the underlying list property needs to be set.</param>
        public ListWrapper(Func<IList<T>?> getPropertyDelegate, Action<IList<T>?> setPropertyDelegate)
        {
            _getPropertyDelegate = getPropertyDelegate;
            _setPropertyDelegate = setPropertyDelegate;
        }

        private IList<T> MutableSourceList
        {
            get
            {
                IList<T>? sourceList = _getPropertyDelegate();

                if (sourceList is null)
                {
                    _setPropertyDelegate(sourceList = new List<T>());
                }

                return sourceList;
            }
        }

        private IList<T> ReadOnlySourceList => _getPropertyDelegate() ?? ImmutableList<T>.Empty;

        /// <inheritdoc />
        public T this[int index]
        {
            get => ReadOnlySourceList[index];
            set => MutableSourceList[index] = value;
        }

        /// <inheritdoc />
        public int Count => ReadOnlySourceList.Count;

        /// <inheritdoc />
        public bool IsReadOnly => ReadOnlySourceList.IsReadOnly;

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator() => ReadOnlySourceList.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        public void Add(T item) => MutableSourceList.Add(item);

        /// <inheritdoc />
        public void Clear()
        {
            _setPropertyDelegate(null);
        }

        /// <inheritdoc />
        public bool Contains(T item) => ReadOnlySourceList.Contains(item);

        /// <inheritdoc />
        public void CopyTo(T[] array, int arrayIndex) => ReadOnlySourceList.CopyTo(array, arrayIndex);

        /// <inheritdoc />
        public bool Remove(T item)
        {
            bool result = MutableSourceList.Remove(item);

            if (Count == 0)
            {
                _setPropertyDelegate(null);
            }

            return result;
        }

        /// <inheritdoc />
        public int IndexOf(T item) => ReadOnlySourceList.IndexOf(item);

        /// <inheritdoc />
        public void Insert(int index, T item) => MutableSourceList.Insert(index, item);

        /// <inheritdoc />
        public void RemoveAt(int index)
        {
            MutableSourceList.RemoveAt(index);

            if (Count == 0)
            {
                _setPropertyDelegate(null);
            }
        }
    }
}