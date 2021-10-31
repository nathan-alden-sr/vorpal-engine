// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable 1591

namespace VorpalEngine.Common.Windows;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public sealed class WindowMessage
{
    public static readonly WindowMessage MN_GETHMENU = new(nameof(MN_GETHMENU), TerraFX.Interop.Windows.MN_GETHMENU);
    public static readonly WindowMessage WM_ACTIVATE = new(nameof(WM_ACTIVATE), TerraFX.Interop.Windows.WM_ACTIVATE);
    public static readonly WindowMessage WM_ACTIVATEAPP = new(nameof(WM_ACTIVATEAPP), TerraFX.Interop.Windows.WM_ACTIVATEAPP);
    public static readonly WindowMessage WM_AFXFIRST = new(nameof(WM_AFXFIRST), TerraFX.Interop.Windows.WM_AFXFIRST);
    public static readonly WindowMessage WM_AFXLAST = new(nameof(WM_AFXLAST), TerraFX.Interop.Windows.WM_AFXLAST);
    public static readonly WindowMessage WM_APP = new(nameof(WM_APP), TerraFX.Interop.Windows.WM_APP);
    public static readonly WindowMessage WM_APPCOMMAND = new(nameof(WM_APPCOMMAND), TerraFX.Interop.Windows.WM_APPCOMMAND);
    public static readonly WindowMessage WM_ASKCBFORMATNAME = new(nameof(WM_ASKCBFORMATNAME), TerraFX.Interop.Windows.WM_ASKCBFORMATNAME);
    public static readonly WindowMessage WM_CANCELJOURNAL = new(nameof(WM_CANCELJOURNAL), TerraFX.Interop.Windows.WM_CANCELJOURNAL);
    public static readonly WindowMessage WM_CANCELMODE = new(nameof(WM_CANCELMODE), TerraFX.Interop.Windows.WM_CANCELMODE);
    public static readonly WindowMessage WM_CAPTURECHANGED = new(nameof(WM_CAPTURECHANGED), TerraFX.Interop.Windows.WM_CAPTURECHANGED);
    public static readonly WindowMessage WM_CHANGECBCHAIN = new(nameof(WM_CHANGECBCHAIN), TerraFX.Interop.Windows.WM_CHANGECBCHAIN);
    public static readonly WindowMessage WM_CHANGEUISTATE = new(nameof(WM_CHANGEUISTATE), TerraFX.Interop.Windows.WM_CHANGEUISTATE);
    public static readonly WindowMessage WM_CHAR = new(nameof(WM_CHAR), TerraFX.Interop.Windows.WM_CHAR);
    public static readonly WindowMessage WM_CHARTOITEM = new(nameof(WM_CHARTOITEM), TerraFX.Interop.Windows.WM_CHARTOITEM);
    public static readonly WindowMessage WM_CHILDACTIVATE = new(nameof(WM_CHILDACTIVATE), TerraFX.Interop.Windows.WM_CHILDACTIVATE);
    public static readonly WindowMessage WM_CLEAR = new(nameof(WM_CLEAR), TerraFX.Interop.Windows.WM_CLEAR);
    public static readonly WindowMessage WM_CLIPBOARDUPDATE = new(nameof(WM_CLIPBOARDUPDATE), TerraFX.Interop.Windows.WM_CLIPBOARDUPDATE);
    public static readonly WindowMessage WM_CLOSE = new(nameof(WM_CLOSE), TerraFX.Interop.Windows.WM_CLOSE);
    public static readonly WindowMessage WM_COMMAND = new(nameof(WM_COMMAND), TerraFX.Interop.Windows.WM_COMMAND);
    public static readonly WindowMessage WM_COMMNOTIFY = new(nameof(WM_COMMNOTIFY), TerraFX.Interop.Windows.WM_COMMNOTIFY);
    public static readonly WindowMessage WM_COMPACTING = new(nameof(WM_COMPACTING), TerraFX.Interop.Windows.WM_COMPACTING);
    public static readonly WindowMessage WM_COMPAREITEM = new(nameof(WM_COMPAREITEM), TerraFX.Interop.Windows.WM_COMPAREITEM);
    public static readonly WindowMessage WM_CONTEXTMENU = new(nameof(WM_CONTEXTMENU), TerraFX.Interop.Windows.WM_CONTEXTMENU);
    public static readonly WindowMessage WM_COPY = new(nameof(WM_COPY), TerraFX.Interop.Windows.WM_COPY);
    public static readonly WindowMessage WM_COPYDATA = new(nameof(WM_COPYDATA), TerraFX.Interop.Windows.WM_COPYDATA);
    public static readonly WindowMessage WM_CREATE = new(nameof(WM_CREATE), TerraFX.Interop.Windows.WM_CREATE);
    public static readonly WindowMessage WM_CTLCOLORBTN = new(nameof(WM_CTLCOLORBTN), TerraFX.Interop.Windows.WM_CTLCOLORBTN);
    public static readonly WindowMessage WM_CTLCOLORDLG = new(nameof(WM_CTLCOLORDLG), TerraFX.Interop.Windows.WM_CTLCOLORDLG);
    public static readonly WindowMessage WM_CTLCOLOREDIT = new(nameof(WM_CTLCOLOREDIT), TerraFX.Interop.Windows.WM_CTLCOLOREDIT);
    public static readonly WindowMessage WM_CTLCOLORLISTBOX = new(nameof(WM_CTLCOLORLISTBOX), TerraFX.Interop.Windows.WM_CTLCOLORLISTBOX);
    public static readonly WindowMessage WM_CTLCOLORMSGBOX = new(nameof(WM_CTLCOLORMSGBOX), TerraFX.Interop.Windows.WM_CTLCOLORMSGBOX);
    public static readonly WindowMessage WM_CTLCOLORSCROLLBAR = new(nameof(WM_CTLCOLORSCROLLBAR), TerraFX.Interop.Windows.WM_CTLCOLORSCROLLBAR);
    public static readonly WindowMessage WM_CTLCOLORSTATIC = new(nameof(WM_CTLCOLORSTATIC), TerraFX.Interop.Windows.WM_CTLCOLORSTATIC);
    public static readonly WindowMessage WM_CUT = new(nameof(WM_CUT), TerraFX.Interop.Windows.WM_CUT);
    public static readonly WindowMessage WM_DEADCHAR = new(nameof(WM_DEADCHAR), TerraFX.Interop.Windows.WM_DEADCHAR);
    public static readonly WindowMessage WM_DELETEITEM = new(nameof(WM_DELETEITEM), TerraFX.Interop.Windows.WM_DELETEITEM);
    public static readonly WindowMessage WM_DESTROY = new(nameof(WM_DESTROY), TerraFX.Interop.Windows.WM_DESTROY);
    public static readonly WindowMessage WM_DESTROYCLIPBOARD = new(nameof(WM_DESTROYCLIPBOARD), TerraFX.Interop.Windows.WM_DESTROYCLIPBOARD);
    public static readonly WindowMessage WM_DEVICECHANGE = new(nameof(WM_DEVICECHANGE), TerraFX.Interop.Windows.WM_DEVICECHANGE);
    public static readonly WindowMessage WM_DEVMODECHANGE = new(nameof(WM_DEVMODECHANGE), TerraFX.Interop.Windows.WM_DEVMODECHANGE);
    public static readonly WindowMessage WM_DISPLAYCHANGE = new(nameof(WM_DISPLAYCHANGE), TerraFX.Interop.Windows.WM_DISPLAYCHANGE);
    public static readonly WindowMessage WM_DPICHANGED = new(nameof(WM_DPICHANGED), TerraFX.Interop.Windows.WM_DPICHANGED);
    public static readonly WindowMessage WM_DPICHANGED_AFTERPARENT = new(nameof(WM_DPICHANGED_AFTERPARENT), TerraFX.Interop.Windows.WM_DPICHANGED_AFTERPARENT);

