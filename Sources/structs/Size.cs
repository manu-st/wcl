// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;
using System.Runtime.InteropServices;

namespace WCL.Structs
{
		/// <summary>
		/// Encapsulation of the Win32 SIZE structure.
		/// See https://msdn.microsoft.com/en-us/library/windows/desktop/dd145106(v=vs.85).aspx for more details.
		/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Size
	{
		public int Width;
		public int Height;
		public Size(int a_width, int a_height)
		{
			Width = a_width;
			Height = a_height;
		}
	}
}
