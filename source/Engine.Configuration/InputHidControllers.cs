// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using VorpalEngine.Configuration;

namespace VorpalEngine.Engine.Configuration;

/// <summary>HID controllers configuration.</summary>
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("Style", "IDE1006:Naming Styles")]
public sealed class InputHidControllers
{
    private IList<InputHidControllersController>? _controllers;

    /// <summary>Gets or sets a value determining whether HID controller input will be processed.</summary>
    public bool? Enabled { get; set; }

    /// <summary>
    ///     Gets the value of the <see cref="Enabled" /> property assuming a particular default if <see cref="Enabled" /> is
    ///     <see langword="null" />.
    /// </summary>
    public bool EnabledDefault => Enabled ?? true;

    /// <summary>
    ///     Gets a list of HID controller configurations. Use <see cref="Controllers" /> to support automatically serializing an
    ///     empty list as <see langword="null" />.
    /// </summary>
    [JsonInclude]
    public IList<InputHidControllersController>? _Controllers { get; private set; }

    /// <summary>Gets a list of HID controller configurations.</summary>
    /// <returns>A list of <see cref="InputHidControllersController" /> objects.</returns>
    public IList<InputHidControllersController> Controllers()
        => _controllers ??= new NullWhenEmptyList<InputHidControllersController>(() => _Controllers, a => _Controllers = a);
}