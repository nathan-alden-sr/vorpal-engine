// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Data;
using static TerraFX.Utilities.ExceptionUtilities;

namespace VorpalEngine.Samples.ConsoleHelpers;

public static class PropertyCollectionExtensions
{
    public static void Add(this PropertyCollection propertyCollection, (object Key, object? Value) item)
    {
        ThrowIfNull(propertyCollection, nameof(propertyCollection));

        propertyCollection.Add(item.Key, item.Value);
    }
}