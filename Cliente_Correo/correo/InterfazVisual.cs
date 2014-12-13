using System;
using System.Drawing;
using System.Windows.Forms;

namespace correo
{
	public class InterfazVisual : Form 
	{
		/**************************************
		 * 
		 * METER INSERTAR Y BORRAR EN LA INTERFAZ PRINCIPAL
		 * CORREGIR BORRAR CUANDO SE FILTRA POR FECHA
		 * LIMPIAR XML MIERDA
		 * 
		 * opcional: AL MODIFICAR EN LA PROPIA LISTA, ACTUALIZAR
		 * ************************************
		 */

		public const int ColNum = 0;
		public const int ColFecha = 1;
		public const int ColNombre = 2;
		public const int ColDesc = 3;

		public InterfazVisual(Lista_Tareas  t)
		{
			this.xml=new Xmlr();
			this.xml.RecuperaXml();
			this.tareas = this.xml.getTareas();
			this.BuildGui();
			this.Actualiza();
		}

		private void BuildCalendario()
		{
			this.Text = "Calendar";
			//Main panel
			menuCalendar=new Form();
			FlowLayoutPanel pnlOps=new FlowLayoutPanel();
			pnlOps.FlowDirection=FlowDirection.LeftToRight;
			pnlOps.Dock=DockStyle.Top;
			pnlOps.MinimumSize=new Size(0,0);


			//initialize MonthCalendar
			calendario = new MonthCalendar();

			//monthCalendar styles
			calendario.TitleBackColor = System.Drawing.Color.DeepSkyBlue;
			calendario.TrailingForeColor = System.Drawing.Color.SlateGray;
			calendario.Font = new System.Drawing.Font("Century Gothic, Arial",12);
			calendario.Dock = DockStyle.Top;
			//calendario.MinimumSize = new System.Drawing.Size(420,280);

			tbCalendar=new TextBox();
			tbCalendar.Dock=DockStyle.Right;
			tbCalendar.TextAlign=HorizontalAlignment.Right;

			var btMostrar = new Button();
			btMostrar.Text = "&Mostrar Todo";
			btMostrar.AutoSize=true;
			btMostrar.Dock=DockStyle.Right;
			btMostrar.Click += (sender, e) => this.MostrarTodo(sender, e);
			//Controls
			pnlOps.Controls.Add(tbCalendar);
			pnlOps.Controls.Add( btMostrar );

			panelCalendar.Controls.Add(calendario);
			panelCalendar.Controls.Add( pnlOps );
		
	
			//haciendo esto la lista de tareas se introduce en la ventana del calendario
			//hay un panel para tareas, hay que rellenarlo y actualizar lista al cambiar dia

			tbCalendar.Text  = calendario.SelectionRange.Start.ToShortDateString();


			calendario.MaxSelectionCount = 1;
			calendario.DateChanged += (sender, e) => this.calendarClick(sender, e);


			//this.pnlPpal.Controls.Add(this.panelCalendar);



		}
		private void MostrarTodo(object sender, EventArgs e)
	    {
			ActualizaLista();

	    }

		private void calendarClick(object sender, EventArgs e)
	    {
			this.tbCalendar.Text = calendario.SelectionRange.Start.ToShortDateString();
			ActualizaListaPorFecha(calendario.SelectionRange.Start.Date);

	    }


		private void BuildGui()
		{
			this.SuspendLayout();

			this.pnlPpal = new Panel();
			this.pnlPpal.SuspendLayout();
			this.pnlPpal.Dock = DockStyle.Fill;

			this.Controls.Add( this.pnlPpal );

			panelCalendar = new TableLayoutPanel();
			this.panelCalendar.Dock = DockStyle.Left;
		
			Size tam=new System.Drawing.Size(275,450);
			this.panelCalendar.MinimumSize=tam;
			this.panelCalendar.MaximumSize=tam;
			this.Controls.Add (this.panelCalendar);

			this.BuildStatus();
			this.BuildMenu();
			this.BuildPanelLista();
			this.BuildDialogInserta();
			this.BuildCalendario();

			this.BuildDialogBorrar();

			this.MinimumSize = new Size(1000,400 );

			this.pnlPpal.ResumeLayout( false );
			this.ResumeLayout( true );
			this.Resize += (obj, e) => this.ResizeWindow();
			this.Text = "Lista de Tareas + Calendar";
			this.ResizeWindow();
			this.Closed += (sender, e) => this.Salir();
		
		}

