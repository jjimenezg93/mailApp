using System; 
using System.Collections; 
using System.Net; 
using System.Net.Mail; 
using System.Net.Mime;
using System.Windows.Forms;

public class PanelEnviar:Form
{ 	
	public PanelEnviar ()
	{
		this.Build ();

	}
	private void Build ()
	{
		this.Text = "Enviar";

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

		//Panel mensaje
		var pnlMsg = new Panel();
		var lblMsg = new Label();
		this.edMsg = new RichTextBox();
		pnlMsg.Dock=DockStyle.Top;
		lblMsg.Text = "Cuerpo del Mensaje";
		lblMsg.Dock=DockStyle.Top;
		this.edMsg.Dock=DockStyle.Fill;
		pnlMsg.Controls.Add(this.edMsg);
		pnlMsg.Controls.Add(lblMsg);

		//Boton siguiente

		var btFirst = new Button();

		btFirst.Text = "Enviar";
		btFirst.Dock = DockStyle.Top;

		btFirst.Click += delegate(object sender, EventArgs e) {

			string destinatario=edDes.Text;
			string asunto=edAsunto.Text;
			string mensaje=edMsg.Text;
			this.Enviar (mensaje,destinatario,asunto);
		};





		pnlPpal.Controls.Add(pnlDes);
		pnlPpal.Controls.Add (pnlAsunto);
		pnlPpal.Controls.Add(pnlMsg);
		pnlPpal.Controls.Add( btFirst );
		pnlPpal.ResumeLayout( false );
		this.Controls.Add (pnlPpal);
		this.MinimumSize= new System.Drawing.Size(320,400);

	}
	public void Enviar(string cuerpo,string destinatario,string asunto) 
	{ 
		System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage(); 
		msg.To.Add(destinatario); 
		msg.From = new MailAddress("", "Oscar", System.Text.Encoding.UTF8); 
		msg.Subject = asunto; 
		msg.SubjectEncoding = System.Text.Encoding.UTF8; 
		msg.Body = cuerpo; 
		msg.BodyEncoding = System.Text.Encoding.UTF8; 
		msg.IsBodyHtml = false;  

		//Aquí es donde se hace lo especial 
		SmtpClient client = new SmtpClient(); 
		client.Credentials = new System.Net.NetworkCredential("", "" ); 
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

	private TextBox edDes;
	private TextBox edAsunto;
	private RichTextBox edMsg;
} 
