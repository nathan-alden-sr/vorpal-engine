using System;
using System.Globalization;

namespace NathanAldenSr.VorpalEngine.Common
{
    /// <summary>Defines a two-dimensional Euclidean vector.</summary>
    /// <typeparam name="T">A numeric type used to represent each component of the vector.</typeparam>
    /// <remarks>Inspired by <a href="https://github.com/terrafx">TerraFX</a>.</remarks>
    public readonly struct Vector2<T> : IEquatable<Vector2<T>>, IFormattable
        where T : struct
    {
        private readonly Numeric<T> _x;
        private readonly Numeric<T> _y;

        /// <summary>Defines a <see cref="Vector2{T}" /> where all components are <see cref="Numeric{T}.Empty" />.</summary>
        public static readonly Vector2<T> Empty = new(Numeric<T>.Empty, Numeric<T>.Empty);

        /// <summary>Defines a <see cref="Vector2{T}" /> where all components are zero.</summary>
        public static readonly Vector2<T> Zero = new(Numeric<T>.Zero, Numeric<T>.Zero);

        /// <summary>Defines a <see cref="Vector2{T}" /> whose x-component is one and whose remaining components are zero.</summary>
        public static readonly Vector2<T> UnitX = new(Numeric<T>.One, Numeric<T>.Zero);

        /// <summary>Defines a <see cref="Vector2{T}" /> whose y-component is one and whose remaining components are zero.</summary>
        public static readonly Vector2<T> UnitY = new(Numeric<T>.Zero, Numeric<T>.One);

        /// <summary>Defines a <see cref="Vector2{T}" /> where all components are one.</summary>
        public static readonly Vector2<T> One = new(Numeric<T>.One, Numeric<T>.One);

        /// <summary>Initializes a new instance of the <see cref="Vector2{T}" /> struct.</summary>
        /// <param name="x">The value of the x-dimension.</param>
        /// <param name="y">The value of the y-dimension.</param>
        public Vector2(T x, T y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>Gets the value of the x-dimension.</summary>
        public T X => _x;

        /// <summary>Gets the value of the y-dimension.</summary>
        public T Y => _y;

        /// <summary>Gets a value determining if this object is empty.</summary>
        public bool IsEmpty => this == Empty;

        /// <summary>Creates a new <see cref="Vector2{T}" /> instance with <see cref="X" /> set to the specified value.</summary>
        /// <param name="value">The new value of the x-dimension.</param>
        /// <returns>A new <see cref="Vector2{T}" /> instance with <see cref="X" /> set to <paramref name="value" />.</returns>
        public Vector2<T> WithX(T value) => new(value, Y);

        /// <summary>Creates a new <see cref="Vector2{T}" /> instance with <see cref="Y" /> set to the specified value.</summary>
        /// <param name="value">The new value of the y-dimension.</param>
        /// <returns>A new <see cref="Vector2{T}" /> instance with <see cref="Y" /> set to <paramref name="value" />.</returns>
        public Vector2<T> WithY(T value) => new(X, value);

        /// <summary>Compares two <see cref="Vector2{T}" /> objects to determine equality.</summary>
        /// <param name="left">The <see cref="Vector2{T}" /> to compare with <paramref name="right" />.</param>
        /// <param name="right">The <see cref="Vector2{T}" /> to compare with <paramref name="left" />.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are equal; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public static bool operator ==(Vector2<T> left, Vector2<T> right) => left._x == right._x && left._y == right._y;

        /// <summary>Compares two <see cref="Vector2{T}" /> objects to determine inequality.</summary>
        /// <param name="left">The <see cref="Vector2{T}" /> to compare with <paramref name="right" />.</param>
        /// <param name="right">The <see cref="Vector2{T}" /> to compare with <paramref name="left" />.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are not equal; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public static bool operator !=(Vector2<T> left, Vector2<T> right) => left._x != right._x || left._y != right._y;

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is Vector2<T> other && Equals(other);

        /// <inheritdoc />
        public bool Equals(Vector2<T> other) => this == other;

        /// <inheritdoc />
        public override int GetHashCode() => HashCode.Combine(X, Y);

        /// <inheritdoc />
        public override string ToString() => ToString(null, null);

        /// <inheritdoc />
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            string separator = NumberFormatInfo.GetInstance(formatProvider).NumberGroupSeparator;

            if (typeof(T) == typeof(int))
            {
                return $"<{((int)(object)X).ToString(format, formatProvider)}{separator} {((int)(object)Y).ToString(format, formatProvider)}>";
            }
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (typeof(T) == typeof(float))
            {
                return $"<{((float)(object)X).ToString(format, formatProvider)}{separator} {((float)(object)Y).ToString(format, formatProvider)}>";
            }

            return default!;
        }
    }
}