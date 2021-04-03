using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Globalization;

namespace NathanAldenSr.VorpalEngine.Common
{
    /// <summary>Defines a rectangle with <see cref="float" /> components.</summary>
    /// <remarks>Inspired by <a href="https://github.com/terrafx">TerraFX</a>.</remarks>
    /// <typeparam name="T">The type of each dimension of the rectangle.</typeparam>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "ConvertToAutoProperty")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Roslyn is over-aggressive")]
    public readonly struct Rectangle<T> : IEquatable<Rectangle<T>>, IFormattable
        where T : unmanaged
    {
        /// <summary>Defines a <see cref="Rectangle{T}" /> where all components are <see cref="Numeric{T}.Empty" />.</summary>
        public static readonly Rectangle<T> Empty = new(Numeric<T>.Empty, Numeric<T>.Empty, Numeric<T>.Empty, Numeric<T>.Empty);

        private readonly Vector2<T> _location;
        private readonly Vector2<T> _size;

        /// <summary>Initializes a new instance of the <see cref="Rectangle{T}" /> struct.</summary>
        /// <param name="location">The location of the rectangle.</param>
        /// <param name="size">The size of the rectangle.</param>
        public Rectangle(Vector2<T> location, Vector2<T> size)
        {
            _location = location;
            _size = size;
        }

        /// <summary>Initializes a new instance of the <see cref="Rectangle{T}" /> struct.</summary>
        /// <param name="x">The x-dimension of the rectangle.</param>
        /// <param name="y">The y-dimension of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public Rectangle(T x, T y, T width, T height)
        {
            _location = new Vector2<T>(x, y);
            _size = new Vector2<T>(width, height);
        }

        /// <summary>Gets the location of the rectangle.</summary>
        public Vector2<T> Location => _location;

        /// <summary>Gets the size of the rectangle.</summary>
        public Vector2<T> Size => _size;

        /// <summary>Gets the x-dimension of the location of the rectangle.</summary>
        public T X => _location.X;

        /// <summary>Gets the y-dimension of the location of the rectangle.</summary>
        public T Y => _location.Y;

        /// <summary>Gets the width of the rectangle.</summary>
        public T Width => _size.X;

        /// <summary>Gets the height of the rectangle.</summary>
        public T Height => _size.Y;

        /// <summary>Gets the x-dimension of the location of the rectangle.</summary>
        public T Left => X;

        /// <summary>Gets the y-dimension of the location of the rectangle.</summary>
        public T Top => Y;

        /// <summary>Gets the x-dimension of the location of the rectangle, plus the width.</summary>
        public T Right => (Numeric<T>)X + Width;

        /// <summary>Gets the y-dimension of the location of the rectangle, plus the height.</summary>
        public T Bottom => (Numeric<T>)Y + Height;

        /// <summary>Gets a value determining if this object is empty.</summary>
        public bool IsEmpty => this == Empty;

        /// <summary>Gets the location of the rectangle at the top-left.</summary>
        public Vector2<T> TopLeft => _location;

        /// <summary>Gets the location of the rectangle at the top-center.</summary>
        public Vector2<T> TopCenter
        {
            get
            {
                if (typeof(T) == typeof(int))
                {
                    return new Vector2<T>((Numeric<T>)Left + (Numeric<T>)Width / (T)(object)2, Top);
                }
                // ReSharper disable once ConvertIfStatementToReturnStatement
                if (typeof(T) == typeof(float))
                {
                    return new Vector2<T>((Numeric<T>)Left + (Numeric<T>)Width / (T)(object)2.0f, Top);
                }

                return default;
            }
        }

        /// <summary>Gets the location of the rectangle at the top-right.</summary>
        public Vector2<T> TopRight => new(Right, Top);

        /// <summary>Gets the location of the rectangle at the center-left.</summary>
        public Vector2<T> CenterLeft
        {
            get
            {
                if (typeof(T) == typeof(int))
                {
                    return new Vector2<T>(Left, (Numeric<T>)Top + (Numeric<T>)Height / (T)(object)2);
                }
                // ReSharper disable once ConvertIfStatementToReturnStatement
                if (typeof(T) == typeof(float))
                {
                    return new Vector2<T>(Left, (Numeric<T>)Top + (Numeric<T>)Height / (T)(object)2.0f);
                }

                return default;
            }
        }

        /// <summary>Gets the location of the rectangle at the center.</summary>
        public Vector2<T> Center
        {
            get
            {
                if (typeof(T) == typeof(int))
                {
                    return new Vector2<T>((Numeric<T>)Left + (Numeric<T>)Width / (T)(object)2, (Numeric<T>)Top + (Numeric<T>)Height / (T)(object)2);
                }
                // ReSharper disable once ConvertIfStatementToReturnStatement
                if (typeof(T) == typeof(float))
                {
                    return new Vector2<T>((Numeric<T>)Left + (Numeric<T>)Width / (T)(object)2, (Numeric<T>)Top + (Numeric<T>)Height / (T)(object)2.0f);
                }

                return default;
            }
        }

        /// <summary>Gets the location of the rectangle at the center-right.</summary>
        public Vector2<T> CenterRight
        {
            get
            {
                if (typeof(T) == typeof(int))
                {
                    return new Vector2<T>((Numeric<T>)Right, (Numeric<T>)Top + (Numeric<T>)Height / (T)(object)2);
                }
                // ReSharper disable once ConvertIfStatementToReturnStatement
                if (typeof(T) == typeof(float))
                {
                    return new Vector2<T>((Numeric<T>)Right, (Numeric<T>)Top + (Numeric<T>)Height / (T)(object)2.0f);
                }

                return default;
            }
        }

        /// <summary>Gets the location of the rectangle at the bottom-left.</summary>
        public Vector2<T> BottomLeft => new(Left, Bottom);

        /// <summary>Gets the location of the rectangle at the bottom-center.</summary>
        public Vector2<T> BottomCenter
        {
            get
            {
                if (typeof(T) == typeof(int))
                {
                    return new Vector2<T>((Numeric<T>)Left + (Numeric<T>)Width / (T)(object)2, Bottom);
                }
                // ReSharper disable once ConvertIfStatementToReturnStatement
                if (typeof(T) == typeof(float))
                {
                    return new Vector2<T>((Numeric<T>)Left + (Numeric<T>)Width / (T)(object)2.0f, Bottom);
                }

                return default;
            }
        }

        /// <summary>Gets the location of the rectangle at the bottom-right.</summary>
        public Vector2<T> BottomRight => new(Right, Bottom);

        /// <summary>Compares two <see cref="Rectangle{T}" /> objects to determine equality.</summary>
        /// <param name="left">The <see cref="Rectangle{T}" /> to compare with <paramref name="right" />.</param>
        /// <param name="right">The <see cref="Rectangle{T}" /> to compare with <paramref name="left" />.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are equal; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public static bool operator ==(Rectangle<T> left, Rectangle<T> right) => left._location == right._location && left._size == right._size;

        /// <summary>Compares two <see cref="Rectangle{T}" /> objects to determine inequality.</summary>
        /// <param name="left">The <see cref="Rectangle{T}" /> to compare with <paramref name="right" />.</param>
        /// <param name="right">The <see cref="Rectangle{T}" /> to compare with <paramref name="left" />.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are not equal; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public static bool operator !=(Rectangle<T> left, Rectangle<T> right) => left._location != right._location || left._size != right._size;

        /// <summary>Creates a new <see cref="Rectangle{T}" /> with <see cref="Location" /> set to the specified value.</summary>
        /// <param name="location">The new location of the rectangle.</param>
        /// <returns>A new <see cref="Rectangle{T}" /> with <see cref="Location" /> set to <paramref name="location" />.</returns>
        [Pure]
        public Rectangle<T> WithLocation(Vector2<T> location) => new(location, _size);

        /// <summary>Creates a new <see cref="Rectangle{T}" /> with <see cref="Location" /> set to the specified x- and y-dimensions.</summary>
        /// <param name="x">The new x-dimension of the rectangle.</param>
        /// <param name="y">The new y-dimension of the rectangle.</param>
        /// <returns>A new <see cref="Rectangle{T}" /> with <see cref="Location" /> set to the specified x- and y-dimensinons.</returns>
        [Pure]
        public Rectangle<T> WithLocation(T x, T y) => WithLocation(new Vector2<T>(x, y));

        /// <summary>Creates a new <see cref="Rectangle{T}" /> with <see cref="Size" /> set to the specified value.</summary>
        /// <param name="size">The new size of the rectangle.</param>
        /// <returns>A new <see cref="Rectangle{T}" /> with <see cref="Size" /> set to <paramref name="size" />.</returns>
        [Pure]
        public Rectangle<T> WithSize(Vector2<T> size) => new(_location, size);

        /// <summary>Creates a new <see cref="Rectangle{T}" /> with <see cref="Size" /> set to the specified width and height.</summary>
        /// <param name="width">The new width of the rectangle.</param>
        /// <param name="height">The new height of the rectangle.</param>
        /// <returns>A new <see cref="Rectangle{T}" /> with <see cref="Size" /> set to the specified width and height.</returns>
        [Pure]
        public Rectangle<T> WithSize(T width, T height) => WithSize(new Vector2<T>(width, height));

        /// <summary>Creates a new <see cref="Rectangle{T}" /> with <see cref="X" /> set to the specified value.</summary>
        /// <param name="x">The new x-dimension of the rectangle.</param>
        /// <returns>A new <see cref="Rectangle{T}" /> with <see cref="X" /> set to <paramref name="x" />.</returns>
        [Pure]
        public Rectangle<T> WithX(T x) => new(new Vector2<T>(x, Y), _size);

        /// <summary>Creates a new <see cref="Rectangle{T}" /> with <see cref="Y" /> set to the specified value.</summary>
        /// <param name="y">The new y-dimension of the rectangle.</param>
        /// <returns>A new <see cref="Rectangle{T}" /> with <see cref="Y" /> set to <paramref name="y" />.</returns>
        [Pure]
        public Rectangle<T> WithY(T y) => new(new Vector2<T>(X, y), _size);

        /// <summary>Creates a new <see cref="Rectangle{T}" /> with <see cref="Width" /> set to the specified value.</summary>
        /// <param name="width">The new width of the rectangle.</param>
        /// <returns>A new <see cref="Rectangle{T}" /> with <see cref="Width" /> set to <paramref name="width" />.</returns>
        [Pure]
        public Rectangle<T> WithWidth(T width) => new(_location, new Vector2<T>(width, Height));

        /// <summary>Creates a new <see cref="Rectangle{T}" /> with <see cref="Height" /> set to the specified value.</summary>
        /// <param name="height">The new height of the rectangle.</param>
        /// <returns>A new <see cref="Rectangle{T}" /> with <see cref="Height" /> set to <paramref name="height" />.</returns>
        [Pure]
        public Rectangle<T> WithHeight(T height) => new(_location, new Vector2<T>(Width, height));

        /// <summary>Creates a new <see cref="Rectangle{T}" /> where the center of the current rectangle is <paramref name="center" />.</summary>
        /// <param name="center">The vector to center on.</param>
        /// <returns>A new <see cref="Rectangle{T}" /> whose center is the same as <paramref name="center" />.</returns>
        [Pure]
        public Rectangle<T> CenterOn(Vector2<T> center)
        {
            if (typeof(T) == typeof(int))
            {
                return new Rectangle<T>(
                    (Numeric<T>)center.X - (Numeric<T>)Width / (T)(object)2,
                    (Numeric<T>)center.Y - (Numeric<T>)Height / (T)(object)2,
                    Width,
                    Height);
            }
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (typeof(T) == typeof(float))
            {
                return new Rectangle<T>(
                    (Numeric<T>)center.X - (Numeric<T>)Width / (T)(object)2.0f,
                    (Numeric<T>)center.Y - (Numeric<T>)Height / (T)(object)2.0f,
                    Width,
                    Height);
            }

            return default;
        }

        /// <summary>
        ///     Creates a new <see cref="Rectangle{T}" /> where the center of the current rectangle is the same as the center of
        ///     <paramref name="rectangle" />.
        /// </summary>
        /// <param name="rectangle">The rectangle to center on.</param>
        /// <returns>A new <see cref="Rectangle{T}" /> whose center is the same as the center of <paramref name="rectangle" />.</returns>
        [Pure]
        public Rectangle<T> CenterOn(Rectangle<T> rectangle) => CenterOn(rectangle.Center);

        /// <summary>Creates a new <see cref="Rectangle{T}" /> from left/top/right/bottom values.</summary>
        /// <param name="left">The left value, to be used as the <see cref="X" />.</param>
        /// <param name="top">The top value, to be used as the <see cref="Y" />.</param>
        /// <param name="right">The right value, to be converted to the appropriate <see cref="Width" />.</param>
        /// <param name="bottom">The bottom value, to be converted to the appropriate <see cref="Height" />.</param>
        /// <returns>A new <see cref="Rectangle{T}" /> with appropriately-translated values.</returns>
        public static Rectangle<T> FromLTRB(T left, T top, T right, T bottom)
        {
            if (typeof(T) == typeof(int))
            {
                return new Rectangle<T>(left, top, (Numeric<T>)right - left, (Numeric<T>)bottom - top);
            }
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (typeof(T) == typeof(float))
            {
                return new Rectangle<T>(left, top, (Numeric<T>)right - left, (Numeric<T>)bottom - top);
            }

            return default;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is Rectangle<T> other && Equals(other);

        /// <inheritdoc />
        public bool Equals(Rectangle<T> other) => this == other;

        /// <inheritdoc />
        public override int GetHashCode() => HashCode.Combine(X, Y, Width, Height);

        /// <inheritdoc />
        public override string ToString() => ToString(null, null);

        /// <inheritdoc />
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            string separator = NumberFormatInfo.GetInstance(formatProvider).NumberGroupSeparator;

            if (typeof(T) == typeof(int))
            {
                return
                    $"<{((int)(object)X).ToString(format, formatProvider)}{separator} {((int)(object)Y).ToString(format, formatProvider)}{separator} {((int)(object)Width).ToString(format, formatProvider)}{separator} {((int)(object)Height).ToString(format, formatProvider)}>";
            }
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (typeof(T) == typeof(float))
            {
                return
                    $"<{((float)(object)X).ToString(format, formatProvider)}{separator} {((float)(object)Y).ToString(format, formatProvider)}{separator} {((float)(object)Width).ToString(format, formatProvider)}{separator} {((float)(object)Height).ToString(format, formatProvider)}>";
            }

            return default!;
        }
    }
}