// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using TerraFX.Interop.Windows;

#pragma warning disable 1591

namespace VorpalEngine.Common.Windows;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public sealed class WindowMessage
{
    public static readonly WindowMessage MN_GETHMENU = new(nameof(MN_GETHMENU), TerraFX.Interop.Windows.Windows.MN_GETHMENU);
    public static readonly WindowMessage WM_ACTIVATE = new(nameof(WM_ACTIVATE), WM.WM_ACTIVATE);
    public static readonly WindowMessage WM_ACTIVATEAPP = new(nameof(WM_ACTIVATEAPP), WM.WM_ACTIVATEAPP);
    public static readonly WindowMessage WM_AFXFIRST = new(nameof(WM_AFXFIRST), WM.WM_AFXFIRST);
    public static readonly WindowMessage WM_AFXLAST = new(nameof(WM_AFXLAST), WM.WM_AFXLAST);
    public static readonly WindowMessage WM_APP = new(nameof(WM_APP), WM.WM_APP);
    public static readonly WindowMessage WM_APPCOMMAND = new(nameof(WM_APPCOMMAND), WM.WM_APPCOMMAND);
    public static readonly WindowMessage WM_ASKCBFORMATNAME = new(nameof(WM_ASKCBFORMATNAME), WM.WM_ASKCBFORMATNAME);
    public static readonly WindowMessage WM_CANCELJOURNAL = new(nameof(WM_CANCELJOURNAL), WM.WM_CANCELJOURNAL);
    public static readonly WindowMessage WM_CANCELMODE = new(nameof(WM_CANCELMODE), WM.WM_CANCELMODE);
    public static readonly WindowMessage WM_CAPTURECHANGED = new(nameof(WM_CAPTURECHANGED), WM.WM_CAPTURECHANGED);
    public static readonly WindowMessage WM_CHANGECBCHAIN = new(nameof(WM_CHANGECBCHAIN), WM.WM_CHANGECBCHAIN);
    public static readonly WindowMessage WM_CHANGEUISTATE = new(nameof(WM_CHANGEUISTATE), WM.WM_CHANGEUISTATE);
    public static readonly WindowMessage WM_CHAR = new(nameof(WM_CHAR), WM.WM_CHAR);
    public static readonly WindowMessage WM_CHARTOITEM = new(nameof(WM_CHARTOITEM), WM.WM_CHARTOITEM);
    public static readonly WindowMessage WM_CHILDACTIVATE = new(nameof(WM_CHILDACTIVATE), WM.WM_CHILDACTIVATE);
    public static readonly WindowMessage WM_CLEAR = new(nameof(WM_CLEAR), WM.WM_CLEAR);
    public static readonly WindowMessage WM_CLIPBOARDUPDATE = new(nameof(WM_CLIPBOARDUPDATE), WM.WM_CLIPBOARDUPDATE);
    public static readonly WindowMessage WM_CLOSE = new(nameof(WM_CLOSE), WM.WM_CLOSE);
    public static readonly WindowMessage WM_COMMAND = new(nameof(WM_COMMAND), WM.WM_COMMAND);
    public static readonly WindowMessage WM_COMMNOTIFY = new(nameof(WM_COMMNOTIFY), WM.WM_COMMNOTIFY);
    public static readonly WindowMessage WM_COMPACTING = new(nameof(WM_COMPACTING), WM.WM_COMPACTING);
    public static readonly WindowMessage WM_COMPAREITEM = new(nameof(WM_COMPAREITEM), WM.WM_COMPAREITEM);
    public static readonly WindowMessage WM_CONTEXTMENU = new(nameof(WM_CONTEXTMENU), WM.WM_CONTEXTMENU);
    public static readonly WindowMessage WM_COPY = new(nameof(WM_COPY), WM.WM_COPY);
    public static readonly WindowMessage WM_COPYDATA = new(nameof(WM_COPYDATA), WM.WM_COPYDATA);
    public static readonly WindowMessage WM_CREATE = new(nameof(WM_CREATE), WM.WM_CREATE);
    public static readonly WindowMessage WM_CTLCOLORBTN = new(nameof(WM_CTLCOLORBTN), WM.WM_CTLCOLORBTN);
    public static readonly WindowMessage WM_CTLCOLORDLG = new(nameof(WM_CTLCOLORDLG), WM.WM_CTLCOLORDLG);
    public static readonly WindowMessage WM_CTLCOLOREDIT = new(nameof(WM_CTLCOLOREDIT), WM.WM_CTLCOLOREDIT);
    public static readonly WindowMessage WM_CTLCOLORLISTBOX = new(nameof(WM_CTLCOLORLISTBOX), WM.WM_CTLCOLORLISTBOX);
    public static readonly WindowMessage WM_CTLCOLORMSGBOX = new(nameof(WM_CTLCOLORMSGBOX), WM.WM_CTLCOLORMSGBOX);
    public static readonly WindowMessage WM_CTLCOLORSCROLLBAR = new(nameof(WM_CTLCOLORSCROLLBAR), WM.WM_CTLCOLORSCROLLBAR);
    public static readonly WindowMessage WM_CTLCOLORSTATIC = new(nameof(WM_CTLCOLORSTATIC), WM.WM_CTLCOLORSTATIC);
    public static readonly WindowMessage WM_CUT = new(nameof(WM_CUT), WM.WM_CUT);
    public static readonly WindowMessage WM_DEADCHAR = new(nameof(WM_DEADCHAR), WM.WM_DEADCHAR);
    public static readonly WindowMessage WM_DELETEITEM = new(nameof(WM_DELETEITEM), WM.WM_DELETEITEM);
    public static readonly WindowMessage WM_DESTROY = new(nameof(WM_DESTROY), WM.WM_DESTROY);
    public static readonly WindowMessage WM_DESTROYCLIPBOARD = new(nameof(WM_DESTROYCLIPBOARD), WM.WM_DESTROYCLIPBOARD);
    public static readonly WindowMessage WM_DEVICECHANGE = new(nameof(WM_DEVICECHANGE), WM.WM_DEVICECHANGE);
    public static readonly WindowMessage WM_DEVMODECHANGE = new(nameof(WM_DEVMODECHANGE), WM.WM_DEVMODECHANGE);
    public static readonly WindowMessage WM_DISPLAYCHANGE = new(nameof(WM_DISPLAYCHANGE), WM.WM_DISPLAYCHANGE);
    public static readonly WindowMessage WM_DPICHANGED = new(nameof(WM_DPICHANGED), WM.WM_DPICHANGED);

