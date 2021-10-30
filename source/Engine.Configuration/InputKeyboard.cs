// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

namespace VorpalEngine.Engine.Configuration;

/// <summary>Keyboard configuration.</summary>
public sealed class InputKeyboard
{
    /// <summary>Gets or sets a value determining whether keyboard input will be processed.</summary>
    public bool? Enabled { get; set; }

    /// <summary>
    ///     Gets the value of the <see cref="Enabled" /> property assuming a particular default if <see cref="Enabled" /> is
    ///     <see langword="null" />.
    /// </summary>
    public bool EnabledDefault => Enabled ?? true;
}