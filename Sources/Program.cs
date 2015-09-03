using System;
using WCL.Sources.windows;
using WCL.Support;

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
