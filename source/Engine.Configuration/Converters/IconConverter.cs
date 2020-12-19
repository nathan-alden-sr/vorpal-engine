using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using static NathanAldenSr.VorpalEngine.Common.AssertHelper;

namespace NathanAldenSr.VorpalEngine.Engine.Configuration.Converters
{
    /// <summary>Converts icons to and from base64-encoded strings.</summary>
    public class IconConverter : JsonConverter<Icon>
    {
        /// <summary>Reads an icon from a base64-encoded string.</summary>
        /// <inheritdoc />
        public override Icon Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? value = reader.GetString();

            AssertNotNull(value);

            byte[] bytes = Convert.FromBase64String(value);
            using var memoryStream = new MemoryStream(bytes);

            return new Icon(memoryStream);
        }

        /// <summary>Writes an icon to a base64-encoded string.</summary>
        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, Icon value, JsonSerializerOptions options)
        {
            using var stream = new MemoryStream();

            value.Save(stream);

            writer.WriteStringValue(Convert.ToBase64String(stream.ToArray()));
        }
    }
}