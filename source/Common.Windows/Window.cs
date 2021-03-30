using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using TerraFX.Interop;
using static NathanAldenSr.VorpalEngine.Common.AssertHelper;
using static NathanAldenSr.VorpalEngine.Common.ExceptionHelper;
using static NathanAldenSr.VorpalEngine.Common.State;
using static NathanAldenSr.VorpalEngine.Common.Windows.ExceptionHelper;
using static TerraFX.Interop.Windows;

namespace NathanAldenSr.VorpalEngine.Common.Windows
{
    /// <summary>Represents a Windows window.</summary>
    /// <remarks>Inspired by <a href="https://github.com/terrafx">TerraFX</a>.</remarks>
    public class Window : IDisposable
    {
        private static readonly unsafe HINSTANCE ModuleHandle = GetModuleHandleW(null);
        private static readonly Size SmallIconSize = new(GetSystemMetrics(SM_CXSMICON), GetSystemMetrics(SM_CYSMICON));
        private readonly WindowMessageHandlerDelegate? _afterMessageHandledDelegate;
        private readonly Action<Window>? _beforeCreationDelegate;
        private readonly WindowMessageHandlerDelegate? _beforeMessageHandledDelegate;
        private readonly IMonitorProvider _monitorProvider;
        private readonly Thread _ownerThread;
        private readonly WindowProvider _windowProvider;
        private bool _allowMaximize = true;
        private bool _allowMinimize = true;
        private BorderStyle _borderStyle;
        private bool _captionVisible = true;
        private Rectangle<int> _clientBounds = Rectangle<int>.Empty;
        private bool _controlsVisible = true;
        private Icon? _icon;
        private bool _iconVisible = true;
        private Rectangle<int> _nonClientBounds = Rectangle<int>.Empty;
        private Icon? _smallIcon;
        private State _state;
        private string _title = "";
        private uint _windowExStyles;
        private ValueLazy<HWND> _windowHandle;
        private WindowState _windowState = WindowState.Restored;
        private uint _windowStyles;

        /// <summary>Initializes a new instance of the <see cref="Window" /> class.</summary>
        /// <param name="monitorProvider">An <see cref="IMonitorProvider" /> implementation.</param>
        /// <param name="windowProvider">A <see cref="WindowProvider" /> object.</param>
        /// <param name="beforeCreationDelegate">A delegate that can be used to configure the new <see cref="Window" /> object.</param>
        /// <param name="beforeMessageHandledDelegate">A delegate invoked before a message is handled.</param>
        /// <param name="afterMessageHandledDelegate">A delegate invoked after a message is handled.</param>
        public Window(
            IMonitorProvider monitorProvider,
            WindowProvider windowProvider,
            Action<Window>? beforeCreationDelegate = null,
            WindowMessageHandlerDelegate? beforeMessageHandledDelegate = null,
            WindowMessageHandlerDelegate? afterMessageHandledDelegate = null)
        {
            _monitorProvider = monitorProvider;
            _windowProvider = windowProvider;
            _beforeCreationDelegate = beforeCreationDelegate;
            _beforeMessageHandledDelegate = beforeMessageHandledDelegate;
            _afterMessageHandledDelegate = afterMessageHandledDelegate;
            _ownerThread = Thread.CurrentThread;
            _windowHandle = new ValueLazy<HWND>(CreateWindowHandle);

            _state.Transition(Initialized);
        }

        /// <summary>Gets the handle of the window. The handle will be created if it has not yet been.</summary>
        public HWND Handle => _windowHandle.Value;

        /// <summary>Gets a value indicating whether the window handle was created.</summary>
        public bool IsHandleCreated => _windowHandle.IsCreated;

        /// <summary>Gets a value indicating if the window is active.</summary>
        public bool IsActive { get; private set; }

        /// <summary>Gets a value indicating if the window is visible.</summary>
        public bool IsVisible { get; private set; }

        /// <summary>Gets a value indicating if the window is enabled.</summary>
        public bool IsEnabled { get; private set; } = true;

        /// <summary>Gets or sets the window state.</summary>
        public WindowState WindowState
        {
            get => _windowState;
            set
            {
                _state.AssertNeitherDisposingNorDisposed();

                if (value == _windowState)
                {
                    return;
                }

                _windowState = value;

                if (!_windowHandle.IsCreated)
                {
                    return;
                }

                switch (_windowState)
                {
                    case WindowState.Restored:
                        _ = ShowWindow(Handle, SW_RESTORE);
                        break;
                    case WindowState.Minimized:
                        _ = ShowWindow(Handle, SW_MINIMIZE);
                        break;
                    case WindowState.Maximized:
                        _ = ShowWindow(Handle, SW_MAXIMIZE);
                        break;
                    default:
                        ThrowArgumentOutOfRangeException(nameof(_windowState), _windowState);
                        break;
                }
            }
        }