    public static readonly WindowMessage WM_DPICHANGED_BEFOREPARENT = new(
        nameof(WM_DPICHANGED_BEFOREPARENT),
        TerraFX.Interop.Windows.WM_DPICHANGED_BEFOREPARENT);

    public static readonly WindowMessage WM_DRAWCLIPBOARD = new(nameof(WM_DRAWCLIPBOARD), TerraFX.Interop.Windows.WM_DRAWCLIPBOARD);
    public static readonly WindowMessage WM_DRAWITEM = new(nameof(WM_DRAWITEM), TerraFX.Interop.Windows.WM_DRAWITEM);
    public static readonly WindowMessage WM_DROPFILES = new(nameof(WM_DROPFILES), TerraFX.Interop.Windows.WM_DROPFILES);

    public static readonly WindowMessage WM_DWMCOLORIZATIONCOLORCHANGED = new(
        nameof(WM_DWMCOLORIZATIONCOLORCHANGED),
        TerraFX.Interop.Windows.WM_DWMCOLORIZATIONCOLORCHANGED);

    public static readonly WindowMessage WM_DWMCOMPOSITIONCHANGED = new(nameof(WM_DWMCOMPOSITIONCHANGED), TerraFX.Interop.Windows.WM_DWMCOMPOSITIONCHANGED);
    public static readonly WindowMessage WM_DWMNCRENDERINGCHANGED = new(nameof(WM_DWMNCRENDERINGCHANGED), TerraFX.Interop.Windows.WM_DWMNCRENDERINGCHANGED);

    public static readonly WindowMessage WM_DWMSENDICONICLIVEPREVIEWBITMAP = new(
        nameof(WM_DWMSENDICONICLIVEPREVIEWBITMAP),
        TerraFX.Interop.Windows.WM_DWMSENDICONICLIVEPREVIEWBITMAP);

    public static readonly WindowMessage WM_DWMSENDICONICTHUMBNAIL = new(nameof(WM_DWMSENDICONICTHUMBNAIL), TerraFX.Interop.Windows.WM_DWMSENDICONICTHUMBNAIL);

    public static readonly WindowMessage WM_DWMWINDOWMAXIMIZEDCHANGE = new(
        nameof(WM_DWMWINDOWMAXIMIZEDCHANGE),
        TerraFX.Interop.Windows.WM_DWMWINDOWMAXIMIZEDCHANGE);

