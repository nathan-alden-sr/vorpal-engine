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
        private readonly ListEx<Component<T>> _dense;
        private readonly ListEx<int?> _sparse;

        /// <summary>Initializes a new instance of the <see cref="ComponentSet{T}" /> class.</summary>
        /// <param name="capacity">The initial capacity of the internal lists.</param>
        public ComponentSet(int capacity = 0)
        {
            _sparse = new ListEx<int?>(capacity);
            _dense = new ListEx<Component<T>>(capacity);
        }

        /// <summary>Gets the number of components in the set.</summary>
        public int Count => _dense.Count;

        /// <summary>Gets the component with the specified ID.</summary>
        /// <param name="id">The ID of the component.</param>
        /// <returns>The component with the specified ID.</returns>
        public ref Component<T> this[int id] => ref Get(id);

        /// <summary>Gets a reference to the component with the specified ID.</summary>
        /// <param name="id">The ID of the component.</param>
        /// <returns>A reference to a component.</returns>
        public ref Component<T> Get(int id)
        {
            int? denseIndex = _sparse[id];

            if (denseIndex is null)
            {
                ExceptionHelper.ThrowArgumentException("Invalid ID.", nameof(id));
            }

            return ref _dense.RefIndex(denseIndex.Value);
        }

        /// <summary>Gets a span of all components.</summary>
        /// <returns>A span of all components.</returns>
        public ReadOnlySpan<Component<T>> GetAll() => _dense.AsSpan();

        /// <summary>Adds a component to the set.</summary>
        /// <param name="component">The component to add.</param>
        public void Add(Component<T> component)
        {
            if (component.Id < 0)
            {
                ExceptionHelper.ThrowArgumentOutOfRangeException(nameof(component.Id), component.Id);
            }

            if (component.Id < _sparse.Count)
            {
                // Dense indexes may be invalid
                int? denseIndex = _sparse[component.Id];

                if (denseIndex is not null)
                {
                    // The dense index is valid, so set its tuple
                    _dense[denseIndex.Value] = component;
                }
                else
                {
                    // The dense index is invalid, so add a new tuple 
                    _dense.Add(component);

                    // Track the new dense index
                    _sparse[component.Id] = _dense.Count - 1;
                }
            }
            else
            {
                // Add the new ID and value
                _dense.Add(component);
                _sparse.AddRange(component.Id - _sparse.Count + 1);
                _sparse[^1] = _dense.Count - 1;
            }
        }

        /// <summary>Adds a component to the set.</summary>
        /// <param name="component">The component to add.</param>
        public void Add(in Component<T> component)
        {
            if (component.Id < 0)
            {
                ExceptionHelper.ThrowArgumentOutOfRangeException(nameof(component.Id), component.Id);
            }

            if (component.Id < _sparse.Count)
            {
                // Dense indexes may be invalid
                int? denseIndex = _sparse[component.Id];

                if (denseIndex is not null)
                {
                    // The dense index is valid, so set its tuple
                    _dense[denseIndex.Value] = component;
                }
                else
                {
                    // The dense index is invalid, so add a new tuple 
                    _dense.Add(component);

                    // Track the new dense index
                    _sparse[component.Id] = _dense.Count - 1;
                }
            }
            else
            {
                // Add the new ID and value
                _dense.Add(component);
                _sparse.AddRange(component.Id - _sparse.Count + 1);
                _sparse[^1] = _dense.Count - 1;
            }
        }

        /// <summary>Adds a component to the set.</summary>
        /// <param name="id">The ID of the component.</param>
        /// <param name="value">The value of the component.</param>
        public void Add(int id, T value)
        {
            Add(new Component<T>(id, value));
        }

        /// <summary>Adds a component to the set.</summary>
        /// <param name="id">The ID of the component.</param>
        /// <param name="value">The value of the component.</param>
        public void Add(int id, in T value)
        {
            Add(new Component<T>(id, value));
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

            int? denseIndex = _sparse[id];

            if (denseIndex is null)
            {
                return false;
            }

            // The dense index for the supplied ID is no longer valid
            _sparse[id] = null;

            // Remove the dense tuple
            _dense.RemoveAt(denseIndex.Value);

            return true;
        }

        /// <summary>Removes a component from the set.</summary>
        /// <param name="component">The component to remove.</param>
        /// <returns><see langword="true" /> if the component was removed; otherwise, <see langword="false" />.</returns>
        public bool Remove(Component<T> component) => Remove(component.Id);

        /// <summary>Removes a component from the set.</summary>
        /// <param name="component">The component to remove.</param>
        /// <returns><see langword="true" /> if the component was removed; otherwise, <see langword="false" />.</returns>
        public bool Remove(in Component<T> component) => Remove(component.Id);

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

            return id < _sparse.Count && _sparse[id] is not null;
        }

        /// <summary>Determines if the set contains a component.</summary>
        /// <param name="component">The component to check.</param>
        /// <returns><see langword="true" /> if the component exists in the set; otherwise, <see langword="false" />.</returns>
        public bool Contains(Component<T> component) => Contains(component.Id);

        /// <summary>Determines if the set contains a component.</summary>
        /// <param name="component">The component to check.</param>
        /// <returns><see langword="true" /> if the component exists in the set; otherwise, <see langword="false" />.</returns>
        public bool Contains(in Component<T> component) => Contains(component.Id);
    }
}