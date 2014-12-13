using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;
using System.Text;

public class formulario : Form
{
	private MainMenu menus;
	private MenuItem menuarchivo;
	private MenuItem menunuevo;
	private MenuItem menuabrir;
	private MenuItem menuguardar;
	private String toret;

public formulario ()
	{
		this.menus = new MainMenu ();
//Declaracion de Grupo de Menus
		this.menuarchivo = new MenuItem ();
//Declaracion de Menus
		this.menunuevo = new MenuItem ();
		this.menuabrir = new MenuItem ();
		this.menuguardar = new MenuItem ();
		this.menus.MenuItems.AddRange (new MenuItem[]{this.menuarchivo});
		this.menuarchivo.Index = 0;
		this.menuarchivo.MenuItems.AddRange (new MenuItem[] {
			this.menunuevo,
			this.menuabrir,
			this.menuguardar
		});
		this.menuarchivo.Text = "&Archivo";
//elementos del menu Archivo
		this.menunuevo.Index = 0;
		this.menunuevo.Text = "&Nuevo";
		this.menunuevo.Click += new System.EventHandler (this.menunuevo_click);
		this.menuabrir.Index = 1;
		this.menuabrir.Text = "&Abrir";
		//this.menuabrir.Click += new System.EventHandler (this.menuabrir_click);
		this.menuguardar.Index = 2;
		this.menuguardar.Text = "&Guardar";
		//this.menuguardar.Click += new System.EventHandler (this.menuguardar_click);
//elementos del menu edicion
		Size = new Size (600, 500);
		Text = "Editor de texto";
		IsMdiContainer = true;
		this.Menu = this.menus;
	}

	private void menunuevo_click (object sender, System.EventArgs e)
	{
		editor formeditor = new editor ();
		formeditor.MdiParent = this;
		formeditor.Visible = true;
	}

	public string menuabrir_click ()
	{
		string toret="";
		OpenFileDialog archivoa = new OpenFileDialog ();
		archivoa.Filter = "Archivos C# (*.txt)|*.txt";
		archivoa.Title = "Abrir Documento C#";
		if (archivoa.ShowDialog () == DialogResult.OK) {
			string namefile;
			namefile = archivoa.FileName;
			StreamReader srarchivo = File.OpenText (namefile);
			toret = srarchivo.ReadToEnd ();
			srarchivo.Close ();
		}
		archivoa.Dispose ();
		this.setToret (toret);
		return toret;
	}

	private void setToret(String aux)
	{
		this.toret = aux;
	}

	public String getToret ()
	{
		return this.toret;
	}


	public void menuguardar_click (string guardar)
	{
		SaveFileDialog guardar_archivo = new SaveFileDialog ();
		guardar_archivo.Filter = "Ficheros C# (*.txt)|*.txt";
		guardar_archivo.CreatePrompt = true;
		guardar_archivo.OverwritePrompt = true;
		guardar_archivo.Title = "Seleccione el nombre del fichero a guardar";
		if (guardar_archivo.ShowDialog () == DialogResult.OK) {
			string namefile;
			namefile = guardar_archivo.FileName;
			StreamWriter swarchivo = File.CreateText (namefile);
			swarchivo.Write (guardar);
			swarchivo.Close ();
		}
		guardar_archivo.Dispose ();
	}

	public void Mostrar (string x)
	{
		Console.WriteLine("El texto es: {0}", x);
	}
}

