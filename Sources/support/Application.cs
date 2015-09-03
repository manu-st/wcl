using System;
using WCL;
using WCL.Structs;
using WCL.Enums;

namespace WCL.Support
{
	class Application
	{
		public Application ()
		{
			
		}

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
	}
}