    public static readonly WindowMessage WM_ENABLE = new(nameof(WM_ENABLE), TerraFX.Interop.Windows.WM_ENABLE);
    public static readonly WindowMessage WM_ENDSESSION = new(nameof(WM_ENDSESSION), TerraFX.Interop.Windows.WM_ENDSESSION);
    public static readonly WindowMessage WM_ENTERIDLE = new(nameof(WM_ENTERIDLE), TerraFX.Interop.Windows.WM_ENTERIDLE);
    public static readonly WindowMessage WM_ENTERMENULOOP = new(nameof(WM_ENTERMENULOOP), TerraFX.Interop.Windows.WM_ENTERMENULOOP);
    public static readonly WindowMessage WM_ENTERSIZEMOVE = new(nameof(WM_ENTERSIZEMOVE), TerraFX.Interop.Windows.WM_ENTERSIZEMOVE);
    public static readonly WindowMessage WM_ERASEBKGND = new(nameof(WM_ERASEBKGND), TerraFX.Interop.Windows.WM_ERASEBKGND);
    public static readonly WindowMessage WM_EXITMENULOOP = new(nameof(WM_EXITMENULOOP), TerraFX.Interop.Windows.WM_EXITMENULOOP);
    public static readonly WindowMessage WM_EXITSIZEMOVE = new(nameof(WM_EXITSIZEMOVE), TerraFX.Interop.Windows.WM_EXITSIZEMOVE);
    public static readonly WindowMessage WM_FONTCHANGE = new(nameof(WM_FONTCHANGE), TerraFX.Interop.Windows.WM_FONTCHANGE);
    public static readonly WindowMessage WM_GESTURE = new(nameof(WM_GESTURE), TerraFX.Interop.Windows.WM_GESTURE);
    public static readonly WindowMessage WM_GESTURENOTIFY = new(nameof(WM_GESTURENOTIFY), TerraFX.Interop.Windows.WM_GESTURENOTIFY);
    public static readonly WindowMessage WM_GETDLGCODE = new(nameof(WM_GETDLGCODE), TerraFX.Interop.Windows.WM_GETDLGCODE);
    public static readonly WindowMessage WM_GETDPISCALEDSIZE = new(nameof(WM_GETDPISCALEDSIZE), TerraFX.Interop.Windows.WM_GETDPISCALEDSIZE);
    public static readonly WindowMessage WM_GETFONT = new(nameof(WM_GETFONT), TerraFX.Interop.Windows.WM_GETFONT);
    public static readonly WindowMessage WM_GETHOTKEY = new(nameof(WM_GETHOTKEY), TerraFX.Interop.Windows.WM_GETHOTKEY);
    public static readonly WindowMessage WM_GETICON = new(nameof(WM_GETICON), TerraFX.Interop.Windows.WM_GETICON);
    public static readonly WindowMessage WM_GETMINMAXINFO = new(nameof(WM_GETMINMAXINFO), TerraFX.Interop.Windows.WM_GETMINMAXINFO);
    public static readonly WindowMessage WM_GETOBJECT = new(nameof(WM_GETOBJECT), TerraFX.Interop.Windows.WM_GETOBJECT);
    public static readonly WindowMessage WM_GETTEXT = new(nameof(WM_GETTEXT), TerraFX.Interop.Windows.WM_GETTEXT);
    public static readonly WindowMessage WM_GETTEXTLENGTH = new(nameof(WM_GETTEXTLENGTH), TerraFX.Interop.Windows.WM_GETTEXTLENGTH);
    public static readonly WindowMessage WM_GETTITLEBARINFOEX = new(nameof(WM_GETTITLEBARINFOEX), TerraFX.Interop.Windows.WM_GETTITLEBARINFOEX);
    public static readonly WindowMessage WM_HANDHELDFIRST = new(nameof(WM_HANDHELDFIRST), TerraFX.Interop.Windows.WM_HANDHELDFIRST);
    public static readonly WindowMessage WM_HANDHELDLAST = new(nameof(WM_HANDHELDLAST), TerraFX.Interop.Windows.WM_HANDHELDLAST);
    public static readonly WindowMessage WM_HELP = new(nameof(WM_HELP), TerraFX.Interop.Windows.WM_HELP);
    public static readonly WindowMessage WM_HOTKEY = new(nameof(WM_HOTKEY), TerraFX.Interop.Windows.WM_HOTKEY);
    public static readonly WindowMessage WM_HSCROLL = new(nameof(WM_HSCROLL), TerraFX.Interop.Windows.WM_HSCROLL);
    public static readonly WindowMessage WM_HSCROLLCLIPBOARD = new(nameof(WM_HSCROLLCLIPBOARD), TerraFX.Interop.Windows.WM_HSCROLLCLIPBOARD);
    public static readonly WindowMessage WM_ICONERASEBKGND = new(nameof(WM_ICONERASEBKGND), TerraFX.Interop.Windows.WM_ICONERASEBKGND);
    public static readonly WindowMessage WM_IME_CHAR = new(nameof(WM_IME_CHAR), TerraFX.Interop.Windows.WM_IME_CHAR);
    public static readonly WindowMessage WM_IME_COMPOSITION = new(nameof(WM_IME_COMPOSITION), TerraFX.Interop.Windows.WM_IME_COMPOSITION);
    public static readonly WindowMessage WM_IME_COMPOSITIONFULL = new(nameof(WM_IME_COMPOSITIONFULL), TerraFX.Interop.Windows.WM_IME_COMPOSITIONFULL);
    public static readonly WindowMessage WM_IME_CONTROL = new(nameof(WM_IME_CONTROL), TerraFX.Interop.Windows.WM_IME_CONTROL);
    public static readonly WindowMessage WM_IME_ENDCOMPOSITION = new(nameof(WM_IME_ENDCOMPOSITION), TerraFX.Interop.Windows.WM_IME_ENDCOMPOSITION);
    public static readonly WindowMessage WM_IME_KEYDOWN = new(nameof(WM_IME_KEYDOWN), TerraFX.Interop.Windows.WM_IME_KEYDOWN);
    public static readonly WindowMessage WM_IME_KEYUP = new(nameof(WM_IME_KEYUP), TerraFX.Interop.Windows.WM_IME_KEYUP);
    public static readonly WindowMessage WM_IME_NOTIFY = new(nameof(WM_IME_NOTIFY), TerraFX.Interop.Windows.WM_IME_NOTIFY);
    public static readonly WindowMessage WM_IME_REQUEST = new(nameof(WM_IME_REQUEST), TerraFX.Interop.Windows.WM_IME_REQUEST);
    public static readonly WindowMessage WM_IME_SELECT = new(nameof(WM_IME_SELECT), TerraFX.Interop.Windows.WM_IME_SELECT);
    public static readonly WindowMessage WM_IME_SETCONTEXT = new(nameof(WM_IME_SETCONTEXT), TerraFX.Interop.Windows.WM_IME_SETCONTEXT);
    public static readonly WindowMessage WM_IME_STARTCOMPOSITION = new(nameof(WM_IME_STARTCOMPOSITION), TerraFX.Interop.Windows.WM_IME_STARTCOMPOSITION);
    public static readonly WindowMessage WM_INITDIALOG = new(nameof(WM_INITDIALOG), TerraFX.Interop.Windows.WM_INITDIALOG);
    public static readonly WindowMessage WM_INITMENU = new(nameof(WM_INITMENU), TerraFX.Interop.Windows.WM_INITMENU);
    public static readonly WindowMessage WM_INITMENUPOPUP = new(nameof(WM_INITMENUPOPUP), TerraFX.Interop.Windows.WM_INITMENUPOPUP);
    public static readonly WindowMessage WM_INPUT = new(nameof(WM_INPUT), TerraFX.Interop.Windows.WM_INPUT);
    public static readonly WindowMessage WM_INPUT_DEVICE_CHANGE = new(nameof(WM_INPUT_DEVICE_CHANGE), TerraFX.Interop.Windows.WM_INPUT_DEVICE_CHANGE);
    public static readonly WindowMessage WM_INPUTLANGCHANGE = new(nameof(WM_INPUTLANGCHANGE), TerraFX.Interop.Windows.WM_INPUTLANGCHANGE);
    public static readonly WindowMessage WM_INPUTLANGCHANGEREQUEST = new(nameof(WM_INPUTLANGCHANGEREQUEST), TerraFX.Interop.Windows.WM_INPUTLANGCHANGEREQUEST);
    public static readonly WindowMessage WM_KEYDOWN = new(nameof(WM_KEYDOWN), TerraFX.Interop.Windows.WM_KEYDOWN);
    public static readonly WindowMessage WM_KEYUP = new(nameof(WM_KEYUP), TerraFX.Interop.Windows.WM_KEYUP);
    public static readonly WindowMessage WM_KILLFOCUS = new(nameof(WM_KILLFOCUS), TerraFX.Interop.Windows.WM_KILLFOCUS);
    public static readonly WindowMessage WM_LBUTTONDBLCLK = new(nameof(WM_LBUTTONDBLCLK), TerraFX.Interop.Windows.WM_LBUTTONDBLCLK);
    public static readonly WindowMessage WM_LBUTTONDOWN = new(nameof(WM_LBUTTONDOWN), TerraFX.Interop.Windows.WM_LBUTTONDOWN);
    public static readonly WindowMessage WM_LBUTTONUP = new(nameof(WM_LBUTTONUP), TerraFX.Interop.Windows.WM_LBUTTONUP);
    public static readonly WindowMessage WM_MBUTTONDBLCLK = new(nameof(WM_MBUTTONDBLCLK), TerraFX.Interop.Windows.WM_MBUTTONDBLCLK);
    public static readonly WindowMessage WM_MBUTTONDOWN = new(nameof(WM_MBUTTONDOWN), TerraFX.Interop.Windows.WM_MBUTTONDOWN);
    public static readonly WindowMessage WM_MBUTTONUP = new(nameof(WM_MBUTTONUP), TerraFX.Interop.Windows.WM_MBUTTONUP);
    public static readonly WindowMessage WM_MDIACTIVATE = new(nameof(WM_MDIACTIVATE), TerraFX.Interop.Windows.WM_MDIACTIVATE);
    public static readonly WindowMessage WM_MDICASCADE = new(nameof(WM_MDICASCADE), TerraFX.Interop.Windows.WM_MDICASCADE);
    public static readonly WindowMessage WM_MDICREATE = new(nameof(WM_MDICREATE), TerraFX.Interop.Windows.WM_MDICREATE);
    public static readonly WindowMessage WM_MDIDESTROY = new(nameof(WM_MDIDESTROY), TerraFX.Interop.Windows.WM_MDIDESTROY);
    public static readonly WindowMessage WM_MDIGETACTIVE = new(nameof(WM_MDIGETACTIVE), TerraFX.Interop.Windows.WM_MDIGETACTIVE);
    public static readonly WindowMessage WM_MDIICONARRANGE = new(nameof(WM_MDIICONARRANGE), TerraFX.Interop.Windows.WM_MDIICONARRANGE);
    public static readonly WindowMessage WM_MDIMAXIMIZE = new(nameof(WM_MDIMAXIMIZE), TerraFX.Interop.Windows.WM_MDIMAXIMIZE);
    public static readonly WindowMessage WM_MDINEXT = new(nameof(WM_MDINEXT), TerraFX.Interop.Windows.WM_MDINEXT);
    public static readonly WindowMessage WM_MDIREFRESHMENU = new(nameof(WM_MDIREFRESHMENU), TerraFX.Interop.Windows.WM_MDIREFRESHMENU);
    public static readonly WindowMessage WM_MDIRESTORE = new(nameof(WM_MDIRESTORE), TerraFX.Interop.Windows.WM_MDIRESTORE);
    public static readonly WindowMessage WM_MDISETMENU = new(nameof(WM_MDISETMENU), TerraFX.Interop.Windows.WM_MDISETMENU);
    public static readonly WindowMessage WM_MDITILE = new(nameof(WM_MDITILE), TerraFX.Interop.Windows.WM_MDITILE);
    public static readonly WindowMessage WM_MEASUREITEM = new(nameof(WM_MEASUREITEM), TerraFX.Interop.Windows.WM_MEASUREITEM);
    public static readonly WindowMessage WM_MENUCHAR = new(nameof(WM_MENUCHAR), TerraFX.Interop.Windows.WM_MENUCHAR);
    public static readonly WindowMessage WM_MENUCOMMAND = new(nameof(WM_MENUCOMMAND), TerraFX.Interop.Windows.WM_MENUCOMMAND);
    public static readonly WindowMessage WM_MENUDRAG = new(nameof(WM_MENUDRAG), TerraFX.Interop.Windows.WM_MENUDRAG);
    public static readonly WindowMessage WM_MENUGETOBJECT = new(nameof(WM_MENUGETOBJECT), TerraFX.Interop.Windows.WM_MENUGETOBJECT);
    public static readonly WindowMessage WM_MENURBUTTONUP = new(nameof(WM_MENURBUTTONUP), TerraFX.Interop.Windows.WM_MENURBUTTONUP);
    public static readonly WindowMessage WM_MENUSELECT = new(nameof(WM_MENUSELECT), TerraFX.Interop.Windows.WM_MENUSELECT);
    public static readonly WindowMessage WM_MOUSEACTIVATE = new(nameof(WM_MOUSEACTIVATE), TerraFX.Interop.Windows.WM_MOUSEACTIVATE);
    public static readonly WindowMessage WM_MOUSEHOVER = new(nameof(WM_MOUSEHOVER), TerraFX.Interop.Windows.WM_MOUSEHOVER);
    public static readonly WindowMessage WM_MOUSEHWHEEL = new(nameof(WM_MOUSEHWHEEL), TerraFX.Interop.Windows.WM_MOUSEHWHEEL);
    public static readonly WindowMessage WM_MOUSELEAVE = new(nameof(WM_MOUSELEAVE), TerraFX.Interop.Windows.WM_MOUSELEAVE);
    public static readonly WindowMessage WM_MOUSEMOVE = new(nameof(WM_MOUSEMOVE), TerraFX.Interop.Windows.WM_MOUSEMOVE);
    public static readonly WindowMessage WM_MOUSEWHEEL = new(nameof(WM_MOUSEWHEEL), TerraFX.Interop.Windows.WM_MOUSEWHEEL);
    public static readonly WindowMessage WM_MOVE = new(nameof(WM_MOVE), TerraFX.Interop.Windows.WM_MOVE);
    public static readonly WindowMessage WM_MOVING = new(nameof(WM_MOVING), TerraFX.Interop.Windows.WM_MOVING);
    public static readonly WindowMessage WM_NCACTIVATE = new(nameof(WM_NCACTIVATE), TerraFX.Interop.Windows.WM_NCACTIVATE);
    public static readonly WindowMessage WM_NCCALCSIZE = new(nameof(WM_NCCALCSIZE), TerraFX.Interop.Windows.WM_NCCALCSIZE);
    public static readonly WindowMessage WM_NCCREATE = new(nameof(WM_NCCREATE), TerraFX.Interop.Windows.WM_NCCREATE);
    public static readonly WindowMessage WM_NCDESTROY = new(nameof(WM_NCDESTROY), TerraFX.Interop.Windows.WM_NCDESTROY);
    public static readonly WindowMessage WM_NCHITTEST = new(nameof(WM_NCHITTEST), TerraFX.Interop.Windows.WM_NCHITTEST);
    public static readonly WindowMessage WM_NCLBUTTONDBLCLK = new(nameof(WM_NCLBUTTONDBLCLK), TerraFX.Interop.Windows.WM_NCLBUTTONDBLCLK);
    public static readonly WindowMessage WM_NCLBUTTONDOWN = new(nameof(WM_NCLBUTTONDOWN), TerraFX.Interop.Windows.WM_NCLBUTTONDOWN);
    public static readonly WindowMessage WM_NCLBUTTONUP = new(nameof(WM_NCLBUTTONUP), TerraFX.Interop.Windows.WM_NCLBUTTONUP);
    public static readonly WindowMessage WM_NCMBUTTONDBLCLK = new(nameof(WM_NCMBUTTONDBLCLK), TerraFX.Interop.Windows.WM_NCMBUTTONDBLCLK);
    public static readonly WindowMessage WM_NCMBUTTONDOWN = new(nameof(WM_NCMBUTTONDOWN), TerraFX.Interop.Windows.WM_NCMBUTTONDOWN);
    public static readonly WindowMessage WM_NCMBUTTONUP = new(nameof(WM_NCMBUTTONUP), TerraFX.Interop.Windows.WM_NCMBUTTONUP);
    public static readonly WindowMessage WM_NCMOUSEHOVER = new(nameof(WM_NCMOUSEHOVER), TerraFX.Interop.Windows.WM_NCMOUSEHOVER);
    public static readonly WindowMessage WM_NCMOUSELEAVE = new(nameof(WM_NCMOUSELEAVE), TerraFX.Interop.Windows.WM_NCMOUSELEAVE);
    public static readonly WindowMessage WM_NCMOUSEMOVE = new(nameof(WM_NCMOUSEMOVE), TerraFX.Interop.Windows.WM_NCMOUSEMOVE);
    public static readonly WindowMessage WM_NCPAINT = new(nameof(WM_NCPAINT), TerraFX.Interop.Windows.WM_NCPAINT);
    public static readonly WindowMessage WM_NCPOINTERDOWN = new(nameof(WM_NCPOINTERDOWN), TerraFX.Interop.Windows.WM_NCPOINTERDOWN);
    public static readonly WindowMessage WM_NCPOINTERUP = new(nameof(WM_NCPOINTERUP), TerraFX.Interop.Windows.WM_NCPOINTERUP);
    public static readonly WindowMessage WM_NCPOINTERUPDATE = new(nameof(WM_NCPOINTERUPDATE), TerraFX.Interop.Windows.WM_NCPOINTERUPDATE);
    public static readonly WindowMessage WM_NCRBUTTONDBLCLK = new(nameof(WM_NCRBUTTONDBLCLK), TerraFX.Interop.Windows.WM_NCRBUTTONDBLCLK);
    public static readonly WindowMessage WM_NCRBUTTONDOWN = new(nameof(WM_NCRBUTTONDOWN), TerraFX.Interop.Windows.WM_NCRBUTTONDOWN);
    public static readonly WindowMessage WM_NCRBUTTONUP = new(nameof(WM_NCRBUTTONUP), TerraFX.Interop.Windows.WM_NCRBUTTONUP);
    public static readonly WindowMessage WM_NCXBUTTONDBLCLK = new(nameof(WM_NCXBUTTONDBLCLK), TerraFX.Interop.Windows.WM_NCXBUTTONDBLCLK);
    public static readonly WindowMessage WM_NCXBUTTONDOWN = new(nameof(WM_NCXBUTTONDOWN), TerraFX.Interop.Windows.WM_NCXBUTTONDOWN);
    public static readonly WindowMessage WM_NCXBUTTONUP = new(nameof(WM_NCXBUTTONUP), TerraFX.Interop.Windows.WM_NCXBUTTONUP);
    public static readonly WindowMessage WM_NEXTDLGCTL = new(nameof(WM_NEXTDLGCTL), TerraFX.Interop.Windows.WM_NEXTDLGCTL);
    public static readonly WindowMessage WM_NEXTMENU = new(nameof(WM_NEXTMENU), TerraFX.Interop.Windows.WM_NEXTMENU);
    public static readonly WindowMessage WM_NOTIFY = new(nameof(WM_NOTIFY), TerraFX.Interop.Windows.WM_NOTIFY);
    public static readonly WindowMessage WM_NOTIFYFORMAT = new(nameof(WM_NOTIFYFORMAT), TerraFX.Interop.Windows.WM_NOTIFYFORMAT);
    public static readonly WindowMessage WM_NULL = new(nameof(WM_NULL), TerraFX.Interop.Windows.WM_NULL);
    public static readonly WindowMessage WM_PAINT = new(nameof(WM_PAINT), TerraFX.Interop.Windows.WM_PAINT);
    public static readonly WindowMessage WM_PAINTCLIPBOARD = new(nameof(WM_PAINTCLIPBOARD), TerraFX.Interop.Windows.WM_PAINTCLIPBOARD);
    public static readonly WindowMessage WM_PAINTICON = new(nameof(WM_PAINTICON), TerraFX.Interop.Windows.WM_PAINTICON);
    public static readonly WindowMessage WM_PALETTECHANGED = new(nameof(WM_PALETTECHANGED), TerraFX.Interop.Windows.WM_PALETTECHANGED);
    public static readonly WindowMessage WM_PALETTEISCHANGING = new(nameof(WM_PALETTEISCHANGING), TerraFX.Interop.Windows.WM_PALETTEISCHANGING);
    public static readonly WindowMessage WM_PARENTNOTIFY = new(nameof(WM_PARENTNOTIFY), TerraFX.Interop.Windows.WM_PARENTNOTIFY);
    public static readonly WindowMessage WM_PASTE = new(nameof(WM_PASTE), TerraFX.Interop.Windows.WM_PASTE);
    public static readonly WindowMessage WM_PENWINFIRST = new(nameof(WM_PENWINFIRST), TerraFX.Interop.Windows.WM_PENWINFIRST);
    public static readonly WindowMessage WM_PENWINLAST = new(nameof(WM_PENWINLAST), TerraFX.Interop.Windows.WM_PENWINLAST);
    public static readonly WindowMessage WM_POINTERACTIVATE = new(nameof(WM_POINTERACTIVATE), TerraFX.Interop.Windows.WM_POINTERACTIVATE);
    public static readonly WindowMessage WM_POINTERCAPTURECHANGED = new(nameof(WM_POINTERCAPTURECHANGED), TerraFX.Interop.Windows.WM_POINTERCAPTURECHANGED);
    public static readonly WindowMessage WM_POINTERDEVICECHANGE = new(nameof(WM_POINTERDEVICECHANGE), TerraFX.Interop.Windows.WM_POINTERDEVICECHANGE);
    public static readonly WindowMessage WM_POINTERDEVICEINRANGE = new(nameof(WM_POINTERDEVICEINRANGE), TerraFX.Interop.Windows.WM_POINTERDEVICEINRANGE);

