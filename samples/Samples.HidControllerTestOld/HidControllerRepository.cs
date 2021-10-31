// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using VorpalEngine.Input.Controller.Hid;

namespace VorpalEngine.Samples.HidControllerTest;

public sealed class HidControllerRepository : IHidControllerRepository
{
    private readonly Dictionary<(string?, string?, string?), uint> _controllers = new();

    public (uint index, bool? enabled, bool enabledDefault) AddHidController(string? manufacturer, string? productName, string? serialNumber)
    {
        if (_controllers.TryGetValue((manufacturer, productName, serialNumber), out uint index))
        {
            return (index, true, true);
        }

        index = (uint)_controllers.Count;

        _controllers.Add((manufacturer, productName, serialNumber), index);

        return (index, true, true);
    }
}