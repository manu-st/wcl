// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;
using WCL.Structs;
using WCL.Enums;
using System.Runtime.InteropServices;

namespace WCL
{
		/// <summary>
		/// All the Win32 API that we need to wrap. 
		/// We are using as a basis the signatures provided by http://www.pinvoke.net.
		/// </summary>
	public static class Win32
	{
#region
		public static int Cw_usedefault = unchecked ((int) 0x80000000);
#endregion

#region Miscellaneous
		[DllImport("kernel32.dll")]
		public static extern uint GetLastError();

		[DllImport ("kernel32.dll", EntryPoint = "RtlFillMemory", SetLastError = false)]
		public static extern void FillMemory (IntPtr destination, uint length, byte fill);
#endregion

#region Windows
		[DllImport ("user32.dll", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, EntryPoint = "CreateWindowExW")]
		public static extern IntPtr CreateWindowEx(WindowStylesEx dwExStyle, string lpClassName, string lpWindowName, WindowStyles dwStyle,
			int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

		[DllImport ("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs (UnmanagedType.Bool)]
		public static extern bool DestroyWindow (IntPtr hwnd);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShowWindow (IntPtr hWnd, ShowWindowCommands nCmdShow);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UpdateWindow(IntPtr hWnd);

		[DllImport("user32.dll", CharSet = CharSet.Unicode, ExactSpelling = true, EntryPoint = "GetClassInfoW")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public unsafe static extern bool GetClassInfo(IntPtr hInstance, IntPtr lpClassName, _WndClass *lpWndClass);

		[DllImport("user32.dll", CharSet = CharSet.Unicode, ExactSpelling = true, EntryPoint = "RegisterClassW")]
		public static extern ushort RegisterClass(IntPtr lpWndClass);

		[DllImport ("user32.dll", CharSet = CharSet.Unicode, ExactSpelling = true, EntryPoint = "UnregisterClassW")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UnregisterClass (IntPtr lpClassName, IntPtr hInstance);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ScreenToClient (IntPtr hWnd, ref Point lpPoint);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ClientToScreen (IntPtr hWnd, ref Point lpPoint);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetClientRect (IntPtr hWnd, out Rect lpRect);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool GetWindowRect(IntPtr hwnd, out Rect lpRect);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, SetWindowPosFlags uFlags);

#endregion

#region Drawing
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

		[DllImport("gdi32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool Rectangle(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

		[DllImport("user32.dll")]
		public static extern IntPtr BeginPaint(IntPtr hwnd, out PaintStruct lpPaint);

		[DllImport("user32.dll")]
		public static extern bool EndPaint(IntPtr hWnd, [In] ref PaintStruct lpPaint);

		[DllImport("gdi32.dll", CharSet = CharSet.Unicode, ExactSpelling = true, EntryPoint = "TextOutW")]
		public static extern bool TextOut(IntPtr hdc, int nXStart, int nYStart, string lpString, int cbString);
#endregion

#region Messaging
		[DllImport ("user32.dll", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, EntryPoint = "DefWindowProcW")]
		public static extern IntPtr DefWindowProc(IntPtr hWnd, WmConstants msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", CharSet = CharSet.Unicode, ExactSpelling = true, EntryPoint = "PeekMessageW")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PeekMessage(out Msg lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax, PeekMessageConstants wRemoveMsg);

		[DllImport ("user32.dll", SetLastError = true, ExactSpelling = true, EntryPoint = "PostMessageW")]
		[return: MarshalAs (UnmanagedType.Bool)]
		public static extern bool PostMessage (IntPtr hWnd, WmConstants msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WaitMessage();

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool TranslateMessage([In] ref Msg lpMsg);

		[DllImport("user32.dll")]
		public static extern IntPtr DispatchMessage([In] ref Msg lpmsg);
#endregion

#region Process
		[DllImport("kernel32.dll", CharSet=CharSet.Unicode)]
		public static extern IntPtr GetModuleHandle([MarshalAs(UnmanagedType.LPWStr)] string lpModuleName);
#endregion

#region GDI
		[DllImport("user32.dll")]
		public static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

		[DllImport("user32.dll")]
		public static extern IntPtr LoadIcon(IntPtr hInstance, IntPtr lpIconName);

		[DllImport("gdi32.dll")]
		public static extern IntPtr GetStockObject(StockObjects fnObject);

#endregion

	}
}
