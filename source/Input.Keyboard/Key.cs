using System.Diagnostics.CodeAnalysis;
using static TerraFX.Interop.Windows;

#pragma warning disable 1591

namespace NathanAldenSr.VorpalEngine.Input.Keyboard
{
    /// <summary></summary>
    /// <remarks>Some duplicates are commented out to prevent dictionary key violations.</remarks>
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "<Pending>")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum Key : byte
    {
        /// <summary><see cref="VK_LBUTTON" />.</summary>
        LeftMouseButton = VK_LBUTTON,

        /// <summary><see cref="VK_RBUTTON" />.</summary>
        RightMouseButton = VK_RBUTTON,

        /// <summary><see cref="VK_CANCEL" />.</summary>
        Break = VK_CANCEL,

        /// <summary><see cref="VK_MBUTTON" />.</summary>
        MiddleMouseButton = VK_MBUTTON,

        /// <summary><see cref="VK_XBUTTON1" />.</summary>
        X1MouseButton = VK_XBUTTON1,

        /// <summary><see cref="VK_XBUTTON2" />.</summary>
        X2MouseButton = VK_XBUTTON2,

        /// <summary><see cref="VK_BACK" />.</summary>
        Backspace = VK_BACK,

        /// <summary><see cref="VK_TAB" />.</summary>
        Tab = VK_TAB,

        /// <summary><see cref="VK_CLEAR" />.</summary>
        Clear = VK_CLEAR,

        /// <summary><see cref="VK_RETURN" />.</summary>
        Enter = VK_RETURN,

        // The following three virtual keys are mapped to their left and right equivalents:
        // Shift = VK_SHIFT,
        // Control = VK_CONTROL,
        // Menu = VK_MENU,

        /// <summary><see cref="VK_PAUSE" />.</summary>
        Pause = VK_PAUSE,

        /// <summary><see cref="VK_CAPITAL" />.</summary>
        CapsLock = VK_CAPITAL,

        // Duplicates:
        // Kana = VK_KANA,
        // Hangeul = VK_HANGEUL,

        /// <summary><see cref="VK_HANGUL" />.</summary>
        ImeHangulMode = VK_HANGUL,

        /// <summary>0x16.</summary>
        ImeOn = 0x16,

        /// <summary><see cref="VK_JUNJA" />.</summary>
        ImeJunjaMode = VK_JUNJA,

        /// <summary><see cref="VK_FINAL" />.</summary>
        ImeFinalMode = VK_FINAL,

        // Duplicate:
        // Hanja = VK_HANJA,

        /// <summary><see cref="VK_KANJI" />.</summary>
        ImeKanjiMode = VK_KANJI,
        ImeOff = 0x1A,

        /// <summary><see cref="VK_ESCAPE" />.</summary>
        Escape = VK_ESCAPE,

        /// <summary><see cref="VK_CONVERT" />.</summary>
        ImeConvert = VK_CONVERT,

        /// <summary><see cref="VK_NONCONVERT" />.</summary>
        ImeNonConvert = VK_NONCONVERT,

        /// <summary><see cref="VK_ACCEPT" />.</summary>
        ImeAccept = VK_ACCEPT,

        /// <summary><see cref="VK_MODECHANGE" />.</summary>
        ImeModeChangeRequest = VK_MODECHANGE,

        /// <summary><see cref="VK_SPACE" />.</summary>
        Space = VK_SPACE,

        /// <summary><see cref="VK_PRIOR" />.</summary>
        PageUp = VK_PRIOR,

        /// <summary><see cref="VK_NEXT" />.</summary>
        PageDown = VK_NEXT,

        /// <summary><see cref="VK_END" />.</summary>
        End = VK_END,

        /// <summary><see cref="VK_HOME" />.</summary>
        Home = VK_HOME,

        /// <summary><see cref="VK_LEFT" />.</summary>
        LeftArrow = VK_LEFT,

        /// <summary><see cref="VK_UP" />.</summary>
        UpArrow = VK_UP,

        /// <summary><see cref="VK_RIGHT" />.</summary>
        RightArrow = VK_RIGHT,

        /// <summary><see cref="VK_DOWN" />.</summary>
        DownArrow = VK_DOWN,

        /// <summary><see cref="VK_SELECT" />.</summary>
        Select = VK_SELECT,

        /// <summary><see cref="VK_PRINT" />.</summary>
        Print = VK_PRINT,

        /// <summary><see cref="VK_EXECUTE" />.</summary>
        Execute = VK_EXECUTE,

        /// <summary><see cref="VK_SNAPSHOT" />.</summary>
        PrintScreen = VK_SNAPSHOT,

        /// <summary><see cref="VK_INSERT" />.</summary>
        Insert = VK_INSERT,

        /// <summary><see cref="VK_DELETE" />.</summary>
        Delete = VK_DELETE,

        /// <summary><see cref="VK_HELP" />.</summary>
        Help = VK_HELP,
        Digit0 = 0x30,
        Digit1 = 0x31,
        Digit2 = 0x32,
        Digit3 = 0x33,
        Digit4 = 0x34,
        Digit5 = 0x35,
        Digit6 = 0x36,
        Digit7 = 0x37,
        Digit8 = 0x38,
        Digit9 = 0x39,
        A = 0x41,
        B = 0x42,
        C = 0x43,
        D = 0x44,
        E = 0x45,
        F = 0x46,
        G = 0x47,
        H = 0x48,
        I = 0x49,
        J = 0x4A,
        K = 0x4B,
        L = 0x4C,
        M = 0x4D,
        N = 0x4E,
        O = 0x4F,
        P = 0x50,
        Q = 0x51,
        R = 0x52,
        S = 0x53,
        T = 0x54,
        U = 0x55,
        V = 0x56,
        W = 0x57,
        X = 0x58,
        Y = 0x59,
        Z = 0x5A,

        /// <summary><see cref="VK_LWIN" />.</summary>
        LeftWindows = VK_LWIN,

        /// <summary><see cref="VK_RWIN" />.</summary>
        RightWindows = VK_RWIN,

        /// <summary><see cref="VK_APPS" />.</summary>
        Applications = VK_APPS,

        /// <summary><see cref="VK_SLEEP" />.</summary>
        Sleep = VK_SLEEP,

        /// <summary><see cref="VK_NUMPAD0" />.</summary>
        NumericKeypad0 = VK_NUMPAD0,

        /// <summary><see cref="VK_NUMPAD1" />.</summary>
        NumericKeypad1 = VK_NUMPAD1,

        /// <summary><see cref="VK_NUMPAD2" />.</summary>
        NumericKeypad2 = VK_NUMPAD2,

        /// <summary><see cref="VK_NUMPAD3" />.</summary>
        NumericKeypad3 = VK_NUMPAD3,

        /// <summary><see cref="VK_NUMPAD4" />.</summary>
        NumericKeypad4 = VK_NUMPAD4,

        /// <summary><see cref="VK_NUMPAD5" />.</summary>
        NumericKeypad5 = VK_NUMPAD5,

        /// <summary><see cref="VK_NUMPAD6" />.</summary>
        NumericKeypad6 = VK_NUMPAD6,

        /// <summary><see cref="VK_NUMPAD7" />.</summary>
        NumericKeypad7 = VK_NUMPAD7,

        /// <summary><see cref="VK_NUMPAD8" />.</summary>
        NumericKeypad8 = VK_NUMPAD8,

        /// <summary><see cref="VK_NUMPAD9" />.</summary>
        NumericKeypad9 = VK_NUMPAD9,

        /// <summary><see cref="VK_MULTIPLY" />.</summary>
        Multiply = VK_MULTIPLY,

        /// <summary><see cref="VK_ADD" />.</summary>
        Add = VK_ADD,

        /// <summary><see cref="VK_SEPARATOR" />.</summary>
        Separator = VK_SEPARATOR,

        /// <summary><see cref="VK_SUBTRACT" />.</summary>
        Subtract = VK_SUBTRACT,

        /// <summary><see cref="VK_DECIMAL" />.</summary>
        Decimal = VK_DECIMAL,

        /// <summary><see cref="VK_DIVIDE" />.</summary>
        Divide = VK_DIVIDE,

        /// <summary><see cref="VK_F1" />.</summary>
        F1 = VK_F1,

        /// <summary><see cref="VK_F2" />.</summary>
        F2 = VK_F2,

        /// <summary><see cref="VK_F3" />.</summary>
        F3 = VK_F3,

        /// <summary><see cref="VK_F4" />.</summary>
        F4 = VK_F4,

        /// <summary><see cref="VK_F5" />.</summary>
        F5 = VK_F5,

        /// <summary><see cref="VK_F6" />.</summary>
        F6 = VK_F6,

        /// <summary><see cref="VK_F7" />.</summary>
        F7 = VK_F7,

        /// <summary><see cref="VK_F8" />.</summary>
        F8 = VK_F8,

        /// <summary><see cref="VK_F9" />.</summary>
        F9 = VK_F9,

        /// <summary><see cref="VK_F10" />.</summary>
        F10 = VK_F10,

        /// <summary><see cref="VK_F11" />.</summary>
        F11 = VK_F11,

        /// <summary><see cref="VK_F12" />.</summary>
        F12 = VK_F12,

        /// <summary><see cref="VK_F13" />.</summary>
        F13 = VK_F13,

        /// <summary><see cref="VK_F14" />.</summary>
        F14 = VK_F14,

        /// <summary><see cref="VK_F15" />.</summary>
        F15 = VK_F15,

        /// <summary><see cref="VK_F16" />.</summary>
        F16 = VK_F16,

        /// <summary><see cref="VK_F17" />.</summary>
        F17 = VK_F17,

        /// <summary><see cref="VK_F18" />.</summary>
        F18 = VK_F18,

        /// <summary><see cref="VK_F19" />.</summary>
        F19 = VK_F19,

        /// <summary><see cref="VK_F20" />.</summary>
        F20 = VK_F20,

        /// <summary><see cref="VK_F21" />.</summary>
        F21 = VK_F21,

        /// <summary><see cref="VK_F22" />.</summary>
        F22 = VK_F22,

        /// <summary><see cref="VK_F23" />.</summary>
        F23 = VK_F23,

        /// <summary><see cref="VK_F24" />.</summary>
        F24 = VK_F24,

        /// <summary><see cref="VK_NUMLOCK" />.</summary>
        NumLock = VK_NUMLOCK,

        /// <summary><see cref="VK_SCROLL" />.</summary>
        ScrollLock = VK_SCROLL,

        /// <summary><see cref="VK_LSHIFT" />.</summary>
        LeftShift = VK_LSHIFT,

        /// <summary><see cref="VK_RSHIFT" />.</summary>
        RightShift = VK_RSHIFT,

        /// <summary><see cref="VK_LCONTROL" />.</summary>
        LeftControl = VK_LCONTROL,

        /// <summary><see cref="VK_RCONTROL" />.</summary>
        RightControl = VK_RCONTROL,

        /// <summary><see cref="VK_LMENU" />.</summary>
        LeftAlt = VK_LMENU,

        /// <summary><see cref="VK_RMENU" />.</summary>
        RightAlt = VK_RMENU,

        /// <summary><see cref="VK_BROWSER_BACK" />.</summary>
        BrowserBack = VK_BROWSER_BACK,

        /// <summary><see cref="VK_BROWSER_FORWARD" />.</summary>
        BrowserForward = VK_BROWSER_FORWARD,

        /// <summary><see cref="VK_BROWSER_REFRESH" />.</summary>
        BrowserRefresh = VK_BROWSER_REFRESH,

        /// <summary><see cref="VK_BROWSER_STOP" />.</summary>
        BrowserStop = VK_BROWSER_STOP,

        /// <summary><see cref="VK_BROWSER_SEARCH" />.</summary>
        BrowserSearch = VK_BROWSER_SEARCH,

        /// <summary><see cref="VK_BROWSER_FAVORITES" />.</summary>
        BrowserFavorites = VK_BROWSER_FAVORITES,

        /// <summary><see cref="VK_BROWSER_HOME" />.</summary>
        BrowserHome = VK_BROWSER_HOME,

        /// <summary><see cref="VK_VOLUME_MUTE" />.</summary>
        VolumeMute = VK_VOLUME_MUTE,

        /// <summary><see cref="VK_VOLUME_DOWN" />.</summary>
        VolumeDown = VK_VOLUME_DOWN,

        /// <summary><see cref="VK_VOLUME_UP" />.</summary>
        VolumeUp = VK_VOLUME_UP,

        /// <summary><see cref="VK_MEDIA_NEXT_TRACK" />.</summary>
        MediaNextTrack = VK_MEDIA_NEXT_TRACK,

        /// <summary><see cref="VK_MEDIA_PREV_TRACK" />.</summary>
        MediaPreviousTrack = VK_MEDIA_PREV_TRACK,

        /// <summary><see cref="VK_MEDIA_STOP" />.</summary>
        MediaStop = VK_MEDIA_STOP,

        /// <summary><see cref="VK_MEDIA_PLAY_PAUSE" />.</summary>
        MediaPlayPause = VK_MEDIA_PLAY_PAUSE,

        /// <summary><see cref="VK_LAUNCH_MAIL" />.</summary>
        LaunchMail = VK_LAUNCH_MAIL,

        /// <summary><see cref="VK_LAUNCH_MEDIA_SELECT" />.</summary>
        LaunchMediaSelect = VK_LAUNCH_MEDIA_SELECT,

        /// <summary><see cref="VK_LAUNCH_APP1" />.</summary>
        LaunchApplication1 = VK_LAUNCH_APP1,

        /// <summary><see cref="VK_LAUNCH_APP2" />.</summary>
        LaunchApplication2 = VK_LAUNCH_APP2,

        /// <summary><see cref="VK_OEM_1" />.</summary>
        Oem1 = VK_OEM_1,

        /// <summary><see cref="VK_OEM_PLUS" />.</summary>
        OemPlus = VK_OEM_PLUS,

        /// <summary><see cref="VK_OEM_COMMA" />.</summary>
        OemComma = VK_OEM_COMMA,

        /// <summary><see cref="VK_OEM_MINUS" />.</summary>
        OemMinus = VK_OEM_MINUS,

        /// <summary><see cref="VK_OEM_PERIOD" />.</summary>
        OemPeriod = VK_OEM_PERIOD,

        /// <summary><see cref="VK_OEM_2" />.</summary>
        Oem2 = VK_OEM_2,

        /// <summary><see cref="VK_OEM_3" />.</summary>
        Oem3 = VK_OEM_3,

        /// <summary><see cref="VK_OEM_4" />.</summary>
        Oem4 = VK_OEM_4,

        /// <summary><see cref="VK_OEM_5" />.</summary>
        Oem5 = VK_OEM_5,

        /// <summary><see cref="VK_OEM_6" />.</summary>
        Oem6 = VK_OEM_6,

        /// <summary><see cref="VK_OEM_7" />.</summary>
        Oem7 = VK_OEM_7,

        /// <summary><see cref="VK_OEM_8" />.</summary>
        Oem8 = VK_OEM_8,
        OemSpecific1 = 0xE1,

        /// <summary><see cref="VK_OEM_102" />.</summary>
        Oem102 = VK_OEM_102,
        OemSpecific2 = 0xE3,
        OemSpecific3 = 0xE4,

        /// <summary><see cref="VK_PROCESSKEY" />.</summary>
        ImeProcess = VK_PROCESSKEY,
        OemSpecific4 = 0xE6,

        /// <summary><see cref="VK_PACKET" />.</summary>
        Packet = VK_PACKET,
        OemSpecific5 = 0xE9,
        OemSpecific6 = 0xEA,
        OemSpecific7 = 0xEB,
        OemSpecific8 = 0xEC,
        OemSpecific9 = 0xED,
        OemSpecific10 = 0xEE,
        OemSpecific11 = 0xEF,
        OemSpecific13 = 0xF0,
        OemSpecific14 = 0xF1,
        OemSpecific15 = 0xF2,
        OemSpecific16 = 0xF3,
        OemSpecific17 = 0xF4,
        OemSpecific18 = 0xF5,

        /// <summary><see cref="VK_ATTN" />.</summary>
        Attn = VK_ATTN,

        /// <summary><see cref="VK_CRSEL" />.</summary>
        CrSel = VK_CRSEL,

        /// <summary><see cref="VK_EXSEL" />.</summary>
        ExSel = VK_EXSEL,

        /// <summary><see cref="VK_EREOF" />.</summary>
        EraseEof = VK_EREOF,

        /// <summary><see cref="VK_PLAY" />.</summary>
        Play = VK_PLAY,

        /// <summary><see cref="VK_ZOOM" />.</summary>
        Zoom = VK_ZOOM,

        /// <summary><see cref="VK_PA1" />.</summary>
        PA1 = VK_PA1,

        /// <summary><see cref="VK_OEM_CLEAR" />.</summary>
        OemClear = VK_OEM_CLEAR
    }
}