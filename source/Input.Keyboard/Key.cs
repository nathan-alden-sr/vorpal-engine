using System.Diagnostics.CodeAnalysis;
using static TerraFX.Interop.Windows;

#pragma warning disable 1591

namespace NathanAldenSr.VorpalEngine.Input.Keyboard
{
    /// <summary></summary>
    /// <remarks>Some duplicates are commented out to prevent dictionary key violations.</remarks>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Roslyn is over-aggressive")]
    public enum Key : byte
    {
        /// <summary>Left mouse button. <see cref="VK_LBUTTON" />.</summary>
        LeftMouseButton = VK_LBUTTON,

        /// <summary>Right mouse button. <see cref="VK_RBUTTON" />.</summary>
        RightMouseButton = VK_RBUTTON,

        /// <summary>Cancel. <see cref="VK_CANCEL" />.</summary>
        Break = VK_CANCEL,

        /// <summary>Middle mouse button. <see cref="VK_MBUTTON" />.</summary>
        MiddleMouseButton = VK_MBUTTON,

        /// <summary>X1 mouse button. <see cref="VK_XBUTTON1" />.</summary>
        X1MouseButton = VK_XBUTTON1,

        /// <summary>X2 mouse button. <see cref="VK_XBUTTON2" />.</summary>
        X2MouseButton = VK_XBUTTON2,

        /// <summary>Backspace. <see cref="VK_BACK" />.</summary>
        Backspace = VK_BACK,

        /// <summary>Tab. <see cref="VK_TAB" />.</summary>
        Tab = VK_TAB,

        /// <summary>Clear. <see cref="VK_CLEAR" />.</summary>
        Clear = VK_CLEAR,

        /// <summary>Return. <see cref="VK_RETURN" />.</summary>
        Enter = VK_RETURN,

        // The following three virtual keys are mapped to their left and right equivalents:
        // Shift = VK_SHIFT,
        // Control = VK_CONTROL,
        // Menu = VK_MENU,

        /// <summary>Pause. <see cref="VK_PAUSE" />.</summary>
        Pause = VK_PAUSE,

        /// <summary>Caps lock. <see cref="VK_CAPITAL" />.</summary>
        CapsLock = VK_CAPITAL,

        // Duplicates:
        // Kana = VK_KANA,
        // Hangeul = VK_HANGEUL,

        /// <summary>IME Hangul mode. <see cref="VK_HANGUL" />.</summary>
        ImeHangulMode = VK_HANGUL,

        /// <summary>IME on.</summary>
        ImeOn = 0x16,

        /// <summary>IME Junja mode. <see cref="VK_JUNJA" />.</summary>
        ImeJunjaMode = VK_JUNJA,

        /// <summary>IME final mode. <see cref="VK_FINAL" />.</summary>
        ImeFinalMode = VK_FINAL,

        // Duplicate:
        // Hanja = VK_HANJA,

        /// <summary>IME Kanji mode. <see cref="VK_KANJI" />.</summary>
        ImeKanjiMode = VK_KANJI,
        ImeOff = 0x1A,

        /// <summary>Escape. <see cref="VK_ESCAPE" />.</summary>
        Escape = VK_ESCAPE,

        /// <summary>IME convert. <see cref="VK_CONVERT" />.</summary>
        ImeConvert = VK_CONVERT,

        /// <summary>IME non-convert. <see cref="VK_NONCONVERT" />.</summary>
        ImeNonConvert = VK_NONCONVERT,

        /// <summary>IME accept. <see cref="VK_ACCEPT" />.</summary>
        ImeAccept = VK_ACCEPT,

        /// <summary>IME mode change request. <see cref="VK_MODECHANGE" />.</summary>
        ImeModeChangeRequest = VK_MODECHANGE,

        /// <summary>Space. <see cref="VK_SPACE" />.</summary>
        Space = VK_SPACE,

        /// <summary>Page up. <see cref="VK_PRIOR" />.</summary>
        PageUp = VK_PRIOR,

        /// <summary>Page down. <see cref="VK_NEXT" />.</summary>
        PageDown = VK_NEXT,

        /// <summary>End. <see cref="VK_END" />.</summary>
        End = VK_END,

        /// <summary>Home. <see cref="VK_HOME" />.</summary>
        Home = VK_HOME,

        /// <summary>Left arrow. <see cref="VK_LEFT" />.</summary>
        LeftArrow = VK_LEFT,

