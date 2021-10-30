// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using VorpalEngine.Common;
using static TerraFX.Utilities.ExceptionUtilities;

namespace VorpalEngine.Engine.Configuration.Converters;

/// <summary>Converts icons to and from base64-encoded strings.</summary>
internal sealed class IconConverter : JsonConverter<Icon>
{
    /// <summary>Reads an icon from a base64-encoded string.</summary>
    /// <inheritdoc />
    public override Icon Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        byte[] bytes = reader.GetBytesFromBase64();
        using MemoryStream memoryStream = MemoryStreamUtilities.RecyclableMemoryStreamManager.GetStream(bytes);

        return new Icon(memoryStream);
    }

    /// <summary>Writes an icon to a base64-encoded string.</summary>
    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, Icon value, JsonSerializerOptions options)
    {
        ThrowIfNull(writer, nameof(writer));
        ThrowIfNull(value, nameof(value));

        using MemoryStream stream = MemoryStreamUtilities.RecyclableMemoryStreamManager.GetStream();

        value.Save(stream);

        writer.WriteBase64StringValue(stream.ToArray());
    }
}