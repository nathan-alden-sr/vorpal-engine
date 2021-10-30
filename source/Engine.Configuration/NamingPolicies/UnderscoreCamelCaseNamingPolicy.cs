// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Text.Json;
using static TerraFX.Utilities.ExceptionUtilities;

namespace VorpalEngine.Engine.Configuration.NamingPolicies;

internal sealed class UnderscoreCamelCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        ThrowIfNull(name, nameof(name));

        return CamelCase.ConvertName(name.StartsWith('_') ? name.Remove(0, 1) : name);
    }
}