		private void BuildStatus()
		{
			this.sbStatus = new StatusBar();
			this.sbStatus.Dock = DockStyle.Bottom;
			this.Controls.Add( this.sbStatus );
		}
	private void ResizeWindow()
		{
			// Tomar las nuevas medidas
			int width = this.pnlPpal.ClientRectangle.Width;
			// Redimensionar la tabla
			this.grdLista.Width = width; 

			this.grdLista.Columns[ ColNum ].Width =
			(int) Math.Floor( width *.10 );
			this.grdLista.Columns[ ColFecha ].Width =
			(int) Math.Floor( width *.30 );	
			this.grdLista.Columns[ ColNombre ].Width =
			(int) Math.Floor( width *.20 ); 
			this.grdLista.Columns[ ColDesc ].Width =
			(int) Math.Floor( width *.40 ); 


		}

		private void BuildMenu()
		{
			this.mPpal = new MainMenu();

			this.opSalir = new MenuItem( "&Salir" );
			this.opSalir.Shortcut = Shortcut.CtrlE;
			this.opSalir.Click += (sender, e) => this.Salir();

			this.opInsertar = new MenuItem( "&Insertar" );
			this.opInsertar.Shortcut = Shortcut.CtrlA;
			this.opInsertar.Click += (sender, e) => this.Inserta();
			//Meter Borrado
			this.opBorrar = new MenuItem( "&Borrar" );
			this.opBorrar.Shortcut = Shortcut.CtrlD;
			this.opBorrar.Click += (sender, e) => this.Borrar();



			this.mPpal.MenuItems.Add( this.opInsertar );
			this.mPpal.MenuItems.Add( this.opBorrar );
		
			this.mPpal.MenuItems.Add( this.opSalir );
			this.Menu = mPpal;
		}

		private void BuildPanelLista()
		{
			this.pnlLista = new Panel();
			this.pnlLista.SuspendLayout();
			this.pnlLista.Dock = DockStyle.Fill;
			this.pnlPpal.Controls.Add( this.pnlLista );

			// Crear gridview
			this.grdLista = new DataGridView();
			this.grdLista.Dock = DockStyle.Fill;
			this.grdLista.AllowUserToResizeRows = false;
			this.grdLista.RowHeadersVisible = false;
			this.grdLista.AutoGenerateColumns = false;
			this.grdLista.MultiSelect = false;
			this.grdLista.AllowUserToAddRows = false;
			this.grdLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			var textCellTemplate0 = new DataGridViewTextBoxCell();
			var textCellTemplate1 = new DataGridViewTextBoxCell();
			var textCellTemplate2 = new DataGridViewTextBoxCell();
			var textCellTemplate3 = new DataGridViewTextBoxCell();
			textCellTemplate0.Style.BackColor = this.grdLista.RowHeadersDefaultCellStyle.BackColor;
			textCellTemplate1.Style.BackColor = Color.Wheat;
			textCellTemplate2.Style.BackColor = Color.Wheat;
			textCellTemplate3.Style.BackColor = Color.Wheat;
			var column0 = new DataGridViewTextBoxColumn();
			var column1 = new DataGridViewTextBoxColumn();
			var column2 = new DataGridViewTextBoxColumn();
			var column3 = new DataGridViewTextBoxColumn();
			column0.SortMode = DataGridViewColumnSortMode.NotSortable;
			column1.SortMode = DataGridViewColumnSortMode.NotSortable;
			column2.SortMode = DataGridViewColumnSortMode.NotSortable;
			column3.SortMode = DataGridViewColumnSortMode.NotSortable;
			column0.CellTemplate = textCellTemplate0;
			column1.CellTemplate = textCellTemplate1;
			column2.CellTemplate = textCellTemplate2;
			column3.CellTemplate = textCellTemplate3;
			column0.HeaderText = "#";
			column0.Width = 50;
			column0.ReadOnly = true;
			column1.HeaderText = "Fecha";
			column1.Width = 100;
			column1.ReadOnly = true;
			column2.HeaderText = "Nombre";
			column2.Width = 100;
			column2.ReadOnly = false;
			column3.HeaderText = "Descripccion";
			column3.Width = 100;
			column3.ReadOnly = false;
	
			this.grdLista.Columns.AddRange( new DataGridViewColumn[] {
				column0, column1, column2, column3
			} );


			this.pnlLista.Controls.Add( this.grdLista );
			this.pnlLista.ResumeLayout( false );
		}

