// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;
using WCL.Support;
using WCL.Windows;

static class Program
{
	static void Main(string[] args)
	{
		Application app = new Application ();
		TitledWindow win = new TitledWindow ("A nice Title!");
		win.show ();
		app.launch ();
	}
}
