using TerraFX.Interop;

namespace NathanAldenSr.VorpalEngine.Engine.Windows
{
    /// <summary>A delegate that is invoked when a window message is received.</summary>
    /// <param name="windowHandle">The window handle the message was sent to.</param>
    /// <param name="message">The window message.</param>
    /// <param name="wParam">The <c>WPARAM</c> value.</param>
    /// <param name="lParam">The <c>LPARAM</c> value.</param>
    public delegate void WindowMessageReceivedDelegate(HWND windowHandle, uint message, nuint wParam, nint lParam);
}