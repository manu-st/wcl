using System;
using System.Diagnostics.Contracts;
using WCL.Structs;
using WCL.Windows;

namespace WCL.Gdi
{
	public class PaintDc : Dc
	{
#region Initialization
		public PaintDc (Window a_window)
		{
			Contract.Requires (a_window != null, "Window not null");
			Contract.Requires (a_window.Exists (), "Window exists");

			_window = a_window;
			_handle = IntPtr.Zero;

			Contract.Ensures (_window == a_window, "window set");
			Contract.Ensures (_handle == IntPtr.Zero, "handle set");
		}
#endregion

#region Access
		public PaintStruct PaintStruct
		{
			get { return _paint_struct; }
		}

		public Rect PaintRect ()
		{
			return _paint_struct.rcPaint;
		}
#endregion

#region Basic operations
		public override void Get ()
		{
			_handle = Win32.BeginPaint(_window.Handle, out _paint_struct);
		}

		public override void Release ()
		{
			Win32.EndPaint(_window.Handle, ref _paint_struct);
		}
#endregion

#region Implementation: Access
		protected PaintStruct _paint_struct;
		protected Window _window;
#endregion

	}
}
