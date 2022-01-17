
namespace _2021
{
    partial class VntDocentes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VntDocentes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelBarraBusqueda = new System.Windows.Forms.Panel();
            this.txtboxBuscadorDocente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBoxEstadoDocente = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelDescripcionEstados = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panelDataGridView = new System.Windows.Forms.Panel();
            this.dataGridViewDocentes = new System.Windows.Forms.DataGridView();
            this.panelNota = new System.Windows.Forms.Panel();
            this.lblNota = new System.Windows.Forms.Label();
            this.panelBarraBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelDescripcionEstados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panelDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocentes)).BeginInit();
            this.panelNota.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBarraBusqueda
            // 
            this.panelBarraBusqueda.Controls.Add(this.txtboxBuscadorDocente);
            this.panelBarraBusqueda.Controls.Add(this.label3);
            this.panelBarraBusqueda.Controls.Add(this.pictureBox1);
            this.panelBarraBusqueda.Controls.Add(this.comboBoxEstadoDocente);
            this.panelBarraBusqueda.Controls.Add(this.pictureBox2);
            this.panelBarraBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBarraBusqueda.Location = new System.Drawing.Point(0, 0);
            this.panelBarraBusqueda.Name = "panelBarraBusqueda";
            this.panelBarraBusqueda.Size = new System.Drawing.Size(800, 85);
            this.panelBarraBusqueda.TabIndex = 48;
            this.panelBarraBusqueda.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBarraBusqueda_Paint);
            // 
            // txtboxBuscadorDocente
            // 
            this.txtboxBuscadorDocente.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxBuscadorDocente.Location = new System.Drawing.Point(457, 31);
            this.txtboxBuscadorDocente.Name = "txtboxBuscadorDocente";
            this.txtboxBuscadorDocente.Size = new System.Drawing.Size(244, 26);
            this.txtboxBuscadorDocente.TabIndex = 25;
            this.txtboxBuscadorDocente.Text = "Buscar...";
            this.txtboxBuscadorDocente.TextChanged += new System.EventHandler(this.txtboxBuscadorDocente_TextChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 18);
            this.label3.TabIndex = 19;
            this.label3.Text = "Estado Docente:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(762, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // comboBoxEstadoDocente
            // 
            this.comboBoxEstadoDocente.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEstadoDocente.FormattingEnabled = true;
            this.comboBoxEstadoDocente.Items.AddRange(new object[] {
            "Disponibles",
            "Todos"});
            this.comboBoxEstadoDocente.Location = new System.Drawing.Point(184, 31);
            this.comboBoxEstadoDocente.Name = "comboBoxEstadoDocente";
            this.comboBoxEstadoDocente.Size = new System.Drawing.Size(244, 26);
            this.comboBoxEstadoDocente.TabIndex = 20;
            this.comboBoxEstadoDocente.Text = "Disponibles";
            this.comboBoxEstadoDocente.SelectedIndexChanged += new System.EventHandler(this.comboBoxEstadoDocente_SelectedIndexChanged_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(707, 29);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(17, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            // 
            // panelDescripcionEstados
            // 
            this.panelDescripcionEstados.Controls.Add(this.label5);
            this.panelDescripcionEstados.Controls.Add(this.label4);
            this.panelDescripcionEstados.Controls.Add(this.pictureBox3);
            this.panelDescripcionEstados.Controls.Add(this.pictureBox4);
            this.panelDescripcionEstados.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDescripcionEstados.Location = new System.Drawing.Point(0, 85);
            this.panelDescripcionEstados.Name = "panelDescripcionEstados";
            this.panelDescripcionEstados.Size = new System.Drawing.Size(800, 46);
            this.panelDescripcionEstados.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(376, 9);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 33;
            this.label5.Text = "Sin Carga:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(215, 9);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "Con Carga:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Red;
            this.pictureBox3.Location = new System.Drawing.Point(301, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.TabIndex = 34;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.Location = new System.Drawing.Point(457, 6);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(24, 24);
            this.pictureBox4.TabIndex = 35;
            this.pictureBox4.TabStop = false;
            // 
            // panelDataGridView
            // 
            this.panelDataGridView.Controls.Add(this.dataGridViewDocentes);
            this.panelDataGridView.Location = new System.Drawing.Point(0, 131);
            this.panelDataGridView.Name = "panelDataGridView";
            this.panelDataGridView.Size = new System.Drawing.Size(800, 214);
            this.panelDataGridView.TabIndex = 50;
            // 
            // dataGridViewDocentes
            // 
            this.dataGridViewDocentes.AllowUserToResizeRows = false;
            this.dataGridViewDocentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDocentes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dataGridViewDocentes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewDocentes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(73)))), ((int)(((byte)(113)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(73)))), ((int)(((byte)(113)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDocentes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDocentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDocentes.EnableHeadersVisualStyles = false;
            this.dataGridViewDocentes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(162)))), ((int)(((byte)(155)))));
            this.dataGridViewDocentes.Location = new System.Drawing.Point(40, 6);
            this.dataGridViewDocentes.MultiSelect = false;
            this.dataGridViewDocentes.Name = "dataGridViewDocentes";
            this.dataGridViewDocentes.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(220)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewDocentes.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewDocentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDocentes.Size = new System.Drawing.Size(684, 193);
            this.dataGridViewDocentes.TabIndex = 28;
            this.dataGridViewDocentes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDocentes_CellContentClick);
            // 
            // panelNota
            // 
            this.panelNota.Controls.Add(this.lblNota);
            this.panelNota.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelNota.Location = new System.Drawing.Point(0, 363);
            this.panelNota.Name = "panelNota";
            this.panelNota.Size = new System.Drawing.Size(800, 87);
            this.panelNota.TabIndex = 51;
            this.panelNota.Paint += new System.Windows.Forms.PaintEventHandler(this.panelNota_Paint);
            // 
            // lblNota
            // 
            this.lblNota.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNota.Location = new System.Drawing.Point(12, 3);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(622, 66);
            this.lblNota.TabIndex = 37;
            this.lblNota.Text = resources.GetString("lblNota.Text");
            this.lblNota.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VntDocentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelNota);
            this.Controls.Add(this.panelDataGridView);
            this.Controls.Add(this.panelDescripcionEstados);
            this.Controls.Add(this.panelBarraBusqueda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VntDocentes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VntDocentes";
            this.Load += new System.EventHandler(this.VntDocentes_Load);
            this.panelBarraBusqueda.ResumeLayout(false);
            this.panelBarraBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelDescripcionEstados.ResumeLayout(false);
            this.panelDescripcionEstados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panelDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocentes)).EndInit();
            this.panelNota.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBarraBusqueda;
        private System.Windows.Forms.TextBox txtboxBuscadorDocente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBoxEstadoDocente;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panelDescripcionEstados;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panelDataGridView;
        private System.Windows.Forms.DataGridView dataGridViewDocentes;
        private System.Windows.Forms.Panel panelNota;
        private System.Windows.Forms.Label lblNota;
    }
}