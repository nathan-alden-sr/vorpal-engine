using NathanAldenSr.VorpalEngine.Common;

namespace NathanAldenSr.VorpalEngine.Engine.Configuration.Messages
{
    /// <summary>Indicates that the configuration has changed.</summary>
    /// <typeparam name="T">The type of configuration.</typeparam>
    public readonly struct ConfigurationChangedMessage<T> : IMessage
        where T : Configuration
    {
        /// <summary>Initializes a new instance of the <see cref="ConfigurationChangedMessage{TConfiguration}" /> struct.</summary>
        /// <param name="oldConfiguration">The old configuration.</param>
        /// <param name="newConfiguration">The new configuration.</param>
        /// <param name="counter">A value that uniquely identifies this particular configuration.</param>
        public ConfigurationChangedMessage(T oldConfiguration, T newConfiguration, ulong counter)
        {
            OldConfiguration = oldConfiguration;
            NewConfiguration = newConfiguration;
            Counter = counter;
        }

        /// <summary>Gets the old configuration.</summary>
        public T OldConfiguration { get; }

        /// <summary>Gets the new configuration.</summary>
        public T NewConfiguration { get; }

        /// <summary>Gets a value that uniquely identifies this particular configuration.</summary>
        public ulong Counter { get; }

        /// <inheritdoc />
        public string Description => $"Configuration was changed; counter is now {Counter}";
    }
}