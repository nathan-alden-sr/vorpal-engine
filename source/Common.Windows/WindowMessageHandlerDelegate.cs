// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using TerraFX.Interop;

namespace VorpalEngine.Common.Windows;

/// <summary>A delegate that handles window messages.</summary>
/// <param name="windowHandle">The window handle the message was sent to.</param>
/// <param name="message">The window message.</param>
/// <param name="wParam">The <c>WPARAM</c> value.</param>
/// <param name="lParam">The <c>LPARAM</c> value.</param>
/// <param name="result">
///     The result of handling the message. When <paramref name="result" /> is <see langword="null" />, the default
///     window procedure will be called; otherwise, it will not be called.
/// </param>
public delegate void WindowMessageHandlerDelegate(HWND windowHandle, uint message, nuint wParam, nint lParam, ref nint? result);