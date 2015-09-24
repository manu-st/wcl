// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;
using System.Runtime.InteropServices;
using System.Diagnostics.Contracts;

namespace WCL.Structs
{
		/// <summary>
		/// Encapsulation of the Win32 POINT structure.
		/// See https://msdn.microsoft.com/en-us/library/dd162897(v=vs.85).aspx for more details.
		/// </summary>
	[StructLayout (LayoutKind.Sequential)]
	public struct Rect
	{
#region Initialization
		public Rect (int a_left, int a_top, int a_right, int a_bottom)
		{
			Left = a_left;
			Top = a_top;
			Right = a_right;
			Bottom = a_bottom;
		}
#endregion

#region Access
		public int Left, Top, Right, Bottom;

		public int X
		{
			get { return Left; }
			set { Right -= (Left - value); Left = value; }
		}

		public int Y
		{
			get { return Top; }
			set { Bottom -= (Top - value); Top = value; }
		}

		public int Height
		{
			get { return Bottom - Top; }
			set { Bottom = value + Top; }
		}

		public int Width
		{
			get { return Right - Left; }
			set { Right = value + Left; }
		}

		public Point Location
		{
			get {
				Point l_point = new Point (Left, Top);

				Contract.Ensures (Contract.Result<Point> ().X == Left, "x set with left");
				Contract.Ensures (Contract.Result<Point> ().Y == Top, "y set with top");

				return l_point;
			}
			set { X = value.X; Y = value.Y; }
		}

		public Size Size
		{
			get { return new Size (Width, Height); }
			set { Width = value.Width; Height = value.Height; }
		}

		public override int GetHashCode ()
		{
				// Taken from http://referencesource.microsoft.com/#System.Drawing/commonui/System/Drawing/Rectangle.cs,17559e21008f381d
			return (int)((UInt32) X ^
						(((UInt32) Y << 13) | ((UInt32) Y >> 19)) ^
						(((UInt32) Width << 26) | ((UInt32) Width >> 6)) ^
						(((UInt32) Height << 7) | ((UInt32) Height >> 25)));
		}
#endregion

#region Comparison
		public static bool operator ==(Rect r1, Rect r2)
		{
			return r1.Equals (r2);
		}

		public static bool operator !=(Rect r1, Rect r2)
		{
			return !r1.Equals (r2);
		}

		public bool Equals (Rect r)
		{
			return r.Left == Left && r.Top == Top && r.Right == Right && r.Bottom == Bottom;
		}

		public override bool Equals(object obj)
		{
			if (obj is Rect) {
				return Equals((Rect) obj);
			} else {
				return false;
			}
		}
#endregion

#region Output
		public override string ToString ()
		{
			return string.Format (System.Globalization.CultureInfo.CurrentCulture, "{{left={0},top={1},right={2},bottom={3}}}", Left, Top, Right, Bottom);
		}
	}
#endregion

}
