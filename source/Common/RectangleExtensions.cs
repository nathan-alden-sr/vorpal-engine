namespace NathanAldenSr.VorpalEngine.Common
{
    /// <summary>Extensions for the <see cref="Vector2{T}" /> struct.</summary>
    public static class RectangleExtensions
    {
        /// <summary>Gets a value indicating whether the rectangle contains only finite dimensions.</summary>
        public static bool IsFinite(this Rectangle<float> rectangle) => rectangle.Location.IsFinite() && rectangle.Size.IsFinite();
    }
}