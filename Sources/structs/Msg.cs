using System;
using System.Runtime.InteropServices;
using WCL.Structs;
using WCL.Enums;

namespace WCL.Structs
{
	[StructLayout (LayoutKind.Sequential)]
	public struct Msg
	{
		public IntPtr hwnd;
		public WmConstants message;
		public IntPtr wParam;
		public IntPtr lParam;
		public UInt32 time;
		public Point pt;

		public bool peek_all ()
			// Peek all messages in the queue.
		{
			return Win32.PeekMessage (out this, (IntPtr) 0, 0, 0, PeekMessageConstants.pm_remove);
		}

		public void wait ()
			// Wait for a new message.
		{
			Win32.WaitMessage ();
		}

		public void translate ()
		{
			Win32.TranslateMessage (ref this);
		}

		public void dispatch ()
		{
			Win32.DispatchMessage (ref this);
		}
	}
}
