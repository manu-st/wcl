// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;
using System.Diagnostics.Contracts;
using WCL;
using WCL.Callbacks;
using WCL.Enums;
using WCL.Gdi;
using WCL.Structs;

namespace WCL.Windows
{
	public abstract class Window
	{
#region Access
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
#endregion

#region Status Report
		public bool exists ()
		{
			return _item != IntPtr.Zero;
		}
#endregion

#region Element change
		public void show ()
			// Show window.
		{
			Win32.ShowWindow (_item, ShowWindowCommands.Show);
		}
#endregion

#region Events
		public delegate void PointerButtonPressDelegate (Window win, int x, int y, int button);
		public delegate void ExposeDelegate (Window win, Dc a_dc, Rect a_rect);

		public event PointerButtonPressDelegate pointer_button_press_actions;
		public event ExposeDelegate expose_actions;
#endregion

#region Messaging
		public IntPtr window_procedure (IntPtr hwnd, WmConstants msg, IntPtr wparam, IntPtr lparam)
			// Routine called by Windows whenever a new message is received for the current window.
		{
			switch (msg) {
				case WmConstants.Wm_erasebkgnd:
					return IntPtr.Zero + 1;

				case WmConstants.Wm_paint:
					PaintDc l_dc = new PaintDc (this);
					l_dc.get ();
					expose_actions?.Invoke (this, l_dc, l_dc.paint_rect ());
					l_dc.release ();
					return IntPtr.Zero;

				case WmConstants.Wm_lbuttondown:
					pointer_button_press_actions?.Invoke (this, (short) lparam.ToInt64 (), (short) (lparam.ToInt64 () >> 16), 1);
					return IntPtr.Zero;

				case WmConstants.Wm_close:
						// Temporary handling to close the application as soon as we close a window.
					Win32.PostMessage (hwnd, WmConstants.Wm_quit, IntPtr.Zero, IntPtr.Zero);
					return IntPtr.Zero;

				default:
					return Win32.DefWindowProc (hwnd, msg, wparam, lparam);
			}
		}
#endregion

#region Drawing facilities

		public void invalidate ()
			// Invalidate client area of current window. Background will be cleared first.
		{
			Win32.InvalidateRect (item, IntPtr.Zero, true);
		}

#endregion

#region Window class properties
		public abstract string class_name ();
		public abstract ClassStyles class_style ();
		public abstract WndProc class_window_procedure ();
#endregion

#region Window default creation properties
		public abstract WindowStyles default_style ();
		public abstract WindowStylesEx default_ex_style ();
#endregion

#region Implementation: Access
		protected Window _parent;
		protected IntPtr _item;
#endregion
	}
}
