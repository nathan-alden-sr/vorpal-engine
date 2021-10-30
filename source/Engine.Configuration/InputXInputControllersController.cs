// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

namespace VorpalEngine.Engine.Configuration;

/// <summary>XInput controller configuration.</summary>
public sealed class InputXInputControllersController
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