        /// <summary>Up arrow. <see cref="VK_UP" />.</summary>
        UpArrow = VK_UP,

        /// <summary>Right arrow. <see cref="VK_RIGHT" />.</summary>
        RightArrow = VK_RIGHT,

        /// <summary>Down arrow. <see cref="VK_DOWN" />.</summary>
        DownArrow = VK_DOWN,

        /// <summary>Select. <see cref="VK_SELECT" />.</summary>
        Select = VK_SELECT,

        /// <summary>Print. <see cref="VK_PRINT" />.</summary>
        Print = VK_PRINT,

        /// <summary>Execute. <see cref="VK_EXECUTE" />.</summary>
        Execute = VK_EXECUTE,

        /// <summary>Print screen. <see cref="VK_SNAPSHOT" />.</summary>
        PrintScreen = VK_SNAPSHOT,

        /// <summary>Insert. <see cref="VK_INSERT" />.</summary>
        Insert = VK_INSERT,

        /// <summary>Delete. <see cref="VK_DELETE" />.</summary>
        Delete = VK_DELETE,

        /// <summary>Help. <see cref="VK_HELP" />.</summary>
        Help = VK_HELP,

        /// <summary>Digit 0.</summary>
        Digit0 = 0x30,

        /// <summary>Digit 1.</summary>
        Digit1 = 0x31,

        /// <summary>Digit 2.</summary>
        Digit2 = 0x32,

        /// <summary>Digit 3.</summary>
        Digit3 = 0x33,

        /// <summary>Digit 4.</summary>
        Digit4 = 0x34,

        /// <summary>Digit 5.</summary>
        Digit5 = 0x35,

        /// <summary>Digit 6.</summary>
        Digit6 = 0x36,

        /// <summary>Digit 7.</summary>
        Digit7 = 0x37,

        /// <summary>Digit 8.</summary>
        Digit8 = 0x38,

        /// <summary>Digit 9.</summary>
        Digit9 = 0x39,

        /// <summary>A.</summary>
        A = 0x41,

        /// <summary>B.</summary>
        B = 0x42,

        /// <summary>C.</summary>
        C = 0x43,

        /// <summary>D.</summary>
        D = 0x44,

        /// <summary>E.</summary>
        E = 0x45,

        /// <summary>F.</summary>
        F = 0x46,

        /// <summary>G.</summary>
        G = 0x47,

        /// <summary>H.</summary>
        H = 0x48,

        /// <summary>I.</summary>
        I = 0x49,

        /// <summary>J.</summary>
        J = 0x4A,

        /// <summary>K.</summary>
        K = 0x4B,

        /// <summary>L.</summary>
        L = 0x4C,

        /// <summary>M.</summary>
        M = 0x4D,

        /// <summary>N.</summary>
        N = 0x4E,

        /// <summary>O.</summary>
        O = 0x4F,

        /// <summary>P.</summary>
        P = 0x50,

        /// <summary>Q.</summary>
        Q = 0x51,

        /// <summary>R.</summary>
        R = 0x52,

        /// <summary>S.</summary>
        S = 0x53,

        /// <summary>T.</summary>
        T = 0x54,

        /// <summary>U.</summary>
        U = 0x55,

        /// <summary>V.</summary>
        V = 0x56,

        /// <summary>W.</summary>
        W = 0x57,

        /// <summary>X.</summary>
        X = 0x58,

        /// <summary>Y.</summary>
        Y = 0x59,

        /// <summary>Z.</summary>
        Z = 0x5A,

        /// <summary>Left Windows. <see cref="VK_LWIN" />.</summary>
        LeftWindows = VK_LWIN,

        /// <summary>Right Windows. <see cref="VK_RWIN" />.</summary>
        RightWindows = VK_RWIN,

        /// <summary>Applications. <see cref="VK_APPS" />.</summary>
        Applications = VK_APPS,

        /// <summary>Sleep. <see cref="VK_SLEEP" />.</summary>
        Sleep = VK_SLEEP,

        /// <summary>Numeric keypad 0. <see cref="VK_NUMPAD0" />.</summary>
        NumericKeypad0 = VK_NUMPAD0,

        /// <summary>Numeric keypad 1. <see cref="VK_NUMPAD1" />.</summary>
        NumericKeypad1 = VK_NUMPAD1,

