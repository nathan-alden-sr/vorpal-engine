namespace NathanAldenSr.VorpalEngine.Engine.Configuration
{
    /// <summary>A delegate that is invoked when configuration changes.</summary>
    /// <typeparam name="T">The type of configuration.</typeparam>
    /// <param name="oldConfiguration">The old configuration.</param>
    /// <param name="newConfiguration">The new configuration.</param>
    /// <param name="counter">A value that uniquely identifies this particular configuration.</param>
    public delegate void ConfigurationChangedDelegate<in T>(T oldConfiguration, T newConfiguration, ulong counter);
}