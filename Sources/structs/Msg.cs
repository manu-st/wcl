// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;
using System.Runtime.InteropServices;
using WCL.Structs;
using WCL.Enums;

namespace WCL.Structs
{
		/// <summary>
		/// Encapsulation of the Win32 MSG structure.
		/// See https://msdn.microsoft.com/en-us/library/windows/desktop/ms644958(v=vs.85).aspx for more details.
		/// </summary>
	[StructLayout (LayoutKind.Sequential)]
	public struct Msg
	{
#region Access
		public IntPtr hwnd;
		public WmConstants message;
		public IntPtr wParam;
		public IntPtr lParam;
		public UInt32 time;
		public Point pt;
#endregion

#region Basic Operations
		public bool PeekAll ()
			// Peek all messages in the queue.
		{
			return Win32.PeekMessage (out this, (IntPtr) 0, 0, 0, PeekMessageConstants.Pm_remove);
		}

		public void Wait ()
			// Wait for a new message.
		{
			Win32.WaitMessage ();
		}

		public void Translate ()
			// Translate virtual-key messages into character messages.
		{
			Win32.TranslateMessage (ref this);
		}

		public void Dispatch ()
			// Dispatch the message to a window procedure.
		{
			Win32.DispatchMessage (ref this);
		}
#endregion

	}
}