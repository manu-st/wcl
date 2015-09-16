// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;
using System.Runtime.InteropServices;

namespace WCL.Structs
{
		/// <summary>
		/// Encapsulation of the Win32 PAINTSTRUCT structure.
		/// See https://msdn.microsoft.com/en-us/library/windows/desktop/dd162768(v=vs.85).aspx for more details.
		/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct PaintStruct {
		public IntPtr hdc;
		public bool fErase;
		public Rect rcPaint;
		public bool fRestore;
		public bool fIncUpdate;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=32)]
		public byte [] rgbReserved;
	}
}