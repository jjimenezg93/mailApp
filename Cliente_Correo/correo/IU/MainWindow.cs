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

			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.miCorreo = new System.Windows.Forms.ToolStripMenuItem();
			this.miCorreoEnviar = new System.Windows.Forms.ToolStripMenuItem();
			this.miCorreoRecibir = new System.Windows.Forms.ToolStripMenuItem();
			this.miContactos = new System.Windows.Forms.ToolStripMenuItem();
			this.miContactosAdmin = new System.Windows.Forms.ToolStripMenuItem();
			this.miToDo = new System.Windows.Forms.ToolStripMenuItem();
			this.miToDoAdmin = new System.Windows.Forms.ToolStripMenuItem();
			this.Text = "Principal";

			// menuStrip1

			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.miCorreo,this.miContactos,this.miToDo});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(531, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";


			//Dropdown menu correo
			this.miCorreo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.miCorreoEnviar,this.miCorreoRecibir});
			this.miCorreo.Name = "miCorreo";
			this.miCorreo.Size = new System.Drawing.Size(60, 20);
			this.miCorreo.Text = "Correo";

			//Correo Enviar
			this.miCorreoEnviar.Name = "miCorreoEnviar";
			this.miCorreoEnviar.Size = new System.Drawing.Size(96, 22);
			this.miCorreoEnviar.Text = "Enviar";
			this.miCorreoEnviar.Click += new System.EventHandler(this.Enviar);

			//Correo Recibir
			this.miCorreoRecibir.Name = "miCorreoRecibir";
			this.miCorreoRecibir.Size = new System.Drawing.Size(96, 22);
			this.miCorreoRecibir.Text = "Bandeja de entrada";
			this.miCorreoRecibir.Click += new System.EventHandler(this.Recibir);



			//Contactos
			//Dropdown menu contactos
			this.miContactos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.miContactosAdmin});
			this.miContactos.Name = "miContactos";
			this.miContactos.Size = new System.Drawing.Size(60, 20);
			this.miContactos.Text = "Contactos";

			//contactos
			this.miContactosAdmin.Name = "miMenuContactos";
			this.miContactosAdmin.Size = new System.Drawing.Size(96, 22);
			this.miContactosAdmin.Text = "Administrar Contactos";
			this.miContactosAdmin.Click += new System.EventHandler(this.Contactos);

			//ToDo
			//Dropdown menu tareas
			this.miToDo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.miToDoAdmin});
			this.miToDo.Name = "miToDo";
			this.miToDo.Size = new System.Drawing.Size(60, 20);
			this.miToDo.Text = "Tareas";

			//tareas
			this.miToDoAdmin.Name = "miMenuTareas";
			this.miToDoAdmin.Size = new System.Drawing.Size(96, 22);
			this.miToDoAdmin.Text = "Administrar Tareas";
			this.miToDoAdmin.Click += new System.EventHandler(this.toDo);

			//Panel Principal
			var pnlPpal = new TableLayoutPanel ();
			pnlPpal.Size = new System.Drawing.Size(896, 487);
			pnlPpal.Dock=DockStyle.Fill;




			pnlPpal.Controls.Add(this.menuStrip1);

			pnlPpal.ResumeLayout( false );

			this.Controls.Add( pnlPpal );


			//Todos
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(896, 487);
			this.Controls.Add(pnlPpal);


		}

		private void Recibir(object sender, EventArgs e){
			var w = new PanelRecibir();
			w.Show ();
		}

		private void Enviar(object sender, EventArgs e){
			var w = new PanelEnviar();
			w.Show();
		}
		private void Contactos(object sender, EventArgs e){
			Form1 contactos = new Form1 ();
			contactos.ShowDialog ();
		}

		private void toDo(object sender, EventArgs e){
			Lista_Tareas l=new Lista_Tareas();
			var f = new InterfazVisual(l);
			f.ShowDialog ();
		}
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem miCorreo;
		private System.Windows.Forms.ToolStripMenuItem miCorreoRecibir;
		private System.Windows.Forms.ToolStripMenuItem miCorreoEnviar;
		private System.Windows.Forms.ToolStripMenuItem miContactos;
		private System.Windows.Forms.ToolStripMenuItem miContactosAdmin;
		private System.Windows.Forms.ToolStripMenuItem miToDo;
		private System.Windows.Forms.ToolStripMenuItem miToDoAdmin;

	}
}