		private void BuildDialogBorrar ()
		{
			this.dlgBorrar = new Form();
			this.dlgBorrar.SuspendLayout();

			var pnlBorrar = new TableLayoutPanel();
			pnlBorrar.Dock = DockStyle.Fill;
			pnlBorrar.SuspendLayout();
			this.dlgBorrar.Controls.Add( pnlBorrar );

			var pnlIndex = new Panel();
			this.tbIndex= new TextBox();
			this.tbIndex.TextAlign = HorizontalAlignment.Right;
			this.tbIndex.Dock = DockStyle.Right;
			var lbIndex = new Label();
			lbIndex.Text = "Numero de la tarea a borrar :";
			lbIndex.Dock = DockStyle.Fill;
			pnlIndex.Controls.Add( this.tbIndex );
			pnlIndex.Controls.Add( lbIndex );
			pnlIndex.Dock = DockStyle.Top;
			pnlIndex.MaximumSize = new Size( int.MaxValue, tbIndex.Height * 2 );
			pnlBorrar.Controls.Add( pnlIndex );


			var pnlBotones = new TableLayoutPanel();
			pnlBotones.ColumnCount = 2;
			pnlBotones.RowCount = 1;
			var btCierra = new Button();
			btCierra.DialogResult = DialogResult.Cancel;
			btCierra.Text = "&Cancelar";
			var btBorra = new Button();
			btBorra.DialogResult = DialogResult.OK;
			btBorra.Text = "&Borrar";
			pnlBotones.Controls.Add( btBorra );
			pnlBotones.Controls.Add( btCierra );
			pnlBotones.Dock = DockStyle.Top;
			pnlBorrar.Controls.Add( pnlBotones );

			this.dlgBorrar.AcceptButton = btBorra;
			this.dlgBorrar.CancelButton = btCierra;
			pnlBorrar.ResumeLayout( true );
			this.dlgBorrar.ResumeLayout( false );
			this.dlgBorrar.Text = "Borrar Tarea";
			this.dlgBorrar.Size = new Size( 400, 
			pnlIndex.Height+ pnlBotones.Height );
			this.dlgBorrar.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.dlgBorrar.MinimizeBox = false;
			this.dlgBorrar.MaximizeBox = false;
			this.dlgBorrar.StartPosition = FormStartPosition.CenterParent;
		}

