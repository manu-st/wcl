// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;
using WCL.Enums;

namespace WCL.Callbacks
{
	public delegate IntPtr WndProc (IntPtr hWnd, WmConstants msg, IntPtr wParam, IntPtr lParam);
}