        /// <summary>Gets or sets the window border style.</summary>
        public BorderStyle BorderStyle
        {
            get => _borderStyle;
            set
            {
                _state.AssertNeitherDisposingNorDisposed();

                if (value == _borderStyle)
                {
                    return;
                }

                _borderStyle = value;

                ApplyWindowStyles();
            }
        }

        /// <summary>
        ///     Gets or sets a value determining whether window controls are visible. Window controls include the system menu, minimize
        ///     button, maximize button, and close button.
        /// </summary>
        public bool ControlsVisible
        {
            get => _controlsVisible;
            set
            {
                _state.AssertNeitherDisposingNorDisposed();

                if (value == _controlsVisible)
                {
                    return;
                }

                _controlsVisible = value;

                ApplyWindowStyles();
            }
        }

        /// <summary>Gets or sets a value determining whether the window caption is visible.</summary>
        public bool CaptionVisible
        {
            get => _captionVisible;
            set
            {
                _state.AssertNeitherDisposingNorDisposed();

                if (value == _captionVisible)
                {
                    return;
                }

                _captionVisible = value;

                ApplyWindowStyles();
            }
        }

        /// <summary>Gets or sets a value determining whether the system menu icon is visible.</summary>
        public bool IconVisible
        {
            get => _iconVisible;
            set
            {
                _state.AssertNeitherDisposingNorDisposed();

                if (value == _iconVisible)
                {
                    return;
                }

                _iconVisible = value;

                ApplyWindowStyles();
                if (_windowHandle.IsCreated)
                {
                    ApplyIcon(Handle, true);
                }
            }
        }

        /// <summary>Gets or sets a value determining whether the user may minimize the window.</summary>
        public bool AllowMinimize
        {
            get => _allowMinimize;
            set
            {
                _state.AssertNeitherDisposingNorDisposed();

                if (value == _allowMinimize)
                {
                    return;
                }

                _allowMinimize = value;

                ApplyWindowStyles();
            }
        }

        /// <summary>Gets or sets a value determining whether the user may maximize the window.</summary>
        public bool AllowMaximize
        {
            get => _allowMaximize;
            set
            {
                _state.AssertNeitherDisposingNorDisposed();

                if (value == _allowMaximize)
                {
                    return;
                }

                _allowMaximize = value;

                ApplyWindowStyles();
            }
        }

        /// <summary>Gets or sets the window title.</summary>
        public string Title
        {
            get => _title;
            set
            {
                _state.AssertNeitherDisposingNorDisposed();

                if (value.Equals(_title, StringComparison.Ordinal))
                {
                    return;
                }

                bool applyWindowStyles = string.IsNullOrEmpty(value) || string.IsNullOrEmpty(_title);

                _title = value;

                ApplyTitle(value);

                if (applyWindowStyles && _windowHandle.IsCreated)
                {
                    ApplyWindowStyles();
                }
            }
        }

        /// <summary>Gets or sets the window icon.</summary>
        public Icon? Icon
        {
            get => _icon;
            set
            {
                _state.AssertNeitherDisposingNorDisposed();

                if (value == _icon)
                {
                    return;
                }

                _icon = value;

                if (_smallIcon is not null)
                {
                    _smallIcon.Dispose();
                    _smallIcon = null;
                }

                if (_windowHandle.IsCreated)
                {
                    ApplyIcon(Handle, true);
                }
            }
        }

        /// <summary>Gets or sets the window's non-client bounds.</summary>
        public Rectangle<int> NonClientBounds
        {
            get => GetBounds(BoundsType.NonClient);
            set => SetBounds(value, BoundsType.NonClient);
        }

        /// <summary>Gets or sets the window's non-client location.</summary>
        public Vector2<int> NonClientLocation
        {
            get => GetLocation(BoundsType.NonClient);
            set => SetLocation(value, BoundsType.NonClient);
        }

        /// <summary>Gets or sets the window's non-client size.</summary>
        public Vector2<int> NonClientSize
        {
            get => GetSize(BoundsType.Client);
            set => SetSize(value, BoundsType.Client);
        }

        /// <summary>Gets or sets the window's client bounds.</summary>
        public Rectangle<int> ClientBounds
        {
            get => GetBounds(BoundsType.Client);
            set => SetBounds(value, BoundsType.Client);
        }

