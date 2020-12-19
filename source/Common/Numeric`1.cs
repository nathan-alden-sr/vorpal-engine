using System;
using System.Runtime.CompilerServices;
using static NathanAldenSr.VorpalEngine.Common.ExceptionHelper;

namespace NathanAldenSr.VorpalEngine.Common
{
    /// <summary>Allows for generic specialization of numeric operations.</summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public readonly struct Numeric<T> : IEquatable<Numeric<T>>
        where T : struct
    {
        /// <summary>A <see cref="Numeric{T}" /> with an empty value.</summary>
        public static readonly Numeric<T> Empty = GetEmpty();

        /// <summary>A <see cref="Numeric{T}" /> with a value of zero.</summary>
        public static readonly Numeric<T> Zero = GetZero();

        /// <summary>A <see cref="Numeric{T}" /> with a value of one.</summary>
        public static readonly Numeric<T> One = GetOne();

        /// <summary>Initializes a new instance of the <see cref="Numeric{T}" /> struct.</summary>
        /// <param name="value">A value.</param>
        public Numeric(T value)
        {
            ThrowForUnsupportedType();

            Value = value;
        }

        /// <summary>Gets a value determining if <typeparamref name="T" /> is a supported type.</summary>
        public static bool IsSupported
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => typeof(T) == typeof(int) || typeof(T) == typeof(float);
        }

        /// <summary>Gets the value.</summary>
        public T Value { get; }

        /// <summary>Implicitly converts a <typeparamref name="T" /> to a <see cref="Numeric{T}" />.</summary>
        /// <param name="value">The <typeparamref name="T" /> to convert.</param>
        public static implicit operator Numeric<T>(T value) => new(value);

        /// <summary>Implicitly converts a <see cref="Numeric{T}" /> to a <typeparamref name="T" />.</summary>
        /// <param name="value">The <see cref="Numeric{T}" /> to convert.</param>
        public static implicit operator T(Numeric<T> value) => value.Value;

        /// <summary>Adds the value contained in <paramref name="left" /> to <paramref name="right" />.</summary>
        /// <param name="left">The left-hand operand.</param>
        /// <param name="right">The right-hand operand.</param>
        /// <returns>The value contained in <paramref name="left" /> plus <paramref name="right" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator +(Numeric<T> left, T right)
        {
            if (typeof(T) == typeof(int))
            {
                return (T)(object)((int)(object)left.Value + (int)(object)right);
            }
            if (typeof(T) == typeof(float))
            {
                return (T)(object)((float)(object)left.Value + (float)(object)right);
            }

            return default;
        }

        /// <summary>Subtracts <paramref name="right" /> from the value contained in <paramref name="left" />.</summary>
        /// <param name="left">The left-hand operand.</param>
        /// <param name="right">The right-hand operand.</param>
        /// <returns>The value contained in <paramref name="left" /> minus <paramref name="right" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator -(Numeric<T> left, T right)
        {
            if (typeof(T) == typeof(int))
            {
                return (T)(object)((int)(object)left.Value - (int)(object)right);
            }
            if (typeof(T) == typeof(float))
            {
                return (T)(object)((float)(object)left.Value - (float)(object)right);
            }

            return default;
        }

        /// <summary>Multiplies the value contained in <paramref name="left" /> by <paramref name="right" />.</summary>
        /// <param name="left">The left-hand operand.</param>
        /// <param name="right">The right-hand operand.</param>
        /// <returns>The value contained in <paramref name="left" /> multiplied by <paramref name="right" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator *(Numeric<T> left, T right)
        {
            if (typeof(T) == typeof(int))
            {
                return (T)(object)((int)(object)left.Value * (int)(object)right);
            }
            if (typeof(T) == typeof(float))
            {
                return (T)(object)((float)(object)left.Value * (float)(object)right);
            }

            return default;
        }

        /// <summary>Divides the value contained in <paramref name="left" /> by <paramref name="right" />.</summary>
        /// <param name="left">The left-hand operand.</param>
        /// <param name="right">The right-hand operand.</param>
        /// <returns>The value contained in <paramref name="left" /> divided by <paramref name="right" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator /(Numeric<T> left, T right)
        {
            if (typeof(T) == typeof(int))
            {
                return (T)(object)((int)(object)left.Value / (int)(object)right);
            }
            if (typeof(T) == typeof(float))
            {
                return (T)(object)((float)(object)left.Value / (float)(object)right);
            }

            return default;
        }

        /// <summary>Calculates the remainder of the value contained in <paramref name="left" /> divided by <paramref name="right" />.</summary>
        /// <param name="left">The left-hand operand.</param>
        /// <param name="right">The right-hand operand.</param>
        /// <returns>The remainder of the value contained in <paramref name="left" /> divided by <paramref name="right" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator %(Numeric<T> left, T right)
        {
            if (typeof(T) == typeof(int))
            {
                return (T)(object)((int)(object)left.Value % (int)(object)right);
            }
            if (typeof(T) == typeof(float))
            {
                return (T)(object)((float)(object)left.Value % (float)(object)right);
            }

            return default;
        }

        /// <summary>Compares two <see cref="Vector2{T}" /> objects to determine equality.</summary>
        /// <param name="left">The <see cref="Vector2{T}" /> to compare with <paramref name="right" />.</param>
        /// <param name="right">The <see cref="Vector2{T}" /> to compare with <paramref name="left" />.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are equal; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public static bool operator ==(Numeric<T> left, Numeric<T> right)
        {
            ThrowForUnsupportedType();

            if (typeof(T) == typeof(int))
            {
                return (int)(object)left.Value == (int)(object)right.Value;
            }
            if (typeof(T) == typeof(float))
            {
                return (float)(object)left.Value == (float)(object)right.Value;
            }

            return default;
        }

        /// <summary>Compares two <see cref="Vector2{T}" /> objects to determine inequality.</summary>
        /// <param name="left">The <see cref="Vector2{T}" /> to compare with <paramref name="right" />.</param>
        /// <param name="right">The <see cref="Vector2{T}" /> to compare with <paramref name="left" />.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are not equal; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public static bool operator !=(Numeric<T> left, Numeric<T> right) => !(left == right);

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is Numeric<T> other && Equals(other);

        /// <inheritdoc />
        public bool Equals(Numeric<T> other) => this == other;

        /// <inheritdoc />
        public override int GetHashCode() => Value.GetHashCode();

        /// <inheritdoc />
        public override string ToString() => Value.ToString()!;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ThrowForUnsupportedType()
        {
            if (!IsSupported)
            {
                ThrowNotSupportedException();
            }
        }

        private static Numeric<T> GetEmpty()
        {
            ThrowForUnsupportedType();

            if (typeof(T) == typeof(int))
            {
                return new Numeric<T>((T)(object)0);
            }
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (typeof(T) == typeof(float))
            {
                return new Numeric<T>((T)(object)float.NaN);
            }

            return default;
        }

        private static Numeric<T> GetZero()
        {
            ThrowForUnsupportedType();

            return new Numeric<T>(default);
        }

        private static Numeric<T> GetOne()
        {
            ThrowForUnsupportedType();

            if (typeof(T) == typeof(int))
            {
                return new Numeric<T>((T)(object)1);
            }
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (typeof(T) == typeof(float))
            {
                return new Numeric<T>((T)(object)1.0f);
            }

            return default;
        }
    }
}