    public static readonly WindowMessage WM_DPICHANGED_AFTERPARENT = new(
        nameof(WM_DPICHANGED_AFTERPARENT),
        WM.WM_DPICHANGED_AFTERPARENT);

    public static readonly WindowMessage WM_DPICHANGED_BEFOREPARENT = new(
        nameof(WM_DPICHANGED_BEFOREPARENT),
        WM.WM_DPICHANGED_BEFOREPARENT);

    public static readonly WindowMessage WM_DRAWCLIPBOARD = new(nameof(WM_DRAWCLIPBOARD), WM.WM_DRAWCLIPBOARD);
    public static readonly WindowMessage WM_DRAWITEM = new(nameof(WM_DRAWITEM), WM.WM_DRAWITEM);
    public static readonly WindowMessage WM_DROPFILES = new(nameof(WM_DROPFILES), WM.WM_DROPFILES);

    public static readonly WindowMessage WM_DWMCOLORIZATIONCOLORCHANGED = new(
        nameof(WM_DWMCOLORIZATIONCOLORCHANGED),
        WM.WM_DWMCOLORIZATIONCOLORCHANGED);

    public static readonly WindowMessage WM_DWMCOMPOSITIONCHANGED = new(
        nameof(WM_DWMCOMPOSITIONCHANGED),
        WM.WM_DWMCOMPOSITIONCHANGED);

    public static readonly WindowMessage WM_DWMNCRENDERINGCHANGED = new(
        nameof(WM_DWMNCRENDERINGCHANGED),
        WM.WM_DWMNCRENDERINGCHANGED);

    public static readonly WindowMessage WM_DWMSENDICONICLIVEPREVIEWBITMAP = new(
        nameof(WM_DWMSENDICONICLIVEPREVIEWBITMAP),
        WM.WM_DWMSENDICONICLIVEPREVIEWBITMAP);

    public static readonly WindowMessage WM_DWMSENDICONICTHUMBNAIL = new(
        nameof(WM_DWMSENDICONICTHUMBNAIL),
        WM.WM_DWMSENDICONICTHUMBNAIL);

    public static readonly WindowMessage WM_DWMWINDOWMAXIMIZEDCHANGE = new(
        nameof(WM_DWMWINDOWMAXIMIZEDCHANGE),
        WM.WM_DWMWINDOWMAXIMIZEDCHANGE);

