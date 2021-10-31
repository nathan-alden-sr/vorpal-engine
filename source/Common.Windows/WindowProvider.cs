// Copyright (c) Nathan Alden, Sr. and Contributors.
// Based on source code copyright (c) Tanner Gooding and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Runtime.InteropServices;
using TerraFX;
using TerraFX.Interop;
using TerraFX.Threading;
using static TerraFX.Interop.Windows;

namespace VorpalEngine.Common.Windows;

/// <summary>Creates <see cref="Window" /> objects.</summary>
/// <remarks>Based on source code from <a href="https://github.com/terrafx">TerraFX</a>.</remarks>
public sealed class WindowProvider : IDisposable
{
    private static readonly unsafe HINSTANCE ModuleHandle = GetModuleHandleW(null);
    private readonly IMonitorProvider _monitorProvider;
    private readonly ThreadLocal<Dictionary<HWND, Window>> _windowsByWindowHandle;
    private ValueLazy<ushort> _classAtom;
    private ValueLazy<GCHandle> _nativeHandle;
    private VolatileState _state;

    /// <summary>Initializes a new instance of the <see cref="WindowProvider" /> class.</summary>
    /// <param name="monitorProvider">An <see cref="IMonitorProvider" /> implementation.</param>
    public WindowProvider(IMonitorProvider monitorProvider)
    {
        ThrowIfNull(monitorProvider, nameof(monitorProvider));

        _monitorProvider = monitorProvider;
        _classAtom = new ValueLazy<ushort>(RegisterClass);
        _nativeHandle = new ValueLazy<GCHandle>(() => GCHandle.Alloc(this, GCHandleType.Normal));
        _windowsByWindowHandle = new ThreadLocal<Dictionary<HWND, Window>>(true);

        _state.Transition(VolatileState.Initialized);
    }

    /// <summary>Gets the class atom of the window.</summary>
    internal ushort ClassAtom
    {
        get
        {
            AssertNotDisposedOrDisposing(_state);

            return _classAtom.Value;
        }
    }

    /// <summary>Gets a native handle used to locate the provider during message processing.</summary>
    internal GCHandle NativeHandle
    {
        get
        {
            AssertNotDisposedOrDisposing(_state);

            return _nativeHandle.Value;
        }
    }

    /// <inheritdoc />
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <inheritdoc />
    ~WindowProvider()
    {
        Dispose(false);
    }

    /// <summary>Creates a new <see cref="Window" /> object.</summary>
    /// <param name="beforeCreationDelegate">
    ///     A delegate that can be used to configure the new <see cref="Window" /> object before the
    ///     window handle is created.
    /// </param>
    /// <param name="afterCreationDelegate">
    ///     A delegate that can be used to configure the new <see cref="Window" /> object after the
    ///     window handle is created.
    /// </param>
    /// <param name="beforeMessageProcessingDelegate">A delegate invoked before a message is processed.</param>
    /// <param name="afterMessageProcessingDelegate">A delegate invoked after a message is processed.</param>
    /// <returns>The new <see cref="Window" />.</returns>
    public Window CreateWindow(
        Action<Window>? beforeCreationDelegate = null,
        Action<Window>? afterCreationDelegate = null,
        WindowMessageHandlerDelegate? beforeMessageProcessingDelegate = null,
        WindowMessageHandlerDelegate? afterMessageProcessingDelegate = null)
    {
        AssertNotDisposedOrDisposing(_state);

        Dictionary<HWND, Window>? windowsByWindowHandle = _windowsByWindowHandle.Value;

        if (windowsByWindowHandle is null)
        {
            _windowsByWindowHandle.Value = windowsByWindowHandle = new Dictionary<HWND, Window>(4);
        }

        Window window = new(
            _monitorProvider,
            this,
            beforeCreationDelegate,
            window =>
            {
                window.ApplyWindowStyles();
                afterCreationDelegate?.Invoke(window);
            },
            beforeMessageProcessingDelegate,
            afterMessageProcessingDelegate);

        if (windowsByWindowHandle.TryAdd(window.Handle, window))
        {
            ThrowInvalidOperationException("Failed to track new window.");
        }

        return window;
    }

    /// <summary>Disposes the object.</summary>
    /// <param name="disposing">A value indicating whether to dispose only managed objects.</param>
    private void Dispose(bool disposing)
    {
        if (_state.BeginDispose() < VolatileState.Disposing)
        {
            DisposeWindows(disposing);
            DisposeClassAtom();
            DisposeNativeHandle();
        }

        _state.EndDispose();
    }

