using System;
using WCL;
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
		{
			Win32.ShowWindow (_item, ShowWindowCommands.Show);
		}

// feature -- Implementation: Access

		private Window _parent;
		private IntPtr _item;
	}
}
