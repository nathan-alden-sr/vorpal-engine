// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using Silk.NET.Maths;

namespace VorpalEngine.Common;

/// <summary>Helper methods for <see cref="Rectangle{T}" /> objects.</summary>
public static class Rectangle
{
    /// <summary>Creates an empty <see cref="Rectangle{T}" />. <see cref="Scalar{T}.NaN" /> is used for all components.</summary>
    /// <typeparam name="T">The type of each component.</typeparam>
    /// <returns>The new <see cref="Rectangle{T}" /> object.</returns>
    public static Rectangle<T> Empty<T>()
        where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
        => new(Vector2D.Empty<T>(), Vector2D.Empty<T>());

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

    /// <summary>Creates a <see cref="Rectangle{T}" /> object.</summary>
    /// <param name="left">The X component of the rectangle's origin.</param>
    /// <param name="top">The Y component of the rectangle's origin.</param>
    /// <param name="right">The X component of the rectangle's size.</param>
    /// <param name="bottom">The Y component of the rectangle's size.</param>
    /// <typeparam name="T">The type of each component.</typeparam>
    /// <returns>The new <see cref="Rectangle{T}" /> object.</returns>
    public static Rectangle<T> FromLeftTopRightBottom<T>(T left, T top, T right, T bottom)
        where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
        => new(new Vector2D<T>(left, top), new Vector2D<T>(Scalar.Subtract(right, left), Scalar.Subtract(bottom, top)));
}