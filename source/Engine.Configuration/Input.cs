using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NathanAldenSr.VorpalEngine.Engine.Configuration
{
    /// <summary>Input configuration.</summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("Style", "IDE1006:Naming Styles")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Roslyn is over-aggressive")]
    public class Input
    {
        /// <summary>Gets or sets keyboard configuration. Use <see cref="Keyboard" /> for finer-grained control over this property.</summary>
        [JsonPropertyName("keyboard")]
        [JsonInclude]
        public InputKeyboard? _Keyboard { get; private set; }

        /// <summary>Gets or sets mouse configuration. Use <see cref="Mouse" /> for finer-grained control over this property.</summary>
        [JsonPropertyName("mouse")]
        [JsonInclude]
        public InputMouse? _Mouse { get; private set; }

        /// <summary>
        ///     Gets or sets HID controller configuration. Use <see cref="HidControllers" /> for finer-grained control over this
        ///     property.
        /// </summary>
        [JsonPropertyName("hidControllers")]
        [JsonInclude]
        public InputHidControllers? _HidControllers { get; private set; }

        /// <summary>
        ///     Gets or sets XInput controller configuration. Use <see cref="XInputControllers" /> for finer-grained control over this
        ///     property.
        /// </summary>
        [JsonPropertyName("xInputControllers")]
        [JsonInclude]
        public InputXInputControllers? _XInputControllers { get; private set; }

        /// <summary>
        ///     Gets the keyboard configuration, optionally initializing the <see cref="_Keyboard" /> property to an instance of
        ///     <see cref="InputKeyboard" />.
        /// </summary>
        /// <param name="initialize">
        ///     A value determining whether to initialize a <see langword="null" /> <see cref="_Keyboard" /> property
        ///     value with an instance of <see cref="InputKeyboard" />.
        /// </param>
        /// <returns>
        ///     An <see cref="InputKeyboard" /> object. If <paramref name="initialize" /> is <see langword="true" />, the
        ///     <see cref="_Keyboard" /> property value was set to the returned object; otherwise, the returned reference should be
        ///     considered temporary.
        /// </returns>
        public InputKeyboard Keyboard(bool initialize = false) => initialize ? _Keyboard ??= new InputKeyboard() : _Keyboard ?? new InputKeyboard();

        /// <summary>
        ///     Gets the keyboard configuration, optionally initializing the <see cref="_Mouse" /> property to an instance of
        ///     <see cref="InputMouse" />.
        /// </summary>
        /// <param name="initialize">
        ///     A value determining whether to initialize a <see langword="null" /> <see cref="_Mouse" /> property value
        ///     with an instance of <see cref="InputMouse" />.
        /// </param>
        /// <returns>
        ///     An <see cref="InputMouse" /> object. If <paramref name="initialize" /> is <see langword="true" />, the
        ///     <see cref="_Mouse" /> property value was set to the returned object; otherwise, the returned reference should be considered
        ///     temporary.
        /// </returns>
        public InputMouse Mouse(bool initialize = false) => initialize ? _Mouse ??= new InputMouse() : _Mouse ?? new InputMouse();

        /// <summary>
        ///     Gets the keyboard configuration, optionally initializing the <see cref="_HidControllers" /> property to an instance of
        ///     <see cref="InputHidControllers" />.
        /// </summary>
        /// <param name="initialize">
        ///     A value determining whether to initialize a <see langword="null" /> <see cref="_HidControllers" />
        ///     property value with an instance of <see cref="InputHidControllers" />.
        /// </param>
        /// <returns>
        ///     An <see cref="InputHidControllers" /> object. If <paramref name="initialize" /> is <see langword="true" />, the
        ///     <see cref="_HidControllers" /> property value was set to the returned object; otherwise, the returned reference should be
        ///     considered temporary.
        /// </returns>
        public InputHidControllers HidControllers(bool initialize = false) =>
            initialize ? _HidControllers ??= new InputHidControllers() : _HidControllers ?? new InputHidControllers();

        /// <summary>
        ///     Gets the keyboard configuration, optionally initializing the <see cref="_XInputControllers" /> property to an instance
        ///     of <see cref="InputXInputControllers" />.
        /// </summary>
        /// <param name="initialize">
        ///     A value determining whether to initialize a <see langword="null" /> <see cref="_XInputControllers" />
        ///     property value with an instance of <see cref="InputXInputControllers" />.
        /// </param>
        /// <returns>
        ///     An <see cref="InputXInputControllers" /> object. If <paramref name="initialize" /> is <see langword="true" />, the
        ///     <see cref="_HidControllers" /> property value was set to the returned object; otherwise, the returned reference should be
        ///     considered temporary.
        /// </returns>
        public InputXInputControllers XInputControllers(bool initialize = false) =>
            initialize ? _XInputControllers ??= new InputXInputControllers() : _XInputControllers ?? new InputXInputControllers();
    }
}