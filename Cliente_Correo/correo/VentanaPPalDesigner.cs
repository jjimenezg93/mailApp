namespace correo
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        


		private void InitializeComponent()
        {
            this.ContenedorPpal = new System.Windows.Forms.SplitContainer();
            this.tablaContactos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.miArchivoSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.miAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.miAyudaSN = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.descripcion = new System.Windows.Forms.RichTextBox();
            this.btBorrar = new System.Windows.Forms.Button();
            this.btGuardar = new System.Windows.Forms.Button();
            this.cbGrupo = new System.Windows.Forms.ComboBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.lbNombre = new System.Windows.Forms.Label();
            this.lbGrupo = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ContenedorPpal)).BeginInit();
            this.ContenedorPpal.Panel1.SuspendLayout();
            this.ContenedorPpal.Panel2.SuspendLayout();
            this.ContenedorPpal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaContactos)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContenedorPpal
            // 
            this.ContenedorPpal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContenedorPpal.Location = new System.Drawing.Point(0, 0);
            this.ContenedorPpal.MaximumSize = new System.Drawing.Size(896, 487);
            this.ContenedorPpal.MinimumSize = new System.Drawing.Size(896, 487);
            this.ContenedorPpal.Name = "ContenedorPpal";
            // 
            // ContenedorPpal.Panel1
            // 
            this.ContenedorPpal.Panel1.Controls.Add(this.tablaContactos);
            this.ContenedorPpal.Panel1.Controls.Add(this.menuStrip1);
            // 
            // ContenedorPpal.Panel2
            // 
            this.ContenedorPpal.Panel2.Controls.Add(this.groupBox1);
            this.ContenedorPpal.Size = new System.Drawing.Size(896, 487);
            this.ContenedorPpal.SplitterDistance = 531;
            this.ContenedorPpal.TabIndex = 0;
            // 
            // tablaContactos
            // 
            this.tablaContactos.AllowUserToOrderColumns = true;
            this.tablaContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaContactos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.grupo,
            this.email});
			this.tablaContactos.AllowUserToAddRows = false;
			this.tablaContactos.ResumeLayout(false);
			this.tablaContactos.RowHeadersVisible = false;
			this.tablaContactos.AutoGenerateColumns = false;
            this.tablaContactos.Location = new System.Drawing.Point(0, 27);
            this.tablaContactos.Name = "tablaContactos";
            this.tablaContactos.Size = new System.Drawing.Size(525, 458);
            this.tablaContactos.TabIndex = 1;
			this.tablaContactos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaContactos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.tablaContactos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.id.HeaderText = "Id";
            this.id.MaxInputLength = 100;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 41;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 150;
            // 
            // grupo
            // 
            this.grupo.HeaderText = "Grupo";
            this.grupo.Name = "grupo";
            this.grupo.ReadOnly = true;
            // 
            // email
            // 
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Width = 300;
		    // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miArchivo,
            this.miAyuda});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(531, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miArchivo
            // 
            this.miArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miArchivoSalir});
            this.miArchivo.Name = "miArchivo";
            this.miArchivo.Size = new System.Drawing.Size(60, 20);
            this.miArchivo.Text = "Archivo";
            // 
            // miArchivoSalir
            // 
            this.miArchivoSalir.Name = "miArchivoSalir";
            this.miArchivoSalir.Size = new System.Drawing.Size(96, 22);
            this.miArchivoSalir.Text = "Salir";
            this.miArchivoSalir.Click += new System.EventHandler(this.miArchivoSalir_Click);
            // 
            // miAyuda
            // 
            this.miAyuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAyudaSN});
            this.miAyuda.Name = "miAyuda";
            this.miAyuda.Size = new System.Drawing.Size(53, 20);
            this.miAyuda.Text = "Ayuda";
            // 
            // miAyudaSN
            // 
            this.miAyudaSN.Name = "miAyudaSN";
            this.miAyudaSN.Size = new System.Drawing.Size(162, 22);
            this.miAyudaSN.Text = "Sobre nosotros...";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.descripcion);
            this.groupBox1.Controls.Add(this.btBorrar);
            this.groupBox1.Controls.Add(this.btGuardar);
            this.groupBox1.Controls.Add(this.cbGrupo);
            this.groupBox1.Controls.Add(this.tbEmail);
            this.groupBox1.Controls.Add(this.tbNombre);
            this.groupBox1.Controls.Add(this.lbNombre);
            this.groupBox1.Controls.Add(this.lbGrupo);
            this.groupBox1.Controls.Add(this.lbEmail);
            this.groupBox1.Location = new System.Drawing.Point(3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 477);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contacto";
            // 
            // descripcion
            // 
            this.descripcion.Location = new System.Drawing.Point(29, 234);
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(303, 220);
            this.descripcion.TabIndex = 9;
            this.descripcion.Text = "";
            // 
            // btBorrar
            // 
            this.btBorrar.Location = new System.Drawing.Point(173, 164);
            this.btBorrar.Name = "btBorrar";
            this.btBorrar.Size = new System.Drawing.Size(109, 23);
            this.btBorrar.TabIndex = 8;
            this.btBorrar.Text = "Borrar";
            this.btBorrar.UseVisualStyleBackColor = true;
            this.btBorrar.Click += new System.EventHandler(this.btBorrar_Click);
            // 
            // btGuardar
            // 
            this.btGuardar.Location = new System.Drawing.Point(27, 164);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(112, 24);
            this.btGuardar.TabIndex = 7;
            this.btGuardar.Text = "Guardar";
            this.btGuardar.UseVisualStyleBackColor = true;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // cbGrupo
            // 
            this.cbGrupo.FormattingEnabled = true;
            this.cbGrupo.Location = new System.Drawing.Point(77, 82);
            this.cbGrupo.Name = "cbGrupo";
            this.cbGrupo.Size = new System.Drawing.Size(205, 21);
            this.cbGrupo.TabIndex = 4;
			this.cbGrupo.Items.Add ("Amigos");
			this.cbGrupo.Items.Add ("Trabajo");
			this.cbGrupo.Items.Add ("Otros");
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(77, 119);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(205, 20);
            this.tbEmail.TabIndex = 5;
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(77, 45);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(205, 20);
            this.tbNombre.TabIndex = 3;
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(24, 122);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(35, 13);
            this.lbNombre.TabIndex = 2;
            this.lbNombre.Text = "Email:";
            // 
            // lbGrupo
            // 
            this.lbGrupo.AutoSize = true;
            this.lbGrupo.Location = new System.Drawing.Point(24, 85);
            this.lbGrupo.Name = "lbGrupo";
            this.lbGrupo.Size = new System.Drawing.Size(39, 13);
            this.lbGrupo.TabIndex = 1;
            this.lbGrupo.Text = "Grupo:";
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(24, 48);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(47, 13);
            this.lbEmail.TabIndex = 0;
            this.lbEmail.Text = "Nombre:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 487);
            this.Controls.Add(this.ContenedorPpal);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion de Contactos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ContenedorPpal.Panel1.ResumeLayout(false);
            this.ContenedorPpal.Panel1.PerformLayout();
            this.ContenedorPpal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ContenedorPpal)).EndInit();
            this.ContenedorPpal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablaContactos)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
			this.FormClosing += (sender, e) => {
				this.Dispose (true);
				this.contactos.GuardaXml();
			};

        }

		private Contactos contactos;

        #endregion

        private System.Windows.Forms.SplitContainer ContenedorPpal;
        private System.Windows.Forms.DataGridView tablaContactos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Label lbGrupo;
        private System.Windows.Forms.RichTextBox descripcion;
        private System.Windows.Forms.Button btBorrar;
        private System.Windows.Forms.Button btGuardar;
        private System.Windows.Forms.ComboBox cbGrupo;
        private System.Windows.Forms.TextBox tbEmail;
		private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miArchivo;
        private System.Windows.Forms.ToolStripMenuItem miArchivoSalir;
        private System.Windows.Forms.ToolStripMenuItem miAyuda;
        private System.Windows.Forms.ToolStripMenuItem miAyudaSN;
    }
}

