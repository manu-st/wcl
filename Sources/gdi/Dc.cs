using System;
using WCL.Structs;

namespace WCL.Gdi
{
	public abstract class Dc
	{

#region Basic operations
		public abstract void Get ();
			// Get the device context.

		public abstract void Release ();
		// Release the device context.
		#endregion


#region Drawing operations

		public void DrawText(string s, int x, int y)
		{
			Win32.TextOut(_handle, x, y, s, s.Length);
		}

		public void DrawRectangle (int left, int top, int right, int bottom)
		{
			Win32.Rectangle (_handle, left, top, right, bottom);
		}

		public void DrawRectangle (Rect r)
		{
			DrawRectangle (r.Left, r.Top, r.Right, r.Bottom);
		}


#endregion

#region Implementation: Access

		protected IntPtr _handle;

#endregion
	}
}
