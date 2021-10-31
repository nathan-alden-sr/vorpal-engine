// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Text;

namespace VorpalEngine.Common;

/// <summary>Extension methods for the <see cref="Type" /> class.</summary>
public static class TypeExtensions
{
    /// <summary>Gets a type's name, optionally including generic arguments.</summary>
    /// <param name="type">A <see cref="Type" /> object.</param>
    /// <param name="fullName">A value indicating whether to include types' namespaces.</param>
    /// <param name="expandGenericArguments">A value indicating whether to include generic type arguments.</param>
    /// <returns>The type name.</returns>
    public static string GetTypeName(this Type type, bool fullName = false, bool expandGenericArguments = true)
    {
        ThrowIfNull(type, nameof(type));

        StringBuilder stringBuilder = new();

        if (expandGenericArguments)
        {
            TransformType(stringBuilder, type, fullName);
        }
        else
        {
            stringBuilder.Append(type.Name);
        }

        return stringBuilder.ToString();
    }

    private static void TransformType(StringBuilder stringBuilder, Type type, bool fullName)
    {
        if (fullName)
        {
            stringBuilder.Append($"{type.Namespace}.");
        }

        int backquoteIndex = type.Name.IndexOf('`');

        stringBuilder.Append(type.Name[..(backquoteIndex < 0 ? type.Name.Length : backquoteIndex)]);

        if (!type.IsGenericType)
        {
            return;
        }

        stringBuilder.Append('<');

        foreach (Type genericArgument in type.GetGenericArguments())
        {
            TransformType(stringBuilder, genericArgument, fullName);
        }

        stringBuilder.Append('>');
    }
}