    public static readonly WindowMessage WM_ENABLE = new(nameof(WM_ENABLE), WM.WM_ENABLE);
    public static readonly WindowMessage WM_ENDSESSION = new(nameof(WM_ENDSESSION), WM.WM_ENDSESSION);
    public static readonly WindowMessage WM_ENTERIDLE = new(nameof(WM_ENTERIDLE), WM.WM_ENTERIDLE);
    public static readonly WindowMessage WM_ENTERMENULOOP = new(nameof(WM_ENTERMENULOOP), WM.WM_ENTERMENULOOP);
    public static readonly WindowMessage WM_ENTERSIZEMOVE = new(nameof(WM_ENTERSIZEMOVE), WM.WM_ENTERSIZEMOVE);
    public static readonly WindowMessage WM_ERASEBKGND = new(nameof(WM_ERASEBKGND), WM.WM_ERASEBKGND);
    public static readonly WindowMessage WM_EXITMENULOOP = new(nameof(WM_EXITMENULOOP), WM.WM_EXITMENULOOP);
    public static readonly WindowMessage WM_EXITSIZEMOVE = new(nameof(WM_EXITSIZEMOVE), WM.WM_EXITSIZEMOVE);
    public static readonly WindowMessage WM_FONTCHANGE = new(nameof(WM_FONTCHANGE), WM.WM_FONTCHANGE);
    public static readonly WindowMessage WM_GESTURE = new(nameof(WM_GESTURE), WM.WM_GESTURE);
    public static readonly WindowMessage WM_GESTURENOTIFY = new(nameof(WM_GESTURENOTIFY), WM.WM_GESTURENOTIFY);
    public static readonly WindowMessage WM_GETDLGCODE = new(nameof(WM_GETDLGCODE), WM.WM_GETDLGCODE);
    public static readonly WindowMessage WM_GETDPISCALEDSIZE = new(nameof(WM_GETDPISCALEDSIZE), WM.WM_GETDPISCALEDSIZE);
    public static readonly WindowMessage WM_GETFONT = new(nameof(WM_GETFONT), WM.WM_GETFONT);
    public static readonly WindowMessage WM_GETHOTKEY = new(nameof(WM_GETHOTKEY), WM.WM_GETHOTKEY);
    public static readonly WindowMessage WM_GETICON = new(nameof(WM_GETICON), WM.WM_GETICON);
    public static readonly WindowMessage WM_GETMINMAXINFO = new(nameof(WM_GETMINMAXINFO), WM.WM_GETMINMAXINFO);
    public static readonly WindowMessage WM_GETOBJECT = new(nameof(WM_GETOBJECT), WM.WM_GETOBJECT);
    public static readonly WindowMessage WM_GETTEXT = new(nameof(WM_GETTEXT), WM.WM_GETTEXT);
    public static readonly WindowMessage WM_GETTEXTLENGTH = new(nameof(WM_GETTEXTLENGTH), WM.WM_GETTEXTLENGTH);
    public static readonly WindowMessage WM_GETTITLEBARINFOEX = new(nameof(WM_GETTITLEBARINFOEX), WM.WM_GETTITLEBARINFOEX);
    public static readonly WindowMessage WM_HANDHELDFIRST = new(nameof(WM_HANDHELDFIRST), WM.WM_HANDHELDFIRST);
    public static readonly WindowMessage WM_HANDHELDLAST = new(nameof(WM_HANDHELDLAST), WM.WM_HANDHELDLAST);
    public static readonly WindowMessage WM_HELP = new(nameof(WM_HELP), WM.WM_HELP);
    public static readonly WindowMessage WM_HOTKEY = new(nameof(WM_HOTKEY), WM.WM_HOTKEY);
    public static readonly WindowMessage WM_HSCROLL = new(nameof(WM_HSCROLL), WM.WM_HSCROLL);
    public static readonly WindowMessage WM_HSCROLLCLIPBOARD = new(nameof(WM_HSCROLLCLIPBOARD), WM.WM_HSCROLLCLIPBOARD);
    public static readonly WindowMessage WM_ICONERASEBKGND = new(nameof(WM_ICONERASEBKGND), WM.WM_ICONERASEBKGND);
    public static readonly WindowMessage WM_IME_CHAR = new(nameof(WM_IME_CHAR), WM.WM_IME_CHAR);
    public static readonly WindowMessage WM_IME_COMPOSITION = new(nameof(WM_IME_COMPOSITION), WM.WM_IME_COMPOSITION);
    public static readonly WindowMessage WM_IME_COMPOSITIONFULL = new(nameof(WM_IME_COMPOSITIONFULL), WM.WM_IME_COMPOSITIONFULL);
    public static readonly WindowMessage WM_IME_CONTROL = new(nameof(WM_IME_CONTROL), WM.WM_IME_CONTROL);
    public static readonly WindowMessage WM_IME_ENDCOMPOSITION = new(nameof(WM_IME_ENDCOMPOSITION), WM.WM_IME_ENDCOMPOSITION);
    public static readonly WindowMessage WM_IME_KEYDOWN = new(nameof(WM_IME_KEYDOWN), WM.WM_IME_KEYDOWN);
    public static readonly WindowMessage WM_IME_KEYUP = new(nameof(WM_IME_KEYUP), WM.WM_IME_KEYUP);
    public static readonly WindowMessage WM_IME_NOTIFY = new(nameof(WM_IME_NOTIFY), WM.WM_IME_NOTIFY);
    public static readonly WindowMessage WM_IME_REQUEST = new(nameof(WM_IME_REQUEST), WM.WM_IME_REQUEST);
    public static readonly WindowMessage WM_IME_SELECT = new(nameof(WM_IME_SELECT), WM.WM_IME_SELECT);
    public static readonly WindowMessage WM_IME_SETCONTEXT = new(nameof(WM_IME_SETCONTEXT), WM.WM_IME_SETCONTEXT);

