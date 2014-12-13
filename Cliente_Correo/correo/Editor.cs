using System.Drawing;
using System.Windows.Forms;

public class editor : Form
{
	private System.ComponentModel.Container components = null;
	public TextBox codigo;

	public editor ()
	{
		this.codigo = new TextBox ();
		this.SuspendLayout ();
		this.codigo.Dock = System.Windows.Forms.DockStyle.Fill;
		this.codigo.Location = new System.Drawing.Point (0, 0);
		this.codigo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.codigo.Name = "codigo";
		this.codigo.Multiline = true;
		this.codigo.Size = new System.Drawing.Size (584, 334);
		this.codigo.TabIndex = 0;
		this.codigo.Text = "Editor de txt";
		this.Controls.Add (this.codigo);
		this.AutoScaleBaseSize = new System.Drawing.Size (5, 13);
		this.ClientSize = new System.Drawing.Size (584, 334);
		this.Size = new Size (400, 400);
		this.Text = "Archivo txt";
		this.ResumeLayout (false);
	}
}

