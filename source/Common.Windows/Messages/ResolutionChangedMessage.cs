namespace NathanAldenSr.VorpalEngine.Common.Windows.Messages
{
    /// <summary>Indicates the resolution has changed.</summary>
    public readonly struct ResolutionChangedMessage : IMessage
    {
        /// <summary>Initializes a new instance of the <see cref="ResolutionChangedMessage" /> struct.</summary>
        /// <param name="oldResolution">The old resolution. A <see langword="null" /> value means the old resolution is unknown.</param>
        /// <param name="newResolution">The new resolution.</param>
        public ResolutionChangedMessage(Vector2<int>? oldResolution, Vector2<int> newResolution)
        {
            OldResolution = oldResolution;
            NewResolution = newResolution;
        }

        /// <summary>Gets the old resolution. A <see langword="null" /> value means the old resolution is unknown.</summary>
        public Vector2<int>? OldResolution { get; }

        /// <summary>Gets the new resolution.</summary>
        public Vector2<int> NewResolution { get; }

        /// <inheritdoc />
        public string Description =>
            OldResolution is object
                ? $"Resolution changed from {GetDescription(OldResolution.Value)} to {GetDescription(NewResolution)}"
                : $"Resolution changed to {GetDescription(NewResolution)}";

        private static string GetDescription(Vector2<int> resolution) => $"{resolution.X}w {resolution.Y}h";
    }
}