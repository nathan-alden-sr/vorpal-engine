using TerraFX.Interop;
using static NathanAldenSr.VorpalEngine.Common.ExceptionHelper;
using static TerraFX.Interop.Windows;

namespace NathanAldenSr.VorpalEngine.Input.Mouse.RawInput
{
    /// <summary>Manages mouse input based on Raw Input.</summary>
    public class RawInputMouseManager : MouseManager, IRawInputMouseManager
    {
        /// <inheritdoc />
        public unsafe void UpdateState(RAWINPUT* rawInput)
        {
            RAWMOUSE rawMouse = rawInput->data.mouse;

            if (rawMouse.usFlags != MOUSE_MOVE_RELATIVE)
            {
                ThrowArgumentOutOfRangeException(nameof(RAWMOUSE.usFlags), rawMouse.usFlags);
            }

            RelativeLocationXDelta += rawMouse.lLastX;
            RelativeLocationYDelta += rawMouse.lLastY;

            ushort buttonFlags = rawMouse.Anonymous.Anonymous.usButtonFlags;

            if ((buttonFlags & RI_MOUSE_LEFT_BUTTON_DOWN) != 0)
            {
                SetButtonDown(Button.Left, true);
            }
            if ((buttonFlags & RI_MOUSE_LEFT_BUTTON_UP) != 0)
            {
                SetButtonDown(Button.Left, false);
            }
            if ((buttonFlags & RI_MOUSE_MIDDLE_BUTTON_DOWN) != 0)
            {
                SetButtonDown(Button.Middle, true);
            }
            if ((buttonFlags & RI_MOUSE_MIDDLE_BUTTON_UP) != 0)
            {
                SetButtonDown(Button.Middle, false);
            }
            if ((buttonFlags & RI_MOUSE_RIGHT_BUTTON_DOWN) != 0)
            {
                SetButtonDown(Button.Right, true);
            }
            if ((buttonFlags & RI_MOUSE_RIGHT_BUTTON_UP) != 0)
            {
                SetButtonDown(Button.Right, false);
            }
            if ((buttonFlags & RI_MOUSE_BUTTON_4_DOWN) != 0)
            {
                SetButtonDown(Button.Four, true);
            }
            if ((buttonFlags & RI_MOUSE_BUTTON_4_UP) != 0)
            {
                SetButtonDown(Button.Four, false);
            }
            if ((buttonFlags & RI_MOUSE_BUTTON_5_DOWN) != 0)
            {
                SetButtonDown(Button.Five, true);
            }
            if ((buttonFlags & RI_MOUSE_BUTTON_5_UP) != 0)
            {
                SetButtonDown(Button.Five, false);
            }
            if ((buttonFlags & RI_MOUSE_WHEEL) != 0)
            {
                RelativeWheelDelta += unchecked((short)rawMouse.Anonymous.Anonymous.usButtonData);
            }
            if ((buttonFlags & RI_MOUSE_HWHEEL) != 0)
            {
                RelativeHorizontalWheelDelta += unchecked((short)rawMouse.Anonymous.Anonymous.usButtonData);
            }
        }
    }
}