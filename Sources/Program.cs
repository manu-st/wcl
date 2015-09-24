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
		_last_char = (char)  0;
		_is_key_down = false;
		win.PointerButtonPressActions += OnLeftClick;
		win.ExposeActions += OnPaint;
		win.CharActions += OnChar;
		win.KeyDownActions += OnKeyDown;
		win.KeyUpActions += OnKeyUp;
		win.CloseActions += OnClose;
		win.Show ();
		win.SetWidth (200);
		win.SetHeight (200);
		app.Launch ();
	}

	public void OnLeftClick (Window win, int x, int y, int button)
	{
		win.Invalidate ();
	}

	public void OnPaint (Window win, Dc a_dc, Rect a_area)
	{
		a_dc.DrawRectangle (39, 39, 300, 60);
		if (_is_key_down) {
			a_dc.DrawText ("Key is down", 40, 40);
		} else {
			if (_last_char == (char) 0) {
				a_dc.DrawText ("Type a key", 40, 40);
			} else {
				a_dc.DrawText ("Last key was '" + _last_char.ToString () + "'", 40, 40);
			}
		}
	}

	public void OnChar (Window win, char a_char, int a_key_flags)
	{
		_last_char = a_char;
		win.Invalidate ();
	}

	public void OnKeyDown (Window win, int a_vk, int a_key_flags)
	{
		_is_key_down = true;
		win.Invalidate ();
	}

	public void OnKeyUp (Window win, int a_vk, int a_key_flags)
	{
		_is_key_down = false;
		win.Invalidate ();
	}

	public void OnClose (Window win)
	{
		win.Destroy ();
	}

	private char _last_char;
	private bool _is_key_down;
}
