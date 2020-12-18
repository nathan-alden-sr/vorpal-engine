using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using TerraFX.Interop;

#pragma warning disable 1591

namespace NathanAldenSr.VorpalEngine.Common.Interop
{
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class WindowMessage
    {
        public static readonly WindowMessage MN_GETHMENU = new(nameof(MN_GETHMENU), Windows.MN_GETHMENU);
        public static readonly WindowMessage WM_ACTIVATE = new(nameof(WM_ACTIVATE), Windows.WM_ACTIVATE);
        public static readonly WindowMessage WM_ACTIVATEAPP = new(nameof(WM_ACTIVATEAPP), Windows.WM_ACTIVATEAPP);
        public static readonly WindowMessage WM_AFXFIRST = new(nameof(WM_AFXFIRST), Windows.WM_AFXFIRST);
        public static readonly WindowMessage WM_AFXLAST = new(nameof(WM_AFXLAST), Windows.WM_AFXLAST);
        public static readonly WindowMessage WM_APP = new(nameof(WM_APP), Windows.WM_APP);
        public static readonly WindowMessage WM_APPCOMMAND = new(nameof(WM_APPCOMMAND), Windows.WM_APPCOMMAND);
        public static readonly WindowMessage WM_ASKCBFORMATNAME = new(nameof(WM_ASKCBFORMATNAME), Windows.WM_ASKCBFORMATNAME);
        public static readonly WindowMessage WM_CANCELJOURNAL = new(nameof(WM_CANCELJOURNAL), Windows.WM_CANCELJOURNAL);
        public static readonly WindowMessage WM_CANCELMODE = new(nameof(WM_CANCELMODE), Windows.WM_CANCELMODE);
        public static readonly WindowMessage WM_CAPTURECHANGED = new(nameof(WM_CAPTURECHANGED), Windows.WM_CAPTURECHANGED);
        public static readonly WindowMessage WM_CHANGECBCHAIN = new(nameof(WM_CHANGECBCHAIN), Windows.WM_CHANGECBCHAIN);
        public static readonly WindowMessage WM_CHANGEUISTATE = new(nameof(WM_CHANGEUISTATE), Windows.WM_CHANGEUISTATE);
        public static readonly WindowMessage WM_CHAR = new(nameof(WM_CHAR), Windows.WM_CHAR);
        public static readonly WindowMessage WM_CHARTOITEM = new(nameof(WM_CHARTOITEM), Windows.WM_CHARTOITEM);
        public static readonly WindowMessage WM_CHILDACTIVATE = new(nameof(WM_CHILDACTIVATE), Windows.WM_CHILDACTIVATE);
        public static readonly WindowMessage WM_CLEAR = new(nameof(WM_CLEAR), Windows.WM_CLEAR);
        public static readonly WindowMessage WM_CLIPBOARDUPDATE = new(nameof(WM_CLIPBOARDUPDATE), Windows.WM_CLIPBOARDUPDATE);
        public static readonly WindowMessage WM_CLOSE = new(nameof(WM_CLOSE), Windows.WM_CLOSE);
        public static readonly WindowMessage WM_COMMAND = new(nameof(WM_COMMAND), Windows.WM_COMMAND);
        public static readonly WindowMessage WM_COMMNOTIFY = new(nameof(WM_COMMNOTIFY), Windows.WM_COMMNOTIFY);
        public static readonly WindowMessage WM_COMPACTING = new(nameof(WM_COMPACTING), Windows.WM_COMPACTING);
        public static readonly WindowMessage WM_COMPAREITEM = new(nameof(WM_COMPAREITEM), Windows.WM_COMPAREITEM);
        public static readonly WindowMessage WM_CONTEXTMENU = new(nameof(WM_CONTEXTMENU), Windows.WM_CONTEXTMENU);
        public static readonly WindowMessage WM_COPY = new(nameof(WM_COPY), Windows.WM_COPY);
        public static readonly WindowMessage WM_COPYDATA = new(nameof(WM_COPYDATA), Windows.WM_COPYDATA);
        public static readonly WindowMessage WM_CREATE = new(nameof(WM_CREATE), Windows.WM_CREATE);
        public static readonly WindowMessage WM_CTLCOLORBTN = new(nameof(WM_CTLCOLORBTN), Windows.WM_CTLCOLORBTN);
        public static readonly WindowMessage WM_CTLCOLORDLG = new(nameof(WM_CTLCOLORDLG), Windows.WM_CTLCOLORDLG);
        public static readonly WindowMessage WM_CTLCOLOREDIT = new(nameof(WM_CTLCOLOREDIT), Windows.WM_CTLCOLOREDIT);
        public static readonly WindowMessage WM_CTLCOLORLISTBOX = new(nameof(WM_CTLCOLORLISTBOX), Windows.WM_CTLCOLORLISTBOX);
        public static readonly WindowMessage WM_CTLCOLORMSGBOX = new(nameof(WM_CTLCOLORMSGBOX), Windows.WM_CTLCOLORMSGBOX);
        public static readonly WindowMessage WM_CTLCOLORSCROLLBAR = new(nameof(WM_CTLCOLORSCROLLBAR), Windows.WM_CTLCOLORSCROLLBAR);
        public static readonly WindowMessage WM_CTLCOLORSTATIC = new(nameof(WM_CTLCOLORSTATIC), Windows.WM_CTLCOLORSTATIC);
        public static readonly WindowMessage WM_CUT = new(nameof(WM_CUT), Windows.WM_CUT);
        public static readonly WindowMessage WM_DEADCHAR = new(nameof(WM_DEADCHAR), Windows.WM_DEADCHAR);
        public static readonly WindowMessage WM_DELETEITEM = new(nameof(WM_DELETEITEM), Windows.WM_DELETEITEM);
        public static readonly WindowMessage WM_DESTROY = new(nameof(WM_DESTROY), Windows.WM_DESTROY);
        public static readonly WindowMessage WM_DESTROYCLIPBOARD = new(nameof(WM_DESTROYCLIPBOARD), Windows.WM_DESTROYCLIPBOARD);
        public static readonly WindowMessage WM_DEVICECHANGE = new(nameof(WM_DEVICECHANGE), Windows.WM_DEVICECHANGE);
        public static readonly WindowMessage WM_DEVMODECHANGE = new(nameof(WM_DEVMODECHANGE), Windows.WM_DEVMODECHANGE);
        public static readonly WindowMessage WM_DISPLAYCHANGE = new(nameof(WM_DISPLAYCHANGE), Windows.WM_DISPLAYCHANGE);
        public static readonly WindowMessage WM_DPICHANGED = new(nameof(WM_DPICHANGED), Windows.WM_DPICHANGED);
        public static readonly WindowMessage WM_DPICHANGED_AFTERPARENT = new(nameof(WM_DPICHANGED_AFTERPARENT), Windows.WM_DPICHANGED_AFTERPARENT);
        public static readonly WindowMessage WM_DPICHANGED_BEFOREPARENT = new(nameof(WM_DPICHANGED_BEFOREPARENT), Windows.WM_DPICHANGED_BEFOREPARENT);
        public static readonly WindowMessage WM_DRAWCLIPBOARD = new(nameof(WM_DRAWCLIPBOARD), Windows.WM_DRAWCLIPBOARD);
        public static readonly WindowMessage WM_DRAWITEM = new(nameof(WM_DRAWITEM), Windows.WM_DRAWITEM);
        public static readonly WindowMessage WM_DROPFILES = new(nameof(WM_DROPFILES), Windows.WM_DROPFILES);

        public static readonly WindowMessage WM_DWMCOLORIZATIONCOLORCHANGED = new(
            nameof(WM_DWMCOLORIZATIONCOLORCHANGED),
            Windows.WM_DWMCOLORIZATIONCOLORCHANGED);

        public static readonly WindowMessage WM_DWMCOMPOSITIONCHANGED = new(nameof(WM_DWMCOMPOSITIONCHANGED), Windows.WM_DWMCOMPOSITIONCHANGED);
        public static readonly WindowMessage WM_DWMNCRENDERINGCHANGED = new(nameof(WM_DWMNCRENDERINGCHANGED), Windows.WM_DWMNCRENDERINGCHANGED);

        public static readonly WindowMessage WM_DWMSENDICONICLIVEPREVIEWBITMAP = new(
            nameof(WM_DWMSENDICONICLIVEPREVIEWBITMAP),
            Windows.WM_DWMSENDICONICLIVEPREVIEWBITMAP);

        public static readonly WindowMessage WM_DWMSENDICONICTHUMBNAIL = new(nameof(WM_DWMSENDICONICTHUMBNAIL), Windows.WM_DWMSENDICONICTHUMBNAIL);
        public static readonly WindowMessage WM_DWMWINDOWMAXIMIZEDCHANGE = new(nameof(WM_DWMWINDOWMAXIMIZEDCHANGE), Windows.WM_DWMWINDOWMAXIMIZEDCHANGE);
        public static readonly WindowMessage WM_ENABLE = new(nameof(WM_ENABLE), Windows.WM_ENABLE);
        public static readonly WindowMessage WM_ENDSESSION = new(nameof(WM_ENDSESSION), Windows.WM_ENDSESSION);
        public static readonly WindowMessage WM_ENTERIDLE = new(nameof(WM_ENTERIDLE), Windows.WM_ENTERIDLE);
        public static readonly WindowMessage WM_ENTERMENULOOP = new(nameof(WM_ENTERMENULOOP), Windows.WM_ENTERMENULOOP);
        public static readonly WindowMessage WM_ENTERSIZEMOVE = new(nameof(WM_ENTERSIZEMOVE), Windows.WM_ENTERSIZEMOVE);
        public static readonly WindowMessage WM_ERASEBKGND = new(nameof(WM_ERASEBKGND), Windows.WM_ERASEBKGND);
        public static readonly WindowMessage WM_EXITMENULOOP = new(nameof(WM_EXITMENULOOP), Windows.WM_EXITMENULOOP);
        public static readonly WindowMessage WM_EXITSIZEMOVE = new(nameof(WM_EXITSIZEMOVE), Windows.WM_EXITSIZEMOVE);
        public static readonly WindowMessage WM_FONTCHANGE = new(nameof(WM_FONTCHANGE), Windows.WM_FONTCHANGE);
        public static readonly WindowMessage WM_GESTURE = new(nameof(WM_GESTURE), Windows.WM_GESTURE);
        public static readonly WindowMessage WM_GESTURENOTIFY = new(nameof(WM_GESTURENOTIFY), Windows.WM_GESTURENOTIFY);
        public static readonly WindowMessage WM_GETDLGCODE = new(nameof(WM_GETDLGCODE), Windows.WM_GETDLGCODE);
        public static readonly WindowMessage WM_GETDPISCALEDSIZE = new(nameof(WM_GETDPISCALEDSIZE), Windows.WM_GETDPISCALEDSIZE);
        public static readonly WindowMessage WM_GETFONT = new(nameof(WM_GETFONT), Windows.WM_GETFONT);
        public static readonly WindowMessage WM_GETHOTKEY = new(nameof(WM_GETHOTKEY), Windows.WM_GETHOTKEY);
        public static readonly WindowMessage WM_GETICON = new(nameof(WM_GETICON), Windows.WM_GETICON);
        public static readonly WindowMessage WM_GETMINMAXINFO = new(nameof(WM_GETMINMAXINFO), Windows.WM_GETMINMAXINFO);
        public static readonly WindowMessage WM_GETOBJECT = new(nameof(WM_GETOBJECT), Windows.WM_GETOBJECT);
        public static readonly WindowMessage WM_GETTEXT = new(nameof(WM_GETTEXT), Windows.WM_GETTEXT);
        public static readonly WindowMessage WM_GETTEXTLENGTH = new(nameof(WM_GETTEXTLENGTH), Windows.WM_GETTEXTLENGTH);
        public static readonly WindowMessage WM_GETTITLEBARINFOEX = new(nameof(WM_GETTITLEBARINFOEX), Windows.WM_GETTITLEBARINFOEX);
        public static readonly WindowMessage WM_HANDHELDFIRST = new(nameof(WM_HANDHELDFIRST), Windows.WM_HANDHELDFIRST);
        public static readonly WindowMessage WM_HANDHELDLAST = new(nameof(WM_HANDHELDLAST), Windows.WM_HANDHELDLAST);
        public static readonly WindowMessage WM_HELP = new(nameof(WM_HELP), Windows.WM_HELP);
        public static readonly WindowMessage WM_HOTKEY = new(nameof(WM_HOTKEY), Windows.WM_HOTKEY);
        public static readonly WindowMessage WM_HSCROLL = new(nameof(WM_HSCROLL), Windows.WM_HSCROLL);
        public static readonly WindowMessage WM_HSCROLLCLIPBOARD = new(nameof(WM_HSCROLLCLIPBOARD), Windows.WM_HSCROLLCLIPBOARD);
        public static readonly WindowMessage WM_ICONERASEBKGND = new(nameof(WM_ICONERASEBKGND), Windows.WM_ICONERASEBKGND);
        public static readonly WindowMessage WM_IME_CHAR = new(nameof(WM_IME_CHAR), Windows.WM_IME_CHAR);
        public static readonly WindowMessage WM_IME_COMPOSITION = new(nameof(WM_IME_COMPOSITION), Windows.WM_IME_COMPOSITION);
        public static readonly WindowMessage WM_IME_COMPOSITIONFULL = new(nameof(WM_IME_COMPOSITIONFULL), Windows.WM_IME_COMPOSITIONFULL);
        public static readonly WindowMessage WM_IME_CONTROL = new(nameof(WM_IME_CONTROL), Windows.WM_IME_CONTROL);
        public static readonly WindowMessage WM_IME_ENDCOMPOSITION = new(nameof(WM_IME_ENDCOMPOSITION), Windows.WM_IME_ENDCOMPOSITION);
        public static readonly WindowMessage WM_IME_KEYDOWN = new(nameof(WM_IME_KEYDOWN), Windows.WM_IME_KEYDOWN);
        public static readonly WindowMessage WM_IME_KEYUP = new(nameof(WM_IME_KEYUP), Windows.WM_IME_KEYUP);
        public static readonly WindowMessage WM_IME_NOTIFY = new(nameof(WM_IME_NOTIFY), Windows.WM_IME_NOTIFY);
        public static readonly WindowMessage WM_IME_REQUEST = new(nameof(WM_IME_REQUEST), Windows.WM_IME_REQUEST);
        public static readonly WindowMessage WM_IME_SELECT = new(nameof(WM_IME_SELECT), Windows.WM_IME_SELECT);
        public static readonly WindowMessage WM_IME_SETCONTEXT = new(nameof(WM_IME_SETCONTEXT), Windows.WM_IME_SETCONTEXT);
        public static readonly WindowMessage WM_IME_STARTCOMPOSITION = new(nameof(WM_IME_STARTCOMPOSITION), Windows.WM_IME_STARTCOMPOSITION);
        public static readonly WindowMessage WM_INITDIALOG = new(nameof(WM_INITDIALOG), Windows.WM_INITDIALOG);
        public static readonly WindowMessage WM_INITMENU = new(nameof(WM_INITMENU), Windows.WM_INITMENU);
        public static readonly WindowMessage WM_INITMENUPOPUP = new(nameof(WM_INITMENUPOPUP), Windows.WM_INITMENUPOPUP);
        public static readonly WindowMessage WM_INPUT = new(nameof(WM_INPUT), Windows.WM_INPUT);
        public static readonly WindowMessage WM_INPUT_DEVICE_CHANGE = new(nameof(WM_INPUT_DEVICE_CHANGE), Windows.WM_INPUT_DEVICE_CHANGE);
        public static readonly WindowMessage WM_INPUTLANGCHANGE = new(nameof(WM_INPUTLANGCHANGE), Windows.WM_INPUTLANGCHANGE);
        public static readonly WindowMessage WM_INPUTLANGCHANGEREQUEST = new(nameof(WM_INPUTLANGCHANGEREQUEST), Windows.WM_INPUTLANGCHANGEREQUEST);
        public static readonly WindowMessage WM_KEYDOWN = new(nameof(WM_KEYDOWN), Windows.WM_KEYDOWN);
        public static readonly WindowMessage WM_KEYUP = new(nameof(WM_KEYUP), Windows.WM_KEYUP);
        public static readonly WindowMessage WM_KILLFOCUS = new(nameof(WM_KILLFOCUS), Windows.WM_KILLFOCUS);
        public static readonly WindowMessage WM_LBUTTONDBLCLK = new(nameof(WM_LBUTTONDBLCLK), Windows.WM_LBUTTONDBLCLK);
        public static readonly WindowMessage WM_LBUTTONDOWN = new(nameof(WM_LBUTTONDOWN), Windows.WM_LBUTTONDOWN);
        public static readonly WindowMessage WM_LBUTTONUP = new(nameof(WM_LBUTTONUP), Windows.WM_LBUTTONUP);
        public static readonly WindowMessage WM_MBUTTONDBLCLK = new(nameof(WM_MBUTTONDBLCLK), Windows.WM_MBUTTONDBLCLK);
        public static readonly WindowMessage WM_MBUTTONDOWN = new(nameof(WM_MBUTTONDOWN), Windows.WM_MBUTTONDOWN);
        public static readonly WindowMessage WM_MBUTTONUP = new(nameof(WM_MBUTTONUP), Windows.WM_MBUTTONUP);
        public static readonly WindowMessage WM_MDIACTIVATE = new(nameof(WM_MDIACTIVATE), Windows.WM_MDIACTIVATE);
        public static readonly WindowMessage WM_MDICASCADE = new(nameof(WM_MDICASCADE), Windows.WM_MDICASCADE);
        public static readonly WindowMessage WM_MDICREATE = new(nameof(WM_MDICREATE), Windows.WM_MDICREATE);
        public static readonly WindowMessage WM_MDIDESTROY = new(nameof(WM_MDIDESTROY), Windows.WM_MDIDESTROY);
        public static readonly WindowMessage WM_MDIGETACTIVE = new(nameof(WM_MDIGETACTIVE), Windows.WM_MDIGETACTIVE);
        public static readonly WindowMessage WM_MDIICONARRANGE = new(nameof(WM_MDIICONARRANGE), Windows.WM_MDIICONARRANGE);
        public static readonly WindowMessage WM_MDIMAXIMIZE = new(nameof(WM_MDIMAXIMIZE), Windows.WM_MDIMAXIMIZE);
        public static readonly WindowMessage WM_MDINEXT = new(nameof(WM_MDINEXT), Windows.WM_MDINEXT);
        public static readonly WindowMessage WM_MDIREFRESHMENU = new(nameof(WM_MDIREFRESHMENU), Windows.WM_MDIREFRESHMENU);
        public static readonly WindowMessage WM_MDIRESTORE = new(nameof(WM_MDIRESTORE), Windows.WM_MDIRESTORE);
        public static readonly WindowMessage WM_MDISETMENU = new(nameof(WM_MDISETMENU), Windows.WM_MDISETMENU);
        public static readonly WindowMessage WM_MDITILE = new(nameof(WM_MDITILE), Windows.WM_MDITILE);
        public static readonly WindowMessage WM_MEASUREITEM = new(nameof(WM_MEASUREITEM), Windows.WM_MEASUREITEM);
        public static readonly WindowMessage WM_MENUCHAR = new(nameof(WM_MENUCHAR), Windows.WM_MENUCHAR);
        public static readonly WindowMessage WM_MENUCOMMAND = new(nameof(WM_MENUCOMMAND), Windows.WM_MENUCOMMAND);
        public static readonly WindowMessage WM_MENUDRAG = new(nameof(WM_MENUDRAG), Windows.WM_MENUDRAG);
        public static readonly WindowMessage WM_MENUGETOBJECT = new(nameof(WM_MENUGETOBJECT), Windows.WM_MENUGETOBJECT);
        public static readonly WindowMessage WM_MENURBUTTONUP = new(nameof(WM_MENURBUTTONUP), Windows.WM_MENURBUTTONUP);
        public static readonly WindowMessage WM_MENUSELECT = new(nameof(WM_MENUSELECT), Windows.WM_MENUSELECT);
        public static readonly WindowMessage WM_MOUSEACTIVATE = new(nameof(WM_MOUSEACTIVATE), Windows.WM_MOUSEACTIVATE);
        public static readonly WindowMessage WM_MOUSEHOVER = new(nameof(WM_MOUSEHOVER), Windows.WM_MOUSEHOVER);
        public static readonly WindowMessage WM_MOUSEHWHEEL = new(nameof(WM_MOUSEHWHEEL), Windows.WM_MOUSEHWHEEL);
        public static readonly WindowMessage WM_MOUSELEAVE = new(nameof(WM_MOUSELEAVE), Windows.WM_MOUSELEAVE);
        public static readonly WindowMessage WM_MOUSEMOVE = new(nameof(WM_MOUSEMOVE), Windows.WM_MOUSEMOVE);
        public static readonly WindowMessage WM_MOUSEWHEEL = new(nameof(WM_MOUSEWHEEL), Windows.WM_MOUSEWHEEL);
        public static readonly WindowMessage WM_MOVE = new(nameof(WM_MOVE), Windows.WM_MOVE);
        public static readonly WindowMessage WM_MOVING = new(nameof(WM_MOVING), Windows.WM_MOVING);
        public static readonly WindowMessage WM_NCACTIVATE = new(nameof(WM_NCACTIVATE), Windows.WM_NCACTIVATE);
        public static readonly WindowMessage WM_NCCALCSIZE = new(nameof(WM_NCCALCSIZE), Windows.WM_NCCALCSIZE);
        public static readonly WindowMessage WM_NCCREATE = new(nameof(WM_NCCREATE), Windows.WM_NCCREATE);
        public static readonly WindowMessage WM_NCDESTROY = new(nameof(WM_NCDESTROY), Windows.WM_NCDESTROY);
        public static readonly WindowMessage WM_NCHITTEST = new(nameof(WM_NCHITTEST), Windows.WM_NCHITTEST);
        public static readonly WindowMessage WM_NCLBUTTONDBLCLK = new(nameof(WM_NCLBUTTONDBLCLK), Windows.WM_NCLBUTTONDBLCLK);
        public static readonly WindowMessage WM_NCLBUTTONDOWN = new(nameof(WM_NCLBUTTONDOWN), Windows.WM_NCLBUTTONDOWN);
        public static readonly WindowMessage WM_NCLBUTTONUP = new(nameof(WM_NCLBUTTONUP), Windows.WM_NCLBUTTONUP);
        public static readonly WindowMessage WM_NCMBUTTONDBLCLK = new(nameof(WM_NCMBUTTONDBLCLK), Windows.WM_NCMBUTTONDBLCLK);
        public static readonly WindowMessage WM_NCMBUTTONDOWN = new(nameof(WM_NCMBUTTONDOWN), Windows.WM_NCMBUTTONDOWN);
        public static readonly WindowMessage WM_NCMBUTTONUP = new(nameof(WM_NCMBUTTONUP), Windows.WM_NCMBUTTONUP);
        public static readonly WindowMessage WM_NCMOUSEHOVER = new(nameof(WM_NCMOUSEHOVER), Windows.WM_NCMOUSEHOVER);
        public static readonly WindowMessage WM_NCMOUSELEAVE = new(nameof(WM_NCMOUSELEAVE), Windows.WM_NCMOUSELEAVE);
        public static readonly WindowMessage WM_NCMOUSEMOVE = new(nameof(WM_NCMOUSEMOVE), Windows.WM_NCMOUSEMOVE);
        public static readonly WindowMessage WM_NCPAINT = new(nameof(WM_NCPAINT), Windows.WM_NCPAINT);
        public static readonly WindowMessage WM_NCPOINTERDOWN = new(nameof(WM_NCPOINTERDOWN), Windows.WM_NCPOINTERDOWN);
        public static readonly WindowMessage WM_NCPOINTERUP = new(nameof(WM_NCPOINTERUP), Windows.WM_NCPOINTERUP);
        public static readonly WindowMessage WM_NCPOINTERUPDATE = new(nameof(WM_NCPOINTERUPDATE), Windows.WM_NCPOINTERUPDATE);
        public static readonly WindowMessage WM_NCRBUTTONDBLCLK = new(nameof(WM_NCRBUTTONDBLCLK), Windows.WM_NCRBUTTONDBLCLK);
        public static readonly WindowMessage WM_NCRBUTTONDOWN = new(nameof(WM_NCRBUTTONDOWN), Windows.WM_NCRBUTTONDOWN);
        public static readonly WindowMessage WM_NCRBUTTONUP = new(nameof(WM_NCRBUTTONUP), Windows.WM_NCRBUTTONUP);
        public static readonly WindowMessage WM_NCXBUTTONDBLCLK = new(nameof(WM_NCXBUTTONDBLCLK), Windows.WM_NCXBUTTONDBLCLK);
        public static readonly WindowMessage WM_NCXBUTTONDOWN = new(nameof(WM_NCXBUTTONDOWN), Windows.WM_NCXBUTTONDOWN);
        public static readonly WindowMessage WM_NCXBUTTONUP = new(nameof(WM_NCXBUTTONUP), Windows.WM_NCXBUTTONUP);
        public static readonly WindowMessage WM_NEXTDLGCTL = new(nameof(WM_NEXTDLGCTL), Windows.WM_NEXTDLGCTL);
        public static readonly WindowMessage WM_NEXTMENU = new(nameof(WM_NEXTMENU), Windows.WM_NEXTMENU);
        public static readonly WindowMessage WM_NOTIFY = new(nameof(WM_NOTIFY), Windows.WM_NOTIFY);
        public static readonly WindowMessage WM_NOTIFYFORMAT = new(nameof(WM_NOTIFYFORMAT), Windows.WM_NOTIFYFORMAT);
        public static readonly WindowMessage WM_NULL = new(nameof(WM_NULL), Windows.WM_NULL);
        public static readonly WindowMessage WM_PAINT = new(nameof(WM_PAINT), Windows.WM_PAINT);
        public static readonly WindowMessage WM_PAINTCLIPBOARD = new(nameof(WM_PAINTCLIPBOARD), Windows.WM_PAINTCLIPBOARD);
        public static readonly WindowMessage WM_PAINTICON = new(nameof(WM_PAINTICON), Windows.WM_PAINTICON);
        public static readonly WindowMessage WM_PALETTECHANGED = new(nameof(WM_PALETTECHANGED), Windows.WM_PALETTECHANGED);
        public static readonly WindowMessage WM_PALETTEISCHANGING = new(nameof(WM_PALETTEISCHANGING), Windows.WM_PALETTEISCHANGING);
        public static readonly WindowMessage WM_PARENTNOTIFY = new(nameof(WM_PARENTNOTIFY), Windows.WM_PARENTNOTIFY);
        public static readonly WindowMessage WM_PASTE = new(nameof(WM_PASTE), Windows.WM_PASTE);
        public static readonly WindowMessage WM_PENWINFIRST = new(nameof(WM_PENWINFIRST), Windows.WM_PENWINFIRST);
        public static readonly WindowMessage WM_PENWINLAST = new(nameof(WM_PENWINLAST), Windows.WM_PENWINLAST);
        public static readonly WindowMessage WM_POINTERACTIVATE = new(nameof(WM_POINTERACTIVATE), Windows.WM_POINTERACTIVATE);
        public static readonly WindowMessage WM_POINTERCAPTURECHANGED = new(nameof(WM_POINTERCAPTURECHANGED), Windows.WM_POINTERCAPTURECHANGED);
        public static readonly WindowMessage WM_POINTERDEVICECHANGE = new(nameof(WM_POINTERDEVICECHANGE), Windows.WM_POINTERDEVICECHANGE);
        public static readonly WindowMessage WM_POINTERDEVICEINRANGE = new(nameof(WM_POINTERDEVICEINRANGE), Windows.WM_POINTERDEVICEINRANGE);
        public static readonly WindowMessage WM_POINTERDEVICEOUTOFRANGE = new(nameof(WM_POINTERDEVICEOUTOFRANGE), Windows.WM_POINTERDEVICEOUTOFRANGE);
        public static readonly WindowMessage WM_POINTERDOWN = new(nameof(WM_POINTERDOWN), Windows.WM_POINTERDOWN);
        public static readonly WindowMessage WM_POINTERENTER = new(nameof(WM_POINTERENTER), Windows.WM_POINTERENTER);
        public static readonly WindowMessage WM_POINTERHWHEEL = new(nameof(WM_POINTERHWHEEL), Windows.WM_POINTERHWHEEL);
        public static readonly WindowMessage WM_POINTERLEAVE = new(nameof(WM_POINTERLEAVE), Windows.WM_POINTERLEAVE);
        public static readonly WindowMessage WM_POINTERROUTEDAWAY = new(nameof(WM_POINTERROUTEDAWAY), Windows.WM_POINTERROUTEDAWAY);
        public static readonly WindowMessage WM_POINTERROUTEDRELEASED = new(nameof(WM_POINTERROUTEDRELEASED), Windows.WM_POINTERROUTEDRELEASED);
        public static readonly WindowMessage WM_POINTERROUTEDTO = new(nameof(WM_POINTERROUTEDTO), Windows.WM_POINTERROUTEDTO);
        public static readonly WindowMessage WM_POINTERUP = new(nameof(WM_POINTERUP), Windows.WM_POINTERUP);
        public static readonly WindowMessage WM_POINTERUPDATE = new(nameof(WM_POINTERUPDATE), Windows.WM_POINTERUPDATE);
        public static readonly WindowMessage WM_POINTERWHEEL = new(nameof(WM_POINTERWHEEL), Windows.WM_POINTERWHEEL);
        public static readonly WindowMessage WM_POWER = new(nameof(WM_POWER), Windows.WM_POWER);
        public static readonly WindowMessage WM_POWERBROADCAST = new(nameof(WM_POWERBROADCAST), Windows.WM_POWERBROADCAST);
        public static readonly WindowMessage WM_PRINT = new(nameof(WM_PRINT), Windows.WM_PRINT);
        public static readonly WindowMessage WM_PRINTCLIENT = new(nameof(WM_PRINTCLIENT), Windows.WM_PRINTCLIENT);
        public static readonly WindowMessage WM_QUERYDRAGICON = new(nameof(WM_QUERYDRAGICON), Windows.WM_QUERYDRAGICON);
        public static readonly WindowMessage WM_QUERYENDSESSION = new(nameof(WM_QUERYENDSESSION), Windows.WM_QUERYENDSESSION);
        public static readonly WindowMessage WM_QUERYNEWPALETTE = new(nameof(WM_QUERYNEWPALETTE), Windows.WM_QUERYNEWPALETTE);
        public static readonly WindowMessage WM_QUERYOPEN = new(nameof(WM_QUERYOPEN), Windows.WM_QUERYOPEN);
        public static readonly WindowMessage WM_QUERYUISTATE = new(nameof(WM_QUERYUISTATE), Windows.WM_QUERYUISTATE);
        public static readonly WindowMessage WM_QUEUESYNC = new(nameof(WM_QUEUESYNC), Windows.WM_QUEUESYNC);
        public static readonly WindowMessage WM_QUIT = new(nameof(WM_QUIT), Windows.WM_QUIT);
        public static readonly WindowMessage WM_RBUTTONDBLCLK = new(nameof(WM_RBUTTONDBLCLK), Windows.WM_RBUTTONDBLCLK);
        public static readonly WindowMessage WM_RBUTTONDOWN = new(nameof(WM_RBUTTONDOWN), Windows.WM_RBUTTONDOWN);
        public static readonly WindowMessage WM_RBUTTONUP = new(nameof(WM_RBUTTONUP), Windows.WM_RBUTTONUP);
        public static readonly WindowMessage WM_RENDERALLFORMATS = new(nameof(WM_RENDERALLFORMATS), Windows.WM_RENDERALLFORMATS);
        public static readonly WindowMessage WM_RENDERFORMAT = new(nameof(WM_RENDERFORMAT), Windows.WM_RENDERFORMAT);
        public static readonly WindowMessage WM_SETCURSOR = new(nameof(WM_SETCURSOR), Windows.WM_SETCURSOR);
        public static readonly WindowMessage WM_SETFOCUS = new(nameof(WM_SETFOCUS), Windows.WM_SETFOCUS);
        public static readonly WindowMessage WM_SETFONT = new(nameof(WM_SETFONT), Windows.WM_SETFONT);
        public static readonly WindowMessage WM_SETHOTKEY = new(nameof(WM_SETHOTKEY), Windows.WM_SETHOTKEY);
        public static readonly WindowMessage WM_SETICON = new(nameof(WM_SETICON), Windows.WM_SETICON);
        public static readonly WindowMessage WM_SETREDRAW = new(nameof(WM_SETREDRAW), Windows.WM_SETREDRAW);
        public static readonly WindowMessage WM_SETTEXT = new(nameof(WM_SETTEXT), Windows.WM_SETTEXT);
        public static readonly WindowMessage WM_SETTINGCHANGE = new(nameof(WM_SETTINGCHANGE), Windows.WM_SETTINGCHANGE);
        public static readonly WindowMessage WM_SHOWWINDOW = new(nameof(WM_SHOWWINDOW), Windows.WM_SHOWWINDOW);
        public static readonly WindowMessage WM_SIZE = new(nameof(WM_SIZE), Windows.WM_SIZE);
        public static readonly WindowMessage WM_SIZECLIPBOARD = new(nameof(WM_SIZECLIPBOARD), Windows.WM_SIZECLIPBOARD);
        public static readonly WindowMessage WM_SIZING = new(nameof(WM_SIZING), Windows.WM_SIZING);
        public static readonly WindowMessage WM_SPOOLERSTATUS = new(nameof(WM_SPOOLERSTATUS), Windows.WM_SPOOLERSTATUS);
        public static readonly WindowMessage WM_STYLECHANGED = new(nameof(WM_STYLECHANGED), Windows.WM_STYLECHANGED);
        public static readonly WindowMessage WM_STYLECHANGING = new(nameof(WM_STYLECHANGING), Windows.WM_STYLECHANGING);
        public static readonly WindowMessage WM_SYNCPAINT = new(nameof(WM_SYNCPAINT), Windows.WM_SYNCPAINT);
        public static readonly WindowMessage WM_SYSCHAR = new(nameof(WM_SYSCHAR), Windows.WM_SYSCHAR);
        public static readonly WindowMessage WM_SYSCOLORCHANGE = new(nameof(WM_SYSCOLORCHANGE), Windows.WM_SYSCOLORCHANGE);
        public static readonly WindowMessage WM_SYSCOMMAND = new(nameof(WM_SYSCOMMAND), Windows.WM_SYSCOMMAND);
        public static readonly WindowMessage WM_SYSDEADCHAR = new(nameof(WM_SYSDEADCHAR), Windows.WM_SYSDEADCHAR);
        public static readonly WindowMessage WM_SYSKEYDOWN = new(nameof(WM_SYSKEYDOWN), Windows.WM_SYSKEYDOWN);
        public static readonly WindowMessage WM_SYSKEYUP = new(nameof(WM_SYSKEYUP), Windows.WM_SYSKEYUP);
        public static readonly WindowMessage WM_TABLET_FIRST = new(nameof(WM_TABLET_FIRST), Windows.WM_TABLET_FIRST);
        public static readonly WindowMessage WM_TABLET_LAST = new(nameof(WM_TABLET_LAST), Windows.WM_TABLET_LAST);
        public static readonly WindowMessage WM_TCARD = new(nameof(WM_TCARD), Windows.WM_TCARD);
        public static readonly WindowMessage WM_THEMECHANGED = new(nameof(WM_THEMECHANGED), Windows.WM_THEMECHANGED);
        public static readonly WindowMessage WM_TIMECHANGE = new(nameof(WM_TIMECHANGE), Windows.WM_TIMECHANGE);
        public static readonly WindowMessage WM_TIMER = new(nameof(WM_TIMER), Windows.WM_TIMER);
        public static readonly WindowMessage WM_TOUCH = new(nameof(WM_TOUCH), Windows.WM_TOUCH);
        public static readonly WindowMessage WM_TOUCHHITTESTING = new(nameof(WM_TOUCHHITTESTING), Windows.WM_TOUCHHITTESTING);
        public static readonly WindowMessage WM_UNDO = new(nameof(WM_UNDO), Windows.WM_UNDO);
        public static readonly WindowMessage WM_UNICHAR = new(nameof(WM_UNICHAR), Windows.WM_UNICHAR);
        public static readonly WindowMessage WM_UNINITMENUPOPUP = new(nameof(WM_UNINITMENUPOPUP), Windows.WM_UNINITMENUPOPUP);
        public static readonly WindowMessage WM_UPDATEUISTATE = new(nameof(WM_UPDATEUISTATE), Windows.WM_UPDATEUISTATE);
        public static readonly WindowMessage WM_USER = new(nameof(WM_USER), Windows.WM_USER);
        public static readonly WindowMessage WM_USERCHANGED = new(nameof(WM_USERCHANGED), Windows.WM_USERCHANGED);
        public static readonly WindowMessage WM_VKEYTOITEM = new(nameof(WM_VKEYTOITEM), Windows.WM_VKEYTOITEM);
        public static readonly WindowMessage WM_VSCROLL = new(nameof(WM_VSCROLL), Windows.WM_VSCROLL);
        public static readonly WindowMessage WM_VSCROLLCLIPBOARD = new(nameof(WM_VSCROLLCLIPBOARD), Windows.WM_VSCROLLCLIPBOARD);
        public static readonly WindowMessage WM_WINDOWPOSCHANGED = new(nameof(WM_WINDOWPOSCHANGED), Windows.WM_WINDOWPOSCHANGED);

        public static readonly WindowMessage WM_WINDOWPOSCHANGING = new(
            nameof(WM_WINDOWPOSCHANGING),
            Windows.WM_WINDOWPOSCHANGING);

        public static readonly WindowMessage WM_WTSSESSION_CHANGE = new(
            nameof(WM_WTSSESSION_CHANGE),
            Windows.WM_WTSSESSION_CHANGE);

        public static readonly WindowMessage WM_XBUTTONDBLCLK = new(nameof(WM_XBUTTONDBLCLK), Windows.WM_XBUTTONDBLCLK);
        public static readonly WindowMessage WM_XBUTTONDOWN = new(nameof(WM_XBUTTONDOWN), Windows.WM_XBUTTONDOWN);
        public static readonly WindowMessage WM_XBUTTONUP = new(nameof(WM_XBUTTONUP), Windows.WM_XBUTTONUP);

        private static readonly WindowsMessageCollection _windowMessageByValue =
            new()
            {
                MN_GETHMENU,
                WM_ACTIVATE,
                WM_ACTIVATEAPP,
                WM_AFXFIRST,
                WM_AFXLAST,
                WM_APP,
                WM_APPCOMMAND,
                WM_ASKCBFORMATNAME,
                WM_CANCELJOURNAL,
                WM_CANCELMODE,
                WM_CAPTURECHANGED,
                WM_CHANGECBCHAIN,
                WM_CHANGEUISTATE,
                WM_CHAR,
                WM_CHARTOITEM,
                WM_CHILDACTIVATE,
                WM_CLEAR,
                WM_CLIPBOARDUPDATE,
                WM_CLOSE,
                WM_COMMAND,
                WM_COMMNOTIFY,
                WM_COMPACTING,
                WM_COMPAREITEM,
                WM_CONTEXTMENU,
                WM_COPY,
                WM_COPYDATA,
                WM_CREATE,
                WM_CTLCOLORBTN,
                WM_CTLCOLORDLG,
                WM_CTLCOLOREDIT,
                WM_CTLCOLORLISTBOX,
                WM_CTLCOLORMSGBOX,
                WM_CTLCOLORSCROLLBAR,
                WM_CTLCOLORSTATIC,
                WM_CUT,
                WM_DEADCHAR,
                WM_DELETEITEM,
                WM_DESTROY,
                WM_DESTROYCLIPBOARD,
                WM_DEVICECHANGE,
                WM_DEVMODECHANGE,
                WM_DISPLAYCHANGE,
                WM_DPICHANGED,
                WM_DPICHANGED_AFTERPARENT,
                WM_DPICHANGED_BEFOREPARENT,
                WM_DRAWCLIPBOARD,
                WM_DRAWITEM,
                WM_DROPFILES,
                WM_DWMCOLORIZATIONCOLORCHANGED,
                WM_DWMCOMPOSITIONCHANGED,
                WM_DWMNCRENDERINGCHANGED,
                WM_DWMSENDICONICLIVEPREVIEWBITMAP,
                WM_DWMSENDICONICTHUMBNAIL,
                WM_DWMWINDOWMAXIMIZEDCHANGE,
                WM_ENABLE,
                WM_ENDSESSION,
                WM_ENTERIDLE,
                WM_ENTERMENULOOP,
                WM_ENTERSIZEMOVE,
                WM_ERASEBKGND,
                WM_EXITMENULOOP,
                WM_EXITSIZEMOVE,
                WM_FONTCHANGE,
                WM_GESTURE,
                WM_GESTURENOTIFY,
                WM_GETDLGCODE,
                WM_GETDPISCALEDSIZE,
                WM_GETFONT,
                WM_GETHOTKEY,
                WM_GETICON,
                WM_GETMINMAXINFO,
                WM_GETOBJECT,
                WM_GETTEXT,
                WM_GETTEXTLENGTH,
                WM_GETTITLEBARINFOEX,
                WM_HANDHELDFIRST,
                WM_HANDHELDLAST,
                WM_HELP,
                WM_HOTKEY,
                WM_HSCROLL,
                WM_HSCROLLCLIPBOARD,
                WM_ICONERASEBKGND,
                WM_IME_CHAR,
                WM_IME_COMPOSITION,
                WM_IME_COMPOSITIONFULL,
                WM_IME_CONTROL,
                WM_IME_ENDCOMPOSITION,
                WM_IME_KEYDOWN,
                WM_IME_KEYUP,
                WM_IME_NOTIFY,
                WM_IME_REQUEST,
                WM_IME_SELECT,
                WM_IME_SETCONTEXT,
                WM_IME_STARTCOMPOSITION,
                WM_INITDIALOG,
                WM_INITMENU,
                WM_INITMENUPOPUP,
                WM_INPUT,
                WM_INPUT_DEVICE_CHANGE,
                WM_INPUTLANGCHANGE,
                WM_INPUTLANGCHANGEREQUEST,
                WM_KEYDOWN,
                WM_KEYUP,
                WM_KILLFOCUS,
                WM_LBUTTONDBLCLK,
                WM_LBUTTONDOWN,
                WM_LBUTTONUP,
                WM_MBUTTONDBLCLK,
                WM_MBUTTONDOWN,
                WM_MBUTTONUP,
                WM_MDIACTIVATE,
                WM_MDICASCADE,
                WM_MDICREATE,
                WM_MDIDESTROY,
                WM_MDIGETACTIVE,
                WM_MDIICONARRANGE,
                WM_MDIMAXIMIZE,
                WM_MDINEXT,
                WM_MDIREFRESHMENU,
                WM_MDIRESTORE,
                WM_MDISETMENU,
                WM_MDITILE,
                WM_MEASUREITEM,
                WM_MENUCHAR,
                WM_MENUCOMMAND,
                WM_MENUDRAG,
                WM_MENUGETOBJECT,
                WM_MENURBUTTONUP,
                WM_MENUSELECT,
                WM_MOUSEACTIVATE,
                WM_MOUSEHOVER,
                WM_MOUSEHWHEEL,
                WM_MOUSELEAVE,
                WM_MOUSEMOVE,
                WM_MOUSEWHEEL,
                WM_MOVE,
                WM_MOVING,
                WM_NCACTIVATE,
                WM_NCCALCSIZE,
                WM_NCCREATE,
                WM_NCDESTROY,
                WM_NCHITTEST,
                WM_NCLBUTTONDBLCLK,
                WM_NCLBUTTONDOWN,
                WM_NCLBUTTONUP,
                WM_NCMBUTTONDBLCLK,
                WM_NCMBUTTONDOWN,
                WM_NCMBUTTONUP,
                WM_NCMOUSEHOVER,
                WM_NCMOUSELEAVE,
                WM_NCMOUSEMOVE,
                WM_NCPAINT,
                WM_NCPOINTERDOWN,
                WM_NCPOINTERUP,
                WM_NCPOINTERUPDATE,
                WM_NCRBUTTONDBLCLK,
                WM_NCRBUTTONDOWN,
                WM_NCRBUTTONUP,
                WM_NCXBUTTONDBLCLK,
                WM_NCXBUTTONDOWN,
                WM_NCXBUTTONUP,
                WM_NEXTDLGCTL,
                WM_NEXTMENU,
                WM_NOTIFY,
                WM_NOTIFYFORMAT,
                WM_NULL,
                WM_PAINT,
                WM_PAINTCLIPBOARD,
                WM_PAINTICON,
                WM_PALETTECHANGED,
                WM_PALETTEISCHANGING,
                WM_PARENTNOTIFY,
                WM_PASTE,
                WM_PENWINFIRST,
                WM_PENWINLAST,
                WM_POINTERACTIVATE,
                WM_POINTERCAPTURECHANGED,
                WM_POINTERDEVICECHANGE,
                WM_POINTERDEVICEINRANGE,
                WM_POINTERDEVICEOUTOFRANGE,
                WM_POINTERDOWN,
                WM_POINTERENTER,
                WM_POINTERHWHEEL,
                WM_POINTERLEAVE,
                WM_POINTERROUTEDAWAY,
                WM_POINTERROUTEDRELEASED,
                WM_POINTERROUTEDTO,
                WM_POINTERUP,
                WM_POINTERUPDATE,
                WM_POINTERWHEEL,
                WM_POWER,
                WM_POWERBROADCAST,
                WM_PRINT,
                WM_PRINTCLIENT,
                WM_QUERYDRAGICON,
                WM_QUERYENDSESSION,
                WM_QUERYNEWPALETTE,
                WM_QUERYOPEN,
                WM_QUERYUISTATE,
                WM_QUEUESYNC,
                WM_QUIT,
                WM_RBUTTONDBLCLK,
                WM_RBUTTONDOWN,
                WM_RBUTTONUP,
                WM_RENDERALLFORMATS,
                WM_RENDERFORMAT,
                WM_SETCURSOR,
                WM_SETFOCUS,
                WM_SETFONT,
                WM_SETHOTKEY,
                WM_SETICON,
                WM_SETREDRAW,
                WM_SETTEXT,
                WM_SETTINGCHANGE,
                WM_SHOWWINDOW,
                WM_SIZE,
                WM_SIZECLIPBOARD,
                WM_SIZING,
                WM_SPOOLERSTATUS,
                WM_STYLECHANGED,
                WM_STYLECHANGING,
                WM_SYNCPAINT,
                WM_SYSCHAR,
                WM_SYSCOLORCHANGE,
                WM_SYSCOMMAND,
                WM_SYSDEADCHAR,
                WM_SYSKEYDOWN,
                WM_SYSKEYUP,
                WM_TABLET_FIRST,
                WM_TABLET_LAST,
                WM_TCARD,
                WM_THEMECHANGED,
                WM_TIMECHANGE,
                WM_TIMER,
                WM_TOUCH,
                WM_TOUCHHITTESTING,
                WM_UNDO,
                WM_UNICHAR,
                WM_UNINITMENUPOPUP,
                WM_UPDATEUISTATE,
                WM_USER,
                WM_USERCHANGED,
                WM_VKEYTOITEM,
                WM_VSCROLL,
                WM_VSCROLLCLIPBOARD,
                WM_WINDOWPOSCHANGED,
                WM_WINDOWPOSCHANGING,
                WM_WTSSESSION_CHANGE,
                WM_XBUTTONDBLCLK,
                WM_XBUTTONDOWN,
                WM_XBUTTONUP
            };

        private WindowMessage(string name, int value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>Gets the name of the window message.</summary>
        public string Name { get; }

        /// <summary>Gets the value of the window message.</summary>
        public int Value { get; }

        /// <summary>Implicitly converts a <see cref="WindowMessage" /> to an <see langword="int" />.</summary>
        /// <param name="value">The <see cref="WindowMessage" /> to convert.</param>
        public static implicit operator int(WindowMessage value) => value.Value;

        /// <summary>Maps a known windows message to a <see cref="WindowMessage" /> object.</summary>
        /// <param name="message">A window message.</param>
        /// <returns>
        ///     A <see cref="WindowMessage" /> object representing <paramref name="message" />, if the message is known; otherwise,
        ///     <see langword="null" />.
        /// </returns>
        public static WindowMessage? MapKnown(uint message)
        {
            _windowMessageByValue.TryGetValue(unchecked((int)message), out WindowMessage? windowsMessage);

            return windowsMessage;
        }

        private class WindowsMessageCollection : KeyedCollection<int, WindowMessage>
        {
            protected override int GetKeyForItem(WindowMessage item) => item.Value;
        }
    }
}