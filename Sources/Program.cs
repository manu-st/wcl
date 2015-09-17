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
		last_char = (char)  0;
		is_key_down = false;
		win.pointer_button_press_actions += on_left_click;
		win.expose_actions += on_paint;
		win.char_actions += on_char;
		win.key_down_actions += on_key_down;
		win.key_up_actions += on_key_up;
		win.show ();
		app.launch ();
	}

	public void on_left_click (Window win, int x, int y, int button)
	{
		win.invalidate ();
	}

	public void on_paint (Window win, Dc a_dc, Rect a_area)
	{
		a_dc.draw_rectangle (39, 39, 300, 60);
		if (is_key_down) {
			a_dc.draw_text ("Key is down", 40, 40);
		} else {
			if (last_char == (char) 0) {
				a_dc.draw_text ("Type a key", 40, 40);
			} else {
				a_dc.draw_text ("Last key was '" + last_char.ToString () + "'", 40, 40);
			}
		}
	}

	public void on_char (Window win, char a_char, int a_key_flags)
	{
		last_char = a_char;
		win.invalidate ();
	}

	public void on_key_down (Window win, int a_vk, int a_key_flags)
	{
		is_key_down = true;
		win.invalidate ();
	}

	public void on_key_up (Window win, int a_vk, int a_key_flags)
	{
		is_key_down = false;
		win.invalidate ();
	}

	private char last_char;
	private bool is_key_down;
}