    public static readonly WindowMessage WM_IME_STARTCOMPOSITION = new(
        nameof(WM_IME_STARTCOMPOSITION),
        WM.WM_IME_STARTCOMPOSITION);

    public static readonly WindowMessage WM_INITDIALOG = new(nameof(WM_INITDIALOG), WM.WM_INITDIALOG);
    public static readonly WindowMessage WM_INITMENU = new(nameof(WM_INITMENU), WM.WM_INITMENU);
    public static readonly WindowMessage WM_INITMENUPOPUP = new(nameof(WM_INITMENUPOPUP), WM.WM_INITMENUPOPUP);
    public static readonly WindowMessage WM_INPUT = new(nameof(WM_INPUT), WM.WM_INPUT);
    public static readonly WindowMessage WM_INPUT_DEVICE_CHANGE = new(nameof(WM_INPUT_DEVICE_CHANGE), WM.WM_INPUT_DEVICE_CHANGE);
    public static readonly WindowMessage WM_INPUTLANGCHANGE = new(nameof(WM_INPUTLANGCHANGE), WM.WM_INPUTLANGCHANGE);

    public static readonly WindowMessage WM_INPUTLANGCHANGEREQUEST = new(
        nameof(WM_INPUTLANGCHANGEREQUEST),
        WM.WM_INPUTLANGCHANGEREQUEST);

