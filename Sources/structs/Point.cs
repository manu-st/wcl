// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;
using System.Runtime.InteropServices;

namespace WCL.Structs
{
		/// <summary>
		/// Encapsulation of the Win32 POINT structure.
		/// See https://msdn.microsoft.com/en-us/library/dd162805(v=vs.85).aspx for more details.
		/// </summary>
	[StructLayout (LayoutKind.Sequential)]
	public struct Point
	{
#region Initialization
		public Point (int a_x, int a_y)
		{
			x = a_x;
			y = a_y;
		}
#endregion

#region Access
		public int x;
		public int y;
#endregion

	}
}