        /// <summary>Gets or sets the window's client location.</summary>
        public Vector2<int> ClientLocation
        {
            get => GetLocation(BoundsType.Client);
            set => SetLocation(value, BoundsType.Client);
        }

        /// <summary>Gets or sets the window's client bounds.</summary>
        public Vector2<int> ClientSize
        {
            get => GetSize(BoundsType.Client);
            set => SetSize(value, BoundsType.Client);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            if (_state.BeginDispose() < Disposing)
            {
                Dispose(true);

                _state.EndDispose();
            }

            GC.SuppressFinalize(this);
        }

        /// <summary>Invoked when the window's non-client location changes.</summary>
        public event EventHandler<PropertyChangedEventArgs<Vector2<int>>>? NonClientLocationChanged;

        /// <summary>Invoked when the window's non-client size changes.</summary>
        public event EventHandler<PropertyChangedEventArgs<Vector2<int>>>? NonClientSizeChanged;

        /// <summary>Invoked when the window's client location changes.</summary>
        public event EventHandler<PropertyChangedEventArgs<Vector2<int>>>? ClientLocationChanged;

        /// <summary>Invoked when the window's client size changes.</summary>
        public event EventHandler<PropertyChangedEventArgs<Vector2<int>>>? ClientSizeChanged;

        /// <summary>Invoked when the window is activated.</summary>
        public event EventHandler? Activated;

        /// <summary>Invoked when the window is deactivated.</summary>
        public event EventHandler? Deactivated;

        /// <inheritdoc />
        ~Window()
        {
            if (_state.BeginDispose() < Disposing)
            {
                Dispose(false);
            }
        }

        /// <summary>Gets the specified type of bounds of the window.</summary>
        /// <param name="type">The type of bounds to retrieve.</param>
        /// <returns>The bounds of type <paramref name="type" />.</returns>
        public Rectangle<int> GetBounds(BoundsType type)
        {
            switch (type)
            {
                case BoundsType.NonClient:
                    return _nonClientBounds;
                case BoundsType.Client:
                    return _clientBounds;
                default:
                    ThrowArgumentOutOfRangeException(nameof(type), type);
                    return default;
            }
        }

        /// <summary>Gets the specified type of location of the window.</summary>
        /// <param name="type">The type of location to retrieve.</param>
        /// <returns>The location of type <paramref name="type" />.</returns>
        public Vector2<int> GetLocation(BoundsType type)
        {
            switch (type)
            {
                case BoundsType.NonClient:
                    return _nonClientBounds.Location;
                case BoundsType.Client:
                    return _clientBounds.Location;
                default:
                    ThrowArgumentOutOfRangeException(nameof(type), type);
                    return default;
            }
        }

        /// <summary>Gets the specified type of size of the window.</summary>
        /// <param name="type">The type of size to retrieve.</param>
        /// <returns>The size of type <paramref name="type" />.</returns>
        public Vector2<int> GetSize(BoundsType type)
        {
            switch (type)
            {
                case BoundsType.NonClient:
                    return _nonClientBounds.Size;
                case BoundsType.Client:
                    return _clientBounds.Size;
                default:
                    ThrowArgumentOutOfRangeException(nameof(type), type);
                    return default;
            }
        }

        /// <summary>Gets the monitor that <see cref="Handle" /> is on, defaulting to the nearest monitor.</summary>
        /// <returns>The monitor that <see cref="Handle" /> is on, defaulting to the nearest monitor.</returns>
        public Monitor GetMonitor() => Monitor.From(Handle);

        /// <summary>Sets the specified type of bounds of the window.</summary>
        /// <param name="bounds">The new bounds.</param>
        /// <param name="type">The type of bounds to set.</param>
        public void SetBounds(Rectangle<int> bounds, BoundsType type)
        {
            _state.AssertNeitherDisposingNorDisposed();

            Rectangle<int> newBounds;

            switch (type)
            {
                case BoundsType.NonClient:
                    if (bounds == _nonClientBounds)
                    {
                        return;
                    }
                    _nonClientBounds = newBounds = bounds;
                    break;
                case BoundsType.Client:
                    if (bounds == _clientBounds)
                    {
                        return;
                    }
                    _clientBounds = newBounds = bounds;
                    break;
                default:
                    ThrowArgumentOutOfRangeException(nameof(type), type);
                    newBounds = default;
                    break;
            }

            ApplyBounds(newBounds, type);
        }

