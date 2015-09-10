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

		[DllImport("kernel32.dll")]
		public static extern uint GetLastError();

		[DllImport ("kernel32.dll", EntryPoint = "RtlFillMemory", SetLastError = false)]
		public static extern void FillMemory (IntPtr destination, uint length, byte fill);

		// feature -- Window

		[DllImport ("user32.dll", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, EntryPoint = "CreateWindowExW")]
		public static extern IntPtr CreateWindowEx(WindowStylesEx dwExStyle, string lpClassName, string lpWindowName, WindowStyles dwStyle,
			int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

		[DllImport ("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs (UnmanagedType.Bool)]
		public static extern bool DestroyWindow (IntPtr hwnd);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShowWindow (IntPtr hWnd, ShowWindowCommands nCmdShow);

		[DllImport("user32.dll", CharSet = CharSet.Unicode, ExactSpelling = true, EntryPoint = "GetClassInfoW")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public unsafe static extern bool GetClassInfo(IntPtr hInstance, IntPtr lpClassName, _WndClass *lpWndClass);

		[DllImport("user32.dll", CharSet = CharSet.Unicode, ExactSpelling = true, EntryPoint = "RegisterClassW")]
		public static extern ushort RegisterClass(IntPtr lpWndClass);

		[DllImport ("user32.dll", CharSet = CharSet.Unicode, ExactSpelling = true, EntryPoint = "UnregisterClassW")]
		public static extern bool UnregisterClassW (IntPtr lpClassName, IntPtr hInstance);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool UnregisterClass([MarshalAs (UnmanagedType.LPWStr)] string lpClassName, IntPtr hInstance);

// feature -- Rect API

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ScreenToClient (IntPtr hWnd, ref Point lpPoint);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ClientToScreen (IntPtr hWnd, ref Point lpPoint);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetClientRect (IntPtr hWnd, out Rect lpRect);

// feature -- Messaging

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

// feature -- Process

		[DllImport("kernel32.dll", CharSet=CharSet.Unicode)]
		public static extern IntPtr GetModuleHandle([MarshalAs(UnmanagedType.LPWStr)] string lpModuleName);

// feature -- Images

		[DllImport("user32.dll")]
		public static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);


	}
}
