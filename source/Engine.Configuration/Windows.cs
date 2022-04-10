// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace VorpalEngine.Engine.Configuration;

/// <summary>Window configuration.</summary>
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("Style", "IDE1006:Naming Styles")]
public sealed class Windows
{
    /// <summary>Gets or sets render window configuration. Use <see cref="Render" /> for finer-grained control over this property.</summary>
    [JsonInclude]
    public WindowsRender? _Render { get; private set; }

    /// <summary>
    ///     Gets the keyboard configuration, optionally initializing the <see cref="_Render" /> property to an instance of
    ///     <see cref="WindowsRender" />.
    /// </summary>
    /// <param name="initialize">
    ///     A value determining whether to initialize a <see langword="null" /> <see cref="_Render" /> property
    ///     value with an instance of <see cref="WindowsRender" />.
    /// </param>
    /// <returns>
    ///     An <see cref="WindowsRender" /> object. If <paramref name="initialize" /> is <see langword="true" />, the
    ///     <see cref="_Render" /> property value was set to the returned object; otherwise, the returned reference should be considered
    ///     temporary.
    /// </returns>
    public WindowsRender Render(bool initialize = false)
        => initialize ? _Render ??= new WindowsRender() : _Render ?? new WindowsRender();
}
