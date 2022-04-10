// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Diagnostics;
using System.Text;

namespace VorpalEngine.Samples.ConsoleHelpers;

[DebuggerDisplay($"{{{nameof(DebuggerDisplay)},nq}}")]
public sealed class ConsoleContent
{
    private readonly StringBuilder _stringBuilder = new();
    private int _visibleLength;

    public ConsoleContent(string text = "")
    {
        _ = Text(text);
    }

    public ConsoleContent(ConsoleContent content)
    {
        ThrowIfNull(content);

        _ = _stringBuilder.Append(content._stringBuilder);
        _visibleLength = content._visibleLength;
    }

    private string DebuggerDisplay
        => Render();

    public string Render()
        => _stringBuilder.ToString();

    public ConsoleContent Text(string text)
    {
        ThrowIfNull(text);

        _ = _stringBuilder.Append(text);
        _visibleLength += text.Length;

        return this;
    }

    public ConsoleContent PadRight(int width)
    {
        _ = _stringBuilder.Append(new string(' ', Math.Max(0, width - _visibleLength)));

        return this;
    }

    public ConsoleContent FormatText(TextFormat format)
    {
        _ = _stringBuilder.Append($"\x1B[{(int)format}m");

        return this;
    }

    public ConsoleContent Copy()
        => new(this);
}