    public static readonly WindowMessage WM_POINTERDEVICEOUTOFRANGE = new(
        nameof(WM_POINTERDEVICEOUTOFRANGE),
        TerraFX.Interop.Windows.WM_POINTERDEVICEOUTOFRANGE);

    public static readonly WindowMessage WM_POINTERDOWN = new(nameof(WM_POINTERDOWN), TerraFX.Interop.Windows.WM_POINTERDOWN);
    public static readonly WindowMessage WM_POINTERENTER = new(nameof(WM_POINTERENTER), TerraFX.Interop.Windows.WM_POINTERENTER);
    public static readonly WindowMessage WM_POINTERHWHEEL = new(nameof(WM_POINTERHWHEEL), TerraFX.Interop.Windows.WM_POINTERHWHEEL);
    public static readonly WindowMessage WM_POINTERLEAVE = new(nameof(WM_POINTERLEAVE), TerraFX.Interop.Windows.WM_POINTERLEAVE);
    public static readonly WindowMessage WM_POINTERROUTEDAWAY = new(nameof(WM_POINTERROUTEDAWAY), TerraFX.Interop.Windows.WM_POINTERROUTEDAWAY);
    public static readonly WindowMessage WM_POINTERROUTEDRELEASED = new(nameof(WM_POINTERROUTEDRELEASED), TerraFX.Interop.Windows.WM_POINTERROUTEDRELEASED);
    public static readonly WindowMessage WM_POINTERROUTEDTO = new(nameof(WM_POINTERROUTEDTO), TerraFX.Interop.Windows.WM_POINTERROUTEDTO);
    public static readonly WindowMessage WM_POINTERUP = new(nameof(WM_POINTERUP), TerraFX.Interop.Windows.WM_POINTERUP);
    public static readonly WindowMessage WM_POINTERUPDATE = new(nameof(WM_POINTERUPDATE), TerraFX.Interop.Windows.WM_POINTERUPDATE);
    public static readonly WindowMessage WM_POINTERWHEEL = new(nameof(WM_POINTERWHEEL), TerraFX.Interop.Windows.WM_POINTERWHEEL);
    public static readonly WindowMessage WM_POWER = new(nameof(WM_POWER), TerraFX.Interop.Windows.WM_POWER);
    public static readonly WindowMessage WM_POWERBROADCAST = new(nameof(WM_POWERBROADCAST), TerraFX.Interop.Windows.WM_POWERBROADCAST);
    public static readonly WindowMessage WM_PRINT = new(nameof(WM_PRINT), TerraFX.Interop.Windows.WM_PRINT);
    public static readonly WindowMessage WM_PRINTCLIENT = new(nameof(WM_PRINTCLIENT), TerraFX.Interop.Windows.WM_PRINTCLIENT);
    public static readonly WindowMessage WM_QUERYDRAGICON = new(nameof(WM_QUERYDRAGICON), TerraFX.Interop.Windows.WM_QUERYDRAGICON);
    public static readonly WindowMessage WM_QUERYENDSESSION = new(nameof(WM_QUERYENDSESSION), TerraFX.Interop.Windows.WM_QUERYENDSESSION);
    public static readonly WindowMessage WM_QUERYNEWPALETTE = new(nameof(WM_QUERYNEWPALETTE), TerraFX.Interop.Windows.WM_QUERYNEWPALETTE);
    public static readonly WindowMessage WM_QUERYOPEN = new(nameof(WM_QUERYOPEN), TerraFX.Interop.Windows.WM_QUERYOPEN);
    public static readonly WindowMessage WM_QUERYUISTATE = new(nameof(WM_QUERYUISTATE), TerraFX.Interop.Windows.WM_QUERYUISTATE);
    public static readonly WindowMessage WM_QUEUESYNC = new(nameof(WM_QUEUESYNC), TerraFX.Interop.Windows.WM_QUEUESYNC);
    public static readonly WindowMessage WM_QUIT = new(nameof(WM_QUIT), TerraFX.Interop.Windows.WM_QUIT);
    public static readonly WindowMessage WM_RBUTTONDBLCLK = new(nameof(WM_RBUTTONDBLCLK), TerraFX.Interop.Windows.WM_RBUTTONDBLCLK);
    public static readonly WindowMessage WM_RBUTTONDOWN = new(nameof(WM_RBUTTONDOWN), TerraFX.Interop.Windows.WM_RBUTTONDOWN);
    public static readonly WindowMessage WM_RBUTTONUP = new(nameof(WM_RBUTTONUP), TerraFX.Interop.Windows.WM_RBUTTONUP);
    public static readonly WindowMessage WM_RENDERALLFORMATS = new(nameof(WM_RENDERALLFORMATS), TerraFX.Interop.Windows.WM_RENDERALLFORMATS);
    public static readonly WindowMessage WM_RENDERFORMAT = new(nameof(WM_RENDERFORMAT), TerraFX.Interop.Windows.WM_RENDERFORMAT);
    public static readonly WindowMessage WM_SETCURSOR = new(nameof(WM_SETCURSOR), TerraFX.Interop.Windows.WM_SETCURSOR);
    public static readonly WindowMessage WM_SETFOCUS = new(nameof(WM_SETFOCUS), TerraFX.Interop.Windows.WM_SETFOCUS);
    public static readonly WindowMessage WM_SETFONT = new(nameof(WM_SETFONT), TerraFX.Interop.Windows.WM_SETFONT);
    public static readonly WindowMessage WM_SETHOTKEY = new(nameof(WM_SETHOTKEY), TerraFX.Interop.Windows.WM_SETHOTKEY);
    public static readonly WindowMessage WM_SETICON = new(nameof(WM_SETICON), TerraFX.Interop.Windows.WM_SETICON);
    public static readonly WindowMessage WM_SETREDRAW = new(nameof(WM_SETREDRAW), TerraFX.Interop.Windows.WM_SETREDRAW);
    public static readonly WindowMessage WM_SETTEXT = new(nameof(WM_SETTEXT), TerraFX.Interop.Windows.WM_SETTEXT);
    public static readonly WindowMessage WM_SETTINGCHANGE = new(nameof(WM_SETTINGCHANGE), TerraFX.Interop.Windows.WM_SETTINGCHANGE);
    public static readonly WindowMessage WM_SHOWWINDOW = new(nameof(WM_SHOWWINDOW), TerraFX.Interop.Windows.WM_SHOWWINDOW);
    public static readonly WindowMessage WM_SIZE = new(nameof(WM_SIZE), TerraFX.Interop.Windows.WM_SIZE);
    public static readonly WindowMessage WM_SIZECLIPBOARD = new(nameof(WM_SIZECLIPBOARD), TerraFX.Interop.Windows.WM_SIZECLIPBOARD);
    public static readonly WindowMessage WM_SIZING = new(nameof(WM_SIZING), TerraFX.Interop.Windows.WM_SIZING);
    public static readonly WindowMessage WM_SPOOLERSTATUS = new(nameof(WM_SPOOLERSTATUS), TerraFX.Interop.Windows.WM_SPOOLERSTATUS);
    public static readonly WindowMessage WM_STYLECHANGED = new(nameof(WM_STYLECHANGED), TerraFX.Interop.Windows.WM_STYLECHANGED);
    public static readonly WindowMessage WM_STYLECHANGING = new(nameof(WM_STYLECHANGING), TerraFX.Interop.Windows.WM_STYLECHANGING);
    public static readonly WindowMessage WM_SYNCPAINT = new(nameof(WM_SYNCPAINT), TerraFX.Interop.Windows.WM_SYNCPAINT);
    public static readonly WindowMessage WM_SYSCHAR = new(nameof(WM_SYSCHAR), TerraFX.Interop.Windows.WM_SYSCHAR);
    public static readonly WindowMessage WM_SYSCOLORCHANGE = new(nameof(WM_SYSCOLORCHANGE), TerraFX.Interop.Windows.WM_SYSCOLORCHANGE);
    public static readonly WindowMessage WM_SYSCOMMAND = new(nameof(WM_SYSCOMMAND), TerraFX.Interop.Windows.WM_SYSCOMMAND);
    public static readonly WindowMessage WM_SYSDEADCHAR = new(nameof(WM_SYSDEADCHAR), TerraFX.Interop.Windows.WM_SYSDEADCHAR);
    public static readonly WindowMessage WM_SYSKEYDOWN = new(nameof(WM_SYSKEYDOWN), TerraFX.Interop.Windows.WM_SYSKEYDOWN);
    public static readonly WindowMessage WM_SYSKEYUP = new(nameof(WM_SYSKEYUP), TerraFX.Interop.Windows.WM_SYSKEYUP);
    public static readonly WindowMessage WM_TABLET_FIRST = new(nameof(WM_TABLET_FIRST), TerraFX.Interop.Windows.WM_TABLET_FIRST);
    public static readonly WindowMessage WM_TABLET_LAST = new(nameof(WM_TABLET_LAST), TerraFX.Interop.Windows.WM_TABLET_LAST);
    public static readonly WindowMessage WM_TCARD = new(nameof(WM_TCARD), TerraFX.Interop.Windows.WM_TCARD);
    public static readonly WindowMessage WM_THEMECHANGED = new(nameof(WM_THEMECHANGED), TerraFX.Interop.Windows.WM_THEMECHANGED);
    public static readonly WindowMessage WM_TIMECHANGE = new(nameof(WM_TIMECHANGE), TerraFX.Interop.Windows.WM_TIMECHANGE);
    public static readonly WindowMessage WM_TIMER = new(nameof(WM_TIMER), TerraFX.Interop.Windows.WM_TIMER);
    public static readonly WindowMessage WM_TOUCH = new(nameof(WM_TOUCH), TerraFX.Interop.Windows.WM_TOUCH);
    public static readonly WindowMessage WM_TOUCHHITTESTING = new(nameof(WM_TOUCHHITTESTING), TerraFX.Interop.Windows.WM_TOUCHHITTESTING);
    public static readonly WindowMessage WM_UNDO = new(nameof(WM_UNDO), TerraFX.Interop.Windows.WM_UNDO);
    public static readonly WindowMessage WM_UNICHAR = new(nameof(WM_UNICHAR), TerraFX.Interop.Windows.WM_UNICHAR);
    public static readonly WindowMessage WM_UNINITMENUPOPUP = new(nameof(WM_UNINITMENUPOPUP), TerraFX.Interop.Windows.WM_UNINITMENUPOPUP);
    public static readonly WindowMessage WM_UPDATEUISTATE = new(nameof(WM_UPDATEUISTATE), TerraFX.Interop.Windows.WM_UPDATEUISTATE);
    public static readonly WindowMessage WM_USER = new(nameof(WM_USER), TerraFX.Interop.Windows.WM_USER);
    public static readonly WindowMessage WM_USERCHANGED = new(nameof(WM_USERCHANGED), TerraFX.Interop.Windows.WM_USERCHANGED);
    public static readonly WindowMessage WM_VKEYTOITEM = new(nameof(WM_VKEYTOITEM), TerraFX.Interop.Windows.WM_VKEYTOITEM);
    public static readonly WindowMessage WM_VSCROLL = new(nameof(WM_VSCROLL), TerraFX.Interop.Windows.WM_VSCROLL);
    public static readonly WindowMessage WM_VSCROLLCLIPBOARD = new(nameof(WM_VSCROLLCLIPBOARD), TerraFX.Interop.Windows.WM_VSCROLLCLIPBOARD);
    public static readonly WindowMessage WM_WINDOWPOSCHANGED = new(nameof(WM_WINDOWPOSCHANGED), TerraFX.Interop.Windows.WM_WINDOWPOSCHANGED);
    public static readonly WindowMessage WM_WINDOWPOSCHANGING = new(nameof(WM_WINDOWPOSCHANGING), TerraFX.Interop.Windows.WM_WINDOWPOSCHANGING);
    public static readonly WindowMessage WM_WTSSESSION_CHANGE = new(nameof(WM_WTSSESSION_CHANGE), TerraFX.Interop.Windows.WM_WTSSESSION_CHANGE);
    public static readonly WindowMessage WM_XBUTTONDBLCLK = new(nameof(WM_XBUTTONDBLCLK), TerraFX.Interop.Windows.WM_XBUTTONDBLCLK);
    public static readonly WindowMessage WM_XBUTTONDOWN = new(nameof(WM_XBUTTONDOWN), TerraFX.Interop.Windows.WM_XBUTTONDOWN);
    public static readonly WindowMessage WM_XBUTTONUP = new(nameof(WM_XBUTTONUP), TerraFX.Interop.Windows.WM_XBUTTONUP);

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
    public static implicit operator int(WindowMessage value)
    {
        ThrowIfNull(value, nameof(value));

        return value.Value;
    }

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

    private sealed class WindowsMessageCollection : KeyedCollection<int, WindowMessage>
    {
        protected override int GetKeyForItem(WindowMessage item)
            => item.Value;
    }
}