    public static readonly WindowMessage WM_KEYDOWN = new(nameof(WM_KEYDOWN), WM.WM_KEYDOWN);
    public static readonly WindowMessage WM_KEYUP = new(nameof(WM_KEYUP), WM.WM_KEYUP);
    public static readonly WindowMessage WM_KILLFOCUS = new(nameof(WM_KILLFOCUS), WM.WM_KILLFOCUS);
    public static readonly WindowMessage WM_LBUTTONDBLCLK = new(nameof(WM_LBUTTONDBLCLK), WM.WM_LBUTTONDBLCLK);
    public static readonly WindowMessage WM_LBUTTONDOWN = new(nameof(WM_LBUTTONDOWN), WM.WM_LBUTTONDOWN);
    public static readonly WindowMessage WM_LBUTTONUP = new(nameof(WM_LBUTTONUP), WM.WM_LBUTTONUP);
    public static readonly WindowMessage WM_MBUTTONDBLCLK = new(nameof(WM_MBUTTONDBLCLK), WM.WM_MBUTTONDBLCLK);
    public static readonly WindowMessage WM_MBUTTONDOWN = new(nameof(WM_MBUTTONDOWN), WM.WM_MBUTTONDOWN);
    public static readonly WindowMessage WM_MBUTTONUP = new(nameof(WM_MBUTTONUP), WM.WM_MBUTTONUP);
    public static readonly WindowMessage WM_MDIACTIVATE = new(nameof(WM_MDIACTIVATE), WM.WM_MDIACTIVATE);
    public static readonly WindowMessage WM_MDICASCADE = new(nameof(WM_MDICASCADE), WM.WM_MDICASCADE);
    public static readonly WindowMessage WM_MDICREATE = new(nameof(WM_MDICREATE), WM.WM_MDICREATE);
    public static readonly WindowMessage WM_MDIDESTROY = new(nameof(WM_MDIDESTROY), WM.WM_MDIDESTROY);
    public static readonly WindowMessage WM_MDIGETACTIVE = new(nameof(WM_MDIGETACTIVE), WM.WM_MDIGETACTIVE);
    public static readonly WindowMessage WM_MDIICONARRANGE = new(nameof(WM_MDIICONARRANGE), WM.WM_MDIICONARRANGE);
    public static readonly WindowMessage WM_MDIMAXIMIZE = new(nameof(WM_MDIMAXIMIZE), WM.WM_MDIMAXIMIZE);
    public static readonly WindowMessage WM_MDINEXT = new(nameof(WM_MDINEXT), WM.WM_MDINEXT);
    public static readonly WindowMessage WM_MDIREFRESHMENU = new(nameof(WM_MDIREFRESHMENU), WM.WM_MDIREFRESHMENU);
    public static readonly WindowMessage WM_MDIRESTORE = new(nameof(WM_MDIRESTORE), WM.WM_MDIRESTORE);
    public static readonly WindowMessage WM_MDISETMENU = new(nameof(WM_MDISETMENU), WM.WM_MDISETMENU);
    public static readonly WindowMessage WM_MDITILE = new(nameof(WM_MDITILE), WM.WM_MDITILE);
    public static readonly WindowMessage WM_MEASUREITEM = new(nameof(WM_MEASUREITEM), WM.WM_MEASUREITEM);
    public static readonly WindowMessage WM_MENUCHAR = new(nameof(WM_MENUCHAR), WM.WM_MENUCHAR);
    public static readonly WindowMessage WM_MENUCOMMAND = new(nameof(WM_MENUCOMMAND), WM.WM_MENUCOMMAND);
    public static readonly WindowMessage WM_MENUDRAG = new(nameof(WM_MENUDRAG), WM.WM_MENUDRAG);
    public static readonly WindowMessage WM_MENUGETOBJECT = new(nameof(WM_MENUGETOBJECT), WM.WM_MENUGETOBJECT);
    public static readonly WindowMessage WM_MENURBUTTONUP = new(nameof(WM_MENURBUTTONUP), WM.WM_MENURBUTTONUP);
    public static readonly WindowMessage WM_MENUSELECT = new(nameof(WM_MENUSELECT), WM.WM_MENUSELECT);
    public static readonly WindowMessage WM_MOUSEACTIVATE = new(nameof(WM_MOUSEACTIVATE), WM.WM_MOUSEACTIVATE);
    public static readonly WindowMessage WM_MOUSEHOVER = new(nameof(WM_MOUSEHOVER), WM.WM_MOUSEHOVER);
    public static readonly WindowMessage WM_MOUSEHWHEEL = new(nameof(WM_MOUSEHWHEEL), WM.WM_MOUSEHWHEEL);
    public static readonly WindowMessage WM_MOUSELEAVE = new(nameof(WM_MOUSELEAVE), WM.WM_MOUSELEAVE);
    public static readonly WindowMessage WM_MOUSEMOVE = new(nameof(WM_MOUSEMOVE), WM.WM_MOUSEMOVE);
    public static readonly WindowMessage WM_MOUSEWHEEL = new(nameof(WM_MOUSEWHEEL), WM.WM_MOUSEWHEEL);
    public static readonly WindowMessage WM_MOVE = new(nameof(WM_MOVE), WM.WM_MOVE);
    public static readonly WindowMessage WM_MOVING = new(nameof(WM_MOVING), WM.WM_MOVING);
    public static readonly WindowMessage WM_NCACTIVATE = new(nameof(WM_NCACTIVATE), WM.WM_NCACTIVATE);
    public static readonly WindowMessage WM_NCCALCSIZE = new(nameof(WM_NCCALCSIZE), WM.WM_NCCALCSIZE);
    public static readonly WindowMessage WM_NCCREATE = new(nameof(WM_NCCREATE), WM.WM_NCCREATE);
    public static readonly WindowMessage WM_NCDESTROY = new(nameof(WM_NCDESTROY), WM.WM_NCDESTROY);
    public static readonly WindowMessage WM_NCHITTEST = new(nameof(WM_NCHITTEST), WM.WM_NCHITTEST);
    public static readonly WindowMessage WM_NCLBUTTONDBLCLK = new(nameof(WM_NCLBUTTONDBLCLK), WM.WM_NCLBUTTONDBLCLK);
    public static readonly WindowMessage WM_NCLBUTTONDOWN = new(nameof(WM_NCLBUTTONDOWN), WM.WM_NCLBUTTONDOWN);
    public static readonly WindowMessage WM_NCLBUTTONUP = new(nameof(WM_NCLBUTTONUP), WM.WM_NCLBUTTONUP);
    public static readonly WindowMessage WM_NCMBUTTONDBLCLK = new(nameof(WM_NCMBUTTONDBLCLK), WM.WM_NCMBUTTONDBLCLK);
    public static readonly WindowMessage WM_NCMBUTTONDOWN = new(nameof(WM_NCMBUTTONDOWN), WM.WM_NCMBUTTONDOWN);
    public static readonly WindowMessage WM_NCMBUTTONUP = new(nameof(WM_NCMBUTTONUP), WM.WM_NCMBUTTONUP);
    public static readonly WindowMessage WM_NCMOUSEHOVER = new(nameof(WM_NCMOUSEHOVER), WM.WM_NCMOUSEHOVER);
    public static readonly WindowMessage WM_NCMOUSELEAVE = new(nameof(WM_NCMOUSELEAVE), WM.WM_NCMOUSELEAVE);
    public static readonly WindowMessage WM_NCMOUSEMOVE = new(nameof(WM_NCMOUSEMOVE), WM.WM_NCMOUSEMOVE);
    public static readonly WindowMessage WM_NCPAINT = new(nameof(WM_NCPAINT), WM.WM_NCPAINT);
    public static readonly WindowMessage WM_NCPOINTERDOWN = new(nameof(WM_NCPOINTERDOWN), WM.WM_NCPOINTERDOWN);
    public static readonly WindowMessage WM_NCPOINTERUP = new(nameof(WM_NCPOINTERUP), WM.WM_NCPOINTERUP);
    public static readonly WindowMessage WM_NCPOINTERUPDATE = new(nameof(WM_NCPOINTERUPDATE), WM.WM_NCPOINTERUPDATE);
    public static readonly WindowMessage WM_NCRBUTTONDBLCLK = new(nameof(WM_NCRBUTTONDBLCLK), WM.WM_NCRBUTTONDBLCLK);
    public static readonly WindowMessage WM_NCRBUTTONDOWN = new(nameof(WM_NCRBUTTONDOWN), WM.WM_NCRBUTTONDOWN);
    public static readonly WindowMessage WM_NCRBUTTONUP = new(nameof(WM_NCRBUTTONUP), WM.WM_NCRBUTTONUP);
    public static readonly WindowMessage WM_NCXBUTTONDBLCLK = new(nameof(WM_NCXBUTTONDBLCLK), WM.WM_NCXBUTTONDBLCLK);
    public static readonly WindowMessage WM_NCXBUTTONDOWN = new(nameof(WM_NCXBUTTONDOWN), WM.WM_NCXBUTTONDOWN);
    public static readonly WindowMessage WM_NCXBUTTONUP = new(nameof(WM_NCXBUTTONUP), WM.WM_NCXBUTTONUP);
    public static readonly WindowMessage WM_NEXTDLGCTL = new(nameof(WM_NEXTDLGCTL), WM.WM_NEXTDLGCTL);
    public static readonly WindowMessage WM_NEXTMENU = new(nameof(WM_NEXTMENU), WM.WM_NEXTMENU);
    public static readonly WindowMessage WM_NOTIFY = new(nameof(WM_NOTIFY), WM.WM_NOTIFY);
    public static readonly WindowMessage WM_NOTIFYFORMAT = new(nameof(WM_NOTIFYFORMAT), WM.WM_NOTIFYFORMAT);
    public static readonly WindowMessage WM_NULL = new(nameof(WM_NULL), WM.WM_NULL);
    public static readonly WindowMessage WM_PAINT = new(nameof(WM_PAINT), WM.WM_PAINT);
    public static readonly WindowMessage WM_PAINTCLIPBOARD = new(nameof(WM_PAINTCLIPBOARD), WM.WM_PAINTCLIPBOARD);
    public static readonly WindowMessage WM_PAINTICON = new(nameof(WM_PAINTICON), WM.WM_PAINTICON);
    public static readonly WindowMessage WM_PALETTECHANGED = new(nameof(WM_PALETTECHANGED), WM.WM_PALETTECHANGED);
    public static readonly WindowMessage WM_PALETTEISCHANGING = new(nameof(WM_PALETTEISCHANGING), WM.WM_PALETTEISCHANGING);
    public static readonly WindowMessage WM_PARENTNOTIFY = new(nameof(WM_PARENTNOTIFY), WM.WM_PARENTNOTIFY);
    public static readonly WindowMessage WM_PASTE = new(nameof(WM_PASTE), WM.WM_PASTE);
    public static readonly WindowMessage WM_PENWINFIRST = new(nameof(WM_PENWINFIRST), WM.WM_PENWINFIRST);
    public static readonly WindowMessage WM_PENWINLAST = new(nameof(WM_PENWINLAST), WM.WM_PENWINLAST);
    public static readonly WindowMessage WM_POINTERACTIVATE = new(nameof(WM_POINTERACTIVATE), WM.WM_POINTERACTIVATE);

