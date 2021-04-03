using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NathanAldenSr.VorpalEngine.Engine.Configuration
{
    /// <summary>Render window configuration</summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("Style", "IDE1006:Naming Styles")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Roslyn is over-aggressive")]
    public class WindowsRender
    {
        /// <summary>Gets or sets the device name of the display on which the render window appears.</summary>
        public string? DisplayDeviceName { get; set; }

        /// <summary>Gets or sets the display mode of the render window when the render window appears.</summary>
        public DisplayMode? DisplayMode { get; set; }

        /// <summary>
        ///     Gets the value of the <see cref="DisplayMode" /> property assuming a particular default if <see cref="DisplayMode" /> is
        ///     <see langword="null" />.
        /// </summary>
        public DisplayMode DisplayModeDefault => DisplayMode ?? Engine.Configuration.DisplayMode.Bordered;

        /// <summary>Gets or sets a value indicating whether the render window will be maximized when it appears.</summary>
        public bool? Maximized { get; set; }

        /// <summary>
        ///     Gets the value of the <see cref="Maximized" /> property assuming a particular default if <see cref="Maximized" /> is
        ///     <see langword="null" />.
        /// </summary>
        public bool MaximizedDefault => Maximized ?? true;

        /// <summary>Gets or sets the size of the render window client area when the render window appears.</summary>
        public Vector2<int>? Resolution { get; set; }

        /// <summary>
        ///     Gets or sets render window logging configuration. Use <see cref="Logging" /> for finer-grained control over this
        ///     property.
        /// </summary>
        [JsonPropertyName("logging")]
        [JsonInclude]
        public WindowsRenderLogging? _Logging { get; private set; }

        /// <summary>
        ///     Gets the keyboard configuration, optionally initializing the <see cref="_Logging" /> property to an instance of
        ///     <see cref="WindowsRenderLogging" />.
        /// </summary>
        /// <param name="initialize">
        ///     A value determining whether to initialize a <see langword="null" /> <see cref="_Logging" /> property
        ///     value with an instance of <see cref="WindowsRenderLogging" />.
        /// </param>
        /// <returns>
        ///     An <see cref="WindowsRenderLogging" /> object. If <paramref name="initialize" /> is <see langword="true" />, the
        ///     <see cref="_Logging" /> property value was set to the returned object; otherwise, the returned reference should be considered
        ///     temporary.
        /// </returns>
        public WindowsRenderLogging Logging(bool initialize = false) =>
            initialize ? _Logging ??= new WindowsRenderLogging() : _Logging ?? new WindowsRenderLogging();
    }
}