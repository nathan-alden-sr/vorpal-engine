namespace NathanAldenSr.VorpalEngine.Engine.Configuration
{
    /// <summary>Render window logging configuration.</summary>
    public class WindowsRenderLogging
    {
        /// <summary>Gets or sets a value indicating whether window messages will be logged.</summary>
        public bool? WindowMessagesEnabled { get; set; }

        /// <summary>
        ///     Gets the value of the <see cref="WindowMessagesEnabled" /> property assuming a particular default if
        ///     <see cref="WindowMessagesEnabled" /> is <see langword="null" />.
        /// </summary>
        public bool WindowMessagesEnabledDefault => WindowMessagesEnabled ?? false;
    }
}