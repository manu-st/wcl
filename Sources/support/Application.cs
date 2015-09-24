// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;
using WCL.Structs;
using WCL.Enums;

namespace WCL.Support
{
	public class Application
	{
#region Initialization
		public Application ()
		{
		}
#endregion

#region Basic Operations
		public void Launch ()
		{
			Msg msg = new Msg ();
			bool done = false;

			while (!done) {
				if (msg.PeekAll ()) {
					if (msg.message == WmConstants.Wm_quit) {
						done = true;
					} else {
						msg.Translate ();
						msg.Dispatch ();
					}
				} else {
						// Idle Actions
					msg.Wait ();
				}
			}
		}

		public void Destroy ()
			// Signal that we want to exit from the even loop.
		{
			Win32.PostMessage (IntPtr.Zero, WmConstants.Wm_quit, IntPtr.Zero, IntPtr.Zero);
		}
#endregion

	}
}
