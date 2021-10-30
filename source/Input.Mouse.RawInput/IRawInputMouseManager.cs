// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using TerraFX.Interop;

namespace VorpalEngine.Input.Mouse.RawInput;

/// <summary>Represents mouse input management based on Raw Input.</summary>
public interface IRawInputMouseManager : IMouseManager
{
    /// <summary>Updates the mouse state with data from Raw Input.</summary>
    /// <param name="rawInput">The new Raw Input data with which the mouse state will be updated.</param>
    unsafe void UpdateState(RAWINPUT* rawInput);
}