    private unsafe ushort RegisterClass()
    {
        AssertNotDisposedOrDisposing(_state);

        var className = $"{GetType().FullName}.{(long)(IntPtr)ModuleHandle:X16}.{GetHashCode():X8}";
        ushort classAtom;

        fixed (char* pClassName = className)
        {
            WNDCLASSEXW windowClass =
                new()
                {
                    cbClsExtra = 0,
                    cbSize = (uint)sizeof(WNDCLASSEXW),
                    cbWndExtra = 0,
                    hbrBackground = GetStockObject(BLACK_BRUSH),
                    hCursor = LoadCursorW(IntPtr.Zero, IDC_ARROW),
                    hIcon = IntPtr.Zero,
                    hIconSm = IntPtr.Zero,
                    hInstance = ModuleHandle,
                    lpfnWndProc = &WindowProc,
                    lpszClassName = (ushort*)pClassName,
                    lpszMenuName = null,
                    style = CS_OWNDC
                };

            classAtom = RegisterClassExW(&windowClass);
        }

        ThrowForLastErrorIfZero((uint)classAtom, nameof(RegisterClassExW));

        return classAtom;
    }

    [UnmanagedCallersOnly]
    private static nint WindowProc(IntPtr hWnd, uint uMsg, nuint wParam, nint lParam)
    {
        return WindowProcLocal(hWnd, uMsg, wParam, lParam);

        static unsafe nint WindowProcLocal(HWND hWnd, uint message, nuint wParam, nint lParam)
        {
            IntPtr userData;

            if (message == WM_CREATE)
            {
                /*
                 * Place the window provider's native handle into the new window's user data
                 * so it can be retrieved when processing subsequent messages.
                 */

                var createStruct = (CREATESTRUCTW*)lParam;

                userData = (IntPtr)createStruct->lpCreateParams;

                SetWindowLongPtrW(hWnd, GWLP_USERDATA, userData);
            }
            else
            {
                // Retrieve the window provider's native handle
                userData = GetWindowLongPtrW(hWnd, GWLP_USERDATA);
            }

            Dictionary<HWND, Window>? windowsByWindowHandle = null;
            Window? window = null;
            var forwardMessage = false;
            nint result;

            if (userData != IntPtr.Zero)
            {
                // Retrieve the window provider from the native handle

                var windowProvider = (WindowProvider)GCHandle.FromIntPtr(userData).Target!;

                windowsByWindowHandle = windowProvider._windowsByWindowHandle.Value;
                forwardMessage = windowsByWindowHandle?.TryGetValue(hWnd, out window) == true;
            }

            if (forwardMessage)
            {
                AssertNotNull(window);
                AssertNotNull(windowsByWindowHandle);

                result = window.HandleWindowMessage(message, wParam, lParam);

                if (message == WM_DESTROY)
                {
                    /*
                     * Forward WM_DESTROY to the corresponding window in case the window handle
                     * was destroyed externally.
                     */
                    RemoveWindow(windowsByWindowHandle, hWnd);
                }
            }
            else
            {
                result = DefWindowProcW(hWnd, message, wParam, lParam);
            }

            return result;
        }
    }

    private static Window RemoveWindow(Dictionary<HWND, Window> windowsByWindowHandle, HWND windowHandle)
    {
        windowsByWindowHandle.Remove(windowHandle, out Window? window);

        if (windowsByWindowHandle.Count == 0)
        {
            PostQuitMessage(0);
        }

        return window!;
    }

    private void DisposeWindows(bool disposing)
    {
        AssertDisposing(_state);

        if (!disposing)
        {
            return;
        }

        foreach (Dictionary<HWND, Window> windowsByWindowHandle in _windowsByWindowHandle.Values)
        {
            Dictionary<HWND, Window>.KeyCollection windowHandles = windowsByWindowHandle.Keys;

            foreach (HWND windowHandle in windowHandles)
            {
                RemoveWindow(windowsByWindowHandle, windowHandle).Dispose();
            }

            Assert(windowsByWindowHandle.Count == 0);
        }

        _windowsByWindowHandle.Dispose();
    }

    private unsafe void DisposeClassAtom()
    {
        AssertDisposing(_state);

        if (_classAtom.IsValueCreated && _classAtom.Value != 0)
        {
            _ = UnregisterClassW((ushort*)_classAtom.Value, ModuleHandle);
        }
    }

    private void DisposeNativeHandle()
    {
        AssertDisposing(_state);

        if (_nativeHandle.IsValueCreated)
        {
            _nativeHandle.Value.Free();
        }
    }
}