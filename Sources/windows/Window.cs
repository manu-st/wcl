// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;
using WCL;
using WCL.Callbacks;
using WCL.Enums;
using WCL.Structs;

namespace WCL.Windows
{
	public abstract class Window
	{

// feature -- Access

		public Window parent
			// Parent of current window if any.
		{
			get { return _parent; }
		}

		public IntPtr item
			// Underlying HWND handle of current window.
		{
			get { return _item;}
		}

		public int x()
			// x coordinate of current window relative to its parent if any. Otherwise `absolute_x'.
		{
			Window l_parent = _parent;

			if (l_parent != null)
			{
				Point point = window_rect ().location;
				Win32.ScreenToClient (l_parent.item, ref point);
				return point.x;
			} else {
				return absolute_x ();
			}
		}

		public int absolute_x ()
			// Absolute x coordinate of current window.
		{
			return window_rect ().x;
		}

		public Rect window_rect ()
			// Dimension of current window as a Rect where `left' and `top' are zero.
		{
			Rect l_result;
			Win32.GetClientRect (_item, out l_result);
			return l_result;
		}

// feature -- Element change

		public void show ()
			// Show window.
		{
			Win32.ShowWindow (_item, ShowWindowCommands.Show);
		}

// feature -- Event loop

		public IntPtr window_procedure (IntPtr hwnd, WmConstants msg, IntPtr wparam, IntPtr lparam)
			// Routine called by Windows whenever a new message is received for the current window.
		{
			switch (msg) {
				case WmConstants.Wm_close:
						// Temporary handling to close the application as soon as we close a window.
					Win32.PostMessage (hwnd, WmConstants.Wm_quit, IntPtr.Zero, IntPtr.Zero);
					return IntPtr.Zero;

				default:
					return Win32.DefWindowProc (hwnd, msg, wparam, lparam);
			}
		}

// feature -- Internal properties

		public abstract string class_name ();
		public abstract ClassStyles class_style ();
		public abstract WndProc class_window_procedure ();
		public abstract WindowStyles default_style ();
		public abstract WindowStylesEx default_ex_style ();

// feature -- Implementation: Access

		protected Window _parent;
		protected IntPtr _item;

	}
}
