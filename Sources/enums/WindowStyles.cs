// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;

namespace WCL.Enums
{
		/// <summary>
		/// Constants for configuration the style of a window.
		/// See https://msdn.microsoft.com/en-us/library/windows/desktop/ms632600(v=vs.85).aspx for more details.
		/// </summary>
	[Flags]
	public enum WindowStyles : uint
	{
		Ws_border = 0x800000,
		Ws_caption = 0xc00000,
		Ws_child = 0x40000000,
		Ws_clipchildren = 0x2000000,
		Ws_clipsiblings = 0x4000000,
		Ws_disabled = 0x8000000,
		Ws_dlgframe = 0x400000,
		Ws_group = 0x20000,
		Ws_hscroll = 0x100000,
		Ws_maximize = 0x1000000,
		Ws_maximizebox = 0x10000,
		Ws_minimize = 0x20000000,
		Ws_minimizebox = 0x20000,
		Ws_overlapped = 0x0,
		Ws_overlappedwindow = Ws_overlapped | Ws_caption | Ws_sysmenu | Ws_thickframe | Ws_minimizebox | Ws_maximizebox,
		Ws_titledwindow = Ws_overlappedwindow,
		Ws_popup = 0x80000000u,
		Ws_popupwindow = Ws_popup | Ws_border | Ws_sysmenu,
		Ws_thickframe = 0x40000,
		Ws_sizebox = Ws_thickframe,
		Ws_sysmenu = 0x80000,
		Ws_tabstop = 0x10000,
		Ws_visible = 0x10000000,
		Ws_vscroll = 0x200000
	}
}
