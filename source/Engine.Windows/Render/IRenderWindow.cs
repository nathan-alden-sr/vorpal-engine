using System;
using NathanAldenSr.VorpalEngine.Common.Windows;
using TerraFX.Interop;

namespace NathanAldenSr.VorpalEngine.Engine.Windows.Render
{
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
}