		private void BuildDialogInserta ()
		{
			this.dlgInserta = new Form();
			this.dlgInserta.SuspendLayout();

			var pnlInserta = new TableLayoutPanel();
			pnlInserta.Dock = DockStyle.Fill;
			pnlInserta.SuspendLayout();
			this.dlgInserta.Controls.Add( pnlInserta );

			var pnlFecha = new Panel();
			this.tbFecha = new TextBox();
			this.tbFecha.TextAlign = HorizontalAlignment.Right;

			this.tbFecha.Dock = DockStyle.Fill;
			var lbFecha = new Label();
			lbFecha.Text = "Fecha:";
			lbFecha.Dock = DockStyle.Left;
			pnlFecha.Controls.Add( this.tbFecha );
			pnlFecha.Controls.Add( lbFecha );
			pnlFecha.Dock = DockStyle.Top;
			pnlFecha.MaximumSize = new Size( int.MaxValue, tbFecha.Height * 2 );
			pnlInserta.Controls.Add( pnlFecha );

			var pnlNombre = new Panel();
			this.tbNombre = new TextBox();
			this.tbNombre.TextAlign = HorizontalAlignment.Right;
			this.tbNombre.Dock = DockStyle.Fill;
			var lbnombre = new Label();
			lbnombre.Text = "Nombre: ";
			lbnombre.Dock = DockStyle.Left;
			pnlNombre.Controls.Add( this.tbNombre );
			pnlNombre.Controls.Add( lbnombre );
			pnlNombre.Dock = DockStyle.Top;
			pnlNombre.MaximumSize = new Size( int.MaxValue, tbNombre.Height * 2 );
			pnlInserta.Controls.Add( pnlNombre );

			var pnlDesc = new Panel();
			this.tbDesc = new TextBox();
			this.tbDesc.TextAlign = HorizontalAlignment.Right;
			this.tbDesc.Dock = DockStyle.Fill;
			var lbDesc = new Label();
			lbDesc.Text = "Descripccion:";
			lbDesc.Dock = DockStyle.Left;
			pnlDesc.Controls.Add( this.tbDesc );
			pnlDesc.Controls.Add( lbDesc );
			pnlDesc.Dock = DockStyle.Top;
			pnlDesc.MaximumSize = new Size( int.MaxValue, tbDesc.Height * 2 );
			pnlInserta.Controls.Add( pnlDesc );

			var pnlBotones = new TableLayoutPanel();
			pnlBotones.ColumnCount = 2;
			pnlBotones.RowCount = 1;
			var btCierra = new Button();
			btCierra.DialogResult = DialogResult.Cancel;
			btCierra.Text = "&Cancelar";
			var btGuarda = new Button();
			btGuarda.DialogResult = DialogResult.OK;
			btGuarda.Text = "&Guardar";
			pnlBotones.Controls.Add( btGuarda );
			pnlBotones.Controls.Add( btCierra );
			pnlBotones.Dock = DockStyle.Top;
			pnlInserta.Controls.Add( pnlBotones );

			this.dlgInserta.AcceptButton = btGuarda;
			this.dlgInserta.CancelButton = btCierra;
			pnlInserta.ResumeLayout( true );
			this.dlgInserta.ResumeLayout( false );
			this.dlgInserta.Text = "Nueva Tarea";
			this.dlgInserta.Size = new Size( 400, 
				pnlFecha.Height + pnlNombre.Height
				+ pnlDesc.Height + pnlBotones.Height );
			this.dlgInserta.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.dlgInserta.MinimizeBox = false;
			this.dlgInserta.MaximizeBox = false;
			this.dlgInserta.StartPosition = FormStartPosition.CenterParent;
		}



		private void Salir()
		{
			this.Dispose( true );
		}

		private void Inserta()
		{
			this.tbNombre.Text = "";
			this.tbFecha.Text =Convert.ToString(System.DateTime.Now);

			this.tbDesc.Text = "";

			if ( this.dlgInserta.ShowDialog() == DialogResult.OK ) {
				Tarea aux = new Tarea (Convert.ToDateTime(this.tbFecha.Text),this.tbNombre.Text,this.tbDesc.Text);
				this.tareas.Anadir(aux);
				this.Actualiza();
			}

			return;
		}

