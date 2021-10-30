// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

namespace VorpalEngine.Input.Mouse.Legacy;

/// <summary>Represents mouse input management based on legacy window messages.</summary>
public interface ILegacyMouseManager : IMouseManager
{
    /// <summary>Updates the mouse state due to a received <c>WM_MOUSEMOVE</c> message.</summary>
    /// <param name="lParam">The <c>WM_MOUSEMOVE</c> <c>LPARAM</c> data containing the mouse cursor location.</param>
    void UpdateStateFromWmMouseMove(nint lParam);

    /// <summary>Updates the mouse state due to a received <c>WM_LBUTTONDOWN</c> message.</summary>
    void UpdateStateFromWmLButtonDown();

    /// <summary>Updates the mouse state due to a received <c>WM_LBUTTONUP</c> message.</summary>
    void UpdateStateFromWmLButtonUp();

    /// <summary>Updates the mouse state due to a received <c>WM_MBUTTONDOWN</c> message.</summary>
    void UpdateStateFromWmMButtonDown();

    /// <summary>Updates the mouse state due to a received <c>WM_MBUTTONUP</c> message.</summary>
    void UpdateStateFromWmMButtonUp();

    /// <summary>Updates the mouse state due to a received <c>WM_RBUTTONDOWN</c> message.</summary>
    void UpdateStateFromWmRButtonDown();

    /// <summary>Updates the mouse state due to a received <c>WM_RBUTTONUP</c> message.</summary>
    void UpdateStateFromWmRButtonUp();

    /// <summary>Updates the mouse state due to a received <c>WM_XBUTTONDOWN</c> message.</summary>
    void UpdateStateFromWmXButtonDown(nuint wParam);

    /// <summary>Updates the mouse state due to a received <c>WM_XBUTTONUP</c> message.</summary>
    void UpdateStateFromWmXButtonUp(nuint wParam);

    /// <summary>Updates the mouse state due to a received <c>WM_MOUSEWHEEL</c> message.</summary>
    /// <param name="wParam">The <c>WM_MOUSEWHEEL</c> <c>WPARAM</c> data containing the delta.</param>
    void UpdateStateFromWmMouseWheel(nuint wParam);

    /// <summary>Updates the mouse state due to a received <c>WM_MOUSEHWHEEL</c> message.</summary>
    /// <param name="wParam">The <c>WM_MOUSEHWHEEL</c> <c>WPARAM</c> data containing the delta.</param>
    void UpdateStateFromWmMouseHWheel(nuint wParam);
}