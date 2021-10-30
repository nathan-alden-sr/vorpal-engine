// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

namespace VorpalEngine.Engine.Configuration;

/// <summary>Display modes the render window can be configured to use.</summary>
public enum DisplayMode
{
    /// <summary>The render window has a resizable border, window controls, and a title bar.</summary>
    Bordered,

    /// <summary>
    ///     The render window does not have a border, window controls, or a title bar. The render window expands to fill the screen
    ///     it's on.
    /// </summary>
    BorderlessFullscreen
}