using System;
using Gtk;

namespace Samples.GtkPrincipal
{
	class Program
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}

