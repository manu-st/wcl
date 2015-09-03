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
