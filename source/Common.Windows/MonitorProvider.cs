// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Runtime.InteropServices;
using TerraFX.Interop.Windows;
using static TerraFX.Interop.Windows.Windows;

namespace VorpalEngine.Common.Windows;

/// <summary>Queries Windows for monitors currently attached to the primary graphics device.</summary>
public sealed class MonitorProvider : IMonitorProvider
{
    private readonly object _lockObject = new();
    private readonly HashSet<Monitor> _monitors = new();

    /// <summary>
    ///     Initializes a new instance of the <see cref="MonitorProvider" /> class. The monitor list will be populated after the
    ///     constructor is executed.
    /// </summary>
    public MonitorProvider()
    {
        Refresh();
    }

    /// <inheritdoc />
    public IReadOnlySet<Monitor> Monitors
    {
        get
        {
            lock (_lockObject)
            {
                return _monitors.ToImmutableHashSet();
            }
        }
    }

    /// <inheritdoc />
    public Monitor? PrimaryMonitor
    {
        get
        {
            lock (_lockObject)
            {
                return _monitors.SingleOrDefault(a => a.Primary);
            }
        }
    }

    /// <inheritdoc />
    public unsafe void Refresh()
    {
        lock (_lockObject)
        {
            _monitors.Clear();

            var monitorsHandle = GCHandle.Alloc(_monitors);

            try
            {
                ThrowIfZero(EnumDisplayMonitors(HDC.NULL, null, &MonitorEnumProc, GCHandle.ToIntPtr(monitorsHandle)));
            }
            finally
            {
                monitorsHandle.Free();
            }
        }
    }

    [UnmanagedCallersOnly]
    private static unsafe BOOL MonitorEnumProc(HMONITOR param0, HDC param1, RECT* param2, LPARAM param3)
    {
        var monitors = (HashSet<Monitor>)GCHandle.FromIntPtr(param3).Target!;

        _ = monitors.Add(new Monitor(param0, param1));

        return BOOL.TRUE;
    }
}
