using NathanAldenSr.VorpalEngine.Engine.Configuration.Messages;

namespace NathanAldenSr.VorpalEngine.Engine.Configuration
{
    /// <summary>A delegate that should be used to modify configuration.</summary>
    /// <typeparam name="T">The type of configuration.</typeparam>
    /// <param name="configuration">The configuration to be modified.</param>
    /// <param name="counter">
    ///     A value that uniquely identifies this particular modify operation. Use <paramref name="counter" /> to skip
    ///     subsequent <see cref="ConfigurationChangedMessage{T}" /> messages if desired.
    /// </param>
    public delegate void ModifyConfigurationDelegate<in T>(T configuration, ulong counter)
        where T : Configuration;
}