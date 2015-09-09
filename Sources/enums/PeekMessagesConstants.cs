// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;

namespace WCL.Enums
{
		/// <summary>
		/// Constants to be used with Win32.PeekMessage.
		/// See https://msdn.microsoft.com/en-us/library/windows/desktop/ms644943(v=vs.85).aspx for more details.
		/// </summary>
	public enum PeekMessageConstants
	{
		pm_noremove = 0,
		pm_remove = 1,
		Pm_noyield = 2,
		Pm_qs_input = 0x4070000,
		Pm_qs_paint = 0x200000,
		Pm_qs_postmessage = 0x980000,
		Pm_qs_sendmessage = 0x400000
	}
}
