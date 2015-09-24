// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;
using System.Diagnostics.Contracts;
using WCL.Callbacks;
using WCL.Enums;
using WCL.Structs;

namespace WCL.Windows
{
	public class TitledWindow : Window
	{
#region Initialization
		public TitledWindow (string a_title)
		{
			RegisterClass ();
			_handle = Win32.CreateWindowEx (DefaultExStyle (), ClassName (), a_title, DefaultStyle (), Win32.Cw_usedefault,
				Win32.Cw_usedefault, Win32.Cw_usedefault, Win32.Cw_usedefault, IntPtr.Zero,
				IntPtr.Zero, Win32.GetModuleHandle (null), IntPtr.Zero);
			if (_handle == IntPtr.Zero) {
				throw new Exception("Cannot create a new window!");
			}
		}
#endregion


#region Internal Properties
		private WndClass wnd_class;

		private void RegisterClass ()
		{
			WndClass l_class = new WndClass (ClassName ());
			if (!l_class.IsRegistered ()) {
				l_class.Style = ClassStyle ();
				l_class.WindowProcedure = ClassWindowProcedure ();
						// For the time being, users cannot change the icon, cursor and brush for the class.
				l_class.Cursor = Win32.LoadCursor (IntPtr.Zero, (int) IdcStandardCursors.Idc_arrow);
				l_class.Icon = Win32.LoadIcon (IntPtr.Zero, new IntPtr ((int) SystemIcons.Idi_application));
				l_class.BackgroundBrush = Win32.GetStockObject (StockObjects.Gray_brush);
				l_class.Register ();
			}
			wnd_class = l_class;

			Contract.Ensures (l_class.IsRegistered (), "class is registered");
		}
#endregion

#region Window class properties
		public override string ClassName ()
		{
			return "WCL_TITLED_WINDOW";
		}

		public override ClassStyles ClassStyle ()
		{
			return ClassStyles.DoubleClicks;
		}

		public override WndProc ClassWindowProcedure ()
		{
			return new WndProc(WindowProcedure);
		}
#endregion

#region Window default creation properties
		public override WindowStyles DefaultStyle ()
		{
			return WindowStyles.Ws_titledwindow | WindowStyles.Ws_dlgframe | WindowStyles.Ws_clipsiblings | WindowStyles.Ws_border;
		}

		public override WindowStylesEx DefaultExStyle ()
		{
			return WindowStylesEx.Ws_ex_controlparent;
		}
#endregion
	}
}
