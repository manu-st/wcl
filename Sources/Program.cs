// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;
using WCL.Gdi;
using WCL.Support;
using WCL.Structs;
using WCL.Windows;

class Program
{
	private static void Main (string[] args)
	{
		Program prg = new Program ();
	}

	public Program ()
	{
		Application app = new Application ();
		TitledWindow win = new TitledWindow ("A nice Title!");
		win.pointer_button_press_actions += on_left_click;
		win.expose_actions += on_paint;
		win.show ();
		app.launch ();
	}

	public void on_left_click (Window win, int x, int y, int button)
	{
		win.invalidate ();
	}

	public void on_paint (Window win, Dc a_dc, Rect a_area)
	{
		//	a_dc.draw_rectangle(1, 1, 100, 50);
		a_dc.draw_text("Test for Drawing", 40, 40);
	}
}
