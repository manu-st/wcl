using System;
using System.Runtime.Serialization;
using System.Diagnostics.Contracts;
using WCL.Structs;
using WCL.Windows;

namespace WCL.Gdi
{
	public abstract class Dc
	{

#region Basic operations
		public abstract void get ();
			// Get the device context.

		public abstract void release ();
		// Release the device context.
		#endregion


#region Drawing operations

		public void draw_text(string s, int x, int y)
		{
			Win32.TextOut(_item, x, y, s, s.Length);
		}

		public void draw_rectangle (int left, int top, int right, int bottom)
		{
			Win32.Rectangle (_item, left, top, right, bottom);
		}

		public void draw_rectangle (Rect r)
		{
			draw_rectangle (r.left, r.top, r.right, r.bottom);
		}


#endregion

#region Implementation: Access

		protected IntPtr _item;

#endregion
	}
}
