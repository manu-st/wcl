// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;

namespace WCL.Enums
{
		/// <summary>
		/// List of predefined cursors to be used with Win32.LoadCursor.
		/// See https://msdn.microsoft.com/en-us/library/windows/desktop/ms648072(v=vs.85).aspx for more details
		/// </summary>
	public enum SystemIcons
	{
		Idi_application = 32512,
		Idi_hand = 32513,
		Idi_question = 32514,
		Idi_exclamation = 32515,
		Idi_asterisk = 32516,
		Idi_winlogo = 32517,
		Idi_warning = Idi_exclamation,
		Idi_error = Idi_hand,
		Idi_information = Idi_asterisk,
	}
}
