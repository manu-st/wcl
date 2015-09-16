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
			Contract.Requires (a_window.exists (), "Window exists");

			window = a_window;
			_item = IntPtr.Zero;

			Contract.Ensures (window == a_window, "window set");
			Contract.Ensures (_item == IntPtr.Zero, "item set");
		}
#endregion

#region Access
		public PaintStruct paint_struct
		{
			get { return _paint_struct; }
		}

		public Rect paint_rect ()
		{
			return _paint_struct.rcPaint;
		}
#endregion

#region Basic operations
		public override void get ()
		{
			_item = Win32.BeginPaint(window.item, out _paint_struct);
		}

		public override void release ()
		{
			Win32.EndPaint(window.item, ref _paint_struct);
		}
#endregion

#region Implementation: Access
		protected PaintStruct _paint_struct;
		protected Window window;
#endregion

	}
}
