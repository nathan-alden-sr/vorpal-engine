using System.Diagnostics.CodeAnalysis;
using NathanAldenSr.VorpalEngine.Common;

namespace NathanAldenSr.VorpalEngine.Engine.Configuration.Messages
{
    /// <summary>Indicates that the configuration has changed.</summary>
    /// <typeparam name="T">The type of configuration.</typeparam>
    [SuppressMessage("ReSharper", "ConvertToAutoProperty")]
    [SuppressMessage("ReSharper", "ConvertToAutoPropertyWhenPossible")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Roslyn is over-aggressive")]
    public readonly struct ConfigurationChangedMessage<T> : IMessage
        where T : Configuration
    {
        private readonly T _oldConfiguration;
        private readonly T _newConfiguration;
        private readonly ulong _counter;

        /// <summary>Initializes a new instance of the <see cref="ConfigurationChangedMessage{T}" /> struct.</summary>
        /// <param name="oldConfiguration">The old configuration.</param>
        /// <param name="newConfiguration">The new configuration.</param>
        /// <param name="counter">A value that uniquely identifies this particular configuration.</param>
        public ConfigurationChangedMessage(T oldConfiguration, T newConfiguration, ulong counter)
        {
            _oldConfiguration = oldConfiguration;
            _newConfiguration = newConfiguration;
            _counter = counter;
        }

        /// <summary>Gets the old configuration.</summary>
        public T OldConfiguration => _oldConfiguration;

        /// <summary>Gets the new configuration.</summary>
        public T NewConfiguration => _newConfiguration;

        /// <summary>Gets a value that uniquely identifies this particular configuration.</summary>
        public ulong Counter => _counter;

        /// <inheritdoc />
        public string Description => $"Configuration was changed; counter is now {_counter}";
    }
}