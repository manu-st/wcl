using System;
using WCL;
using WCL.Callbacks;
using WCL.Enums;
using WCL.Structs;
using WCL.Windows;

namespace WCL.Windows
{
	class TitledWindow : Window
	{
		public TitledWindow (string a_title)
		{
			register_class ();
			Win32.CreateWindowEx (default_ex_style (), class_name (), a_title, default_style (), 0, 0, 0, 0, IntPtr.Zero,
				IntPtr.Zero, Win32.GetModuleHandle (null), IntPtr.Zero);
		}

// feature -- Internal properties

		private WndClass wnd_class;

		private void register_class ()
		{
			WndClass l_class = new WndClass (class_name ());
			if (!l_class.is_registered ()) {
				l_class.style = class_style ();
				l_class.lpfnWndProc = class_window_procedure ();
				// Check if we want to set the icon, the background brush, the menu name too.
				l_class.register ();
			}
			wnd_class = l_class;
		}

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
			return null;
		}

		public override WindowStyles default_style ()
		{
			return WindowStyles.WS_TITLEDWINDOW | WindowStyles.WS_DLGFRAME | WindowStyles.WS_CLIPSIBLINGS | WindowStyles.WS_BORDER;
		}

		public override WindowStylesEx default_ex_style ()
		{
			return WindowStylesEx.WS_EX_CONTROLPARENT;
		}
	}
}
