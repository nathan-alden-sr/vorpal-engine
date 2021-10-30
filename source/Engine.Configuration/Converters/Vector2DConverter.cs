// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Silk.NET.Maths;

namespace VorpalEngine.Engine.Configuration.Converters;

internal sealed class Vector2DConverter<T> : JsonConverter<Vector2D<T>>
    where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
{
    public override bool HandleNull => false;

    public override Vector2D<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var vector2D = JsonSerializer.Deserialize<Vector2D>(ref reader, options);

        return new Vector2D<T>(vector2D.X, vector2D.Y);
    }

    public override void Write(Utf8JsonWriter writer, Vector2D<T> value, JsonSerializerOptions options)
    {
        var vector2D = new Vector2D(value.X, value.Y);

        JsonSerializer.Serialize(writer, vector2D, options);
    }

    private struct Vector2D
    {
        public Vector2D(T x, T y)
        {
            X = x;
            Y = y;
        }

        public T X { get; set; }
        public T Y { get; set; }
    }
}