        /// <summary>Sets the specified type of location of the window.</summary>
        /// <param name="location">The new location.</param>
        /// <param name="type">The type of location to set.</param>
        public void SetLocation(Vector2<int> location, BoundsType type)
        {
            _state.AssertNeitherDisposingNorDisposed();

            Rectangle<int> newBounds;

            switch (type)
            {
                case BoundsType.NonClient:
                    newBounds = _nonClientBounds;
                    break;
                case BoundsType.Client:
                    newBounds = _clientBounds;
                    break;
                default:
                    ThrowArgumentOutOfRangeException(nameof(type), type);
                    newBounds = default;
                    break;
            }

            SetBounds(newBounds.WithLocation(location), type);
        }

        /// <summary>Sets the specified type of size of the window.</summary>
        /// <param name="size">The new size.</param>
        /// <param name="type">The type of size to set.</param>
        public void SetSize(Vector2<int> size, BoundsType type)
        {
            _state.AssertNeitherDisposingNorDisposed();

            Rectangle<int> newBounds;

            switch (type)
            {
                case BoundsType.NonClient:
                    newBounds = _nonClientBounds;
                    break;
                case BoundsType.Client:
                    newBounds = _clientBounds;
                    break;
                default:
                    ThrowArgumentOutOfRangeException(nameof(type), type);
                    newBounds = default;
                    break;
            }

            SetBounds(newBounds.WithSize(size), type);
        }

        /// <summary>Makes the window visible.</summary>
        public void Show()
        {
            _state.AssertNeitherDisposingNorDisposed();

            if (!IsVisible)
            {
                _ = ShowWindow(Handle, SW_SHOW);
            }
        }

        /// <summary>Makes the window invisible.</summary>
        public void Hide()
        {
            _state.AssertNeitherDisposingNorDisposed();

            if (IsVisible)
            {
                _ = ShowWindow(Handle, SW_HIDE);
            }
        }

        /// <summary>Activates the window.</summary>
        public void Activate()
        {
            _state.AssertNeitherDisposingNorDisposed();

            if (!TryActivate())
            {
                ThrowExternalExceptionForLastWin32Error(nameof(SetForegroundWindow));
            }
        }

        /// <summary>Attempts to activate the window.</summary>
        /// <returns><see langword="true" /> if the window was activated; otherwise, <see langword="false" />.</returns>
        public bool TryActivate()
        {
            _state.AssertNeitherDisposingNorDisposed();

            return IsActive || SetForegroundWindow(Handle) != FALSE;
        }

        /// <summary>Enables the window.</summary>
        public void Enable()
        {
            _state.AssertNeitherDisposingNorDisposed();

            if (!IsEnabled)
            {
                _ = EnableWindow(Handle, TRUE);
            }
        }

        /// <summary>Disables the window.</summary>
        public void Disable()
        {
            _state.AssertNeitherDisposingNorDisposed();

            if (IsEnabled)
            {
                _ = EnableWindow(Handle, FALSE);
            }
        }

        /// <summary>Minimizes the window.</summary>
        public void Minimize()
        {
            _state.AssertNeitherDisposingNorDisposed();

            if (WindowState != WindowState.Minimized)
            {
                _ = ShowWindow(Handle, SW_MINIMIZE);
            }
        }

        /// <summary>Maximizes the window.</summary>
        public void Maximize()
        {
            _state.AssertNeitherDisposingNorDisposed();

            if (WindowState != WindowState.Maximized)
            {
                _ = ShowWindow(Handle, SW_MAXIMIZE);
            }
        }

        /// <summary>Restores the window.</summary>
        public void Restore()
        {
            _state.AssertNeitherDisposingNorDisposed();

            if (WindowState != WindowState.Restored)
            {
                _ = ShowWindow(Handle, SW_RESTORE);
            }
        }

        /// <summary>Sends a <c>WM_CLOSE</c> message to the window.</summary>
        public void Close()
        {
            _state.AssertNeitherDisposingNorDisposed();

            if (_windowHandle.IsCreated)
            {
                SendMessageW(Handle, WM_CLOSE, UIntPtr.Zero, IntPtr.Zero);
            }
        }

