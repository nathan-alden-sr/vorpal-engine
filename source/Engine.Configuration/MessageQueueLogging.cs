// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

namespace VorpalEngine.Engine.Configuration;

/// <summary>Message queue logging configuration.</summary>
public sealed class MessageQueueLogging
{
    /// <summary>Gets or sets a value indicating whether log messages are written before a message is handled.</summary>
    public bool? MessageHandlingEnabled { get; set; }

    /// <summary>
    ///     Gets the value of the <see cref="MessageHandlingEnabled" /> property assuming a particular default if
    ///     <see cref="MessageHandlingEnabled" /> is <see langword="null" />.
    /// </summary>
    public bool MessageHandlingEnabledDefault => MessageHandlingEnabled ?? false;

    /// <summary>Gets or sets a value indicating whether log messages are written after a message is handled.</summary>
    public bool? MessageHandledEnabled { get; set; }

    /// <summary>
    ///     Gets the value of the <see cref="MessageHandledEnabled" /> property assuming a particular default if
    ///     <see cref="MessageHandledEnabled" /> is <see langword="null" />.
    /// </summary>
    public bool MessageHandledEnabledDefault => MessageHandledEnabled ?? false;

    /// <summary>Gets or sets a value indicating whether log messages are written before a message is published.</summary>
    public bool? MessagePublishingEnabled { get; set; }

    /// <summary>
    ///     Gets the value of the <see cref="MessagePublishingEnabled" /> property assuming a particular default if
    ///     <see cref="MessagePublishingEnabled" /> is <see langword="null" />.
    /// </summary>
    public bool MessagePublishingEnabledDefault => MessagePublishingEnabled ?? false;

    /// <summary>Gets or sets a value indicating whether log messages are written after a message is published.</summary>
    public bool? MessagePublishedEnabled { get; set; }

    /// <summary>
    ///     Gets the value of the <see cref="MessagePublishedEnabled" /> property assuming a particular default if
    ///     <see cref="MessagePublishedEnabled" /> is <see langword="null" />.
    /// </summary>
    public bool MessagePublishedEnabledDefault => MessagePublishedEnabled ?? false;

    /// <summary>Gets or sets a value indicating whether log messages are written when a message is subscribed to.</summary>
    public bool? MessageSubscribedEnabled { get; set; }

    /// <summary>
    ///     Gets the value of the <see cref="MessageSubscribedEnabled" /> property assuming a particular default if
    ///     <see cref="MessageSubscribedEnabled" /> is <see langword="null" />.
    /// </summary>
    public bool MessageSubscribedEnabledDefault => MessageSubscribedEnabled ?? false;

    /// <summary>Gets or sets a value indicating whether log messages are written when a message is unsubscribed from.</summary>
    public bool? MessageUnsubscribedEnabled { get; set; }

    /// <summary>
    ///     Gets the value of the <see cref="MessageUnsubscribedEnabled" /> property assuming a particular default if
    ///     <see cref="MessageUnsubscribedEnabled" /> is <see langword="null" />.
    /// </summary>
    public bool MessageUnsubscribedEnabledDefault => MessageUnsubscribedEnabled ?? false;
}
