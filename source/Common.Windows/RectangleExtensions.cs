// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System;
using System.Diagnostics.CodeAnalysis;
using Silk.NET.Maths;
using TerraFX.Interop;

namespace VorpalEngine.Common.Windows;

/// <summary>Extensions for the <see cref="Rectangle{T}" /> class.</summary>
public static class RectangleExtensions
{
    /// <summary>Implicitly converts a <see cref="Rectangle{T}" /> to a <see cref="RECT" />.</summary>
    /// <param name="value">The <see cref="Rectangle{T}" /> to convert.</param>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static RECT ToRECT<T>(this Rectangle<T> value)
        where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
    {
        if (typeof(T) == typeof(int))
        {
            return new RECT((int)(object)value.Origin.X, (int)(object)value.Origin.Y, (int)(object)value.Max.X, (int)(object)value.Max.Y);
        }
        // ReSharper disable once ConvertIfStatementToReturnStatement
        if (typeof(T) == typeof(float))
        {
            return new RECT(
                (int)(float)(object)value.Origin.X,
                (int)(float)(object)value.Origin.Y,
                (int)(float)(object)value.Max.X,
                (int)(float)(object)value.Max.Y);
        }

        return default;
    }
}