// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using VorpalEngine.Common.Messaging;
using static TerraFX.Utilities.ExceptionUtilities;

namespace VorpalEngine.Common.Windows.Messages;

/// <summary>Indicates the monitor the render window is primarily located on has changed.</summary>
public readonly struct MonitorChangedMessage : IMessage
{
    /// <summary>Initializes a new instance of the <see cref="MonitorChangedMessage" /> struct.</summary>
    /// <param name="oldMonitor">The old monitor. A <see langword="null" /> value means the old monitor is unknown.</param>
    /// <param name="newMonitor">The new monitor.</param>
    public MonitorChangedMessage(Monitor? oldMonitor, Monitor newMonitor)
    {
        ThrowIfNull(newMonitor, nameof(newMonitor));

        OldMonitor = oldMonitor;
        NewMonitor = newMonitor;
    }

    /// <summary>Gets the old monitor. A <see langword="null" /> value means the old monitor is unknown.</summary>
    public Monitor? OldMonitor { get; }

    /// <summary>Gets the new monitor.</summary>
    public Monitor NewMonitor { get; }

    /// <inheritdoc />
    public string Description
        => OldMonitor is not null
               ? $"Monitor changed from {GetDescription(OldMonitor)} to {GetDescription(NewMonitor)}"
               : $"Monitor changed to {GetDescription(NewMonitor)}";

    private static string GetDescription(Monitor monitor)
        => $"{monitor.DeviceName} {monitor.WorkingArea.Size.X}w {monitor.WorkingArea.Size.Y}h {monitor.BitsPerPixel}bpp";
}