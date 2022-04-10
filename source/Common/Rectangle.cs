// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using Silk.NET.Maths;

namespace VorpalEngine.Common;

/// <summary>Helper methods for <see cref="Rectangle{T}" /> objects.</summary>
public static class Rectangle
{
    /// <summary>Creates a <see cref="Rectangle{T}" /> object with <see cref="Scalar{T}.NaN" /> used for all components.</summary>
    /// <typeparam name="T">The type of each component.</typeparam>
    /// <returns>The new <see cref="Rectangle{T}" /> object.</returns>
    public static Rectangle<T> NaN<T>()
        where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
        => new(Vector2D.NaN<T>(), Vector2D.NaN<T>());

    /// <summary>Creates a <see cref="Rectangle{T}" /> object.</summary>
    /// <param name="originX">The X component of the rectangle's origin.</param>
    /// <param name="originY">The Y component of the rectangle's origin.</param>
    /// <param name="sizeX">The X component of the rectangle's size.</param>
    /// <param name="sizeY">The Y component of the rectangle's size.</param>
    /// <typeparam name="T">The type of each component.</typeparam>
    /// <returns>The new <see cref="Rectangle{T}" /> object.</returns>
    public static Rectangle<T> FromOriginSizeComponents<T>(T originX, T originY, T sizeX, T sizeY)
        where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
        => new(new Vector2D<T>(originX, originY), new Vector2D<T>(sizeX, sizeY));
}
