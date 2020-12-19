using System.Diagnostics.CodeAnalysis;
using TerraFX.Interop;

namespace NathanAldenSr.VorpalEngine.Common.Windows
{
    /// <summary>Extensions for the <see cref="Rectangle{T}" /> class.</summary>
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "<Pending>")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class RectangleExtensions
    {
        /// <summary>Implicitly converts a <see cref="Rectangle{T}" /> to a <see cref="RECT" />.</summary>
        /// <param name="value">The <see cref="Rectangle{T}" /> to convert.</param>
        public static RECT ToRECT<T>(this Rectangle<T> value)
            where T : struct
        {
            if (typeof(T) == typeof(int))
            {
                return new RECT((int)(object)value.Left, (int)(object)value.Top, (int)(object)value.Right, (int)(object)value.Bottom);
            }
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (typeof(T) == typeof(float))
            {
                return new RECT(
                    (int)(float)(object)value.Left,
                    (int)(float)(object)value.Top,
                    (int)(float)(object)value.Right,
                    (int)(float)(object)value.Bottom);
            }

            return default;
        }
    }
}