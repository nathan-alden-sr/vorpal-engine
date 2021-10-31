// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using Silk.NET.Maths;

namespace VorpalEngine.Common;

/// <summary>Extensions for the <see cref="Vector2D{T}" /> struct.</summary>
public static class Vector2DExtensions
{
    /// <summary>Determines if the vector is empty.</summary>
    /// <param name="vector">The vector to test.</param>
    /// <typeparam name="T">The type of each component.</typeparam>
    /// <returns><see langword="true" /> if the vector is empty; otherwise, <see langword="false" />.</returns>
    public static bool IsEmpty<T>(this Vector2D<T> vector)
        where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T> => vector.X.Equals(Scalar<T>.NaN) && vector.Y.Equals(Scalar<T>.NaN);

    /// <summary>Gets a value indicating whether the vector contains only finite dimensions.</summary>
    public static bool IsFinite(this Vector2D<float> vector)
        => float.IsFinite(vector.X) && float.IsFinite(vector.Y);

    /// <summary>Gets a value indicating whether the vector contains only finite dimensions.</summary>
    public static bool IsFinite(this Vector2D<double> vector)
        => double.IsFinite(vector.X) && double.IsFinite(vector.Y);
}