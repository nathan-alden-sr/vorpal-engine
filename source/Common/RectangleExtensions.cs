// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System;
using Silk.NET.Maths;

namespace VorpalEngine.Common;

/// <summary>Extensions for the <see cref="Rectangle{T}" /> struct.</summary>
public static class RectangleExtensions
{
    /// <summary>Determines if the rectangle is empty.</summary>
    /// <param name="rectangle">The rectangle to test.</param>
    /// <typeparam name="T">The type of each component.</typeparam>
    /// <returns><see langword="true" /> if the rectangle is empty; otherwise, <see langword="false" />.</returns>
    public static bool IsEmpty<T>(this Rectangle<T> rectangle)
        where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
        => rectangle.Origin.IsEmpty() && rectangle.Size.IsEmpty();

    /// <summary>Gets a value indicating whether the rectangle contains only finite dimensions.</summary>
    public static bool IsFinite(this Rectangle<float> rectangle)
        => rectangle.Origin.IsFinite() && rectangle.Size.IsFinite();

    /// <summary>Gets a value indicating whether the rectangle contains only finite dimensions.</summary>
    public static bool IsFinite(this Rectangle<double> rectangle)
        => rectangle.Origin.IsFinite() && rectangle.Size.IsFinite();

    /// <summary>Creates a new <see cref="Rectangle{T}" /> where the center of the current rectangle is <paramref name="center" />.</summary>
    /// <param name="rectangle">The source rectangle.</param>
    /// <param name="center">The vector to center on.</param>
    /// <returns>A new <see cref="Rectangle{T}" /> whose center is the same as <paramref name="center" />.</returns>
    public static Rectangle<T> CenterOn<T>(this Rectangle<T> rectangle, Vector2D<T> center)
        where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
        => new(
            new Vector2D<T>(
                Scalar.Subtract(center.X, Scalar.Divide(rectangle.Size.X, (T)(object)2)),
                Scalar.Subtract(center.Y, Scalar.Divide(rectangle.Size.Y, (T)(object)2))),
            rectangle.Size);

    /// <summary>
    ///     Creates a new <see cref="Rectangle{T}" /> where the center of the current rectangle is the same as the center of
    ///     <paramref name="center" />.
    /// </summary>
    /// <param name="rectangle">The source rectangle.</param>
    /// <param name="center">The rectangle to center on.</param>
    /// <returns>A new <see cref="Rectangle{T}" /> whose center is the same as <paramref name="center" />.</returns>
    public static Rectangle<T> CenterOn<T>(this Rectangle<T> rectangle, Rectangle<T> center)
        where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
        => rectangle.CenterOn(center.Center);
}