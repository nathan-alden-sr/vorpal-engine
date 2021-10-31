// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using VorpalEngine.Common;

namespace VorpalEngine.Input.Controller.XInput;

/// <summary>A factory for creating <see cref="IXInputControllerManager" /> objects.</summary>
public sealed class XInputControllerManagerFactory : IXInputControllerManagerFactory
{
    private readonly IXInputControllerRepository _xInputControllerRepository;

    /// <summary>Initializes a new instance of the <see cref="XInputControllerManagerFactory" /> class.</summary>
    /// <param name="xInputControllerRepository">An <see cref="IXInputControllerRepository" /> implementation.</param>
    public XInputControllerManagerFactory(IXInputControllerRepository xInputControllerRepository)
    {
        ThrowIfNull(xInputControllerRepository, nameof(xInputControllerRepository));

        _xInputControllerRepository = xInputControllerRepository;
    }

    /// <inheritdoc />
    public IXInputControllerManager Create(NestedContext context = default)
        => new XInputControllerManager(_xInputControllerRepository, context);
}