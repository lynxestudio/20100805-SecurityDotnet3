using System;
using Gtk;
using System.Security.Principal;
using System.Threading;

public partial class MainWindow : Gtk.Window
{
	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected virtual void OnBtnEnterClicked (object sender, System.EventArgs e)
	{
		System.Text.StringBuilder buf = new System.Text.StringBuilder();
		Gtk.TextBuffer textbuf = txtInfo.Buffer;
		textbuf.Clear();
		try{
			AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
			WindowsPrincipal wp = (WindowsPrincipal)Thread.CurrentPrincipal;
			buf.AppendFormat("Login: {0}\n",wp.Identity.Name);
			buf.AppendFormat("Esta autentificado: {0}\n",wp.Identity.IsAuthenticated);
			buf.AppendFormat("Tipo de autentificación: {0}\n",wp.Identity.AuthenticationType);
		}catch(FormatException fe)
			{
				buf.AppendFormat("Error al asignar el rid.\n");
				buf.AppendFormat("Mensaje: {0}",fe.Message);
			}
			catch(System.Security.SecurityException se)
			{
				buf.AppendFormat("No tiene permisos para establecer el principal.\n");
				buf.AppendFormat("Mensaje: {0}\n",se.Message);
			}
			catch(InvalidCastException ie){
				buf.AppendFormat("Error al obtener el principal.\n");
				buf.AppendFormat("Mensaje: {0}",ie.Message);
				}
			finally{
			textbuf.Text = buf.ToString(); 
			}
	}
	
	protected virtual void OnBtnCloseClicked (object sender, System.EventArgs e)
	{
		Application.Quit();
	}
	
	
	
}

