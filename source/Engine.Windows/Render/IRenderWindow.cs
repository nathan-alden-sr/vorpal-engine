// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using TerraFX.Interop.Windows;
using VorpalEngine.Common.Windows;

namespace VorpalEngine.Engine.Windows.Render;

/// <summary>Represents a Windows window that renders the game and receives input messages.</summary>
public interface IRenderWindow : IDisposable
{
    /// <inheritdoc cref="Window.Handle" />
    HWND Handle { get; }

    /// <inheritdoc cref="Window.IsActive" />
    bool IsActive { get; }

    /// <inheritdoc cref="Window.Title" />
    string Title { get; set; }

    /// <summary>Gets or sets the display mode.</summary>
    DisplayMode DisplayMode { get; set; }

    /// <summary>Invoked when a window message is received.</summary>
    event WindowMessageReceivedDelegate? WindowMessageReceived;

    /// <inheritdoc cref="Window.Show" />
    void Show();
}