        /// <summary>Changes the window's location such that it is centered on the specified vector.</summary>
        /// <param name="monitor">
        ///     A monitor to center the window on. A <see langword="null" /> value will default to the nearest monitor
        ///     associated with <see cref="Handle" />.
        /// </param>
        /// <param name="newSize">The new size of the window. A <see langword="null" /> value will not change the current size of the window.</param>
        public void Center(Monitor? monitor = null, (Vector2<int> size, BoundsType type)? newSize = null)
        {
            _state.AssertNeitherDisposingNorDisposed();

            if (monitor is null)
            {
                IntPtr monitorHandle = MonitorFromWindow(Handle, MONITOR_DEFAULTTONEAREST);

                monitor = _monitorProvider.Monitors.SingleOrDefault(a => a.MonitorHandle == monitorHandle);
            }
            if (monitor is null)
            {
                ThrowInvalidOperationException("Failed to retrieve monitor information.");
            }

            if (newSize is null)
            {
                if (!_nonClientBounds.IsEmpty)
                {
                    SetBounds(_nonClientBounds.CenterOn(monitor.WorkingArea), BoundsType.NonClient);
                }
                else if (!_clientBounds.IsEmpty)
                {
                    SetBounds(_nonClientBounds.CenterOn(monitor.WorkingArea), BoundsType.Client);
                }
            }
            else
            {
                SetBounds(GetBounds(newSize.Value.type).WithSize(newSize.Value.size), newSize.Value.type);
            }
        }

        /// <summary>Sets window styles.</summary>
        /// <param name="borderStyle">The border style. A <see langword="null" /> value will not change the current border style.</param>
        /// <param name="captionVisible">
        ///     A value determining whether the caption is visible. A <see langword="null" /> value will not change
        ///     the current caption visibility.
        /// </param>
        /// <param name="controlsVisible">
        ///     A value determining whether window controls are visible. A <see langword="null" /> value will not
        ///     change the current window control visibility.
        /// </param>
        /// <param name="iconVisible">
        ///     A value determining whether the system menu icon is visible. A <see langword="null" /> value will not
        ///     change the current system menu icon visibility.
        /// </param>
        /// <param name="allowMinimize">
        ///     A value determining whether the user may minimize the window. A <see langword="null" /> value will
        ///     not change the current minimize permission.
        /// </param>
        /// <param name="allowMaximize">
        ///     A value determining whether the user may maximize the window. A <see langword="null" /> value will
        ///     not change the current maximize permission.
        /// </param>
        public void SetWindowStyles(
            BorderStyle? borderStyle = null,
            bool? captionVisible = null,
            bool? controlsVisible = null,
            bool? iconVisible = null,
            bool? allowMinimize = null,
            bool? allowMaximize = null)
        {
            _state.AssertNeitherDisposingNorDisposed();

            _borderStyle = borderStyle ?? _borderStyle;
            _controlsVisible = controlsVisible ?? _controlsVisible;
            _captionVisible = captionVisible ?? _captionVisible;
            _iconVisible = iconVisible ?? _iconVisible;
            _allowMinimize = allowMinimize ?? _allowMinimize;
            _allowMaximize = allowMaximize ?? _allowMinimize;

            ApplyWindowStyles();
        }

        /// <summary>Handles a window message.</summary>
        /// <param name="message">The window message being processed.</param>
        /// <param name="wParam">A <c>WPARAM</c> value.</param>
        /// <param name="lParam">An <c>LPARAM</c> value.</param>
        /// <returns>The message processing result.</returns>
        internal nint HandleWindowMessage(uint message, nuint wParam, nint lParam)
        {
            ThrowIfCurrentThreadIsNotSuppliedThread(_ownerThread);

            nint? result = null;

            _beforeMessageHandledDelegate?.Invoke(Handle, message, wParam, lParam, ref result);

            if (result is not null)
            {
                return result.Value;
            }

            result =
                message switch
                {
                    WM_ACTIVATEAPP => HandleWmActivateApp(wParam),
                    WM_CLOSE => HandleWmClose(),
                    WM_ENABLE => HandleWmEnable(wParam),
                    WM_DESTROY => HandleWmDestroy(),
                    WM_MOVE => HandleWmMove(lParam),
                    WM_NCDESTROY => HandleWmNcDestroy(),
                    WM_SETTEXT => HandleWmSetText(wParam, lParam),
                    WM_SHOWWINDOW => HandleWmShowWindow(wParam),
                    WM_SIZE => HandleWmSize(wParam, lParam),
                    _ => null
                };

            _afterMessageHandledDelegate?.Invoke(Handle, message, wParam, lParam, ref result);

            return result ?? DefWindowProcW(Handle, message, wParam, lParam);
        }

