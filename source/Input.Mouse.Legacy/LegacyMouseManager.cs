// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using Silk.NET.Maths;
using static TerraFX.Interop.Windows.Windows;

namespace VorpalEngine.Input.Mouse.Legacy;

/// <summary>Manages mouse input based on legacy window messages.</summary>
public sealed class LegacyMouseManager : MouseManager, ILegacyMouseManager
{
    private Vector2D<int>? _oldLocation;

    /// <inheritdoc />
    public void UpdateStateFromWmMouseMove(nint lParam)
    {
        var newLocation = new Vector2D<int>(LOWORD((uint)lParam), HIWORD((uint)lParam));

        if (_oldLocation is not null)
        {
            RelativeLocationXDelta += newLocation.X - _oldLocation.Value.X;
            RelativeLocationYDelta += newLocation.Y - _oldLocation.Value.Y;
        }

        _oldLocation = newLocation;
    }

    /// <inheritdoc />
    public void UpdateStateFromWmLButtonDown()
        => SetButtonDown(Button.Left, true);

    /// <inheritdoc />
    public void UpdateStateFromWmLButtonUp()
        => SetButtonDown(Button.Left, false);

    /// <inheritdoc />
    public void UpdateStateFromWmMButtonDown()
        => SetButtonDown(Button.Middle, true);

    /// <inheritdoc />
    public void UpdateStateFromWmMButtonUp()
        => SetButtonDown(Button.Middle, false);

    /// <inheritdoc />
    public void UpdateStateFromWmRButtonDown()
        => SetButtonDown(Button.Right, true);

    /// <inheritdoc />
    public void UpdateStateFromWmRButtonUp()
        => SetButtonDown(Button.Right, false);

    /// <inheritdoc />
    public void UpdateStateFromWmXButtonDown(nuint wParam)
    {
        switch (HIWORD((uint)wParam))
        {
            case XBUTTON1:
                SetButtonDown(Button.X1, true);
                break;
            case XBUTTON2:
                SetButtonDown(Button.X2, true);
                break;
        }
    }

    /// <inheritdoc />
    public void UpdateStateFromWmXButtonUp(nuint wParam)
    {
        switch (HIWORD((uint)wParam))
        {
            case XBUTTON1:
                SetButtonDown(Button.X1, false);
                break;
            case XBUTTON2:
                SetButtonDown(Button.X2, false);
                break;
        }
    }

    /// <inheritdoc />
    public void UpdateStateFromWmMouseWheel(nuint wParam)
        => RelativeWheelDelta += unchecked((short)HIWORD((uint)wParam));

    /// <inheritdoc />
    public void UpdateStateFromWmMouseHWheel(nuint wParam)
        => RelativeHorizontalWheelDelta += unchecked((short)HIWORD((uint)wParam));
}
