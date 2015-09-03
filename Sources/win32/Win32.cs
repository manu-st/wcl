using System;
using WCL.Structs;
using WCL.enums;
using System.Runtime.InteropServices;

namespace WCL
{
	public static class Win32
	{

// feature -- Window

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShowWindow (IntPtr hWnd, ShowWindowCommands nCmdShow);

// feature -- Rect API

		[DllImport("user32.dll")]
		public static extern bool ScreenToClient (IntPtr hWnd, ref Point lpPoint);

		[DllImport("user32.dll")]
		public static extern bool ClientToScreen (IntPtr hWnd, ref Point lpPoint);

		[DllImport("user32.dll")]
		public static extern bool GetClientRect (IntPtr hWnd, out Rect lpRect);


	}
}
