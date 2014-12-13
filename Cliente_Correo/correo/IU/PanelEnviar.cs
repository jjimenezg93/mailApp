using System; 
using System.Collections; 
using System.Net; 
using System.Net.Mail; 
using System.Net.Mime;
using System.Windows.Forms;

namespace correo{
public class PanelEnviar:Form
{ 	
	public PanelEnviar ()
	{
		this.Build ();

	}
	private void Build ()
	{
		this.Text = "Enviar";
		this.ClientSize = new System.Drawing.Size(896, 487);
		//Panel principal
		var pnlPpal= new TableLayoutPanel();
		pnlPpal.Dock=DockStyle.Fill;

			//Panel Destinatario
			var pnlDes = new Panel();
			var lblDes = new Label();
			this.edDes = new TextBox();
			pnlDes.Dock=DockStyle.Top;
			lblDes.Text = "Destinatario";
			lblDes.Dock=DockStyle.Left;
			this.edDes.Dock=DockStyle.Fill;
			pnlDes.Controls.Add(this.edDes);
			pnlDes.Controls.Add(lblDes);
			pnlDes.Size = new System.Drawing.Size(205, 30);
		
		//boton contactos
		var pnlContacto = new Panel ();
		pnlContacto.Dock=DockStyle.Top;

		var btContacto = new Button ();
		btContacto.Text = "Añadir Contacto";
		btContacto.Dock = DockStyle.Right;
		btContacto.Click += (object sender, EventArgs e) => this.startContactos();
		btContacto.Size = new System.Drawing.Size(109, 23);
		pnlContacto.Controls.Add (btContacto);
		pnlContacto.Size=new System.Drawing.Size(205, 30);
		
		var pnlHueco = new Panel ();
		pnlHueco.Dock=DockStyle.Top;
		pnlHueco.Size=new System.Drawing.Size(205, 30);
		
		//Panel Asunto
		var pnlAsunto = new Panel();
		var lblAsunto = new Label();
		this.edAsunto = new TextBox();
		pnlAsunto.Dock=DockStyle.Top;
		lblAsunto.Text = "Asunto";
		lblAsunto.Dock=DockStyle.Left;
		this.edAsunto.Dock=DockStyle.Fill;
		pnlAsunto.Controls.Add(this.edAsunto);
		pnlAsunto.Controls.Add(lblAsunto);
			pnlAsunto.Size = new System.Drawing.Size(205, 50);

		//Panel mensaje
		var pnlMsg = new Panel();
		var lblMsg = new Label();
		this.edMsg = new RichTextBox();
			this.edMsg.Size = new System.Drawing.Size(205, 205);
		pnlMsg.Dock=DockStyle.Top;
		lblMsg.Text = "Cuerpo del Mensaje";
		lblMsg.Dock=DockStyle.Top;
		this.edMsg.Dock=DockStyle.Fill;
		pnlMsg.Controls.Add(this.edMsg);
		pnlMsg.Controls.Add(lblMsg);
			pnlMsg.Size = new System.Drawing.Size(205, 205);

		//Boton siguiente

		var btFirst = new Button();

		btFirst.Text = "Enviar";
		btFirst.Dock = DockStyle.Top;

		btFirst.Click += delegate(object sender, EventArgs e) {

			string destinatario=edDes.Text;
			string asunto=edAsunto.Text;
			string mensaje=edMsg.Text;
				string origen=edOrigen.Text;
				string password=edPwd.Text;
				this.Enviar (mensaje,destinatario,asunto,origen,password);
		};

		//Boton Abrir


		var btOpen = new Button();
		btOpen.Text = "Abrir";
		btOpen.Dock = DockStyle.Top;

		btOpen.Click += (object sender, EventArgs e) => this.setText();

		//Boton Guardar
		var btSave = new Button();
		btSave.Text = "Guardar";
		btSave.Dock = DockStyle.Top;

		btSave.Click += (object sender, EventArgs e) => this.saveText();



		
		pnlPpal.ResumeLayout( false );


		

			//Grupo destinatario
		var groupBox1 = new System.Windows.Forms.GroupBox();
		groupBox1.Location = new System.Drawing.Point(3, 7);
		groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(400, 477);
		groupBox1.TabIndex = 0;
		groupBox1.TabStop = false;
		groupBox1.Text = "Destino";

			groupBox1.Controls.Add( btFirst );
		groupBox1.Controls.Add( btSave );
		groupBox1.Controls.Add( btOpen );
		groupBox1.Controls.Add(pnlMsg);
		groupBox1.Controls.Add (pnlAsunto);
			groupBox1.Controls.Add (pnlHueco);
		groupBox1.Controls.Add (pnlContacto);
		groupBox1.Controls.Add(pnlDes);




			//Panel usuario origen
			var pnlOrigen = new Panel();
			var lblOrigen = new Label();
			this.edOrigen = new TextBox();
			pnlOrigen.Dock=DockStyle.Top;
			lblOrigen.Text = "Usuario";
			lblOrigen.Dock=DockStyle.Left;
			this.edOrigen.Dock=DockStyle.Fill;
			pnlOrigen.Controls.Add(this.edOrigen);
			pnlOrigen.Controls.Add(lblOrigen);
			pnlOrigen.Size = new System.Drawing.Size(205, 30);

			//Panel usuario destino

			//Panel Destinatario
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
			//Grupos Origen
			var groupBox2 = new System.Windows.Forms.GroupBox();
			groupBox2.Location = new System.Drawing.Point(3, 7);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(400, 477);
			groupBox2.TabIndex = 0;
			groupBox2.TabStop = false;
			groupBox2.Text = "Origen";
			groupBox2.Dock = DockStyle.Right;

			groupBox2.Controls.Add (pnlPwd);
			groupBox2.Controls.Add (pnlOrigen);




			//Contenedor Principal
			var Container = new System.Windows.Forms.SplitContainer ();

			Container.Dock = System.Windows.Forms.DockStyle.Fill;
			Container.Location = new System.Drawing.Point(0, 0);
			Container.MaximumSize = new System.Drawing.Size(896, 487);
			Container.MinimumSize = new System.Drawing.Size(800, 487);
			Container.Name = "ContenedorPpal";
			Container.Panel1.Controls.Add (groupBox1);
			Container.SplitterDistance = 410;
			Container.Panel2.Controls.Add (groupBox2);
			pnlPpal.Controls.Add (Container);
		this.Controls.Add (pnlPpal);

	}
		public void Enviar(string cuerpo,string destinatario,string asunto,string emisor, string contraseña) 
	{ 
		System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage(); 
		msg.To.Add(destinatario); 
			msg.From = new MailAddress(emisor, emisor, System.Text.Encoding.UTF8); 
		msg.Subject = asunto; 
		msg.SubjectEncoding = System.Text.Encoding.UTF8; 
		msg.Body = cuerpo; 
		msg.BodyEncoding = System.Text.Encoding.UTF8; 
		msg.IsBodyHtml = false;  

		//Aquí es donde se hace lo especial 
		SmtpClient client = new SmtpClient(); 
			client.Credentials = new System.Net.NetworkCredential(emisor, contraseña ); 
		client.Port = 587; 
		client.Host = "smtp.gmail.com"; 
		client.EnableSsl = true; //Esto es para que vaya a través de SSL que es obligatorio con GMail 
		try 
		{ 
			client.Send(msg); 
			MessageBox.Show("Enviado");

		} 
		catch (System.Net.Mail.SmtpException ex) 
		{ 
			Console.WriteLine(ex.Message); 
			Console.ReadLine(); 
		} 


	} 

	private void setText ()
	{
		var formulario = new formulario ();
		string toret = formulario.menuabrir_click();
		this.edMsg.Text=toret;
	}

	private void saveText ()
	{
		var formulario = new formulario ();
		formulario.menuguardar_click(this.edMsg.Text);
	}


	private void startContactos(){
			Form1 contactos = new Form1 ();
			contactos.ShowDialog ();
			this.edDes.Text = contactos.Toret;
			contactos.Dispose ();
	}


	private TextBox edDes;
	private TextBox edAsunto;
	private RichTextBox edMsg;
		private TextBox edOrigen;
		private TextBox edPwd;
} 
}