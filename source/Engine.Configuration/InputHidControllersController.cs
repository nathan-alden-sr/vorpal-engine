namespace NathanAldenSr.VorpalEngine.Engine.Configuration
{
    /// <summary>HID controller configuration.</summary>
    public class InputHidControllersController
    {
        /// <summary>Gets or sets the index of the HID controller.</summary>
        public uint Index { get; set; }

        /// <summary>
        ///     Gets the value of the <see cref="Enabled" /> property assuming a particular default if <see cref="Enabled" /> is
        ///     <see langword="null" />.
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>Gets the default value of the <see cref="Enabled" /> property.</summary>
        public bool EnabledDefault => Enabled ?? true;

        /// <summary>
        ///     Gets or sets the manufacturer of the HID controller. A <see langword="null" /> value indicates the manufacturer is
        ///     unknown.
        /// </summary>
        public string? Manufacturer { get; set; }

        /// <summary>
        ///     Gets or sets the product name of the HID controller. A <see langword="null" /> value indicates the product name is
        ///     unknown.
        /// </summary>
        public string? ProductName { get; set; }

        /// <summary>
        ///     Gets or sets the serial number of the HID controller. A <see langword="null" /> value indicates the serial number is
        ///     unknown.
        /// </summary>
        public string? SerialNumber { get; set; }
    }
}