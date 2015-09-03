using System;

namespace WCL.Callbacks
{
	public delegate IntPtr WndProc (IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
}