        /// <summary>Numeric keypad 2. <see cref="VK_NUMPAD2" />.</summary>
        NumericKeypad2 = VK_NUMPAD2,

        /// <summary>Numeric keypad 3. <see cref="VK_NUMPAD3" />.</summary>
        NumericKeypad3 = VK_NUMPAD3,

        /// <summary>Numeric keypad 4. <see cref="VK_NUMPAD4" />.</summary>
        NumericKeypad4 = VK_NUMPAD4,

        /// <summary>Numeric keypad 5. <see cref="VK_NUMPAD5" />.</summary>
        NumericKeypad5 = VK_NUMPAD5,

        /// <summary>Numeric keypad 6. <see cref="VK_NUMPAD6" />.</summary>
        NumericKeypad6 = VK_NUMPAD6,

        /// <summary>Numeric keypad 7. <see cref="VK_NUMPAD7" />.</summary>
        NumericKeypad7 = VK_NUMPAD7,

        /// <summary>Numeric keypad 8. <see cref="VK_NUMPAD8" />.</summary>
        NumericKeypad8 = VK_NUMPAD8,

        /// <summary>Numeric keypad 9. <see cref="VK_NUMPAD9" />.</summary>
        NumericKeypad9 = VK_NUMPAD9,

        /// <summary>Multiply. <see cref="VK_MULTIPLY" />.</summary>
        Multiply = VK_MULTIPLY,

        /// <summary>Add. <see cref="VK_ADD" />.</summary>
        Add = VK_ADD,

        /// <summary>Separator. <see cref="VK_SEPARATOR" />.</summary>
        Separator = VK_SEPARATOR,

        /// <summary>Subtract. <see cref="VK_SUBTRACT" />.</summary>
        Subtract = VK_SUBTRACT,

        /// <summary>Decimal. <see cref="VK_DECIMAL" />.</summary>
        Decimal = VK_DECIMAL,

        /// <summary>Divide. <see cref="VK_DIVIDE" />.</summary>
        Divide = VK_DIVIDE,

        /// <summary>F1. <see cref="VK_F1" />.</summary>
        F1 = VK_F1,

        /// <summary>F2. <see cref="VK_F2" />.</summary>
        F2 = VK_F2,

        /// <summary>F3. <see cref="VK_F3" />.</summary>
        F3 = VK_F3,

        /// <summary>F4. <see cref="VK_F4" />.</summary>
        F4 = VK_F4,

        /// <summary>F5. <see cref="VK_F5" />.</summary>
        F5 = VK_F5,

        /// <summary>F6. <see cref="VK_F6" />.</summary>
        F6 = VK_F6,

        /// <summary>F7. <see cref="VK_F7" />.</summary>
        F7 = VK_F7,

        /// <summary>F8. <see cref="VK_F8" />.</summary>
        F8 = VK_F8,

        /// <summary>F9. <see cref="VK_F9" />.</summary>
        F9 = VK_F9,

        /// <summary>F10. <see cref="VK_F10" />.</summary>
        F10 = VK_F10,

        /// <summary>F11. <see cref="VK_F11" />.</summary>
        F11 = VK_F11,

        /// <summary>F12. <see cref="VK_F12" />.</summary>
        F12 = VK_F12,

        /// <summary>F13. <see cref="VK_F13" />.</summary>
        F13 = VK_F13,

        /// <summary>F14. <see cref="VK_F14" />.</summary>
        F14 = VK_F14,

        /// <summary>F15. <see cref="VK_F15" />.</summary>
        F15 = VK_F15,

        /// <summary>F16. <see cref="VK_F16" />.</summary>
        F16 = VK_F16,

        /// <summary>F17. <see cref="VK_F17" />.</summary>
        F17 = VK_F17,

        /// <summary>F18. <see cref="VK_F18" />.</summary>
        F18 = VK_F18,

        /// <summary>F19. <see cref="VK_F19" />.</summary>
        F19 = VK_F19,

        /// <summary>F20. <see cref="VK_F20" />.</summary>
        F20 = VK_F20,

        /// <summary>F21. <see cref="VK_F21" />.</summary>
        F21 = VK_F21,

        /// <summary>F22. <see cref="VK_F22" />.</summary>
        F22 = VK_F22,

        /// <summary>F23. <see cref="VK_F23" />.</summary>
        F23 = VK_F23,

