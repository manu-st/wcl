using System;
using WCL.Structs;
using WCL.Enums;
using System.Runtime.InteropServices;

namespace WCL
{
	public static class Win32
	{

// feature -- Window

		[DllImport("user32.dll", SetLastError=true)]
		public static extern IntPtr CreateWindowEx(WindowStylesEx dwExStyle, string lpClassName, string lpWindowName, WindowStyles dwStyle,
			int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShowWindow (IntPtr hWnd, ShowWindowCommands nCmdShow);

		[DllImport("user32.dll")]
		public static extern bool GetClassInfo(IntPtr hInstance, string lpClassName, out WndClass lpWndClass);

		[DllImport("user32.dll")]
		public static extern ushort RegisterClass([In] ref WndClass lpWndClass);

		[DllImport("user32.dll")]
		static extern bool UnregisterClass(string lpClassName, IntPtr hInstance);

// feature -- Rect API

		[DllImport("user32.dll")]
		public static extern bool ScreenToClient (IntPtr hWnd, ref Point lpPoint);

		[DllImport("user32.dll")]
		public static extern bool ClientToScreen (IntPtr hWnd, ref Point lpPoint);

		[DllImport("user32.dll")]
		public static extern bool GetClientRect (IntPtr hWnd, out Rect lpRect);

// feature -- Messaging

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PeekMessage(out Msg lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax, PeekMessageConstants wRemoveMsg);

		[DllImport("user32.dll")]
		public static extern bool WaitMessage();

		[DllImport("user32.dll")]
		public static extern bool TranslateMessage([In] ref Msg lpMsg);

		[DllImport("user32.dll")]
		public static extern IntPtr DispatchMessage([In] ref Msg lpmsg);

// feature -- Process

		[DllImport("kernel32.dll", CharSet=CharSet.Unicode)]
		public static extern IntPtr GetModuleHandle(string lpModuleName);

	}
}
