using System;
using System.Windows.Forms;
namespace correo
{
	public class MainWindow: Form
	{
		public MainWindow ()
		{
			this.Build();
		}
		private void Build ()
		{
			this.Text = "Correo";

			//Panel Principal
			var pnlPpal= new TableLayoutPanel();
			pnlPpal.Dock=DockStyle.Fill;



			//Boton Entrar

			var btFirst = new Button();
			var btSecond = new Button();

			btFirst.Text = "Recibir Correo";
			btFirst.Dock = DockStyle.Top;
			btSecond.Text = "Enviar Correo";
			btSecond.Dock = DockStyle.Top;

			btFirst.Click += delegate(object sender, EventArgs e) {
				var w = new PanelRecibir();
				w.Show();
			};

			btSecond.Click += delegate(object sender, EventArgs e) {
				var w = new PanelEnviar();
				w.Show();
			};

			pnlPpal.Controls.Add( btFirst );
			pnlPpal.Controls.Add( btSecond );

			pnlPpal.ResumeLayout( false );
			this.Controls.Add( pnlPpal );


			//Todos

			this.Controls.Add(pnlPpal);


		}
	}
}