        /// <summary>Calculates and applies window styles.</summary>
        internal void ApplyWindowStyles(HWND? windowHandle = null)
        {
            windowHandle = ResolveWindowHandle(windowHandle);

            CalculateWindowStyles(windowHandle);

            if (windowHandle is null || windowHandle == HWND.NULL)
            {
                return;
            }

            CalculateWindowStyles(windowHandle);

            // SetWindowLongPtrW can return 0 if the previous style is actually 0, so don't check for errors

            SetWindowLongPtrW(windowHandle.Value, GWL_STYLE, (nint)_windowStyles);
            SetWindowLongPtrW(windowHandle.Value, GWL_EXSTYLE, (nint)_windowExStyles);

            /*
             * SetWindowPos leads to several window messages being sent, including WM_ACTIVATE, despite the
             * window being invisible. There is no need to call SetWindowPos if the window is invisible.
             */
            if (IsVisible)
            {
                _ = SetWindowPos(windowHandle.Value, IntPtr.Zero, 0, 0, 0, 0, SWP_FRAMECHANGED | SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_NOREPOSITION);
            }

            ApplyIcon(windowHandle.Value, false);
        }

        /// <summary>Disposes the object.</summary>
        /// <param name="disposing">A value indicating whether to dispose only managed objects.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_state.BeginDispose() != Disposing)
            {
                return;
            }

            // Window handles must be disposed of on the thread that created them.

            if (Thread.CurrentThread != _ownerThread)
            {
                Close();
            }
            else
            {
                DisposeWindowHandle();
            }
        }

        private nint HandleWmActivateApp(nuint wParam)
        {
            bool isActive = wParam == TRUE;

            if (isActive && !IsActive)
            {
                IsActive = isActive;
                Activated?.Invoke(this, EventArgs.Empty);
            }
            else if (!isActive && IsActive)
            {
                IsActive = isActive;
                Deactivated?.Invoke(this, EventArgs.Empty);
            }

            return 0;
        }

        private nint HandleWmClose()
        {
            /*
             * Dispose may be called on a thread other than the owner thread. In that case,
             * WM_CLOSE is sent to the window so that it closes on the owner thread. The below
             * code detects that case and immediately disposes the window handle rather than
             * disposing again.
             */

            if (_state == Disposing)
            {
                DisposeWindowHandle();
            }
            else
            {
                Dispose();
            }

            return 0;
        }

        private nint HandleWmDestroy()
        {
            /*
             * If a disposal is not in progress then the window was destroyed some other way.
             * In this case, consider the window disposed.
             */

            if (_state != Disposing)
            {
                _state.Transition(Disposed);
            }

            return 0;
        }

        private nint HandleWmEnable(nuint wParam)
        {
            IsEnabled = wParam != FALSE;

            return 0;
        }

        private nint HandleWmMove(nint lParam)
        {
            Vector2<int> oldNonClientLocation = _nonClientBounds.Location;
            Vector2<int> oldClientLocation = _clientBounds.Location;
            var x = unchecked((short)LOWORD((uint)lParam));
            var y = unchecked((short)HIWORD((uint)lParam));
            var newClientLocation = new Vector2<int>(x, y);

            _clientBounds = _clientBounds.WithLocation(newClientLocation);
            _nonClientBounds = ClientBoundsToNonClientBounds(_clientBounds);

            Vector2<int> newNonClientLocation = _nonClientBounds.Location;

            if (oldNonClientLocation != newNonClientLocation)
            {
                NonClientLocationChanged?.Invoke(this, new PropertyChangedEventArgs<Vector2<int>>(oldNonClientLocation, newNonClientLocation));
            }
            if (oldClientLocation != newClientLocation)
            {
                ClientLocationChanged?.Invoke(this, new PropertyChangedEventArgs<Vector2<int>>(oldClientLocation, newClientLocation));
            }

            return 0;
        }

        private nint HandleWmNcDestroy()
        {
            _windowHandle.Dispose();

            return 0;
        }

        private unsafe nint HandleWmSetText(nuint wParam, nint lParam)
        {
            nint result = DefWindowProcW(Handle, WM_SETTEXT, wParam, lParam);

            if (result == TRUE)
            {
                _title = new string((char*)lParam);
            }

            return result;
        }

        private nint HandleWmShowWindow(nuint wParam)
        {
            IsVisible = LOWORD((uint)wParam) != FALSE;

            return 0;
        }

