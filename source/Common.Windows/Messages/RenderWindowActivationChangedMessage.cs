using System.Diagnostics.CodeAnalysis;

namespace NathanAldenSr.VorpalEngine.Common.Windows.Messages
{
    /// <summary>Indicates the render window's activation state has changed.</summary>
    [SuppressMessage("ReSharper", "ConvertToAutoProperty")]
    [SuppressMessage("ReSharper", "ConvertToAutoPropertyWhenPossible")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Roslyn is over-aggressive")]
    public readonly struct RenderWindowActivationChangedMessage : IMessage
    {
        private readonly bool _oldIsActive;
        private readonly bool _newIsActive;

        /// <summary>Initializes a new instance of the <see cref="RenderWindowActivationChangedMessage" /> struct.</summary>
        /// <param name="oldIsActive">The old activation status. A <see langword="null" /> value means the old activation status is unknown.</param>
        /// <param name="newIsActive">The new activation status.</param>
        public RenderWindowActivationChangedMessage(bool oldIsActive, bool newIsActive)
        {
            _oldIsActive = oldIsActive;
            _newIsActive = newIsActive;
        }

        /// <summary>Gets the old activation status.</summary>
        public bool OldIsActive => _oldIsActive;

        /// <summary>Gets the new activation status.</summary>
        public bool NewIsActive => _newIsActive;

        /// <inheritdoc />
        public string Description => $"Render window is {(!_newIsActive ? "de" : "")}activated";
    }
}