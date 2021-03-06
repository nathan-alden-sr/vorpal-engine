using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static TerraFX.Interop.Windows;

namespace NathanAldenSr.VorpalEngine.Samples.ConsoleHelpers
{
    public unsafe class ConsoleHelper
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new();
        private readonly Queue<ConsoleContent> _contents = new();
        private readonly int _bufferHeight;
        private readonly StringBuilder _stringBuilder = new();
        private readonly int _width;

        public ConsoleHelper(string title, int width, int windowHeight, int bufferHeight)
        {
            _width = width;
            _bufferHeight = bufferHeight;

            IntPtr standardOutputHandle = GetStdHandle(STD_OUTPUT_HANDLE);
            uint dwMode;

            _ = GetConsoleMode(standardOutputHandle, &dwMode);

            dwMode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING;

            _ = SetConsoleMode(standardOutputHandle, dwMode);

            Console.Title = title;
            Console.CursorVisible = false;
            Console.SetWindowSize(width, windowHeight);
            Console.SetBufferSize(width, bufferHeight);

            Console.CancelKeyPress += (_, _) => _cancellationTokenSource.Cancel();
        }

        public bool IsCanceled => _cancellationTokenSource.IsCancellationRequested;

        public void Clear() => _contents.Clear();

        public void WriteLine(string content = "")
        {
            WriteLine(new ConsoleContent(content));
        }

        public void WriteLine(ConsoleContent content)
        {
            if (_contents.Count == _bufferHeight)
            {
                _contents.Dequeue();
            }

            _contents.Enqueue(content);
        }

        public void Render()
        {
            _stringBuilder.Clear();

            void Append(string text = "")
            {
                _stringBuilder.Append(text);
            }

            Console.SetCursorPosition(0, 0);

            // Write each line of content
            while (_contents.TryDequeue(out ConsoleContent? content))
            {
                Append(content.Copy().PadRight(_width).Render());
            }

            Console.SetCursorPosition(0, 0);
            Console.Out.Write(_stringBuilder);
        }
    }
}