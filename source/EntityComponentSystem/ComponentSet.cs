using System;
using NathanAldenSr.VorpalEngine.Common;

namespace NathanAldenSr.VorpalEngine.EntityComponentSystem
{
    /// <summary>
    ///     A sparse set of components keyed by entity ID. Components are stored contiguously in memory for better cacheability and
    ///     faster iteration.
    /// </summary>
    /// <typeparam name="T">The type of component.</typeparam>
    public class ComponentSet<T>
    {
        private const int InvalidComponentId = -1;

        // Stores the actual components
        // Every non-null element in _sparse maps to an element in _dense
        // T component = _dense[_sparse[componentId]];
        private readonly ListEx<T> _dense;

        // Stores indexes into the dense list
        // The index of each element in _sparse maps to a component ID
        // int denseIndex = _sparse[componentId];
        private readonly ListEx<int> _sparse;

        /// <summary>Initializes a new instance of the <see cref="ComponentSet{T}" /> class.</summary>
        /// <param name="capacity">The initial capacity of the internal lists.</param>
        public ComponentSet(int capacity = 0)
        {
            _sparse = new ListEx<int>(capacity);
            _dense = new ListEx<T>(capacity);
        }

        /// <summary>Gets the number of components in the set.</summary>
        public int Count => _dense.Count;

        /// <summary>Gets the component with the specified ID.</summary>
        /// <param name="id">The ID of the component.</param>
        /// <returns>The component with the specified ID.</returns>
        public ref T this[int id] => ref GetRef(id);

        /// <summary>Gets a reference to the component with the specified ID.</summary>
        /// <param name="id">The ID of the component.</param>
        /// <returns>A reference to a component.</returns>
        public ref T GetRef(int id)
        {
            if (id < 0)
            {
                ExceptionHelper.ThrowArgumentOutOfRangeException(nameof(id), id);
            }

            int denseIndex = _sparse[id];

            if (denseIndex < 0)
            {
                ExceptionHelper.ThrowArgumentOutOfRangeException(nameof(denseIndex), denseIndex);
            }

            return ref _dense.GetRef(denseIndex);
        }

        /// <summary>Gets a span of all components.</summary>
        /// <returns>A span of all components.</returns>
        public Span<T> GetAll() => _dense.AsSpan();

        /// <summary>Adds a component to the set.</summary>
        /// <param name="id">The ID of the component.</param>
        /// <param name="component">The component to add.</param>
        public void Add(int id, T component)
        {
            if (id < 0)
            {
                ExceptionHelper.ThrowArgumentOutOfRangeException(nameof(id), id);
            }

            if (id < _sparse.Count)
            {
                int denseIndex = _sparse[id];

                if (denseIndex >= 0)
                {
                    // The dense index is valid, so set its tuple
                    _dense[denseIndex] = component;
                }
                else
                {
                    // The dense index is invalid, so add a new tuple 
                    _dense.Add(component);

                    // Track the new dense index
                    _sparse[id] = _dense.Count - 1;
                }
            }
            else
            {
                // Add the new ID and value
                _dense.Add(component);
                _sparse.AddRange(id - _sparse.Count + 1);
                _sparse[^1] = _dense.Count - 1;
            }
        }

        /// <summary>Adds a component to the set.</summary>
        /// <param name="id">The ID of the component.</param>
        /// <param name="component">The component to add.</param>
        public void Add(int id, in T component)
        {
            if (id < 0)
            {
                ExceptionHelper.ThrowArgumentOutOfRangeException(nameof(id), id);
            }

            if (id < _sparse.Count)
            {
                int denseIndex = _sparse[id];

                if (denseIndex >= 0)
                {
                    // The dense index is valid, so set its tuple
                    _dense[denseIndex] = component;
                }
                else
                {
                    // The dense index is invalid, so add a new tuple 
                    _dense.Add(component);

                    // Track the new dense index
                    _sparse[id] = _dense.Count - 1;
                }
            }
            else
            {
                // Add the new ID and value
                _dense.Add(component);
                _sparse.AddRange(id - _sparse.Count + 1);
                _sparse[^1] = _dense.Count - 1;
            }
        }

        /// <summary>Removes a component from the set.</summary>
        /// <param name="id">The ID of the component to remove.</param>
        /// <returns><see langword="true" /> if the component was removed; otherwise, <see langword="false" />.</returns>
        public bool Remove(int id)
        {
            if (id < 0)
            {
                ExceptionHelper.ThrowArgumentOutOfRangeException(nameof(id), id);
            }

            if (id >= _sparse.Count)
            {
                return false;
            }

            int denseIndex = _sparse[id];

            if (denseIndex < 0)
            {
                return false;
            }

            // The dense index for the supplied ID is no longer valid
            _sparse[id] = InvalidComponentId;

            // Remove the dense tuple
            _dense.RemoveAt(denseIndex);

            return true;
        }

        /// <summary>Removes all components from the set.</summary>
        public void Clear()
        {
            _sparse.Clear();
            _dense.Clear();
        }

        /// <summary>Resizes the capacity to match the number of components.</summary>
        public void TrimExcess()
        {
            _sparse.TrimExcess();
            _dense.TrimExcess();
        }

        /// <summary>Determines if the set contains a component.</summary>
        /// <param name="id">The ID of the component to check.</param>
        /// <returns><see langword="true" /> if the component exists in the set; otherwise, <see langword="false" />.</returns>
        public bool Contains(int id)
        {
            if (id < 0)
            {
                ExceptionHelper.ThrowArgumentOutOfRangeException(nameof(id), id);
            }

            return id < _sparse.Count && _sparse[id] != InvalidComponentId;
        }
    }
}