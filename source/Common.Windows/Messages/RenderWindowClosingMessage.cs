namespace NathanAldenSr.VorpalEngine.Common.Windows.Messages
{
    /// <summary>Indicates the render window is closing.</summary>
    public readonly struct RenderWindowClosingMessage : IMessage
    {
        /// <inheritdoc />
        public string Description => "Render window is closing";
    }
}