namespace NathanAldenSr.VorpalEngine.Common.Windows.Messages
{
    /// <summary>Indicates that the render window's display mode changed.</summary>
    public readonly struct DisplayModeChangedMessage : IMessage
    {
        /// <summary>Initializes a new instance of the <see cref="DisplayModeChangedMessage" /> struct.</summary>
        /// <param name="oldDisplayMode">The old display mode. A <see langword="null" /> value means the old display mode is unknown.</param>
        /// <param name="newDisplayMode">The new display mode.</param>
        public DisplayModeChangedMessage(DisplayMode? oldDisplayMode, DisplayMode newDisplayMode)
        {
            OldDisplayMode = oldDisplayMode;
            NewDisplayMode = newDisplayMode;
        }

        /// <summary>Gets the old display mode. A <see langword="null" /> value means the old display mode is unknown.</summary>
        public DisplayMode? OldDisplayMode { get; }

        /// <summary>Gets the new display mode.</summary>
        public DisplayMode NewDisplayMode { get; }

        /// <inheritdoc />
        public string Description =>
            OldDisplayMode is not null
                ? $"Display mode changed from {OldDisplayMode.Value} to {NewDisplayMode}"
                : $"Display mode changed to {NewDisplayMode}";
    }
}