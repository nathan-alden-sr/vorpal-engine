// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using VorpalEngine.Common;

namespace VorpalEngine.Input.Controller.Hid;

/// <summary>A factory for creating <see cref="IHidControllerManager" /> objects.</summary>
public sealed class HidControllerManagerFactory : IHidControllerManagerFactory
{
    private readonly IHidControllerRepository _hidControllerRepository;

    /// <summary>Initializes a new instance of the <see cref="HidControllerManagerFactory" /> class.</summary>
    /// <param name="hidControllerRepository">An <see cref="IHidControllerRepository" /> implementation.</param>
    public HidControllerManagerFactory(IHidControllerRepository hidControllerRepository)
    {
        ThrowIfNull(hidControllerRepository, nameof(hidControllerRepository));

        _hidControllerRepository = hidControllerRepository;
    }

    /// <inheritdoc />
    public IHidControllerManager Create(NestedContext context = default) => new HidControllerManager(_hidControllerRepository, context);
}