// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Diagnostics.CodeAnalysis;
using TerraFX.Interop.Windows;

namespace VorpalEngine.Input.Controller.Hid;

/// <summary>Represents the management of HID controller input.</summary>
public interface IHidControllerManager
{
    /// <summary>Gets a collection of HID controller indexes that can have their states changes queried.</summary>
    IReadOnlyCollection<uint> StateChangeIndexes { get; }

    /// <summary>Updates the HID controller state with data from Raw Input.</summary>
    /// <param name="rawInput">The new Raw Input data with which the HID controller state will be updated.</param>
    unsafe void UpdateState(RAWINPUT* rawInput);

    /// <summary>Attempts to retrieve the state of a HID controller.</summary>
    /// <param name="index">The index of the HID controller to query state changes for.</param>
    /// <param name="controller">The HID controller.</param>
    /// <param name="state">An <see cref="HidControllerState" /> object that will contain the HID controller state.</param>
    /// <returns><see langword="true" /> if state was successfully retrieved; otherwise, <see langword="false" />.</returns>
    bool TryGetState(uint index, [NotNullWhen(true)] out IHidController? controller, out HidControllerState state);

    /// <summary>Removes a HID controller from the cache.</summary>
    /// <param name="index">The index of the HID Input controller to remove from the cache.</param>
    void InvalidateController(uint index);
}
