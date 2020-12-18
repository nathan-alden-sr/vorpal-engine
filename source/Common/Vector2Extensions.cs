namespace NathanAldenSr.VorpalEngine.Common
{
    /// <summary>Extensions for the <see cref="Vector2{T}" /> struct.</summary>
    public static class Vector2Extensions
    {
        /// <summary>Gets a value indicating whether the vector contains only finite dimensions.</summary>
        public static bool IsFinite(this Vector2<float> vector) => float.IsFinite(vector.X) && float.IsFinite(vector.Y);
    }
}