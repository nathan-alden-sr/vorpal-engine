// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Text;
using static TerraFX.Interop.Windows.ENABLE;
using static TerraFX.Interop.Windows.STD;
using static TerraFX.Interop.Windows.Windows;

namespace VorpalEngine.Samples.ConsoleHelpers;

public sealed unsafe class ConsoleHelper
{
    private readonly int _bufferHeight;
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    private readonly Queue<ConsoleContent> _contents = new();
    private readonly StringBuilder _stringBuilder = new();
    private readonly int _width;

    public ConsoleHelper(string title, int width, int windowHeight, int bufferHeight)
    {
        ThrowIfNull(title);

        _width = width;
        _bufferHeight = bufferHeight;

        var standardOutputHandle = GetStdHandle(STD_OUTPUT_HANDLE);
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

    public void Clear()
        => _contents.Clear();

    public void WriteLine(string content = "")
        => WriteLine(new ConsoleContent(content));

    public void WriteLine(ConsoleContent content)
    {
        ThrowIfNull(content);

        if (_contents.Count == _bufferHeight)
        {
            _ = _contents.Dequeue();
        }

        _contents.Enqueue(content);
    }

    public void Render()
    {
        _ = _stringBuilder.Clear();

        void Append(string text = "")
            => _ = _stringBuilder.Append(text);

        Console.SetCursorPosition(0, 0);

        // Write each line of content
        while (_contents.TryDequeue(out var content))
        {
            Append(content.Copy().PadRight(_width).Render());
        }

        Console.SetCursorPosition(0, 0);
        Console.Out.Write(_stringBuilder);
    }
}
