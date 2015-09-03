﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCL.Enums
{
	public enum WmConstants : uint
	{
		Wm_null = 0,
		Wm_create = 1,
		Wm_destroy = 2,
		Wm_move = 3,
		Wm_size = 5,
		Wm_activate = 6,
		Wm_setfocus = 7,
		Wm_killfocus = 8,
		Wm_enable = 10,
		Wm_setredraw = 11,
		Wm_settext = 12,
		Wm_gettext = 13,
		Wm_gettextlength = 14,
		Wm_paint = 15,
		Wm_close = 16,
		Wm_queryendsession = 17,
		Wm_quit = 18,
		Wm_queryopen = 19,
		Wm_erasebkgnd = 20,
		Wm_syscolorchange = 21,
		Wm_endsession = 22,
		Wm_showwindow = 24,
		Wm_wininichange, Wm_settingchange = 26,
		Wm_devmodechange = 27,
		Wm_activateapp = 28,
		Wm_fontchange = 29,
		Wm_timechange = 30,
		Wm_cancelmode = 31,
		Wm_setcursor = 32,
		Wm_mouseactivate = 33,
		Wm_childactivate = 34,
		Wm_queuesync = 35,
		Wm_getminmaxinfo = 36,
		Wm_painticon = 38,
		Wm_iconerasebkgnd = 39,
		Wm_nextdlgctl = 40,
		Wm_spoolerstatus = 42,
		Wm_drawitem = 43,
		Wm_measureitem = 44,
		Wm_deleteitem = 45,
		Wm_vkeytoitem = 46,
		Wm_chartoitem = 47,
		Wm_setfont = 48,
		Wm_getfont = 49,
		Wm_sethotkey = 50,
		Wm_gethotkey = 51,
		Wm_querydragicon = 55,
		Wm_compareitem = 57,
		Wm_getobject = 61,
		Wm_compacting = 65,
		Wm_commnotify = 68,
		Wm_windowposchanging = 70,
		Wm_windowposchanged = 71,
		Wm_power = 72,
		Wm_copydata = 74,
		Wm_canceljournal = 75,
		Wm_notify = 78,
		Wm_inputlangchangerequest = 80,
		Wm_inputlangchange = 81,
		Wm_tcard = 82,
		Wm_help = 83,
		Wm_userchanged = 84,
		Wm_notifyformat = 85,
		Wm_contextmenu = 123,
		Wm_stylechanging = 124,
		Wm_stylechanged = 125,
		Wm_displaychange = 126,
		Wm_geticon = 127,
		Wm_seticon = 128,
		Wm_nccreate = 129,
		Wm_ncdestroy = 130,
		Wm_nccalcsize = 131,
		Wm_nchittest = 132,
		Wm_ncpaint = 133,
		Wm_ncactivate = 134,
		Wm_getdlgcode = 135,
		Wm_syncpaint = 136,
		Wm_ncmousemove = 160,
		Wm_nclbuttondown = 161,
		Wm_nclbuttonup = 162,
		Wm_nclbuttondblclk = 163,
		Wm_ncrbuttondown = 164,
		Wm_ncrbuttonup = 165,
		Wm_ncrbuttondblclk = 166,
		Wm_ncmbuttondown = 167,
		Wm_ncmbuttonup = 168,
		Wm_ncmbuttondblclk = 169,
		Wm_ncxbuttondown = 171,
		Wm_ncxbuttonup = 172,
		Wm_ncxbuttondblclk = 173,
		Wm_keydown = 256,
		Wm_keyfirst = 256,
		Wm_keyup = 257,
		Wm_char = 258,
		Wm_deadchar = 259,
		Wm_syskeydown = 260,
		Wm_syskeyup = 261,
		Wm_syschar = 262,
		Wm_sysdeadchar = 263,
		Wm_keylast = 265,
		Wm_ime_startcomposition = 269,
		Wm_ime_endcomposition = 270,
		Wm_ime_composition = 271,
		Wm_ime_keylast = 271,
		Wm_initdialog = 272,
		Wm_command = 273,
		Wm_syscommand = 274,
		Wm_timer = 275,
		Wm_hscroll = 276,
		Wm_vscroll = 277,
		Wm_initmenu = 278,
		Wm_initmenupopup = 279,
		Wm_menuselect = 287,
		Wm_menuchar = 288,
		Wm_enteridle = 289,
		Wm_menurbuttonup = 290,
		Wm_menudrag = 291,
		Wm_menugetobject = 292,
		Wm_uninitmenupopup = 293,
		Wm_menucommand = 294,
		Wm_changeuistate = 295,
		Wm_updateuistate = 296,
		Wm_queryuistate = 297,
		Wm_ctlcolor = 25,
		Wm_ctlcolormsgbox = 306,
		Wm_ctlcoloredit = 307,
		Wm_ctlcolorlistbox = 308,
		Wm_ctlcolorbtn = 309,
		Wm_ctlcolordlg = 310,
		Wm_ctlcolorscrollbar = 311,
		Wm_ctlcolorstatic = 312,
		Wm_mousemove = 512,
		Wm_mousefirst = 512,
		Wm_lbuttondown = 513,
		Wm_lbuttonup = 514,
		Wm_lbuttondblclk = 515,
		Wm_rbuttondown = 516,
		Wm_rbuttonup = 517,
		Wm_rbuttondblclk = 518,
		Wm_mbuttondown = 519,
		Wm_mbuttonup = 520,
		Wm_mbuttondblclk = 521,
		Wm_mousewheel = 522,
		Wm_xbuttondown = 523,
		Wm_xbuttonup = 524,
		Wm_xbuttondblclk = 525,
		Wm_mouselast = 525,
		Wm_parentnotify = 528,
		Wm_entermenuloop = 529,
		Wm_exitmenuloop = 530,
		Wm_nextmenu = 531,
		Wm_sizing = 532,
		Wm_capturechanged = 533,
		Wm_moving = 534,
		Wm_powerbroadcast = 536,
		Wm_devicechange = 537,
		Wm_mdicreate = 544,
		Wm_mdidestroy = 545,
		Wm_mdiactivate = 546,
		Wm_mdirestore = 547,
		Wm_mdinext = 548,
		Wm_mdimaximize = 549,
		Wm_mditile = 550,
		Wm_mdicascade = 551,
		Wm_mdiiconarrange = 552,
		Wm_mdigetactive = 553,
		Wm_mdisetmenu = 560,
		Wm_entersizemove = 561,
		Wm_exitsizemove = 562,
		Wm_dropfiles = 563,
		Wm_mdirefreshmenu = 564,
		Wm_ime_setcontext = 641,
		Wm_ime_notify = 642,
		Wm_ime_control = 643,
		Wm_ime_compositionfull = 644,
		Wm_ime_select = 645,
		Wm_ime_char = 646,
		Wm_ime_request = 648,
		Wm_ime_keydown = 656,
		Wm_ime_keyup = 657,
		Wm_ncmousehover = 672,
		Wm_mousehover = 673,
		Wm_ncmouseleave = 674,
		Wm_mouseleave = 675,
		Wm_cut = 768,
		Wm_copy = 769,
		Wm_paste = 770,
		Wm_clear = 771,
		Wm_undo = 772,
		Wm_renderformat = 773,
		Wm_renderallformats = 774,
		Wm_destroyclipboard = 775,
		Wm_drawclipboard = 776,
		Wm_paintclipboard = 777,
		Wm_sizeclipboard = 779,
		Wm_vscrollclipboard = 778,
		Wm_hscrollclipboard = 782,
		Wm_askcbformatname = 780,
		Wm_changecbchain = 781,
		Wm_querynewpalette = 783,
		Wm_paletteischanging = 784,
		Wm_palettechanged = 785,
		Wm_hotkey = 786,
		Wm_print = 791,
		Wm_printclient = 792,
		Wm_appcommand = 793,
		Wm_handheldfirst = 856,
		Wm_handheldlast = 863,
		Wm_afxfirst = 864,
		Wm_afxlast = 895,
		Wm_forwardmsg = 895,
		Wm_penwinfirst = 896,
		Wm_penwinlast = 911,
		Wm_user = 1024,
		Wm_app = 32768,

	}
}
