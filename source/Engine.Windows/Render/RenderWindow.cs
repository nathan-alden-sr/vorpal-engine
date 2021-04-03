using System;
using System.Linq;
using NathanAldenSr.VorpalEngine.Common;
using NathanAldenSr.VorpalEngine.Common.Windows;
using NathanAldenSr.VorpalEngine.Common.Windows.Messages;
using NathanAldenSr.VorpalEngine.Engine.Messaging;
using NathanAldenSr.VorpalEngine.Logging;
using TerraFX.Interop;
using static NathanAldenSr.VorpalEngine.Common.ExceptionHelper;
using static NathanAldenSr.VorpalEngine.Common.State;
using static NathanAldenSr.VorpalEngine.Common.Windows.ExceptionHelper;
using static TerraFX.Interop.Windows;
using WindowsRender = NathanAldenSr.VorpalEngine.Engine.Configuration.WindowsRender;

namespace NathanAldenSr.VorpalEngine.Engine.Windows.Render
{
    /// <summary>A Windows window that renders the game and receives input messages.</summary>
    /// <typeparam name="T">The type of configuration.</typeparam>
    public class RenderWindow<T> : IRenderWindow
        where T : Configuration.Configuration
    {
        private readonly Counter _ignoreClientSizeChanges;
        private readonly ContextLogger? _logger;
        private readonly MessageQueueHelper _messageQueueHelper;
        private readonly IMonitorProvider _monitorProvider;
        private readonly Window _window;
        private bool _cachedAllowMaximize;
        private bool _cachedAllowMinimize;
        private BorderStyle _cachedBorderStyle;
        private bool _cachedCaptionVisible;
        private Rectangle<int>? _cachedClientBounds;
        private bool _cachedControlsVisible;
        private bool _cachedIconVisible;
        private Vector2<int>? _cachedResolution;

        private unsafe WINDOWPLACEMENT _cachedWindowPlacement =
            new()
            {
                length = (uint)sizeof(WINDOWPLACEMENT)
            };

        private DisplayMode _displayMode;
        private Monitor _monitor;
        private bool _mouseCaptured;
        private State _state;
        private bool _wasShown;

        /// <summary>Initializes a new instance of the <see cref="RenderWindow{TConfiguration}" /> class.</summary>
        /// <param name="messageQueue">An <see cref="IMessageQueue" /> implementation.</param>
        /// <param name="monitorProvider">An <see cref="IMonitorProvider" /> implementation.</param>
        /// <param name="configurationManager">An <see cref="Configuration.IConfigurationManager{TConfiguration}" /> implementation.</param>
        /// <param name="windowProvider">
        ///     A <see cref="WindowProvider" /> object that will be used to create the underlying
        ///     <see cref="Window" />.
        /// </param>
        /// <param name="windowConfigurationDelegate">A delegate that can be used to configure the underlying <see cref="Window" /> object.</param>
        /// <param name="context">A nested context.</param>
        public RenderWindow(
            IMessageQueue messageQueue,
            IMonitorProvider monitorProvider,
            Configuration.IConfigurationManager<T> configurationManager,
            WindowProvider windowProvider,
            Action<Window>? windowConfigurationDelegate = null,
            NestedContext context = default)
        {
            context = context.Push<RenderWindow<T>>();

            _messageQueueHelper = messageQueue.ToHelper(context);
            _monitorProvider = monitorProvider;
            _logger = new ContextLogger(context);
            _ignoreClientSizeChanges = new Counter(ProcessResolutionChange, CacheResolution);

            // Position and configure the window using configuration

            T configuration = configurationManager.GetConfiguration();
            WindowsRender windowsRender = configuration.Windows().Render();
            Configuration.Vector2<int> resolution =
                windowsRender.Resolution ??
                new Configuration.Vector2<int>
                {
                    X = 1280,
                    Y = 720
                };
            Monitor? monitor =
                monitorProvider.Monitors.SingleOrDefault(a => a.DeviceName.Equals(windowsRender.DisplayDeviceName, StringComparison.Ordinal))
                ?? monitorProvider.PrimaryMonitor;

            if (monitor is null)
            {
                ThrowInvalidOperationException("Failed to retrieve primary monitor information.");
                _monitor = default;
            }
            else
            {
                _monitor = monitor;
            }

            switch (windowsRender.DisplayMode)
            {
                case Configuration.DisplayMode.Bordered:
                case null:
                    _displayMode = DisplayMode.Bordered;
                    break;
                case Configuration.DisplayMode.BorderlessFullscreen:
                    _displayMode = DisplayMode.BorderlessFullscreen;
                    break;
                default:
                    ThrowArgumentOutOfRangeException(nameof(windowsRender.DisplayMode), windowsRender.DisplayMode);
                    break;
            }

            // Create the window

            _window = windowProvider.CreateWindow(
                window =>
                {
                    Rectangle<int> clientBounds = new Rectangle<int>(Vector2<int>.Zero, resolution).CenterOn(_monitor.WorkingArea);

                    switch (_displayMode)
                    {
                        case DisplayMode.Bordered:
                            window.ClientBounds = clientBounds;
                            if (windowsRender.Maximized == true)
                            {
                                window.WindowState = WindowState.Maximized;
                            }
                            window.SetWindowStyles(BorderStyle.Sizable, true, true, true, true, true);
                            break;
                        case DisplayMode.BorderlessFullscreen:
                            CacheWindowStyles(window);
                            _cachedClientBounds = clientBounds;
                            window.ClientBounds = _monitor.Bounds;
                            window.SetWindowStyles(BorderStyle.None, false, false, false, false, false);
                            break;
                        default:
                            ThrowArgumentOutOfRangeException(nameof(_displayMode), _displayMode);
                            break;
                    }

                    windowConfigurationDelegate?.Invoke(window);
                },
                WindowOnBeforeMessageProcessing,
                WindowOnAfterMessageProcessing);
            _window.ClientSizeChanged += WindowOnClientSizeChanged;
            _window.NonClientLocationChanged += WindowOnNonClientLocationChanged;
            _window.Activated += WindowOnActivated;
            _window.Deactivated += WindowOnDeactivated;

            RegisterRawInputDevices(_window.Handle);

            XInputEnable(TRUE);

            _state.Transition(Initialized);
        }

        /// <inheritdoc />
        public HWND Handle => _window.Handle;

        /// <inheritdoc />
        public bool IsActive => _window.IsActive;

        /// <inheritdoc />
        public string Title
        {
            get => _window.Title;
            set => _window.Title = value;
        }

        /// <inheritdoc />
        public unsafe DisplayMode DisplayMode
        {
            get => _displayMode;
            set
            {
                _state.ThrowIfDisposingOrDisposed();

                if (value == _displayMode)
                {
                    return;
                }

                DisplayMode oldDisplayMode = _displayMode;

                _displayMode = value;

                if (!_window.IsHandleCreated)
                {
                    return;
                }

                using (_ignoreClientSizeChanges.Increment())
                {
                    switch (_displayMode)
                    {
                        case DisplayMode.Bordered:
                            RestoreCachedWindowStyles();
                            break;
                        case DisplayMode.BorderlessFullscreen:
                            CacheWindowStyles(_window);
                            CacheWindowPlacement();

                            Monitor monitor = Monitor.From(_window.Handle);

                            _window.SetWindowStyles(BorderStyle.None, false, false, false, false, false);

                            var windowPlacement =
                                new WINDOWPLACEMENT
                                {
                                    flags = 0,
                                    length = (uint)sizeof(WINDOWPLACEMENT),
                                    rcNormalPosition = monitor.Bounds.ToRECT(),
                                    showCmd = SW_SHOWNORMAL
                                };

                            ThrowExternalExceptionIfFALSE(
                                SetWindowPlacement(_window.Handle, &windowPlacement),
                                nameof(SetWindowPlacement));
                            break;
                        default:
                            ThrowArgumentOutOfRangeException(nameof(_displayMode), _displayMode);
                            break;
                    }

                    _messageQueueHelper.Publish(new DisplayModeChangedMessage(oldDisplayMode, value));
                }
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            if (_state.BeginDispose() < Disposing)
            {
                _window.Dispose();
            }

            _state.EndDispose();

            GC.SuppressFinalize(this);
        }

        /// <inheritdoc />
        public event WindowMessageReceivedDelegate? WindowMessageReceived;

        /// <inheritdoc />
        public void Show()
        {
            _state.ThrowIfDisposingOrDisposed();

            _window.Show();

            if (_wasShown)
            {
                return;
            }

            _wasShown = true;

            _messageQueueHelper.Publish(new DisplayModeChangedMessage(null, _displayMode));
            _messageQueueHelper.Publish(new MonitorChangedMessage(null, _window.GetMonitor()));
            _messageQueueHelper.Publish(new ResolutionChangedMessage(null, _window.ClientSize));
        }

        private unsafe void RegisterRawInputDevices(HWND windowHandle)
        {
            _logger?.Debug("Registering Raw Input devices");

            ushort[] usages =
            {
                HID_USAGE_GENERIC_GAMEPAD,
                HID_USAGE_GENERIC_JOYSTICK,
                HID_USAGE_GENERIC_KEYBOARD,
                HID_USAGE_GENERIC_MOUSE
            };
            RAWINPUTDEVICE* pRawInputDevices = stackalloc RAWINPUTDEVICE[usages.Length];

            for (uint i = 0; i < usages.Length; i++)
            {
                ushort usage = usages[i];

                pRawInputDevices[i] =
                    new RAWINPUTDEVICE
                    {
                        dwFlags =
                            (usage == HID_USAGE_GENERIC_KEYBOARD ? RIDEV_NOHOTKEYS : 0u) |
                            (usage == (HID_USAGE_GENERIC_GAMEPAD | HID_USAGE_GENERIC_JOYSTICK) ? RIDEV_INPUTSINK : 0u),
                        hwndTarget = windowHandle,
                        usUsage = usage,
                        usUsagePage = HID_USAGE_PAGE_GENERIC
                    };
            }

            ThrowExternalExceptionIfFALSE(
                TerraFX.Interop.Windows.RegisterRawInputDevices(pRawInputDevices, (uint)usages.Length, (uint)sizeof(RAWINPUTDEVICE)),
                nameof(TerraFX.Interop.Windows.RegisterRawInputDevices));
        }

        private void CacheWindowStyles(Window window)
        {
            _cachedBorderStyle = window.BorderStyle;
            _cachedControlsVisible = window.ControlsVisible;
            _cachedCaptionVisible = window.CaptionVisible;
            _cachedIconVisible = window.IconVisible;
            _cachedAllowMinimize = window.AllowMinimize;
            _cachedAllowMaximize = window.AllowMaximize;
        }

        private void RestoreCachedWindowStyles()
        {
            // Cached client bounds will only exist if the display mode was initially set to borderless fullscreen

            using (_ignoreClientSizeChanges.Increment())
            {
                _window.SetWindowStyles(
                    _cachedBorderStyle,
                    _cachedCaptionVisible,
                    _cachedControlsVisible,
                    _cachedIconVisible,
                    _cachedAllowMinimize,
                    _cachedAllowMaximize);

                if (_cachedClientBounds is not null)
                {
                    _window.ClientBounds = _cachedClientBounds.Value;
                    _cachedClientBounds = null;
                }
                else
                {
                    // If there are no cached client bounds, use the cached window placement, instead
                    RestoreCachedWindowPlacement();
                }
            }
        }

        private unsafe void CacheWindowPlacement()
        {
            fixed (WINDOWPLACEMENT* pCachedWindowPlacement = &_cachedWindowPlacement)
            {
                ThrowExternalExceptionIfFALSE(
                    GetWindowPlacement(_window.Handle, pCachedWindowPlacement),
                    nameof(GetWindowPlacement));
            }
        }

        private unsafe void RestoreCachedWindowPlacement()
        {
            fixed (WINDOWPLACEMENT* pCachedWindowPlacement = &_cachedWindowPlacement)
            {
                ThrowExternalExceptionIfFALSE(
                    SetWindowPlacement(_window.Handle, pCachedWindowPlacement),
                    nameof(SetWindowPlacement));
            }
        }

        private void CacheResolution()
        {
            _cachedResolution = _window.ClientSize;
        }

        private void ProcessResolutionChange()
        {
            if (_window.ClientSize != _cachedResolution)
            {
                _messageQueueHelper.Publish(new ResolutionChangedMessage(_cachedResolution, _window.ClientSize));
            }
        }

        private void HandleWmCaptureChanged()
        {
            _mouseCaptured = false;
            _ = ShowCursor(TRUE);
        }

        private void HandleWmClose(out nint? result)
        {
            _messageQueueHelper.Publish<RenderWindowClosingMessage>();

            result = 0;
        }

        private void HandleWmDisplayChange()
        {
            _monitorProvider.Refresh();
        }

        private void HandleWmEnterSizeMove()
        {
            _ignoreClientSizeChanges.Increment();
        }

        private void HandleWmExitSizeMove()
        {
            _ignoreClientSizeChanges.Decrement();
        }

        private static void HandleWmMenuChar(out nint? result)
        {
            result = MNC_CLOSE << 16;
        }

        private void HandleWmMouseMove()
        {
            if (!_mouseCaptured)
            {
                return;
            }

            Vector2<int> center = _window.ClientBounds.Center;

            ThrowExternalExceptionIfFALSE(
                SetCursorPos(center.X, center.Y),
                nameof(SetCursorPos));
        }

        private static void HandleWmPowerBroadcast(nuint wParam, ref nint? result)
        {
            if (wParam == PBT_APMQUERYSUSPEND)
            {
                result = 1;
            }
        }

        private void WindowOnBeforeMessageProcessing(HWND windowHandle, uint message, nuint wParam, nint lParam, ref nint? result)
        {
            WindowMessageReceived?.Invoke(windowHandle, message, wParam, lParam);
        }

        private void WindowOnAfterMessageProcessing(HWND windowHandle, uint message, nuint wParam, nint lParam, ref nint? result)
        {
            switch (message)
            {
                case WM_CLOSE:
                    HandleWmClose(out result);
                    break;
                case WM_CAPTURECHANGED:
                    HandleWmCaptureChanged();
                    break;
                case WM_DISPLAYCHANGE:
                    HandleWmDisplayChange();
                    break;
                case WM_ENTERSIZEMOVE:
                    HandleWmEnterSizeMove();
                    break;
                case WM_EXITSIZEMOVE:
                    HandleWmExitSizeMove();
                    break;
                case WM_MENUCHAR:
                    HandleWmMenuChar(out result);
                    break;
                case WM_MOUSEMOVE:
                    HandleWmMouseMove();
                    break;
                case WM_POWERBROADCAST:
                    HandleWmPowerBroadcast(wParam, ref result);
                    break;
            }
        }

        private void WindowOnClientSizeChanged(object? sender, PropertyChangedEventArgs<Vector2<int>> e)
        {
            if (_ignoreClientSizeChanges.IsZero)
            {
                _messageQueueHelper.Publish(new ResolutionChangedMessage(e.OldValue, e.NewValue));
            }
        }

        private void WindowOnNonClientLocationChanged(object? sender, PropertyChangedEventArgs<Vector2<int>> e)
        {
            Monitor newMonitor = _window.GetMonitor();

            if (newMonitor == _monitor)
            {
                return;
            }

            Monitor oldMonitor = _monitor;

            _monitor = newMonitor;

            _messageQueueHelper.Publish(new MonitorChangedMessage(oldMonitor, newMonitor));
        }

        private void WindowOnActivated(object? sender, EventArgs e)
        {
            _messageQueueHelper.Publish(new RenderWindowActivationChangedMessage(false, true));
        }

        private void WindowOnDeactivated(object? sender, EventArgs e)
        {
            if (_mouseCaptured)
            {
                ThrowExternalExceptionIfFALSE(
                    ReleaseCapture(),
                    nameof(ReleaseCapture));
            }

            _messageQueueHelper.Publish(new RenderWindowActivationChangedMessage(true, false));
        }
    }
}