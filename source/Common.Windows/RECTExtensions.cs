using System.Diagnostics.CodeAnalysis;
using TerraFX.Interop;

namespace NathanAldenSr.VorpalEngine.Common.Windows
{
    /// <summary>Extensions for the <see cref="RECT" /> struct.</summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Roslyn is over-aggressive")]
    public static class RECTExtensions
    {
        /// <summary>Implicitly converts a <see cref="RECT" /> to a <see cref="Rectangle{T}" />.</summary>
        /// <typeparam name="T">The type of each dimension of the rectangle.</typeparam>
        /// <param name="value">The <see cref="RECT" /> to convert.</param>
        public static Rectangle<T> ToRectangle<T>(this RECT value)
            where T : unmanaged
        {
            if (typeof(T) == typeof(int))
            {
                return new Rectangle<T>(
                    (T)(object)value.left,
                    (T)(object)value.top,
                    (T)(object)(value.right - value.left),
                    (T)(object)(value.bottom - value.top));
            }
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (typeof(T) == typeof(float))
            {
                return new Rectangle<T>(
                    (T)(object)(float)value.left,
                    (T)(object)(float)value.top,
                    (T)(object)(float)(value.right - value.left),
                    (T)(object)(float)(value.bottom - value.top));
            }

            return default;
        }
    }
}