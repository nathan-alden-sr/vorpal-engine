// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Diagnostics.CodeAnalysis;
using Silk.NET.Maths;
using TerraFX.Interop.Windows;

namespace VorpalEngine.Common.Windows;

/// <summary>Extensions for the <see cref="RECT" /> struct.</summary>
[SuppressMessage("ReSharper", "InconsistentNaming")]
public static class RECTExtensions
{
    /// <summary>Implicitly converts a <see cref="RECT" /> to a <see cref="Rectangle{T}" />.</summary>
    /// <typeparam name="T">The type of each dimension of the rectangle.</typeparam>
    /// <param name="value">The <see cref="RECT" /> to convert.</param>
    public static Rectangle<T> ToRectangle<T>(this RECT value)
        where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
    {
        if (typeof(T) == typeof(int))
        {
            return new Rectangle<T>(
                new Vector2D<T>((T)(object)value.left, (T)(object)value.top),
                new Vector2D<T>((T)(object)(value.right - value.left), (T)(object)(value.bottom - value.top)));
        }
        if (typeof(T) == typeof(float))
        {
            return new Rectangle<T>(
                new Vector2D<T>((T)(object)(float)value.left, (T)(object)(float)value.top),
                new Vector2D<T>((T)(object)(float)(value.right - value.left), (T)(object)(float)(value.bottom - value.top)));
        }

        return default;
    }
}
