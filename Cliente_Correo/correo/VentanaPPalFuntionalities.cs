using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace correo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
			Console.WriteLine ("Cargando ventana");
			this.contactos = Contactos.Crea ();
			this.Actualiza ();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
			Console.WriteLine ("Simple click");
			DataGridViewRow row = tablaContactos.Rows [e.RowIndex];
			this.currentRow = e.RowIndex;
			this.tbNombre.Text = row.Cells[1].Value.ToString();
			this.tbEmail.Text = row.Cells [3].Value.ToString();
			this.cbGrupo.Text = row.Cells[2].Value.ToString();
			this.descripcion.Text = contactos.GetDescripcion (this.currentRow);
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
			Console.WriteLine ("Double Click");
			//Esto nos permitira quedarnos con un solo contacto en la aplicacion final
			DataGridViewRow row = tablaContactos.Rows [e.RowIndex];
			this.currentRow = e.RowIndex;
			this.Toret = row.Cells [3].Value.ToString();
			this.Close ();

        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
			if ( this.tbNombre.Text !="" && this.tbEmail.Text !="" && this.cbGrupo.Text != "" ) {
				this.contactos.Add( new Contacto( this.tbNombre.Text,
					this.tbEmail.Text, this.cbGrupo.Text,this.descripcion.Text ) );

				this.Actualiza();
			}
			this.tbNombre.Text = "";
			this.tbEmail.Text = "";
			this.cbGrupo.Text = "";
			this.descripcion.Text = "";

			return;
        }

        private void btBorrar_Click(object sender, EventArgs e)
        {
			this.contactos.RemoveAt(currentRow);
			this.Actualiza();
			this.tbNombre.Text = "";
			this.tbEmail.Text = "";
			this.cbGrupo.Text = "";
        }

        private void miArchivoSalir_Click(object sender, EventArgs e)
        {
			this.Dispose (true);
			this.contactos.GuardaXml();
        }


		private void Actualiza()
		{
			this.ActualizaLista( 0 );
		}

		private void ActualizaLista(int numRow)
		{
			// Crea y actualiza filas
			for (int i = numRow; i < this.contactos.Count; ++i) {
				if ( this.tablaContactos.Rows.Count <= i ) {
					this.tablaContactos.Rows.Add();
				}

				this.ActualizaFilaDeLista( i );
			}

			// Eliminar filas sobrantes
			int numExtra = this.tablaContactos.Rows.Count - this.contactos.Count;
			for(; numExtra > 0 ; --numExtra) {
				this.tablaContactos.Rows.RemoveAt( this.contactos.Count );
			}

			return;
		}


		private void ActualizaFilaDeLista(int rowIndex)
		{
			if ( rowIndex < 0
				|| rowIndex > this.tablaContactos.Rows.Count )
			{
				throw new ArgumentOutOfRangeException( "fila fuera de rango: " + rowIndex );
			}

			DataGridViewRow row = this.tablaContactos.Rows[ rowIndex ];
			Contacto contacto = this.contactos[ rowIndex ];

			row.Cells[ 0 ].Value = ( rowIndex + 1 ).ToString().PadLeft( 4, ' ' );
			row.Cells[ 1 ].Value = contacto.Nombre;
			row.Cells[ 2 ].Value = contacto.Categoria;
			row.Cells[ 3 ].Value = contacto.Email;

			return;
		}

		public string Toret {
			get{ return toret;}
			set{ toret = value; }
		}

		public void Prueba(){}


		private int currentRow;
		private string toret;
        
    }
}
