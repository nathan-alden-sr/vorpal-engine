// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using Silk.NET.Maths;

namespace VorpalEngine.Common;

/// <summary>Extensions for the <see cref="Vector2D{T}" /> struct.</summary>
public static class Vector2DExtensions
{
    /// <summary>Determines if the vector's components are <see cref="Scalar{T}.NaN" />.</summary>
    /// <param name="vector">The vector to test.</param>
    /// <typeparam name="T">The type of each component.</typeparam>
    /// <returns>
    ///     <see langword="true" /> if the vector's components are equal to <see cref="Scalar{T}.NaN" />; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool IsNaN<T>(this Vector2D<T> vector)
        where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
        => Scalar.IsNaN(vector.X) && Scalar.IsNaN(vector.Y);

    /// <summary>Determines if the vector's components are finite.</summary>
    /// <param name="vector">The vector to test.</param>
    /// <typeparam name="T">The type of each component.</typeparam>
    /// <returns><see langword="true" /> if the vector is finite; otherwise, <see langword="false" />.</returns>
    public static bool IsFinite<T>(this Vector2D<T> vector)
        where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
        => Scalar.IsFinite(vector.X) && Scalar.IsFinite(vector.Y);

    /// <summary>
    ///     Determines if the vector's components are either <see cref="Scalar{T}.PositiveInfinity" /> or
    ///     <see cref="Scalar{T}.NegativeInfinity" />.
    /// </summary>
    /// <param name="vector">The vector to test.</param>
    /// <typeparam name="T">The type of each component.</typeparam>
    /// <returns><see langword="true" /> if the vector is finite; otherwise, <see langword="false" />.</returns>
    public static bool IsInfinity<T>(this Vector2D<T> vector)
        where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
        => Scalar.IsInfinity(vector.X) && Scalar.IsInfinity(vector.Y);

    /// <summary>Determines if the vector's components are <see cref="Scalar{T}.PositiveInfinity" />.</summary>
    /// <param name="vector">The vector to test.</param>
    /// <typeparam name="T">The type of each component.</typeparam>
    /// <returns>
    ///     <see langword="true" /> if the vector's components are equal to <see cref="Scalar{T}.PositiveInfinity" />; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool IsPositiveInfinity<T>(this Vector2D<T> vector)
        where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
        => Scalar.IsPositiveInfinity(vector.X) && Scalar.IsPositiveInfinity(vector.Y);

    /// <summary>Determines if the vector's components are <see cref="Scalar{T}.NegativeInfinity" />.</summary>
    /// <param name="vector">The vector to test.</param>
    /// <typeparam name="T">The type of each component.</typeparam>
    /// <returns>
    ///     <see langword="true" /> if the vector's components are equal to <see cref="Scalar{T}.NegativeInfinity" />; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool IsNegativeInfinity<T>(this Vector2D<T> vector)
        where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
        => Scalar.IsNegativeInfinity(vector.X) && Scalar.IsNegativeInfinity(vector.Y);
}
