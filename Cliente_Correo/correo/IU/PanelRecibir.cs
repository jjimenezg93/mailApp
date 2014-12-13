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

			this.Build ();

		}
		private void Build ()
		{
			this.Text = "Recibidos";
			this.ClientSize = new System.Drawing.Size(896, 487);
			this.numeroMostrar = 0;
			this.numeroMsg = 0;
			//Panel principal
			var pnlPpal= new TableLayoutPanel();
			pnlPpal.Dock=DockStyle.Fill;

			//Panel numero de mensajes
			var pnlOp1 = new Panel();
			var lblOp1 = new Label();
			this.lblMsg = new Label ();
			pnlOp1.Dock=DockStyle.Top;
			lblOp1.Text = "Numero Mensajes";
			lblOp1.Dock=DockStyle.Left;
			this.lblMsg.Dock = DockStyle.Fill;
			pnlOp1.Controls.Add(this.lblMsg);
			pnlOp1.Controls.Add(lblOp1);
			pnlOp1.Size = new System.Drawing.Size(205,50);


			//Panel From
			var pnlFrom = new Panel ();
			this.lblFrom = new Label ();
			this.lblFrom.Text="From";
			this.lblFrom2 = new Label ();


			pnlFrom.Dock=DockStyle.Top;
			this.lblFrom.Dock = DockStyle.Left;
			this.lblFrom2.Dock = DockStyle.Right;
			
			pnlFrom.Controls.Add (lblFrom);
			pnlFrom.Controls.Add (lblFrom2);

			pnlFrom.Size = new System.Drawing.Size(205,30);


			//Panel Asunto
			var pnlAsunto = new Panel ();
			this.lblAsunto = new Label ();
			this.lblAsunto.Text="Asunto";
			this.lblAsunto2 = new Label ();

			pnlAsunto.Dock=DockStyle.Top;
			this.lblAsunto.Dock = DockStyle.Left;
			this.lblAsunto2.Dock = DockStyle.Right;

			pnlAsunto.Controls.Add (lblAsunto);
			pnlAsunto.Controls.Add (lblAsunto2);
			pnlAsunto.Size = new System.Drawing.Size(205,30);


			//Panel Fecha
			var pnlFecha = new Panel ();
			this.lblFecha = new Label ();
			this.lblFecha.Text="Fecha";
			this.lblFecha2 = new Label ();
			
			pnlFecha.Dock=DockStyle.Top;
			this.lblFecha.Dock = DockStyle.Left;
			this.lblFecha2.Dock = DockStyle.Right;

			pnlFecha.Controls.Add (lblFecha);
			pnlFecha.Controls.Add (lblFecha2);
			pnlFecha.Size = new System.Drawing.Size(205,30);





			//Panel mensaje
			var pnlOp2 = new Panel();
			this.edMensaje = new RichTextBox();
			pnlOp2.Dock=DockStyle.Top;
			this.edMensaje.Dock=DockStyle.Fill;
			pnlOp2.Controls.Add (this.edMensaje);
			pnlOp2.Size = new System.Drawing.Size(205,300);

			//Boton siguiente

			var btFirst = new Button();

			btFirst.Text = "Siguiente";
			btFirst.Dock = DockStyle.Top;

			btFirst.Click+= (object sender, EventArgs e) => this.siguiente();




			//Panel usuario
			var pnlOrigen = new Panel();
			var lblOrigen = new Label();
			this.edUsuario = new TextBox();
			pnlOrigen.Dock=DockStyle.Top;
			lblOrigen.Text = "Usuario";
			lblOrigen.Dock=DockStyle.Left;
			this.edUsuario.Dock=DockStyle.Fill;
			pnlOrigen.Controls.Add(this.edUsuario);
			pnlOrigen.Controls.Add(lblOrigen);
			pnlOrigen.Size = new System.Drawing.Size(205, 30);

			//Panel usuario destino

			//Panel Contraseña
			var pnlPwd = new Panel();
			var lblPwd = new Label();
			this.edPwd = new TextBox();
			pnlPwd.Dock=DockStyle.Top;
			lblPwd.Text = "Contraseña";
			lblPwd.Dock=DockStyle.Left;
			this.edPwd.Dock=DockStyle.Fill;
			pnlPwd.Controls.Add(this.edPwd);
			pnlPwd.Controls.Add(lblPwd);
			pnlPwd.Size = new System.Drawing.Size(205, 30);




			//Boton recibir

			var btRecibir = new Button();

			btRecibir.Text = "Recibir";
			btRecibir.Dock = DockStyle.Top;

			btRecibir.Click += (object sender, EventArgs e) => this.recibir();

			var groupBox1 = new System.Windows.Forms.GroupBox();
			groupBox1.Location = new System.Drawing.Point(3, 7);
			groupBox1.Name = "groupBox2";
			groupBox1.Size = new System.Drawing.Size(400, 477);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Mensajes";
			groupBox1.Dock = DockStyle.Right;

			groupBox1.Controls.Add (btFirst);
			groupBox1.Controls.Add (pnlOp2);
			groupBox1.Controls.Add (pnlFecha);
			groupBox1.Controls.Add (pnlAsunto);
			groupBox1.Controls.Add (pnlFrom);
			groupBox1.Controls.Add (pnlOp1);

			//Grupos Origen
			var groupBox2 = new System.Windows.Forms.GroupBox();
			groupBox2.Location = new System.Drawing.Point(3, 7);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(400, 477);
			groupBox2.TabIndex = 0;
			groupBox2.TabStop = false;
			groupBox2.Text = "Iniciar Sesion";
			groupBox2.Dock = DockStyle.Left;

			groupBox2.Controls.Add (btRecibir);
			groupBox2.Controls.Add (pnlPwd);
			groupBox2.Controls.Add (pnlOrigen);




			//Contenedor Principal
			var Container = new System.Windows.Forms.SplitContainer ();

			Container.Dock = System.Windows.Forms.DockStyle.Fill;
			Container.Location = new System.Drawing.Point(0, 0);
			Container.MaximumSize = new System.Drawing.Size(896, 487);
			Container.MinimumSize = new System.Drawing.Size(800, 487);
			Container.Name = "ContenedorPpal";
			Container.Panel1.Controls.Add (groupBox2);
			Container.SplitterDistance = 410;
			Container.Panel2.Controls.Add (groupBox1);
			pnlPpal.Controls.Add (Container);
			this.Controls.Add (pnlPpal);

			pnlPpal.ResumeLayout( false );
			this.Controls.Add (pnlPpal);
		}

		private void recibir(){
			//Recuperamos los mensajes
			string usuario = edUsuario.Text;
			string pass = edPwd.Text;
			this.mensajes=Principal.FetchAllMessages("pop.gmail.com",995,true,usuario,pass);

			//Borramos los campos de inicio de sesion
			this.edUsuario.Text = "";
			this.edPwd.Text = "";

			//Mostramos el número de mensajes
			this.numeroMsg = this.mensajes.Count;
			this.lblMsg.Text = this.numeroMsg.ToString();

			this.edMensaje.Text=mostrarMensaje (this.mensajes);
			this.lblFrom2.Text = mostrarFrom (this.mensajes);
			this.lblAsunto2.Text = mostrarAsunto (this.mensajes);
			this.lblFecha2.Text = mostrarFecha (this.mensajes);

		}
		private string mostrarMensaje(List<OpenPop.Mime.Message> mensajes)
		{
			OpenPop.Mime.Message mensaje = this.mensajes[this.numeroMostrar];
			OpenPop.Mime.MessagePart plainTextPart = mensaje.FindFirstPlainTextVersion();
			if (plainTextPart != null)
			{
				return plainTextPart.GetBodyAsText();
			} else {
				string error = "Este mensaje no tiene version de texto";
				return error;
			}

		}

		private string mostrarFrom(List<OpenPop.Mime.Message> mensajes)
		{
			OpenPop.Mime.Message mensaje = this.mensajes[this.numeroMostrar];
			return mensaje.Headers.From.ToString();
			
		}

		private string mostrarAsunto(List<OpenPop.Mime.Message> mensajes)
		{
			OpenPop.Mime.Message mensaje = this.mensajes[this.numeroMostrar];
			return mensaje.Headers.Subject;
		}

		private string mostrarFecha(List<OpenPop.Mime.Message> mensajes)
		{
			OpenPop.Mime.Message mensaje = this.mensajes[this.numeroMostrar];
			return mensaje.Headers.DateSent.ToString();
		}

		private void siguiente(){
			if (this.numeroMsg != 0) {
				if (this.numeroMostrar < this.numeroMsg - 1) {
					this.numeroMostrar = this.numeroMostrar + 1;
				} else {
					this.numeroMostrar = 0;

				}
				this.edMensaje.Text = mostrarMensaje (this.mensajes);
				this.lblFrom2.Text = mostrarFrom (this.mensajes);
				this.lblAsunto2.Text = mostrarAsunto (this.mensajes);
				this.lblFecha2.Text = mostrarFecha (this.mensajes);
			}
		}

		private Label lblMsg;
		private TextBox edUsuario;
		private TextBox edPwd;
		private RichTextBox edMensaje;
		private int numeroMostrar;
		private List<OpenPop.Mime.Message> mensajes;
		private int numeroMsg;
		private Label lblFrom;
		private Label lblFrom2;
		private Label lblAsunto;
		private Label lblAsunto2;
		private Label lblFecha;
		private Label lblFecha2;
	}
}

