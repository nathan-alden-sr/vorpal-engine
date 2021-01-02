using System;
using System.Diagnostics;
using System.Text;

namespace NathanAldenSr.VorpalEngine.Samples.ConsoleHelpers
{
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class ConsoleContent
    {
        private readonly StringBuilder _stringBuilder = new();
        private int _visibleLength;

        public ConsoleContent(string text = "")
        {
            Text(text);
        }

        public ConsoleContent(ConsoleContent content)
        {
            _stringBuilder.Append(content._stringBuilder);
            _visibleLength = content._visibleLength;
        }

        private string DebuggerDisplay => Render();

        public string Render() => _stringBuilder.ToString();

        public ConsoleContent Text(string text)
        {
            _stringBuilder.Append(text);
            _visibleLength += text.Length;

            return this;
        }

        public ConsoleContent PadRight(int width)
        {
            _stringBuilder.Append(new string(' ', Math.Max(0, width - _visibleLength)));

            return this;
        }

        public ConsoleContent FormatText(TextFormat format)
        {
            _stringBuilder.Append($"\x1B[{(int)format}m");

            return this;
        }

        public ConsoleContent Copy() => new(this);
    }
}