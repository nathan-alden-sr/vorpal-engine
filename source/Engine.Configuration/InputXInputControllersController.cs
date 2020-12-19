namespace NathanAldenSr.VorpalEngine.Engine.Configuration
{
    /// <summary>XInput controller configuration.</summary>
    public class InputXInputControllersController
    {
        /// <summary>Gets or sets the index of the HID controller.</summary>
        public byte Index { get; set; }

        /// <summary>
        ///     Gets the value of the <see cref="Enabled" /> property assuming a particular default if <see cref="Enabled" /> is
        ///     <see langword="null" />.
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>Gets the default value of the <see cref="Enabled" /> property.</summary>
        public bool EnabledDefault => Enabled ?? true;
    }
}