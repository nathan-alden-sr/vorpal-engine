// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace VorpalEngine.Engine.Configuration;

/// <summary>Base class for configuration.</summary>
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("Style", "IDE1006:Naming Styles")]
public abstract class Configuration
{
    /// <summary>Gets or sets input configuration.</summary>
    [JsonInclude]
    public Input? _Input { get; private set; }

    /// <summary>Gets or sets logging-configuration.</summary>
    [JsonInclude]
    public Logging? _Logging { get; private set; }

    /// <summary>Gets or sets message queue configuration.</summary>
    [JsonInclude]
    public MessageQueue? _MessageQueue { get; private set; }

    /// <summary>Gets or sets window configuration.</summary>
    [JsonInclude]
    public Windows? _Windows { get; private set; }

    /// <summary>
    ///     Gets the input configuration, optionally initializing the <see cref="_Input" /> property to an instance of
    ///     <see cref="Engine.Configuration.Input" />.
    /// </summary>
    /// <param name="initialize">
    ///     A value determining whether to initialize a <see langword="null" /> <see cref="_Input" /> property value
    ///     with an instance of <see cref="Engine.Configuration.Input" />.
    /// </param>
    /// <returns>
    ///     An <see cref="Engine.Configuration.Input" /> object. If <paramref name="initialize" /> is <see langword="true" />, the
    ///     <see cref="_Input" /> property value was set to the returned object; otherwise, the returned reference should be considered
    ///     temporary.
    /// </returns>
    public Input Input(bool initialize = false)
        => initialize ? _Input ??= new Input() : _Input ?? new Input();

    /// <summary>
    ///     Gets the logging configuration, optionally initializing the <see cref="_Logging" /> property to an instance of
    ///     <see cref="Engine.Configuration.Logging" />.
    /// </summary>
    /// <param name="initialize">
    ///     A value determining whether to initialize a <see langword="null" /> <see cref="_Logging" /> property
    ///     value with an instance of <see cref="Engine.Configuration.Logging" />.
    /// </param>
    /// <returns>
    ///     An <see cref="Engine.Configuration.Logging" /> object. If <paramref name="initialize" /> is <see langword="true" />, the
    ///     <see cref="_Logging" /> property value was set to the returned object; otherwise, the returned reference should be considered
    ///     temporary.
    /// </returns>
    public Logging Logging(bool initialize = false)
        => initialize ? _Logging ??= new Logging() : _Logging ?? new Logging();

    /// <summary>
    ///     Gets the message queue configuration, optionally initializing the <see cref="_MessageQueue" /> property to an instance
    ///     of <see cref="Engine.Configuration.MessageQueue" />.
    /// </summary>
    /// <param name="initialize">
    ///     A value determining whether to initialize a <see langword="null" /> <see cref="_MessageQueue" />
    ///     property value with an instance of <see cref="Engine.Configuration.MessageQueue" />.
    /// </param>
    /// <returns>
    ///     An <see cref="Engine.Configuration.MessageQueue" /> object. If <paramref name="initialize" /> is <see langword="true" />
    ///     , the <see cref="_MessageQueue" /> property value was set to the returned object; otherwise, the returned reference should be
    ///     considered temporary.
    /// </returns>
    public MessageQueue MessageQueue(bool initialize = false)
        => initialize ? _MessageQueue ??= new MessageQueue() : _MessageQueue ?? new MessageQueue();

    /// <summary>
    ///     Gets the windows configuration, optionally initializing the <see cref="_Windows" /> property to an instance of
    ///     <see cref="Engine.Configuration.Windows" />.
    /// </summary>
    /// <param name="initialize">
    ///     A value determining whether to initialize a <see langword="null" /> <see cref="_Windows" /> property
    ///     value with an instance of <see cref="Engine.Configuration.Windows" />.
    /// </param>
    /// <returns>
    ///     An <see cref="Engine.Configuration.Windows" /> object. If <paramref name="initialize" /> is <see langword="true" />, the
    ///     <see cref="_Windows" /> property value was set to the returned object; otherwise, the returned reference should be considered
    ///     temporary.
    /// </returns>
    public Windows Windows(bool initialize = false)
        => initialize ? _Windows ??= new Windows() : _Windows ?? new Windows();
}