// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

namespace WCL.Enums
{
		/// <summary>
		/// List of predefined cursors to be used with Win32.LoadCursor.
		/// See https://msdn.microsoft.com/en-us/library/windows/desktop/dd144925(v=vs.85).aspx for more details
		/// </summary>
	public enum StockObjects
	{
		White_brush = 0,
		Ltgray_brush = 1,
		Gray_brush = 2,
		Dkgray_brush = 3,
		Black_brush = 4,
		Null_brush = 5,
		Hollow_brush = Null_brush,
		White_pen = 6,
		Black_pen = 7,
		Null_pen = 8,
		Oem_fixed_font = 10,
		Ansi_fixed_font = 11,
		Ansi_var_font = 12,
		System_font = 13,
		Device_default_font = 14,
		Default_palette = 15,
		System_fixed_font = 16,
		Default_gui_font = 17,
		Dc_brush = 18,
		Dc_pen = 19,
	}
}
