// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;
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
		public Window Parent
			// Parent of current window if any.
		{
			get { return _parent; }
		}

		public IntPtr Handle
			// Underlying HWND handle of current window.
		{
			get { return _handle;}
		}

		public int X
			// x coordinate of current window relative to its parent if any. Otherwise `absolute_x'.
		{
			get
			{
				Window l_parent = _parent;

				if (l_parent != null) {
					Point point = ClientRect.Location;
					Win32.ScreenToClient (l_parent.Handle, ref point);
					return point.X;
				} else {
					return ScreenX;
				}
			}
		}

		public int Y
			// y coordinate of current window relative to its parent if any. Otherwise `absolute_y'.
		{
			get
			{
				Window l_parent = _parent;

				if (l_parent != null) {
					Point point = ClientRect.Location;
					Win32.ScreenToClient (l_parent.Handle, ref point);
					return point.Y;
				} else {
					return ScreenY;
				}
			}
		}

		public int Width
			// Width of current window.
		{
			get { return ClientRect.Width; }
		}
		public int Height
			// Height of current window.
		{
			get { return ClientRect.Height; }
		}

		public int ScreenX
			// Absolute x coordinate of current window.
		{
			get { return ClientRect.X; }
		}

		public int ScreenY
			// Absolute y coordinate of current window.
		{
			get { return ClientRect.Y; }
		}

		public Rect ClientRect
			// Dimension of current window as a Rect where `left' and `top' are zero.
		{
			get
			{
				Rect l_result;
				Win32.GetClientRect (_handle, out l_result);
				return l_result;
			}
		}

		public Size ClientSize
		{
			get { return ClientRect.Size; }
		}
#endregion

#region Status Report
		public bool Exists ()
		{
			return _handle != IntPtr.Zero;
		}
#endregion

#region Element change
		public void Show ()
			// Show window.
		{
			Win32.ShowWindow (_handle, ShowWindowCommands.Show);
			Win32.UpdateWindow (_handle);
		}

		public void Destroy ()
			// Destroy window
		{
			Contract.Requires (Exists (), "Window exists.");

			Win32.DestroyWindow (_handle);
			_handle = IntPtr.Zero;

			Contract.Ensures (!Exists (), "Window destroyed.");
		}

		public void SetWidth(int v)
			// Set `width' with `v'.
		{
			Win32.SetWindowPos (_handle, IntPtr.Zero, -1, -1, v, Height, SetWindowPosFlags.Swp_nomove);
		}

		public void SetHeight (int v)
			// Set `height' with `v'.
		{
			Win32.SetWindowPos (_handle, IntPtr.Zero, -1, -1, Width, v, SetWindowPosFlags.Swp_nomove);
		}
#endregion

#region Events
		public delegate void PointerButtonPressDelegate (Window win, int x, int y, int button);
		public delegate void ExposeDelegate (Window win, Dc a_dc, Rect a_rect);
		public delegate void KeyDelegate (Window win, int a_vk, int a_key_flags);
		public delegate void CharDelegate (Window win, char a_char, int a_key_flags);
		public delegate void NotificationDelegate (Window win);

		public event PointerButtonPressDelegate PointerButtonPressActions;
		public event ExposeDelegate ExposeActions;
		public event KeyDelegate KeyDownActions;
		public event KeyDelegate KeyUpActions;
		public event CharDelegate CharActions;
		public event NotificationDelegate CloseActions;
#endregion

#region Messaging
		public IntPtr WindowProcedure (IntPtr hwnd, WmConstants msg, IntPtr wparam, IntPtr lparam)
			// Routine called by Windows whenever a new message is received for the current window.
		{
			switch (msg) {
				case WmConstants.Wm_erasebkgnd:
					return IntPtr.Zero + 1;

				case WmConstants.Wm_paint:
					PaintDc l_dc = new PaintDc (this);
					l_dc.Get ();
					ExposeActions?.Invoke (this, l_dc, l_dc.PaintRect ());
					l_dc.Release ();
					return IntPtr.Zero;

				case WmConstants.Wm_lbuttondown:
					PointerButtonPressActions?.Invoke (this, (short) lparam.ToInt64 (), (short) (lparam.ToInt64 () >> 16), 1);
					return IntPtr.Zero;

				case WmConstants.Wm_keydown:
					KeyDownActions?.Invoke (this, (int) wparam.ToInt64(), (int) lparam.ToInt64());
					return IntPtr.Zero;

				case WmConstants.Wm_keyup:
					KeyUpActions?.Invoke (this, (int) wparam.ToInt64(), (int) lparam.ToInt64());
					return IntPtr.Zero;

				case WmConstants.Wm_char:
					CharActions?.Invoke (this, (char) wparam.ToInt64(), (int) lparam.ToInt64());
					return IntPtr.Zero;

				case WmConstants.Wm_close:
						// Temporary handling to close the application as soon as we close a window.
					CloseActions?.Invoke (this);
					return IntPtr.Zero;

				default:
					return Win32.DefWindowProc (hwnd, msg, wparam, lparam);
			}
		}
#endregion

#region Drawing facilities

		public void Invalidate ()
			// Invalidate client area of current window. Background will be cleared first.
		{
			Win32.InvalidateRect (Handle, IntPtr.Zero, true);
		}

#endregion

#region Window class properties
		public abstract string ClassName { get; }
		public abstract ClassStyles ClassStyle { get; }
		public abstract WndProc ClassWindowProcedure { get; }
#endregion

#region Window default creation properties
		public abstract WindowStyles DefaultStyle { get; }
		public abstract WindowStylesEx DefaultExStyle { get; }
#endregion

#region Implementation: Access
		protected Window _parent;
		protected IntPtr _handle;
#endregion
	}
}
