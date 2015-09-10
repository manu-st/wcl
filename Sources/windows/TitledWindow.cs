// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;
using System.Diagnostics.Contracts;
using WCL.Callbacks;
using WCL.Enums;
using WCL.Structs;

namespace WCL.Windows
{
	class TitledWindow : Window
	{
#region Initialization
		public TitledWindow (string a_title)
		{
			register_class ();
			_item = Win32.CreateWindowEx (default_ex_style (), class_name (), a_title, default_style (), -1, -1, -1, -1, IntPtr.Zero,
				IntPtr.Zero, Win32.GetModuleHandle (null), IntPtr.Zero);
			if (_item == IntPtr.Zero) {
				throw new Exception("Cannot create a new window!");
			}
		}
#endregion

#region Internal Properties
		private WndClass wnd_class;

		private void register_class ()
		{
			WndClass l_class = new WndClass (class_name ());
			if (!l_class.is_registered ()) {
				l_class.style = class_style ();
				l_class.window_procedure = class_window_procedure ();
				l_class.cursor = Win32.LoadCursor (IntPtr.Zero, (int) IdcStandardCursors.Idc_arrow);
				l_class.register ();
			}
			wnd_class = l_class;

			Contract.Ensures (l_class.is_registered (), "class is registered");
		}
#endregion

#region Window class properties
		public override string class_name ()
		{
			return "WCL_TITLED_WINDOW";
		}

		public override ClassStyles class_style ()
		{
			return ClassStyles.DoubleClicks;
		}

		public override WndProc class_window_procedure ()
		{
			return new WndProc(window_procedure);
		}
#endregion

#region Window default creation properties
		public override WindowStyles default_style ()
		{
			return WindowStyles.WS_TITLEDWINDOW | WindowStyles.WS_DLGFRAME | WindowStyles.WS_CLIPSIBLINGS | WindowStyles.WS_BORDER;
		}

		public override WindowStylesEx default_ex_style ()
		{
			return WindowStylesEx.WS_EX_CONTROLPARENT;
		}
#endregion
	}
}