        /// <summary>F24. <see cref="VK_F24" />.</summary>
        F24 = VK_F24,

        /// <summary>Number lock. <see cref="VK_NUMLOCK" />.</summary>
        NumLock = VK_NUMLOCK,

        /// <summary>Scroll lock. <see cref="VK_SCROLL" />.</summary>
        ScrollLock = VK_SCROLL,

        /// <summary>Left shift. <see cref="VK_LSHIFT" />.</summary>
        LeftShift = VK_LSHIFT,

        /// <summary>Right shift. <see cref="VK_RSHIFT" />.</summary>
        RightShift = VK_RSHIFT,

        /// <summary>Left control. <see cref="VK_LCONTROL" />.</summary>
        LeftControl = VK_LCONTROL,

        /// <summary>Right control. <see cref="VK_RCONTROL" />.</summary>
        RightControl = VK_RCONTROL,

        /// <summary>Left alt. <see cref="VK_LMENU" />.</summary>
        LeftAlt = VK_LMENU,

        /// <summary>Right alt. <see cref="VK_RMENU" />.</summary>
        RightAlt = VK_RMENU,

        /// <summary>Browser back. <see cref="VK_BROWSER_BACK" />.</summary>
        BrowserBack = VK_BROWSER_BACK,

        /// <summary>Browser forward. <see cref="VK_BROWSER_FORWARD" />.</summary>
        BrowserForward = VK_BROWSER_FORWARD,

        /// <summary>Browser refresh. <see cref="VK_BROWSER_REFRESH" />.</summary>
        BrowserRefresh = VK_BROWSER_REFRESH,

        /// <summary>Browser stop. <see cref="VK_BROWSER_STOP" />.</summary>
        BrowserStop = VK_BROWSER_STOP,

        /// <summary>Browser search. <see cref="VK_BROWSER_SEARCH" />.</summary>
        BrowserSearch = VK_BROWSER_SEARCH,

        /// <summary>Browser favorites. <see cref="VK_BROWSER_FAVORITES" />.</summary>
        BrowserFavorites = VK_BROWSER_FAVORITES,

        /// <summary>Browser home. <see cref="VK_BROWSER_HOME" />.</summary>
        BrowserHome = VK_BROWSER_HOME,

        /// <summary>Volume mute. <see cref="VK_VOLUME_MUTE" />.</summary>
        VolumeMute = VK_VOLUME_MUTE,

        /// <summary>Volume down. <see cref="VK_VOLUME_DOWN" />.</summary>
        VolumeDown = VK_VOLUME_DOWN,

        /// <summary>Volume up. <see cref="VK_VOLUME_UP" />.</summary>
        VolumeUp = VK_VOLUME_UP,

        /// <summary>Media next track. <see cref="VK_MEDIA_NEXT_TRACK" />.</summary>
        MediaNextTrack = VK_MEDIA_NEXT_TRACK,

        /// <summary>Media previous track. <see cref="VK_MEDIA_PREV_TRACK" />.</summary>
        MediaPreviousTrack = VK_MEDIA_PREV_TRACK,

        /// <summary>Media stop. <see cref="VK_MEDIA_STOP" />.</summary>
        MediaStop = VK_MEDIA_STOP,

        /// <summary>Media play/pause. <see cref="VK_MEDIA_PLAY_PAUSE" />.</summary>
        MediaPlayPause = VK_MEDIA_PLAY_PAUSE,

        /// <summary>Launch mail. <see cref="VK_LAUNCH_MAIL" />.</summary>
        LaunchMail = VK_LAUNCH_MAIL,

        /// <summary>Launch/select media. <see cref="VK_LAUNCH_MEDIA_SELECT" />.</summary>
        LaunchMediaSelect = VK_LAUNCH_MEDIA_SELECT,

        /// <summary>Launch application 1. <see cref="VK_LAUNCH_APP1" />.</summary>
        LaunchApplication1 = VK_LAUNCH_APP1,

        /// <summary>Launch application 2. <see cref="VK_LAUNCH_APP2" />.</summary>
        LaunchApplication2 = VK_LAUNCH_APP2,

        /// <summary>OEM 1. <see cref="VK_OEM_1" />.</summary>
        Oem1 = VK_OEM_1,

        /// <summary>OEM plus. <see cref="VK_OEM_PLUS" />.</summary>
        OemPlus = VK_OEM_PLUS,

