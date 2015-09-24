// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;

namespace WCL.Enums
{
		/// <summary>
		/// Constants used to control how a window is positionned.
		/// See https://msdn.microsoft.com/en-us/library/windows/desktop/ms633545(v=vs.85).aspx for more details.
		/// </summary>
	[Flags()]
	public enum SetWindowPosFlags : uint
	{
		Swp_asyncwindowpos = 0x4000,
		Swp_defererase = 0x2000,
		Swp_drawframe = 0x0020,
		Swp_framechanged = 0x0020,
		Swp_hidewindow = 0x0080,
		Swp_noactivate = 0x0010,
		Swp_nocopybits = 0x0100,
		Swp_nomove = 0x0002,
		Swp_noownerzorder = 0x0200,
		Swp_noredraw = 0x0008,
		Swp_noreposition = 0x0200,
		Swp_nosendchanging = 0x0400,
		Swp_nosize = 0x0001,
		Swp_nozorder = 0x0004,
		Swp_showwindow = 0x0040,
	}

		/// <summary>
		/// Constants used to control how a window is positionned.
		/// See https://msdn.microsoft.com/en-us/library/windows/desktop/ms633545(v=vs.85).aspx for more details.
		/// </summary>
	public static class HWND
	{  
		public static IntPtr
			Hwnd_notopmost = new IntPtr(-2),
			Hwnd_topmost = new IntPtr(-1),
			Hwnd_top = new IntPtr(0),
			Hwnd_bottom = new IntPtr(1);
	}
}
