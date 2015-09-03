using System;
using System.Runtime.InteropServices;

namespace WCL.Structs
{
	[StructLayout(LayoutKind.Sequential)]
	public struct Point
	{
		public int x;
		public int y;

		public Point (int a_x, int a_y)
		{
			x = a_x;
			y = a_y;
		}
	}
}