        /// <summary>OEM comma. <see cref="VK_OEM_COMMA" />.</summary>
        OemComma = VK_OEM_COMMA,

        /// <summary>OEM minus. <see cref="VK_OEM_MINUS" />.</summary>
        OemMinus = VK_OEM_MINUS,

        /// <summary>OEM period. <see cref="VK_OEM_PERIOD" />.</summary>
        OemPeriod = VK_OEM_PERIOD,

        /// <summary>OEM 2. <see cref="VK_OEM_2" />.</summary>
        Oem2 = VK_OEM_2,

        /// <summary>OEM 3. <see cref="VK_OEM_3" />.</summary>
        Oem3 = VK_OEM_3,

        /// <summary>OEM 4. <see cref="VK_OEM_4" />.</summary>
        Oem4 = VK_OEM_4,

        /// <summary>OEM 5. <see cref="VK_OEM_5" />.</summary>
        Oem5 = VK_OEM_5,

        /// <summary>OEM 6. <see cref="VK_OEM_6" />.</summary>
        Oem6 = VK_OEM_6,

        /// <summary>OEM 7. <see cref="VK_OEM_7" />.</summary>
        Oem7 = VK_OEM_7,

        /// <summary>OEM 8. <see cref="VK_OEM_8" />.</summary>
        Oem8 = VK_OEM_8,

        /// <summary>OEM-specific 1.</summary>
        OemSpecific1 = 0xE1,

        /// <summary>OEM 102. <see cref="VK_OEM_102" />.</summary>
        Oem102 = VK_OEM_102,

        /// <summary>OEM-specific 2.</summary>
        OemSpecific2 = 0xE3,

        /// <summary>OEM-specific 3.</summary>
        OemSpecific3 = 0xE4,

        /// <summary>IME process. <see cref="VK_PROCESSKEY" />.</summary>
        ImeProcess = VK_PROCESSKEY,

        /// <summary>OEM-specific 4.</summary>
        OemSpecific4 = 0xE6,

        /// <summary>Packet. <see cref="VK_PACKET" />.</summary>
        Packet = VK_PACKET,

        /// <summary>OEM-specific 5.</summary>
        OemSpecific5 = 0xE9,

        /// <summary>OEM-specific 6.</summary>
        OemSpecific6 = 0xEA,

        /// <summary>OEM-specific 7.</summary>
        OemSpecific7 = 0xEB,

        /// <summary>OEM-specific 8.</summary>
        OemSpecific8 = 0xEC,

        /// <summary>OEM-specific 9.</summary>
        OemSpecific9 = 0xED,

        /// <summary>OEM-specific 10.</summary>
        OemSpecific10 = 0xEE,

        /// <summary>OEM-specific 11.</summary>
        OemSpecific11 = 0xEF,

        /// <summary>OEM-specific 12.</summary>
        OemSpecific12 = 0xF0,

        /// <summary>OEM-specific 13.</summary>
        OemSpecific13 = 0xF1,

        /// <summary>OEM-specific 14.</summary>
        OemSpecific14 = 0xF2,

        /// <summary>OEM-specific 15.</summary>
        OemSpecific15 = 0xF3,

        /// <summary>OEM-specific 16.</summary>
        OemSpecific16 = 0xF4,

        /// <summary>OEM-specific 17.</summary>
        OemSpecific17 = 0xF5,

        /// <summary>Attn. <see cref="VK_ATTN" />.</summary>
        Attn = VK_ATTN,

        /// <summary>CrSel. <see cref="VK_CRSEL" />.</summary>
        CrSel = VK_CRSEL,

        /// <summary>ExSel. <see cref="VK_EXSEL" />.</summary>
        ExSel = VK_EXSEL,

        /// <summary>Erase EOF. <see cref="VK_EREOF" />.</summary>
        EraseEof = VK_EREOF,

        /// <summary>Play. <see cref="VK_PLAY" />.</summary>
        Play = VK_PLAY,

        /// <summary>Zoom. <see cref="VK_ZOOM" />.</summary>
        Zoom = VK_ZOOM,

        /// <summary>PA1. <see cref="VK_PA1" />.</summary>
        PA1 = VK_PA1,

        /// <summary>OEM clear. <see cref="VK_OEM_CLEAR" />.</summary>
        OemClear = VK_OEM_CLEAR
    }
}