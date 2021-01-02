using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using TerraFX.Interop;
using static NathanAldenSr.VorpalEngine.Common.AssertHelper;
using static NathanAldenSr.VorpalEngine.Common.State;
using static NathanAldenSr.VorpalEngine.Common.Windows.ExceptionHelper;
using static TerraFX.Interop.Windows;

namespace NathanAldenSr.VorpalEngine.Common.Windows
{
    /// <summary>Creates <see cref="Window" /> objects.</summary>
    /// <remarks>Inspired by <a href="https://github.com/terrafx">TerraFX</a>.</remarks>
    public class WindowProvider : IDisposable
    {
        private static readonly unsafe HINSTANCE ModuleHandle = GetModuleHandleW(null);
        private readonly IMonitorProvider _monitorProvider;
        private readonly ThreadLocal<Dictionary<HWND, Window>> _windowsByWindowHandle;
        private ValueLazy<ushort> _classAtom;
        private ValueLazy<GCHandle> _nativeHandle;
        private State _state;

        /// <summary>Initializes a new instance of the <see cref="WindowProvider" /> class.</summary>
        /// <param name="monitorProvider">An <see cref="IMonitorProvider" /> implementation.</param>
        public WindowProvider(IMonitorProvider monitorProvider)
        {
            _monitorProvider = monitorProvider;
            _classAtom = new ValueLazy<ushort>(RegisterClass);
            _nativeHandle = new ValueLazy<GCHandle>(() => GCHandle.Alloc(this, GCHandleType.Normal));
            _windowsByWindowHandle = new ThreadLocal<Dictionary<HWND, Window>>(true);

            _state.Transition(Initialized);
        }

        /// <summary>Gets the class atom of the window.</summary>
        internal ushort ClassAtom
        {
            get
            {
                _state.ThrowIfDisposingOrDisposed();

                return _classAtom.Value;
            }
        }

        /// <summary>Gets a native handle used to locate the provider during message processing.</summary>
        internal GCHandle NativeHandle
        {
            get
            {
                _state.ThrowIfDisposingOrDisposed();

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
        /// <param name="beforeCreationDelegate">A delegate that can be used to configure the returned <see cref="Window" /> object.</param>
        /// <param name="beforeMessageProcessingDelegate">A delegate invoked before a message is processed.</param>
        /// <param name="afterMessageProcessingDelegate">A delegate invoked after a message is processed.</param>
        /// <returns>The new <see cref="Window" />.</returns>
        public Window CreateWindow(
            Action<Window>? beforeCreationDelegate = null,
            WindowMessageHandlerDelegate? beforeMessageProcessingDelegate = null,
            WindowMessageHandlerDelegate? afterMessageProcessingDelegate = null)
        {
            _state.ThrowIfDisposingOrDisposed();

            Dictionary<HWND, Window>? windowsByWindowHandle = _windowsByWindowHandle.Value;

            if (windowsByWindowHandle is null)
            {
                _windowsByWindowHandle.Value = windowsByWindowHandle = new Dictionary<HWND, Window>(4);
            }

            var window = new Window(_monitorProvider, this, beforeCreationDelegate, beforeMessageProcessingDelegate, afterMessageProcessingDelegate);

            Assert(windowsByWindowHandle.TryAdd(window.Handle, window), "Failed to track new window.");

            window.ApplyWindowStyles(window.Handle);

            return window;
        }

        /// <summary>Disposes the object.</summary>
        /// <param name="disposing">A value indicating whether to dispose only managed objects.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_state.BeginDispose() < Disposing)
            {
                DisposeWindows(disposing);
                DisposeClassAtom();
                DisposeNativeHandle();
            }

            _state.EndDispose();
        }

        private unsafe ushort RegisterClass()
        {
            _state.AssertNeitherDisposingNorDisposed();

            var className = $"{GetType().FullName}.{(long)(IntPtr)ModuleHandle:X16}.{GetHashCode():X8}";
            ushort classAtom;

            fixed (char* pClassName = className)
            {
                var wndProc = (delegate* unmanaged<IntPtr, uint, nuint, nint, nint>)&WindowProc;
                var windowClass =
                    new WNDCLASSEXW
                    {
                        cbClsExtra = 0,
                        cbSize = (uint)sizeof(WNDCLASSEXW),
                        cbWndExtra = 0,
                        hbrBackground = GetStockObject(BLACK_BRUSH),
                        hCursor = LoadCursorW(IntPtr.Zero, IDC_ARROW),
                        hIcon = IntPtr.Zero,
                        hIconSm = IntPtr.Zero,
                        hInstance = ModuleHandle,
                        lpfnWndProc = wndProc,
                        lpszClassName = (ushort*)pClassName,
                        lpszMenuName = null,
                        style = CS_OWNDC
                    };

                classAtom = RegisterClassExW(&windowClass);
            }

            if (classAtom == 0)
            {
                ThrowExternalExceptionForLastWin32Error(nameof(RegisterClassExW));
            }

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

                WindowProvider? windowProvider = null;
                Dictionary<HWND, Window>? windowsByWindowHandle = null;
                Window? window = null;
                var forwardMessage = false;
                nint result;

                if (userData != IntPtr.Zero)
                {
                    // Retrieve the window provider from the native handle
                    windowProvider = (WindowProvider)GCHandle.FromIntPtr(userData).Target!;
                    windowsByWindowHandle = windowProvider._windowsByWindowHandle.Value;
                    forwardMessage = windowsByWindowHandle?.TryGetValue(hWnd, out window) == true;
                }

                if (forwardMessage)
                {
                    AssertNotNull(window, nameof(window));
                    AssertNotNull(windowsByWindowHandle, nameof(windowsByWindowHandle));

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
            _state.AssertDisposing();

            if (!disposing)
            {
                return;
            }

            foreach (Dictionary<HWND, Window> windowsByWindowHandle in _windowsByWindowHandle.Values)
            {
                var windowHandles = windowsByWindowHandle.Keys;

                foreach (HWND windowHandle in windowHandles)
                {
                    RemoveWindow(windowsByWindowHandle, windowHandle).Dispose();
                }

                Assert(
                    windowsByWindowHandle.Count == 0,
                    a => a.Message("Some windows were not removed.").Parameter(nameof(windowsByWindowHandle.Count), windowsByWindowHandle.Count));
            }

            _windowsByWindowHandle.Dispose();
        }

        private unsafe void DisposeClassAtom()
        {
            _state.AssertDisposing();

            if (_classAtom.IsCreated && _classAtom.Value != 0)
            {
                _ = UnregisterClassW((ushort*)_classAtom.Value, ModuleHandle);
            }
            _classAtom.Dispose();
        }

        private void DisposeNativeHandle()
        {
            _state.AssertDisposing();

            if (_nativeHandle.IsCreated)
            {
                _nativeHandle.Value.Free();
            }
            _nativeHandle.Dispose();
        }
    }
}