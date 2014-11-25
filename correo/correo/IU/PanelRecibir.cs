using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
namespace correo
{
	public class PanelRecibir:Form
	{
		public PanelRecibir ()
		{
			mensajes=Principal.FetchAllMessages("pop.gmail.com",995,true,"oscaresei@gmail.com","");
			this.Build ();
		}
		private void Build ()
		{
			this.Text = "Recibidos";
			String numeroMsg = mensajes.Count.ToString();
			//Panel principal
			var pnlPpal= new TableLayoutPanel();
			pnlPpal.Dock=DockStyle.Fill;

			//Panel numero de mensajes
			var pnlOp1 = new Panel();
			var lblOp1 = new Label();
			this.edOp1 = new TextBox();
			pnlOp1.Dock=DockStyle.Top;
			lblOp1.Text = "Numeros Mensajes";
			this.edOp1.Text=numeroMsg;
			lblOp1.Dock=DockStyle.Left;
			this.edOp1.Dock=DockStyle.Fill;
			pnlOp1.Controls.Add(this.edOp1);
			pnlOp1.Controls.Add(lblOp1);

			//Panel mensaje
			var pnlOp2 = new Panel();
			var lblOp2 = new Label();
			this.edOp2 = new RichTextBox();
			pnlOp2.Dock=DockStyle.Top;
			lblOp2.Text = "Mensaje";
			this.edOp2.Text=mostrarMensaje(mensajes);
			lblOp2.Dock=DockStyle.Top;
			this.edOp2.Dock=DockStyle.Fill;
			pnlOp2.Controls.Add(this.edOp2);
			pnlOp2.Controls.Add(lblOp2);

			//Boton siguiente

			var btFirst = new Button();

			btFirst.Text = "Siguiente";
			btFirst.Dock = DockStyle.Top;

			btFirst.Click += delegate(object sender, EventArgs e) {

				numeroMostrar=numeroMostrar+1;
				this.Build ();
			};





			pnlPpal.Controls.Add(pnlOp1);
			pnlPpal.Controls.Add(pnlOp2);
			pnlPpal.Controls.Add( btFirst );
			pnlPpal.ResumeLayout( false );
			this.Controls.Add (pnlPpal);
		}

		private string mostrarMensaje(List<OpenPop.Mime.Message> mensajes)
		{
			OpenPop.Mime.Message mensaje = mensajes[numeroMostrar];
			OpenPop.Mime.MessagePart plainTextPart = mensaje.FindFirstPlainTextVersion();
			if (plainTextPart != null)
			{
				return plainTextPart.GetBodyAsText();
			} else {
				string error = "Este mensaje no tiene version de texto";
				return error;
			}

		}

		private TextBox edOp1;
		private RichTextBox edOp2;
		private int numeroMostrar=0;
		private List<OpenPop.Mime.Message> mensajes;

	}
}

