// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using TerraFX.Collections;

namespace VorpalEngine.EntityComponentSystem;

/// <summary>
///     A sparse set of components keyed by entity ID. Components are stored contiguously in memory for better cacheability and
///     faster iteration.
/// </summary>
/// <typeparam name="T">The type of component.</typeparam>
public sealed class ComponentSet<T>
    where T : unmanaged
{
    private const int InvalidComponentId = -1;

    // Stores the actual components
    // Every non-null element in _sparse maps to an element in _dense
    // T component = _dense[_sparse[componentId]];
    private ValueList<T> _dense;

    // Stores indexes into the dense list
    // The index of each element in _sparse maps to a component ID
    // int denseIndex = _sparse[componentId];
    private ValueList<int> _sparse;

    /// <summary>Initializes a new instance of the <see cref="ComponentSet{T}" /> class.</summary>
    /// <param name="capacity">The initial capacity of the internal lists.</param>
    public ComponentSet(int capacity = 0)
    {
        _sparse = new ValueList<int>(capacity);
        _dense = new ValueList<T>(capacity);
    }

    /// <summary>Gets the number of components in the set.</summary>
    public int Count => _dense.Count;

    /// <summary>Gets the component with the specified ID.</summary>
    /// <param name="id">The ID of the component.</param>
    /// <returns>The component with the specified ID.</returns>
    public T this[int id]
    {
        get
        {
            if (id < 0)
            {
                ThrowArgumentOutOfRangeException(nameof(id), id, "Invalid ID.");
            }

            var denseIndex = _sparse[id];

            if (denseIndex < 0)
            {
                ThrowArgumentOutOfRangeException(nameof(denseIndex), denseIndex, "Invalid dense index.");
            }

            return _dense[denseIndex];
        }
    }

    /// <summary>Adds a component to the set.</summary>
    /// <param name="id">The ID of the component.</param>
    /// <param name="component">The component to add.</param>
    public void Add(int id, T component)
    {
        if (id < 0)
        {
            ThrowArgumentOutOfRangeException(nameof(id), id, "Invalid ID.");
        }

        if (id < _sparse.Count)
        {
            var denseIndex = _sparse[id];

            if (denseIndex >= 0)
            {
                // The dense index is valid, so set its corresponding component
                _dense[denseIndex] = component;
            }
            else
            {
                // The dense index is invalid, so add the component 
                _dense.Add(component);

                // Track the new dense index
                _sparse[id] = _dense.Count - 1;
            }
        }
        else
        {
            // Add the new ID and component
            _dense.Add(component);
            _sparse.Add(_dense.Count - 1);
        }
    }

    /// <summary>Adds a component to the set.</summary>
    /// <param name="id">The ID of the component.</param>
    /// <param name="component">The component to add.</param>
    public void Add(int id, in T component)
    {
        if (id < 0)
        {
            ThrowArgumentOutOfRangeException(nameof(id), id, "Invalid ID.");
        }

        if (id < _sparse.Count)
        {
            var denseIndex = _sparse[id];

            if (denseIndex >= 0)
            {
                // The dense index is valid, so set its corresponding component
                _dense[denseIndex] = component;
            }
            else
            {
                // The dense index is invalid, so add the component 
                _dense.Add(component);

                // Track the new dense index
                _sparse[id] = _dense.Count - 1;
            }
        }
        else
        {
            // Add the new ID and component
            _dense.Add(component);
            _sparse.Add(_dense.Count - 1);
        }
    }

    /// <summary>Removes a component from the set.</summary>
    /// <param name="id">The ID of the component to remove.</param>
    /// <returns><see langword="true" /> if the component was removed; otherwise, <see langword="false" />.</returns>
    public bool Remove(int id)
    {
        if (id < 0)
        {
            ThrowArgumentOutOfRangeException(nameof(id), id, "Invalid ID.");
        }

        if (id >= _sparse.Count)
        {
            return false;
        }

        var denseIndex = _sparse[id];

        if (denseIndex < 0)
        {
            return false;
        }

        // The dense index for the supplied ID is no longer valid
        _sparse[id] = InvalidComponentId;

        // Remove the component
        _dense.RemoveAt(denseIndex);

        return true;
    }

    /// <summary>Gets an enumerable all components.</summary>
    /// <returns>An enumerable of all components.</returns>
    public IEnumerable<T> GetAll()
        => _dense;

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
    /// <param name="id">The ID of the component to test.</param>
    /// <returns><see langword="true" /> if the component exists in the set; otherwise, <see langword="false" />.</returns>
    public bool Contains(int id)
    {
        if (id < 0)
        {
            ThrowArgumentOutOfRangeException(nameof(id), id, "Invalid ID.");
        }

        return id < _sparse.Count && _sparse[id] != InvalidComponentId;
    }
}
