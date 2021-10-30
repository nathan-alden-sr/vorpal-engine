// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System;
using System.Numerics;
using Silk.NET.Maths;
using TerraFX.Interop;
using static TerraFX.Interop.Windows;
using static TerraFX.Utilities.ExceptionUtilities;

namespace VorpalEngine.Common.Windows;

/// <summary>A Windows monitor.</summary>
public sealed class Monitor : IEquatable<Monitor>
{
    /// <summary>Initializes a new instance of the <see cref="Monitor" /> class.</summary>
    /// <param name="monitorHandle">The handle of the monitor.</param>
    /// <param name="deviceContextHandle">The device context (DC) handle of the monitor.</param>
    public unsafe Monitor(IntPtr monitorHandle, IntPtr deviceContextHandle)
    {
        if (monitorHandle == IntPtr.Zero)
        {
            ThrowArgumentException("Invalid monitor handle.", nameof(monitorHandle));
        }

        MonitorHandle = monitorHandle;

        MONITORINFOEXW monitorInfo =
            new()
            {
                Base =
                {
                    cbSize = (uint)sizeof(MONITORINFOEXW)
                }
            };

        ThrowIfZero(
            GetMonitorInfoW(monitorHandle, (MONITORINFO*)&monitorInfo),
            nameof(GetMonitorInfoW));

        RECT bounds = monitorInfo.Base.rcMonitor;
        RECT workingArea = monitorInfo.Base.rcWork;

        Bounds = bounds.ToRectangle<int>();
        WorkingArea = workingArea.ToRectangle<int>();
        Primary = (monitorInfo.Base.dwFlags & MONITORINFOF_PRIMARY) != 0;
        DeviceName = new string((char*)monitorInfo.szDevice);

        IntPtr screenDeviceContextHandle = deviceContextHandle;

        try
        {
            if (screenDeviceContextHandle == IntPtr.Zero)
            {
                ThrowIfZero(
                    screenDeviceContextHandle = CreateDCW(monitorInfo.szDevice, null, null, null),
                    nameof(CreateDCW));
            }

            BitsPerPixel = GetDeviceCaps(screenDeviceContextHandle, BITSPIXEL);
            BitsPerPixel *= GetDeviceCaps(screenDeviceContextHandle, PLANES);
        }
        finally
        {
            if (screenDeviceContextHandle != deviceContextHandle)
            {
                _ = DeleteDC(screenDeviceContextHandle);
            }
        }
    }

    /// <summary>Initializes a new instance of the <see cref="Monitor" /> class.</summary>
    /// <param name="monitorHandle">The handle of the monitor.</param>
    public Monitor(IntPtr monitorHandle) : this(monitorHandle, IntPtr.Zero)
    {
    }

    /// <summary>Gets the handle of the monitor.</summary>
    public IntPtr MonitorHandle { get; }

    /// <summary>Gets a <see cref="Rectangle{T}" /> representing the full size of the monitor's display area.</summary>
    public Rectangle<int> Bounds { get; }

    /// <summary>
    ///     Gets a <see cref="Rectangle{T}" /> representing the working area of the monitor's display area. Working area excludes
    ///     the Windows taskbar.
    /// </summary>
    public Rectangle<int> WorkingArea { get; }

    /// <summary>Gets a value indicating if the monitor is the primary monitor.</summary>
    public bool Primary { get; }

    /// <summary>Gets the name of the monitor device.</summary>
    public string DeviceName { get; }

    /// <summary>Gets the number of bits per pixel.</summary>
    public int BitsPerPixel { get; }

    /// <inheritdoc />
    public bool Equals(Monitor? other)
        => this == other;

    /// <summary>Creates a <see cref="Monitor" /> from a <see cref="Vector2" />.</summary>
    /// <param name="vector">The monitor containing this vector will be returned.</param>
    /// <returns>A <see cref="Monitor" /> whose bounds contain <paramref name="vector" />, defaulting to the nearest monitor.</returns>
    public static Monitor From(Vector2D<int> vector)
    {
        POINT point = new(vector.X, vector.Y);

        return new Monitor(MonitorFromPoint(point, MONITOR_DEFAULTTONEAREST));
    }

