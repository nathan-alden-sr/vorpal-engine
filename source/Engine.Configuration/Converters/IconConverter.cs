// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;
using VorpalEngine.Common;

namespace VorpalEngine.Engine.Configuration.Converters;

/// <summary>Converts icons to and from base64-encoded strings.</summary>
internal sealed class IconConverter : JsonConverter<Icon>
{
    /// <summary>Reads an icon from a base64-encoded string.</summary>
    /// <inheritdoc />
    public override Icon Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var bytes = reader.GetBytesFromBase64();
        using var memoryStream = MemoryStreamUtilities.RecyclableMemoryStreamManager.GetStream(bytes);

        return new Icon(memoryStream);
    }

    /// <summary>Writes an icon to a base64-encoded string.</summary>
    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, Icon value, JsonSerializerOptions options)
    {
        ThrowIfNull(writer);
        ThrowIfNull(value);

        using var stream = MemoryStreamUtilities.RecyclableMemoryStreamManager.GetStream();

        value.Save(stream);

        writer.WriteBase64StringValue(stream.ToArray());
    }
}
