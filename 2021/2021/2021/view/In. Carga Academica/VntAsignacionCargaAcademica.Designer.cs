
namespace _2021
{
    partial class VntAsignacionCargaAcademica
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VntAsignacionCargaAcademica));
            this.dataGridViewDocentes2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewCursosActivos = new System.Windows.Forms.DataGridView();
            this.columna0 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtboxBuscadorDocente = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtboxBuscadorCurso = new System.Windows.Forms.TextBox();
            this.comboBoxPeriodo = new System.Windows.Forms.ComboBox();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.comboBoxAnio = new System.Windows.Forms.ComboBox();
            this.lblAnio = new System.Windows.Forms.Label();
            this.comboBoxTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMostrarHorario = new System.Windows.Forms.Button();
            this.imagen = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocentes2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCursosActivos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagen)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDocentes2
            // 
            this.dataGridViewDocentes2.AllowUserToAddRows = false;
            this.dataGridViewDocentes2.AllowUserToDeleteRows = false;
            this.dataGridViewDocentes2.AllowUserToResizeRows = false;
            this.dataGridViewDocentes2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDocentes2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dataGridViewDocentes2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDocentes2.Location = new System.Drawing.Point(79, 519);
            this.dataGridViewDocentes2.MultiSelect = false;
            this.dataGridViewDocentes2.Name = "dataGridViewDocentes2";
            this.dataGridViewDocentes2.ReadOnly = true;
            this.dataGridViewDocentes2.RowHeadersVisible = false;
            this.dataGridViewDocentes2.Size = new System.Drawing.Size(801, 188);
            this.dataGridViewDocentes2.TabIndex = 31;
            this.dataGridViewDocentes2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDocentes2_CellContentClick);
            // 
            // dataGridViewCursosActivos
            // 
            this.dataGridViewCursosActivos.AllowUserToAddRows = false;
            this.dataGridViewCursosActivos.AllowUserToDeleteRows = false;
            this.dataGridViewCursosActivos.AllowUserToResizeRows = false;
            this.dataGridViewCursosActivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCursosActivos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dataGridViewCursosActivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCursosActivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columna0});
            this.dataGridViewCursosActivos.Location = new System.Drawing.Point(79, 202);
            this.dataGridViewCursosActivos.MultiSelect = false;
            this.dataGridViewCursosActivos.Name = "dataGridViewCursosActivos";
            this.dataGridViewCursosActivos.ReadOnly = true;
            this.dataGridViewCursosActivos.RowHeadersVisible = false;
            this.dataGridViewCursosActivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCursosActivos.Size = new System.Drawing.Size(1081, 241);
            this.dataGridViewCursosActivos.TabIndex = 30;
            this.dataGridViewCursosActivos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCursosActivos_CellContentClick);
            // 
            // columna0
            // 
            this.columna0.HeaderText = "check";
            this.columna0.Name = "columna0";
            this.columna0.ReadOnly = true;
            this.columna0.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(398, 464);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(17, 31);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // txtboxBuscadorDocente
            // 
            this.txtboxBuscadorDocente.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxBuscadorDocente.Location = new System.Drawing.Point(148, 464);
            this.txtboxBuscadorDocente.Name = "txtboxBuscadorDocente";
            this.txtboxBuscadorDocente.Size = new System.Drawing.Size(244, 26);
            this.txtboxBuscadorDocente.TabIndex = 28;
            this.txtboxBuscadorDocente.Text = "Buscar...";
            this.txtboxBuscadorDocente.TextChanged += new System.EventHandler(this.txtboxBuscadorDocente_TextChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(408, 150);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(17, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            // 
            // txtboxBuscadorCurso
            // 
            this.txtboxBuscadorCurso.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxBuscadorCurso.Location = new System.Drawing.Point(148, 150);
            this.txtboxBuscadorCurso.Name = "txtboxBuscadorCurso";
            this.txtboxBuscadorCurso.Size = new System.Drawing.Size(244, 26);
            this.txtboxBuscadorCurso.TabIndex = 25;
            this.txtboxBuscadorCurso.Text = "Buscar...";
            this.txtboxBuscadorCurso.TextChanged += new System.EventHandler(this.txtboxBuscadorCurso_TextChanged);
            // 
            // comboBoxPeriodo
            // 
            this.comboBoxPeriodo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPeriodo.FormattingEnabled = true;
            this.comboBoxPeriodo.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.comboBoxPeriodo.Location = new System.Drawing.Point(720, 100);
            this.comboBoxPeriodo.Name = "comboBoxPeriodo";
            this.comboBoxPeriodo.Size = new System.Drawing.Size(200, 26);
            this.comboBoxPeriodo.TabIndex = 24;
            this.comboBoxPeriodo.Text = "Septiembre";
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodo.Location = new System.Drawing.Point(639, 104);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(79, 18);
            this.lblPeriodo.TabIndex = 23;
            this.lblPeriodo.Text = "Periodo :";
            // 
            // comboBoxAnio
            // 
            this.comboBoxAnio.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAnio.FormattingEnabled = true;
            this.comboBoxAnio.Items.AddRange(new object[] {
            "2021",
            "2020",
            "2019",
            "2018",
            "2017",
            "2016",
            "2015",
            "2014"});
            this.comboBoxAnio.Location = new System.Drawing.Point(434, 100);
            this.comboBoxAnio.Name = "comboBoxAnio";
            this.comboBoxAnio.Size = new System.Drawing.Size(200, 26);
            this.comboBoxAnio.TabIndex = 22;
            this.comboBoxAnio.Text = "2021";
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnio.Location = new System.Drawing.Point(383, 104);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(49, 18);
            this.lblAnio.TabIndex = 21;
            this.lblAnio.Text = "Año :";
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTipo.FormattingEnabled = true;
            this.comboBoxTipo.Items.AddRange(new object[] {
            "CCI",
            "DAI",
            "INF"});
            this.comboBoxTipo.Location = new System.Drawing.Point(148, 100);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.Size = new System.Drawing.Size(200, 26);
            this.comboBoxTipo.TabIndex = 20;
            this.comboBoxTipo.Text = "DAI";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(95, 104);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(51, 18);
            this.lblTipo.TabIndex = 19;
            this.lblTipo.Text = "Tipo :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(72, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(541, 37);
            this.label1.TabIndex = 32;
            this.label1.Text = "ASIGNACION CARGA ACADEMICA";
            // 
            // btnMostrarHorario
            // 
            this.btnMostrarHorario.BackColor = System.Drawing.Color.White;
            this.btnMostrarHorario.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMostrarHorario.BackgroundImage")));
            this.btnMostrarHorario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMostrarHorario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarHorario.FlatAppearance.BorderSize = 0;
            this.btnMostrarHorario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarHorario.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarHorario.Location = new System.Drawing.Point(1003, 667);
            this.btnMostrarHorario.Margin = new System.Windows.Forms.Padding(0);
            this.btnMostrarHorario.Name = "btnMostrarHorario";
            this.btnMostrarHorario.Size = new System.Drawing.Size(135, 50);
            this.btnMostrarHorario.TabIndex = 33;
            this.btnMostrarHorario.Text = "Asignar Carga";
            this.btnMostrarHorario.UseVisualStyleBackColor = false;
            this.btnMostrarHorario.Click += new System.EventHandler(this.btnMostrarHorario_Click);
            // 
            // imagen
            // 
            this.imagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.imagen.Image = ((System.Drawing.Image)(resources.GetObject("imagen.Image")));
            this.imagen.Location = new System.Drawing.Point(945, 464);
            this.imagen.Name = "imagen";
            this.imagen.Size = new System.Drawing.Size(250, 180);
            this.imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagen.TabIndex = 34;
            this.imagen.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(981, 647);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "Asignar una carga academica:";
            // 
            // VntAsignacionCargaAcademica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1260, 801);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.imagen);
            this.Controls.Add(this.btnMostrarHorario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewDocentes2);
            this.Controls.Add(this.dataGridViewCursosActivos);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txtboxBuscadorDocente);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtboxBuscadorCurso);
            this.Controls.Add(this.comboBoxPeriodo);
            this.Controls.Add(this.lblPeriodo);
            this.Controls.Add(this.comboBoxAnio);
            this.Controls.Add(this.lblAnio);
            this.Controls.Add(this.comboBoxTipo);
            this.Controls.Add(this.lblTipo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VntAsignacionCargaAcademica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VntAsignacionCargaAcademica";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocentes2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCursosActivos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewDocentes2;
        private System.Windows.Forms.DataGridView dataGridViewCursosActivos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columna0;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtboxBuscadorDocente;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtboxBuscadorCurso;
        private System.Windows.Forms.ComboBox comboBoxPeriodo;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.ComboBox comboBoxAnio;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.ComboBox comboBoxTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMostrarHorario;
        private System.Windows.Forms.PictureBox imagen;
        private System.Windows.Forms.Label label2;
    }
}