        private nint HandleWmSize(nuint wParam, nint lParam)
        {
            switch ((uint)wParam)
            {
                case 0:
                    _windowState = WindowState.Restored;
                    break;
                case 1:
                    _windowState = WindowState.Minimized;
                    break;
                case 2:
                    _windowState = WindowState.Maximized;
                    break;
                default:
                    ThrowArgumentOutOfRangeException(nameof(wParam), wParam);
                    break;
            }

            Vector2<int> oldNonClientSize = _nonClientBounds.Size;
            Vector2<int> oldClientSize = _clientBounds.Size;
            ushort width = LOWORD(lParam);
            ushort height = HIWORD(lParam);
            var newClientSize = new Vector2<int>(width, height);

            _clientBounds = _clientBounds.WithSize(newClientSize);
            _nonClientBounds = ClientBoundsToNonClientBounds(_clientBounds);

            Vector2<int> newNonClientSize = _nonClientBounds.Size;

            if (oldNonClientSize != newNonClientSize)
            {
                NonClientSizeChanged?.Invoke(this, new PropertyChangedEventArgs<Vector2<int>>(oldNonClientSize, newNonClientSize));
            }
            if (oldClientSize != newClientSize)
            {
                ClientSizeChanged?.Invoke(this, new PropertyChangedEventArgs<Vector2<int>>(oldClientSize, newClientSize));
            }

            return 0;
        }

        private unsafe HWND CreateWindowHandle()
        {
            _state.AssertNeitherDisposingNorDisposed();

            _beforeCreationDelegate?.Invoke(this);

            HWND hWnd;
            Rectangle<int>? bounds = null;

            if (!_nonClientBounds.IsEmpty)
            {
                bounds = _nonClientBounds;
            }
            else if (!_clientBounds.IsEmpty)
            {
                bounds = ClientBoundsToNonClientBounds(_clientBounds);
            }

            fixed (char* pTitle = _title)
            {
                hWnd =
                    CreateWindowExW(
                        _windowExStyles,
                        (ushort*)_windowProvider.ClassAtom,
                        (ushort*)pTitle,
                        _windowStyles,
                        bounds?.X ?? CW_USEDEFAULT,
                        bounds?.Y ?? CW_USEDEFAULT,
                        bounds?.Width ?? CW_USEDEFAULT,
                        bounds?.Height ?? CW_USEDEFAULT,
                        IntPtr.Zero,
                        IntPtr.Zero,
                        ModuleHandle,
                        GCHandle.ToIntPtr(_windowProvider.NativeHandle).ToPointer());
            }

            ThrowExternalExceptionIfZero(hWnd, nameof(CreateWindowExW));

            return hWnd;
        }

        private unsafe Rectangle<int> ClientBoundsToNonClientBounds(Rectangle<int> clientBounds)
        {
            RECT rect;

            ThrowExternalExceptionIfFALSE(
                AdjustWindowRectEx(&rect, _windowStyles, FALSE, _windowExStyles),
                nameof(AdjustWindowRectEx));

            return new Rectangle<int>(
                clientBounds.X + rect.left,
                clientBounds.Y + rect.top,
                clientBounds.Width + (rect.right - rect.left),
                clientBounds.Height + (rect.bottom - rect.top));
        }

        private unsafe void ApplyTitle(string title)
        {
            if (_windowHandle.IsCreated)
            {
                fixed (char* pTitle = title)
                {
                    _ = SetWindowTextW(Handle, (ushort*)pTitle);
                }
            }
        }

        private void ApplyBounds(Rectangle<int> bounds, BoundsType boundsType)
        {
            if (!_windowHandle.IsCreated)
            {
                return;
            }
            if (bounds.IsEmpty)
            {
                ThrowArgumentException("Bounds are empty.", nameof(bounds));
            }

            Rectangle<int> adjustedBounds;

            switch (boundsType)
            {
                case BoundsType.NonClient:
                    adjustedBounds = bounds;
                    break;
                case BoundsType.Client:
                    adjustedBounds = ClientBoundsToNonClientBounds(bounds);
                    break;
                default:
                    ThrowArgumentOutOfRangeException(nameof(boundsType), boundsType);
                    adjustedBounds = default;
                    break;
            }

            ThrowExternalExceptionIfFALSE(
                SetWindowPos(Handle, IntPtr.Zero, adjustedBounds.X, adjustedBounds.Y, adjustedBounds.Width, adjustedBounds.Height, 0),
                nameof(SetWindowPos));
        }

