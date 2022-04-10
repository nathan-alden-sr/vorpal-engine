// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using VorpalEngine.Common;

namespace VorpalEngine.Input.Controller.Hid;

/// <summary>A factory for creating <see cref="IHidControllerManager" /> objects.</summary>
public interface IHidControllerManagerFactory
{
    /// <summary>Creates an <see cref="IHidControllerManager" /> object.</summary>
    /// <param name="context">A nested context.</param>
    /// <returns>The new <see cref="IHidControllerManager" /> object.</returns>
    IHidControllerManager Create(NestedContext context = default);
}
