namespace NathanAldenSr.VorpalEngine.Engine.Configuration
{
    /// <summary>Defines a two-dimensional Euclidean vector with <see cref="float" /> components.</summary>
    /// <remarks>This struct is necessary because System.Text.Json does not yet serialize nullable structs properly.</remarks>
    public struct Vector2<T>
        where T : struct
    {
        /// <summary>Gets the value of the x-dimension.</summary>
        public T X { get; set; }

        /// <summary>Gets the value of the y-dimension.</summary>
        public T Y { get; set; }

        /// <summary>Implicitly converts a <see cref="Vector2{Y}" /> to a <see cref="VorpalEngine.Common.Vector2{T}" />.</summary>
        /// <param name="value">The <see cref="Vector2{Y}" /> to convert.</param>
        public static implicit operator VorpalEngine.Common.Vector2<T>(Vector2<T> value) =>
            new(value.X, value.Y);

        /// <summary>Implicitly converts a <see cref="VorpalEngine.Common.Vector2{T}" /> to a <see cref="Vector2{Y}" />.</summary>
        /// <param name="value">The <see cref="VorpalEngine.Common.Vector2{T}" /> to convert.</param>
        public static implicit operator Vector2<T>(VorpalEngine.Common.Vector2<T> value) =>
            new()
            {
                X = value.X,
                Y = value.Y
            };

        /// <summary>Implicitly converts a <see cref="Vector2{Y}" /> to a <see cref="VorpalEngine.Common.Vector2{T}" />.</summary>
        /// <param name="value">The <see cref="Vector2{Y}" /> to convert.</param>
        public static implicit operator VorpalEngine.Common.Vector2<T>?(Vector2<T>? value) =>
            value is not null
                ? new VorpalEngine.Common.Vector2<T>(value.Value.X, value.Value.Y)
                : (VorpalEngine.Common.Vector2<T>?)null;

        /// <summary>Implicitly converts a <see cref="VorpalEngine.Common.Vector2{T}" /> to a <see cref="Vector2{Y}" />.</summary>
        /// <param name="value">The <see cref="VorpalEngine.Common.Vector2{T}" /> to convert.</param>
        public static implicit operator Vector2<T>?(VorpalEngine.Common.Vector2<T>? value) =>
            value is not null
                ? new Vector2<T>
                  {
                      X = value.Value.X,
                      Y = value.Value.Y
                  }
                : (Vector2<T>?)null;
    }
}