    public static readonly WindowMessage WM_POINTERCAPTURECHANGED = new(
        nameof(WM_POINTERCAPTURECHANGED),
        WM.WM_POINTERCAPTURECHANGED);

    public static readonly WindowMessage WM_POINTERDEVICECHANGE = new(nameof(WM_POINTERDEVICECHANGE), WM.WM_POINTERDEVICECHANGE);

    public static readonly WindowMessage WM_POINTERDEVICEINRANGE = new(
        nameof(WM_POINTERDEVICEINRANGE),
        WM.WM_POINTERDEVICEINRANGE);

    public static readonly WindowMessage WM_POINTERDEVICEOUTOFRANGE = new(
        nameof(WM_POINTERDEVICEOUTOFRANGE),
        WM.WM_POINTERDEVICEOUTOFRANGE);

    public static readonly WindowMessage WM_POINTERDOWN = new(nameof(WM_POINTERDOWN), WM.WM_POINTERDOWN);
    public static readonly WindowMessage WM_POINTERENTER = new(nameof(WM_POINTERENTER), WM.WM_POINTERENTER);
    public static readonly WindowMessage WM_POINTERHWHEEL = new(nameof(WM_POINTERHWHEEL), WM.WM_POINTERHWHEEL);
    public static readonly WindowMessage WM_POINTERLEAVE = new(nameof(WM_POINTERLEAVE), WM.WM_POINTERLEAVE);
    public static readonly WindowMessage WM_POINTERROUTEDAWAY = new(nameof(WM_POINTERROUTEDAWAY), WM.WM_POINTERROUTEDAWAY);

    public static readonly WindowMessage WM_POINTERROUTEDRELEASED = new(
        nameof(WM_POINTERROUTEDRELEASED),
        WM.WM_POINTERROUTEDRELEASED);

