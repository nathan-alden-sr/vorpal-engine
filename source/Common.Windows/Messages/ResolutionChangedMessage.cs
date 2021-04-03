using System.Diagnostics.CodeAnalysis;

namespace NathanAldenSr.VorpalEngine.Common.Windows.Messages
{
    /// <summary>Indicates the resolution has changed.</summary>
    [SuppressMessage("ReSharper", "ConvertToAutoPropertyWhenPossible")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Roslyn is over-aggressive")]
    public readonly struct ResolutionChangedMessage : IMessage
    {
        private readonly Vector2<int>? _oldResolution;
        private readonly Vector2<int> _newResolution;

        /// <summary>Initializes a new instance of the <see cref="ResolutionChangedMessage" /> struct.</summary>
        /// <param name="oldResolution">The old resolution. A <see langword="null" /> value means the old resolution is unknown.</param>
        /// <param name="newResolution">The new resolution.</param>
        public ResolutionChangedMessage(Vector2<int>? oldResolution, Vector2<int> newResolution)
        {
            _oldResolution = oldResolution;
            _newResolution = newResolution;
        }

        /// <summary>Gets the old resolution. A <see langword="null" /> value means the old resolution is unknown.</summary>
        public Vector2<int>? OldResolution => _oldResolution;

        /// <summary>Gets the new resolution.</summary>
        public Vector2<int> NewResolution => _newResolution;

        /// <inheritdoc />
        public string Description =>
            _oldResolution is not null
                ? $"Resolution changed from {GetDescription(_oldResolution.Value)} to {GetDescription(_newResolution)}"
                : $"Resolution changed to {GetDescription(_newResolution)}";

        private static string GetDescription(Vector2<int> resolution) => $"{resolution.X}w {resolution.Y}h";
    }
}