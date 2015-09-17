// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;

namespace WCL.Enums
{
		/// <summary>
		/// Constants for configuring the extended style of a window.
		/// See https://msdn.microsoft.com/en-us/library/windows/desktop/ff700543(v=vs.85).aspx for more details.
		/// </summary>
	[Flags]
	public enum WindowStylesEx : uint
	{
		Ws_ex_acceptfiles = 0x00000010,
		Ws_ex_appwindow = 0x00040000,
		Ws_ex_clientedge = 0x00000200,
		Ws_ex_composited = 0x02000000,
		Ws_ex_contexthelp = 0x00000400,
		Ws_ex_controlparent = 0x00010000,
		Ws_ex_dlgmodalframe = 0x00000001,
		Ws_ex_layered = 0x00080000,
		Ws_ex_layoutrtl = 0x00400000,
		Ws_ex_left = 0x00000000,
		Ws_ex_leftscrollbar = 0x00004000,
		Ws_ex_ltrreading = 0x00000000,
		Ws_ex_mdichild = 0x00000040,
		Ws_ex_noactivate = 0x08000000,
		Ws_ex_noinheritlayout = 0x00100000,
		Ws_ex_noparentnotify = 0x00000004,
		Ws_ex_overlappedwindow = Ws_ex_windowedge | Ws_ex_clientedge,
		Ws_ex_palettewindow = Ws_ex_windowedge | Ws_ex_toolwindow | Ws_ex_topmost,
		Ws_ex_right = 0x00001000,
		Ws_ex_rightscrollbar = 0x00000000,
		Ws_ex_rtlreading = 0x00002000,
		Ws_ex_staticedge = 0x00020000,
		Ws_ex_toolwindow = 0x00000080,
		Ws_ex_topmost = 0x00000008,
		Ws_ex_transparent = 0x00000020,
		Ws_ex_windowedge = 0x00000100
	}
}