    /// <summary>Creates a <see cref="Monitor" /> from a <see cref="Vector2D{T}" />.</summary>
    /// <param name="rectangle">The monitor containing this rectangle will be returned.</param>
    /// <returns>A <see cref="Monitor" /> whose bounds contain <paramref name="rectangle" />, defaulting to the nearest monitor.</returns>
    public static unsafe Monitor From(Rectangle<int> rectangle)
    {
        var rect = rectangle.ToRECT();

        return new Monitor(MonitorFromRect(&rect, MONITOR_DEFAULTTONEAREST));
    }

    /// <summary>Creates a <see cref="Monitor" /> for a window handle.</summary>
    /// <param name="windowHandle">The monitor containing this rectangle will be returned.</param>
    /// <returns>The <see cref="Monitor" /> that <paramref name="windowHandle" /> is on, defaulting to the nearest monitor.</returns>
    public static Monitor From(HWND windowHandle)
    {
        if (windowHandle == HWND.NULL)
        {
            ThrowArgumentException("Invalid HWND.", nameof(windowHandle));
        }

        return new Monitor(MonitorFromWindow(windowHandle, MONITOR_DEFAULTTONEAREST));
    }

    /// <summary>Gets the working area of the monitor whose bounds contain <paramref name="vector" />.</summary>
    /// <param name="vector">The working area of the monitor containing this vector will be returned.</param>
    /// <returns>
    ///     A <see cref="Rectangle{T}" /> representing the working area of the monitor containing <paramref name="vector" />,
    ///     defaulting to the nearest monitor.
    /// </returns>
    public static Rectangle<int> GetWorkingArea(Vector2D<int> vector)
        => From(vector).WorkingArea;

    /// <summary>Gets the working area of the monitor whose bounds contain <paramref name="rectangle" />.</summary>
    /// <param name="rectangle">The working area of the monitor containing this rectangle will be returned.</param>
    /// <returns>
    ///     A <see cref="Rectangle{T}" /> representing the working area of the monitor containing <paramref name="rectangle" />,
    ///     defaulting to the nearest monitor.
    /// </returns>
    public static Rectangle<int> GetWorkingArea(Rectangle<int> rectangle)
        => From(rectangle).WorkingArea;

    /// <summary>Gets the bounds of the monitor whose bounds contain <paramref name="vector" />.</summary>
    /// <param name="vector">The bounds of the monitor containing this vector will be returned.</param>
    /// <returns>
    ///     A <see cref="Rectangle{T}" /> representing the bounds of the monitor containing <paramref name="vector" />, defaulting
    ///     to the nearest monitor.
    /// </returns>
    public static Rectangle<int> GetBounds(Vector2D<int> vector)
        => From(vector).Bounds;

    /// <summary>Gets the bounds of the monitor whose bounds contain <paramref name="rectangle" />.</summary>
    /// <param name="rectangle">The bounds of the monitor containing this rectangle will be returned.</param>
    /// <returns>
    ///     A <see cref="Rectangle{T}" /> representing the working area of the monitor containing <paramref name="rectangle" />,
    ///     defaulting to the nearest monitor.
    /// </returns>
    public static Rectangle<int> GetBounds(Rectangle<int> rectangle)
        => From(rectangle).Bounds;

    /// <inheritdoc />
    public override bool Equals(object? obj)
        => obj is Monitor monitor && this == monitor;

    /// <inheritdoc />
    public override int GetHashCode()
        => HashCode.Combine(MonitorHandle);

    /// <summary>Compares two <see cref="Monitor" /> objects to determine equality.</summary>
    /// <param name="left">The <see cref="Monitor" /> to compare with <paramref name="right" />.</param>
    /// <param name="right">The <see cref="Monitor" /> to compare with <paramref name="left" />.</param>
    /// <returns>
    ///     see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool operator ==(Monitor? left, Monitor? right)
        => left?.MonitorHandle == right?.MonitorHandle;

    /// <summary>Compares two <see cref="Monitor" /> objects to determine inequality.</summary>
    /// <param name="left">The <see cref="Monitor" /> to compare with <paramref name="right" />.</param>
    /// <param name="right">The <see cref="Monitor" /> to compare with <paramref name="left" />.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are not equal; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool operator !=(Monitor? left, Monitor? right)
        => !(left == right);
}