		private void Borrar ()
		{
			this.tbIndex.Text = "1";
			if (this.dlgBorrar.ShowDialog () == DialogResult.OK) {

				if (tareas.Tamaño () >= Convert.ToInt32 (this.tbIndex.Text) && 0 < Convert.ToInt32 (this.tbIndex.Text)) {
					this.tareas.Borrar (Convert.ToInt32 (this.tbIndex.Text) - 1);
				}
				this.Actualiza ();
			}
		}

		private void Calendar()
		{
			this.tbIndex.Text = "1";
			if ( this.menuCalendar.ShowDialog() == DialogResult.OK ) {

				if (tareas.Tamaño () >= Convert.ToInt32 (this.tbIndex.Text) && 0 < Convert.ToInt32 (this.tbIndex.Text)) {
					this.tareas.Borrar (Convert.ToInt32 (this.tbIndex.Text) - 1);
				}
				this.Actualiza();
			}


		}

		private void Actualiza()
		{
			this.sbStatus.Text = "Tareas: " + this.tareas.Tamaño().ToString();
			this.ActualizaLista(  );
			this.xml.Actualizar(this.tareas);
			this.xml.GuardaXml();
		}

		

		private void ActualizaLista()
		{
			// Crea y actualiza filas
		for (int i = 0; i < this.tareas.Tamaño(); i++) {
				if ( this.grdLista.Rows.Count <= i ) {
					this.grdLista.Rows.Add();
				}

				this.ActualizaFilaDeLista( i );
			}

			// Eliminar filas sobrantes
		int numExtra = this.grdLista.Rows.Count - this.tareas.Tamaño();
			for(; numExtra > 0 ; --numExtra) {
			this.grdLista.Rows.RemoveAt( this.tareas.Tamaño() );
			}

			return;
		}


		private void ActualizaListaPorFecha (DateTime fecha)
		{
			int cont=0;
			// Crea y actualiza filas
			for (int i = 0; i < this.tareas.Tamaño(); i++) {
				if(this.ComprobarFecha(i)){
					cont++;
				if (this.grdLista.Rows.Count <= i) {
					this.grdLista.Rows.Add ();
				}

				this.ActualizaFilaDeLista (i);
			}
			}

			// Eliminar filas sobrantes
		int numExtra = this.grdLista.Rows.Count - cont;
			for(; numExtra > 0 ; --numExtra) {
			this.grdLista.Rows.RemoveAt( cont );
			}

			return;
		}
		private bool ComprobarFecha (int i)
		{
			Tarea aux =this.tareas.Recibir(i);
			return this.tbCalendar.Text==aux.Fecha.ToShortDateString();

		}
		private void ActualizaFilaDeLista(int rowIndex)
		{
			if ( rowIndex < 0
				|| rowIndex > this.grdLista.Rows.Count )
			{
				throw new ArgumentOutOfRangeException( "fila fuera de rango: " + rowIndex );
			}

			DataGridViewRow row = this.grdLista.Rows[ rowIndex ];
		Tarea	tarea = this.tareas.Recibir(rowIndex);

		row.Cells[ ColNum ].Value = ( rowIndex + 1 ).ToString().PadLeft( 4, ' ' );
		row.Cells[ ColFecha ].Value = tarea.Fecha;
		row.Cells[ ColNombre ].Value = tarea.Nombre;
		row.Cells[ ColDesc ].Value = tarea.Descripcion;

			return;
		}

		private MainMenu mPpal;
		private MenuItem opSalir;
		private MenuItem opInsertar;
		private MenuItem opBorrar;
		private StatusBar sbStatus;
		private Panel pnlLista;
		private Panel panelCalendar;
		private Panel pnlPpal;
		private TextBox tbCalendar;
		private TextBox tbFecha;
		private TextBox tbNombre;
		private TextBox tbDesc;
		private DataGridView grdLista;
		private Form dlgInserta;
		private Form menuCalendar;
		private TextBox tbIndex;
		private Form dlgBorrar;
		private MonthCalendar calendario;
		private Lista_Tareas tareas;
		private Xmlr xml;
	}


}
