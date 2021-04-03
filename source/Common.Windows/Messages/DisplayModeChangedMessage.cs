using System.Diagnostics.CodeAnalysis;

namespace NathanAldenSr.VorpalEngine.Common.Windows.Messages
{
    /// <summary>Indicates that the render window's display mode changed.</summary>
    [SuppressMessage("ReSharper", "ConvertToAutoPropertyWhenPossible")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Roslyn is over-aggressive")]
    public readonly struct DisplayModeChangedMessage : IMessage
    {
        private readonly DisplayMode? _oldDisplayMode;
        private readonly DisplayMode _newDisplayMode;

        /// <summary>Initializes a new instance of the <see cref="DisplayModeChangedMessage" /> struct.</summary>
        /// <param name="oldDisplayMode">The old display mode. A <see langword="null" /> value means the old display mode is unknown.</param>
        /// <param name="newDisplayMode">The new display mode.</param>
        public DisplayModeChangedMessage(DisplayMode? oldDisplayMode, DisplayMode newDisplayMode)
        {
            _oldDisplayMode = oldDisplayMode;
            _newDisplayMode = newDisplayMode;
        }

        /// <summary>Gets the old display mode. A <see langword="null" /> value means the old display mode is unknown.</summary>
        public DisplayMode? OldDisplayMode => _oldDisplayMode;

        /// <summary>Gets the new display mode.</summary>
        public DisplayMode NewDisplayMode => _newDisplayMode;

        /// <inheritdoc />
        public string Description =>
            _oldDisplayMode is not null
                ? $"Display mode changed from {_oldDisplayMode.Value} to {_newDisplayMode}"
                : $"Display mode changed to {_newDisplayMode}";
    }
}