    public static readonly WindowMessage WM_POINTERROUTEDTO = new(nameof(WM_POINTERROUTEDTO), WM.WM_POINTERROUTEDTO);
    public static readonly WindowMessage WM_POINTERUP = new(nameof(WM_POINTERUP), WM.WM_POINTERUP);
    public static readonly WindowMessage WM_POINTERUPDATE = new(nameof(WM_POINTERUPDATE), WM.WM_POINTERUPDATE);
    public static readonly WindowMessage WM_POINTERWHEEL = new(nameof(WM_POINTERWHEEL), WM.WM_POINTERWHEEL);
    public static readonly WindowMessage WM_POWER = new(nameof(WM_POWER), WM.WM_POWER);
    public static readonly WindowMessage WM_POWERBROADCAST = new(nameof(WM_POWERBROADCAST), WM.WM_POWERBROADCAST);
    public static readonly WindowMessage WM_PRINT = new(nameof(WM_PRINT), WM.WM_PRINT);
    public static readonly WindowMessage WM_PRINTCLIENT = new(nameof(WM_PRINTCLIENT), WM.WM_PRINTCLIENT);
    public static readonly WindowMessage WM_QUERYDRAGICON = new(nameof(WM_QUERYDRAGICON), WM.WM_QUERYDRAGICON);
    public static readonly WindowMessage WM_QUERYENDSESSION = new(nameof(WM_QUERYENDSESSION), WM.WM_QUERYENDSESSION);
    public static readonly WindowMessage WM_QUERYNEWPALETTE = new(nameof(WM_QUERYNEWPALETTE), WM.WM_QUERYNEWPALETTE);
    public static readonly WindowMessage WM_QUERYOPEN = new(nameof(WM_QUERYOPEN), WM.WM_QUERYOPEN);
    public static readonly WindowMessage WM_QUERYUISTATE = new(nameof(WM_QUERYUISTATE), WM.WM_QUERYUISTATE);
    public static readonly WindowMessage WM_QUEUESYNC = new(nameof(WM_QUEUESYNC), WM.WM_QUEUESYNC);
    public static readonly WindowMessage WM_QUIT = new(nameof(WM_QUIT), WM.WM_QUIT);
    public static readonly WindowMessage WM_RBUTTONDBLCLK = new(nameof(WM_RBUTTONDBLCLK), WM.WM_RBUTTONDBLCLK);
    public static readonly WindowMessage WM_RBUTTONDOWN = new(nameof(WM_RBUTTONDOWN), WM.WM_RBUTTONDOWN);
    public static readonly WindowMessage WM_RBUTTONUP = new(nameof(WM_RBUTTONUP), WM.WM_RBUTTONUP);
    public static readonly WindowMessage WM_RENDERALLFORMATS = new(nameof(WM_RENDERALLFORMATS), WM.WM_RENDERALLFORMATS);
    public static readonly WindowMessage WM_RENDERFORMAT = new(nameof(WM_RENDERFORMAT), WM.WM_RENDERFORMAT);
    public static readonly WindowMessage WM_SETCURSOR = new(nameof(WM_SETCURSOR), WM.WM_SETCURSOR);
    public static readonly WindowMessage WM_SETFOCUS = new(nameof(WM_SETFOCUS), WM.WM_SETFOCUS);
    public static readonly WindowMessage WM_SETFONT = new(nameof(WM_SETFONT), WM.WM_SETFONT);
    public static readonly WindowMessage WM_SETHOTKEY = new(nameof(WM_SETHOTKEY), WM.WM_SETHOTKEY);
    public static readonly WindowMessage WM_SETICON = new(nameof(WM_SETICON), WM.WM_SETICON);
    public static readonly WindowMessage WM_SETREDRAW = new(nameof(WM_SETREDRAW), WM.WM_SETREDRAW);
    public static readonly WindowMessage WM_SETTEXT = new(nameof(WM_SETTEXT), WM.WM_SETTEXT);
    public static readonly WindowMessage WM_SETTINGCHANGE = new(nameof(WM_SETTINGCHANGE), WM.WM_SETTINGCHANGE);
    public static readonly WindowMessage WM_SHOWWINDOW = new(nameof(WM_SHOWWINDOW), WM.WM_SHOWWINDOW);
    public static readonly WindowMessage WM_SIZE = new(nameof(WM_SIZE), WM.WM_SIZE);
    public static readonly WindowMessage WM_SIZECLIPBOARD = new(nameof(WM_SIZECLIPBOARD), WM.WM_SIZECLIPBOARD);
    public static readonly WindowMessage WM_SIZING = new(nameof(WM_SIZING), WM.WM_SIZING);
    public static readonly WindowMessage WM_SPOOLERSTATUS = new(nameof(WM_SPOOLERSTATUS), WM.WM_SPOOLERSTATUS);
    public static readonly WindowMessage WM_STYLECHANGED = new(nameof(WM_STYLECHANGED), WM.WM_STYLECHANGED);
    public static readonly WindowMessage WM_STYLECHANGING = new(nameof(WM_STYLECHANGING), WM.WM_STYLECHANGING);
    public static readonly WindowMessage WM_SYNCPAINT = new(nameof(WM_SYNCPAINT), WM.WM_SYNCPAINT);
    public static readonly WindowMessage WM_SYSCHAR = new(nameof(WM_SYSCHAR), WM.WM_SYSCHAR);
    public static readonly WindowMessage WM_SYSCOLORCHANGE = new(nameof(WM_SYSCOLORCHANGE), WM.WM_SYSCOLORCHANGE);
    public static readonly WindowMessage WM_SYSCOMMAND = new(nameof(WM_SYSCOMMAND), WM.WM_SYSCOMMAND);
    public static readonly WindowMessage WM_SYSDEADCHAR = new(nameof(WM_SYSDEADCHAR), WM.WM_SYSDEADCHAR);
    public static readonly WindowMessage WM_SYSKEYDOWN = new(nameof(WM_SYSKEYDOWN), WM.WM_SYSKEYDOWN);
    public static readonly WindowMessage WM_SYSKEYUP = new(nameof(WM_SYSKEYUP), WM.WM_SYSKEYUP);
    public static readonly WindowMessage WM_TABLET_FIRST = new(nameof(WM_TABLET_FIRST), WM.WM_TABLET_FIRST);
    public static readonly WindowMessage WM_TABLET_LAST = new(nameof(WM_TABLET_LAST), WM.WM_TABLET_LAST);
    public static readonly WindowMessage WM_TCARD = new(nameof(WM_TCARD), WM.WM_TCARD);
    public static readonly WindowMessage WM_THEMECHANGED = new(nameof(WM_THEMECHANGED), WM.WM_THEMECHANGED);
    public static readonly WindowMessage WM_TIMECHANGE = new(nameof(WM_TIMECHANGE), WM.WM_TIMECHANGE);
    public static readonly WindowMessage WM_TIMER = new(nameof(WM_TIMER), WM.WM_TIMER);
    public static readonly WindowMessage WM_TOUCH = new(nameof(WM_TOUCH), WM.WM_TOUCH);
    public static readonly WindowMessage WM_TOUCHHITTESTING = new(nameof(WM_TOUCHHITTESTING), WM.WM_TOUCHHITTESTING);
    public static readonly WindowMessage WM_UNDO = new(nameof(WM_UNDO), WM.WM_UNDO);
    public static readonly WindowMessage WM_UNICHAR = new(nameof(WM_UNICHAR), WM.WM_UNICHAR);
    public static readonly WindowMessage WM_UNINITMENUPOPUP = new(nameof(WM_UNINITMENUPOPUP), WM.WM_UNINITMENUPOPUP);
    public static readonly WindowMessage WM_UPDATEUISTATE = new(nameof(WM_UPDATEUISTATE), WM.WM_UPDATEUISTATE);
    public static readonly WindowMessage WM_USER = new(nameof(WM_USER), WM.WM_USER);
    public static readonly WindowMessage WM_USERCHANGED = new(nameof(WM_USERCHANGED), WM.WM_USERCHANGED);
    public static readonly WindowMessage WM_VKEYTOITEM = new(nameof(WM_VKEYTOITEM), WM.WM_VKEYTOITEM);
    public static readonly WindowMessage WM_VSCROLL = new(nameof(WM_VSCROLL), WM.WM_VSCROLL);
    public static readonly WindowMessage WM_VSCROLLCLIPBOARD = new(nameof(WM_VSCROLLCLIPBOARD), WM.WM_VSCROLLCLIPBOARD);
    public static readonly WindowMessage WM_WINDOWPOSCHANGED = new(nameof(WM_WINDOWPOSCHANGED), WM.WM_WINDOWPOSCHANGED);
    public static readonly WindowMessage WM_WINDOWPOSCHANGING = new(nameof(WM_WINDOWPOSCHANGING), WM.WM_WINDOWPOSCHANGING);
    public static readonly WindowMessage WM_WTSSESSION_CHANGE = new(nameof(WM_WTSSESSION_CHANGE), WM.WM_WTSSESSION_CHANGE);
    public static readonly WindowMessage WM_XBUTTONDBLCLK = new(nameof(WM_XBUTTONDBLCLK), WM.WM_XBUTTONDBLCLK);
    public static readonly WindowMessage WM_XBUTTONDOWN = new(nameof(WM_XBUTTONDOWN), WM.WM_XBUTTONDOWN);
    public static readonly WindowMessage WM_XBUTTONUP = new(nameof(WM_XBUTTONUP), WM.WM_XBUTTONUP);

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
        ThrowIfNull(value);

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
        _ = _windowMessageByValue.TryGetValue(unchecked((int)message), out var windowsMessage);

        return windowsMessage;
    }

    private sealed class WindowsMessageCollection : KeyedCollection<int, WindowMessage>
    {
        protected override int GetKeyForItem(WindowMessage item)
            => item.Value;
    }
}
