// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

namespace VorpalEngine.Input.Controller.XInput;

/// <summary>Represents a repository of XInput controllers.</summary>
public interface IXInputControllerRepository
{
    /// <summary>Adds an XInput controller to the repository if it has not already been added.</summary>
    /// <returns>A tuple containing values indicating whether the controller is enabled.</returns>
    (bool? enabled, bool enabledDefault) AddXInputController(byte index);
}
