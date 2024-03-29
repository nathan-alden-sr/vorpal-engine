// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using Silk.NET.Maths;

namespace VorpalEngine.Common;

/// <summary>Helper methods for <see cref="Vector2D{T}" /> objects.</summary>
public static class Vector2D
{
    /// <summary>Creates a <see cref="Vector2D{T}" /> object with <see cref="Scalar{T}.NaN" /> used for all components.</summary>
    /// <typeparam name="T">The type of each component.</typeparam>
    /// <returns>The new <see cref="Vector2D{T}" /> object.</returns>
    public static Vector2D<T> NaN<T>()
        where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
        => new(Scalar<T>.NaN, Scalar<T>.NaN);
}
