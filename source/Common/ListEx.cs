using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using static System.Numerics.BitOperations;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static System.Runtime.CompilerServices.Unsafe;
using static System.Runtime.InteropServices.MemoryMarshal;
using static NathanAldenSr.VorpalEngine.Common.ExceptionHelper;

namespace NathanAldenSr.VorpalEngine.Common
{
    /// <summary>A more efficient list implementation than <see cref="List{T}" />. The internal array grows by powers of two.</summary>
    /// <remarks>Inspired by ValueList from John K of the C# Discord.</remarks>
    /// <typeparam name="T">The type of item.</typeparam>
    public class ListEx<T>
    {
        private readonly ArrayPool<T>? _pool;
        private T[] _items;

        /// <summary>Initializes a new instance of the <see cref="ListEx{T}" /> class.</summary>
        /// <param name="capacity">The initial capacity of the internal array.</param>
        /// <param name="pool">An array pool used to allocate new internal arrays.</param>
        public ListEx(int capacity = 0, ArrayPool<T>? pool = null)
        {
            if (capacity < 0)
            {
                ThrowArgumentOutOfRangeException(nameof(capacity), capacity);
            }

            _pool = pool;
            _items = new T[capacity];
        }

        /// <summary>Gets or sets the item at the specified index.</summary>
        /// <param name="index">The index of the item.</param>
        /// <returns>The item at the specified index.</returns>
        public T this[int index]
        {
            get => GetRef(index);
            set => GetRef(index) = value;
        }

        /// <summary>Gets the number of items in the list.</summary>
        public int Count { get; private set; }

        /// <summary>Gets the capacity of the internal array.</summary>
        public int Capacity => _items.Length;

        /// <summary>Gets a span that spans the items in the list.</summary>
        /// <returns>A span.</returns>
        public Span<T> AsSpan() => _items.AsSpan(0, Count);

        /// <summary>
        ///     Adds the specified number of items to the list. The value of the new items is <see langword="default" /> of type
        ///     <typeparamref name="T" />.
        /// </summary>
        /// <param name="count">The number of items to add.</param>
        public void AddRange(int count)
        {
            Resize(count);
            Count += count;
        }

        /// <summary>Adds the specified items to the list.</summary>
        /// <param name="items">The items to add.</param>
        public void AddRange(ReadOnlySpan<T> items)
        {
            int length = Count;

            Resize(items.Length);
            items.CopyTo(_items.AsSpan(length));
            Count += items.Length;
        }

        /// <summary>Gets a reference to the first item in the list.</summary>
        /// <returns>A reference to the first item in the list.</returns>
        public ref T GetReference() => ref GetArrayDataReference(_items);

        /// <summary>Gets a pinnable reference to the first item in the list.</summary>
        /// <returns>A pinnable reference to the first item in the list.</returns>
        public ref T GetPinnableReference() => ref Count == 0 ? ref NullRef<T>() : ref GetArrayDataReference(_items);

        /// <summary>
        ///     Adds a single item to the list. The value of the new item is <see langword="default" /> of type
        ///     <typeparamref name="T" />.
        /// </summary>
        public void Add() => AddRange(1);

        /// <summary>Adds an item to the list.</summary>
        /// <param name="item">The item to add.</param>
        public void Add(T item)
        {
            Resize(1);
            _items[Count++] = item;
        }

        /// <summary>Adds an item to the list.</summary>
        /// <param name="item">The item to add.</param>
        public void Add(in T item)
        {
            Resize(1);
            _items[Count++] = item;
        }

        /// <summary>Removes an item at the specified index from the list.</summary>
        /// <param name="index">The index of the item to remove.</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                ThrowArgumentOutOfRangeException(nameof(index), index);
            }

            if (index < Count - 1)
            {
                // Shift items to the left by one
                // This operation is safe for overlapping ranges
                _items[(index + 1)..Count].CopyTo(_items.AsSpan(index));
            }
            if (IsReferenceOrContainsReferences<T>())
            {
                // Ensure the index that used to store the last item is defaulted to prevent reference leaks
                _items[^1] = default!;
            }

            Count--;
        }

        /// <summary>Removes all items from the list.</summary>
        public void Clear()
        {
            _items.AsSpan().Clear();
            Count = 0;
        }

        /// <summary>Resizes the capacity to match the number of items.</summary>
        public void TrimExcess()
        {
            Resize(-(Capacity - Count));
        }

        /// <summary>Gets a reference to the item at the specified index.</summary>
        /// <param name="index">The index of the item.</param>
        /// <returns>A reference to the item at the specified index.</returns>
        public ref T GetRef(int index)
        {
            if (index < 0 || index >= Count)
            {
                ThrowArgumentOutOfRangeException(nameof(index), index);
            }

            return ref Unsafe.Add(ref GetArrayDataReference(_items), index);
        }

        private void Resize(int capacityDelta)
        {
            if (capacityDelta == 0)
            {
                return;
            }

            int capacity = RoundUpPowerOfTwo(Capacity + capacityDelta);

            if (capacity == Capacity)
            {
                return;
            }

            T[] oldItems = _items;

            _items = _pool?.Rent(capacity) ?? new T[capacity];

            oldItems.AsSpan(0, Count).CopyTo(_items);

            if (IsReferenceOrContainsReferences<T>())
            {
                oldItems.AsSpan().Clear();
            }

            _pool?.Return(oldItems);
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int RoundUpPowerOfTwo(int value) => value > 0 ? 1 << (32 - LeadingZeroCount((uint)(value - 1))) : value;
    }
}