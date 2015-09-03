using System;
using System.Runtime.InteropServices;
using WCL.Callbacks;
using WCL.Enums;

namespace WCL.Structs
{
	[StructLayout (LayoutKind.Sequential)]
	public struct WndClass
	{
		public ClassStyles style;
		[MarshalAs (UnmanagedType.FunctionPtr)]
		public WndProc lpfnWndProc;
		public int cbClsExtra;
		public int cbWndExtra;
		public IntPtr hInstance;
		public IntPtr hIcon;
		public IntPtr hCursor;
		public IntPtr hbrBackground;
		[MarshalAs (UnmanagedType.LPTStr)]
		public string lpszMenuName;
		[MarshalAs (UnmanagedType.LPTStr)]
		public string lpszClassName;

		public WndClass (string v) : this ()
		{
			style = 0;
			lpfnWndProc = null;
			cbClsExtra = 0;
			cbWndExtra = 0;
			hInstance = Win32.GetModuleHandle (null);
			hIcon = IntPtr.Zero;
			hCursor = IntPtr.Zero;
			hbrBackground = IntPtr.Zero;
			lpszMenuName = null;
			lpszClassName = v;
		}

		public void register ()
		{
			Win32.RegisterClass (ref this);
		}

		public void unregister ()
		{
		}

		public bool is_registered ()
		{
			WndClass l_class;
			return Win32.GetClassInfo (IntPtr.Zero, lpszClassName, out l_class) ||
				Win32.GetClassInfo (hInstance, lpszClassName, out l_class);
		}
	}
}
