// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;
using WCL.Structs;
using WCL.Enums;

namespace WCL.Support
{
	class Application
	{
#region Initialization
		public Application ()
		{
		}
#endregion

#region Basic Operations
		public void launch ()
		{
			Msg msg = new Msg ();
			bool done = false;

			while (!done) {
				if (msg.peek_all ()) {
					if (msg.message == WmConstants.Wm_quit) {
						done = true;
					} else {
						msg.translate ();
						msg.dispatch ();
					}
				} else {
						// Idle Actions
					msg.wait ();
				}
			}
		}
#endregion

	}
}
