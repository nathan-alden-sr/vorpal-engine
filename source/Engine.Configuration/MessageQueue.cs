// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace VorpalEngine.Engine.Configuration;

/// <summary>Message queue configuration.</summary>
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("Style", "IDE1006:Naming Styles")]
public sealed class MessageQueue
{
    /// <summary>
    ///     Gets or sets message queue logging configuration. Use <see cref="Logging" /> for finer-grained control over this
    ///     property.
    /// </summary>
    [JsonInclude]
    public MessageQueueLogging? _Logging { get; private set; }

    /// <summary>
    ///     Gets the keyboard configuration, optionally initializing the <see cref="MessageQueueLogging" /> property to an instance
    ///     of <see cref="MessageQueueLogging" />.
    /// </summary>
    /// <param name="initialize">
    ///     A value determining whether to initialize a <see langword="null" /> <see cref="MessageQueueLogging" />
    ///     property value with an instance of <see cref="MessageQueueLogging" />.
    /// </param>
    /// <returns>
    ///     An <see cref="MessageQueueLogging" /> object. If <paramref name="initialize" /> is <see langword="true" />, the
    ///     <see cref="MessageQueueLogging" /> property value was set to the returned object; otherwise, the returned reference should be
    ///     considered temporary.
    /// </returns>
    public MessageQueueLogging Logging(bool initialize = false)
        => initialize ? _Logging ??= new MessageQueueLogging() : _Logging ?? new MessageQueueLogging();
}