        private unsafe void ApplyIcon(HWND windowHandle, bool invalidateFrame)
        {
            // https://github.com/dotnet/winforms/blob/da5436b857cfe42183cf9725269e7ce5794aa5b5/src/System.Windows.Forms/src/System/Windows/Forms/Form.cs#L5822

            /*
             * There appears to be a defect in user32 where windows created with no border do not properly
             * render icons. I've only been able to work around this defect by first removing the current
             * icons.
             */

            SendMessageW(windowHandle, WM_SETICON, ICON_SMALL, 0);
            SendMessageW(windowHandle, WM_SETICON, ICON_BIG, 0);

            Icon? icon = _iconVisible ? _icon : null;

            if (icon is not null)
            {
                if (_smallIcon is null)
                {
                    try
                    {
                        _smallIcon = new Icon(icon, SmallIconSize);
                    }
                    // ReSharper disable once EmptyGeneralCatchClause
                    catch
                    {
                    }
                }

                if (_smallIcon is not null)
                {
                    SendMessageW(windowHandle, WM_SETICON, ICON_SMALL, _smallIcon.Handle);
                }

                SendMessageW(windowHandle, WM_SETICON, ICON_BIG, icon.Handle);
            }

            if (invalidateFrame)
            {
                _ = RedrawWindow(windowHandle, null, IntPtr.Zero, RDW_INVALIDATE | RDW_FRAME);
            }
        }

        private void CalculateWindowStyles(HWND? windowHandle = null)
        {
            uint windowStyles = 0;
            uint windowExStyles = 0;

            if (windowHandle is not null)
            {
                // Remove all styles set by the code below
                // GetWindowLongPtrW can return 0 if the style is actually 0, so don't check for errors

                windowStyles = (uint)GetWindowLongPtrW(windowHandle.Value, GWL_STYLE);
                windowExStyles = (uint)GetWindowLongPtrW(windowHandle.Value, GWL_EXSTYLE);
            }
            else
            {
                // Before the window is created, set the initial window state

                switch (_windowState)
                {
                    case WindowState.Minimized:
                        windowStyles = WS_MINIMIZE;
                        break;
                    case WindowState.Maximized:
                        windowStyles = WS_MAXIMIZE;
                        break;
                    case WindowState.Restored:
                        windowStyles = 0;
                        break;
                    default:
                        ThrowArgumentOutOfRangeException(nameof(_windowState), _windowState);
                        break;
                }

                windowExStyles |= WS_EX_APPWINDOW;
            }

            // Set border styles

            switch (_borderStyle)
            {
                case BorderStyle.Sizable:
                    windowStyles |= WS_BORDER | WS_THICKFRAME;
                    windowExStyles |= WS_EX_CLIENTEDGE | WS_EX_WINDOWEDGE;
                    break;
                case BorderStyle.NonSizable:
                    windowStyles |= WS_BORDER;
                    windowStyles &= ~(uint)WS_THICKFRAME;
                    windowExStyles |= WS_EX_CLIENTEDGE | WS_EX_WINDOWEDGE;
                    break;
                case BorderStyle.None:
                    windowStyles &= ~(uint)(WS_BORDER | WS_THICKFRAME);
                    windowExStyles &= ~(uint)(WS_EX_CLIENTEDGE | WS_EX_WINDOWEDGE);
                    break;
                default:
                    ThrowArgumentOutOfRangeException(nameof(_borderStyle), _borderStyle);
                    break;
            }

            if (_title.Length > 0)
            {
                // Show the caption
                windowStyles |= WS_CAPTION;
            }

            if (_controlsVisible)
            {
                // Show the system menu and caption, potentially including minimize, maximize, and close buttons
                windowStyles |= WS_SYSMENU | WS_CAPTION;
            }
            else
            {
                // Hide the system menu
                windowStyles &= ~(uint)WS_SYSMENU;
            }

            if (_borderStyle == BorderStyle.None)
            {
                // Hide the title bar
                windowStyles &= ~(uint)WS_CAPTION;
            }

            if (_allowMaximize)
            {
                // Show the maximize button
                windowStyles |= WS_MAXIMIZEBOX;
            }
            else
            {
                // Hide the maximize button
                windowStyles &= ~(uint)WS_MAXIMIZEBOX;
            }

            if (_allowMinimize)
            {
                // Show the minimize button
                windowStyles |= WS_MINIMIZEBOX;
            }
            else
            {
                // Hide the minimize button
                windowStyles &= ~(uint)WS_MINIMIZEBOX;
            }

            _windowStyles = windowStyles;
            _windowExStyles = windowExStyles;
        }

        private HWND? ResolveWindowHandle(HWND? windowHandle) =>
            (windowHandle is not null && windowHandle.Value != HWND.NULL ? windowHandle.Value : (HWND?)null) ??
            (_windowHandle.IsCreated ? _windowHandle.Value : (HWND?)null);

        private void DisposeWindowHandle()
        {
            Assert(Thread.CurrentThread == _ownerThread, "Current thread is not the owner thread.");

            _state.AssertDisposing();

            if (_windowHandle.IsCreated)
            {
                ThrowExternalExceptionIfFALSE(
                    DestroyWindow(Handle),
                    nameof(DestroyWindow));
            }
        }
    }
}