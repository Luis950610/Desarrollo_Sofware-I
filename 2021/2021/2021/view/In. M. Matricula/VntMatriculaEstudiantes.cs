using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2021
{
    public partial class VntMatriculaEstudiantes : Form
    {
        CN_Matricula objetoCN_Matricula = new CN_Matricula();
        CN_Estudiante N_Estudiante = new CN_Estudiante();
        CE_Estudiante E_Estudiante = new CE_Estudiante();
        CN_Boleta N_Boleta = new CN_Boleta();
        CE_Boleta E_Boleta = new CE_Boleta();
        CN_CursoActivo N_CursoAct = new CN_CursoActivo();
        CE_CursoActivo E_CursoAct = new CE_CursoActivo();
        public VntMatriculaEstudiantes()
        {
            InitializeComponent();
            //refreshDataGridView();
        }
        

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }


        void Limpiar_Datos()
        {

            textCodigo.Text = "";
            textNombre.Text = "";
            textApMa.Text = "";
            textDNI.Text = "";
            textApPa.Text = "";
            textEmail.Text = "";
            textBuscar.Text = "";
            datetimeFechaEmision.Text = "";
            cnbCurso.Text = "";
            textNroSerie.Text = "";
            cnbTipoDscto.Text = "";
            textNroBoleta.Text = "";
            textCosto.Text = "";
            textPago.Text = "";
            textObs.Text = "";
            dataGridView1.DataSource = objetoCN_Matricula.N_Detalle_EstudianteMatriculado();
        }
        void Mantenimiento_Matricula(String accion)
        {
            E_Estudiante.Codigo = textCodigo.Text;
            E_Estudiante.Nombre = textNombre.Text;
            E_Estudiante.AppPaterno = textApPa.Text;
            E_Estudiante.AppMaterno = textApMa.Text;
            E_Estudiante.DNI = textDNI.Text;
            E_Estudiante.Email = textEmail.Text;
            E_Estudiante.accion = accion;


            E_Boleta.Codigo = textNroBoleta.Text;
            E_Boleta.FechaEmision = Convert.ToString(datetimeFechaEmision.Text);
            E_Boleta.NroSerie = textNroSerie.Text;
            E_Boleta.TipoDscto = cnbTipoDscto.Text;
            E_Boleta.CodCursoActivo = cnbCurso.Text;
            E_Boleta.Costo = float.Parse(textCosto.Text);
            E_Boleta.Pago = float.Parse(textPago.Text);
            E_Boleta.Observacion = textObs.Text;
            E_Boleta.accion = accion;
            E_Boleta.CodEstudiante = textCodigo.Text;
            String men = N_Estudiante.N_Manteniemiento_EstudianteMatriculado(E_Estudiante);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            String men1 = N_Boleta.N_Mantenimiento_BoletadeMatricula(E_Boleta);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_2(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;


            textCodigo.Text = dataGridView1[0, fila].Value.ToString();
            textNombre.Text = dataGridView1[1, fila].Value.ToString();
            textApMa.Text = dataGridView1[3, fila].Value.ToString();
            textDNI.Text = dataGridView1[4, fila].Value.ToString();
            textApPa.Text = dataGridView1[2, fila].Value.ToString();
            textEmail.Text = dataGridView1[5, fila].Value.ToString();
            //textBuscar.Text = dataGridView1[2, fila].Value.ToString();
            //datetimeFechaEmision.Text = dataGridView1[2, fila].Value.ToString();
            cnbCurso.Text = dataGridView1[1, fila].Value.ToString();
            textNroSerie.Text = dataGridView1[6, fila].Value.ToString();
            cnbTipoDscto.Text = dataGridView1[9, fila].Value.ToString();
            textNroBoleta.Text = dataGridView1[7, fila].Value.ToString();
            //textCosto.Text = dataGridView1[12, fila].Value.ToString();
            textPago.Text = dataGridView1[8, fila].Value.ToString();
            textObs.Text = dataGridView1[11, fila].Value.ToString();
            /*
            if (cnbTipoDscto.Text == "DCTO1")
            {
                textCosto.Text = (float.Parse(textPago.Text) - 20.00).ToString();
            }
            else if(cnbTipoDscto.Text == "DCTO2")
                    {
                textCosto.Text = (float.Parse(textPago.Text) - 15.00).ToString();
            }
            */


        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void Nuevo_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textCodigo.Text != "" && textNroBoleta.Text != "" && textApMa.Text != "" && textApPa.Text != "" && textDNI.Text != "" && textEmail.Text != "" && textNombre.Text != "" && textNroSerie.Text != "" && textPago.Text != "" && textObs.Text != "")
            {
                if (MessageBox.Show("¿Deseas modificar a " + textNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Mantenimiento_Matricula("1");
                    Limpiar_Datos();
                }
            }
            else { MessageBox.Show("Algunos Campos no se ingresaron", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

        }

        private void DateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void VntMatriculaEstudiantes_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = objetoCN_Matricula.N_Detalle_EstudianteMatriculado();

            cnbCurso.DataSource = N_CursoAct.N_Mostrar_CursoActivo();
            cnbCurso.DisplayMember = "Codigo";
            cnbCurso.ValueMember = "Codigo";
            cnbTipoDscto.DataSource = N_Boleta.N_Mostrar_TipoDescuento();
            cnbTipoDscto.DisplayMember = "TipoDsto";
            cnbTipoDscto.ValueMember = "TipoDsto";
            TM.Visible = false;
            textBox1.Visible = false;

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar_Datos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textCodigo.Text != "" && textNroBoleta.Text != "" && textApMa.Text != "" && textApPa.Text != "" && textDNI.Text != "" && textEmail.Text != "" && textNombre.Text != "" && textNroSerie.Text != "" && textPago.Text != "" && textObs.Text != "")
            {
                if (MessageBox.Show("¿Deseas modificar a " + textNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Mantenimiento_Matricula("2");
                    Limpiar_Datos();
                }
            }
            else { MessageBox.Show("Algunos Campos no se ingresaron", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (textBuscar.Text != "")
            {
                E_Estudiante.Codigo = textBuscar.Text;
                DataTable DT = new DataTable();
                DT = N_Estudiante.N_Buscar_EstudianteMatriculado(E_Estudiante);
                if (DT.Rows.Count > 0)
                {

                    dataGridView1.DataSource = DT;
                    int fila = dataGridView1.CurrentCell.RowIndex;


                    textCodigo.Text = dataGridView1[0, fila].Value.ToString();
                    textNombre.Text = dataGridView1[1, fila].Value.ToString();
                    textApMa.Text = dataGridView1[2, fila].Value.ToString();
                    textDNI.Text = dataGridView1[4, fila].Value.ToString();
                    textApPa.Text = dataGridView1[3, fila].Value.ToString();
                    textEmail.Text = dataGridView1[5, fila].Value.ToString();

                }
                else
                {
                    MessageBox.Show("No se registro estudiante " + textBuscar.Text);
                }


            }
            else
            {
                dataGridView1.DataSource = objetoCN_Matricula.N_Detalle_EstudianteMatriculado();
            }
        }

        private void textCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96 || e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void textApMa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96 || e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textApPa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96 || e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }


        private void textDNI_TextChanged(object sender, EventArgs e)
        {

            int DNI = Convert.ToInt32(textDNI.TextLength);
            if (DNI > 7)
            {
                MessageBox.Show("DNI tiene 8 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }



        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void cnbTipoDscto_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (cnbTipoDscto.Text == "DCTO1")
            {
                textCosto.Text = (Convert.ToInt32(textPago) - 10).ToString();
            }
            else if (cnbTipoDscto.Text == "DCTO2")
            {
                textCosto.Text = (Convert.ToInt32(textPago) - 20).ToString();
            }
            */
        }

        private void cnbTipoDscto_Click(object sender, EventArgs e)
        {
            if (cnbTipoDscto.Text == "DCTO1")
            {
                textCosto.Text = (float.Parse(textPago.Text) - 20.00).ToString();
            }
            else if (cnbTipoDscto.Text == "DCTO2")
            {
                textCosto.Text = (float.Parse(textPago.Text) - 15.00).ToString();
            }
        }

        private void textNroSerie_TextChanged(object sender, EventArgs e)
        {
            int DNI = Convert.ToInt32(textNroSerie.TextLength);
            if (DNI > 3)
            {
                MessageBox.Show("El numero de serie tiene 4 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
        }

        private void textNroBoleta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textNroSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textNroBoleta_TextChanged(object sender, EventArgs e)
        {
            int DNI = Convert.ToInt32(textNroBoleta.TextLength);
            if (DNI > 3)
            {
                MessageBox.Show("El numero de boleta tiene 4 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
        }

        private void textCodigo_TextChanged(object sender, EventArgs e)
        {

            int DNI = Convert.ToInt32(textCodigo.TextLength);

            if (DNI > 5)
            {
                MessageBox.Show("El codigo tiene 6 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }



        }

        private void textBuscar_TextChanged(object sender, EventArgs e)
        {

            int DNI = Convert.ToInt32(textCodigo.TextLength);
            if (DNI > 5)
            {
                MessageBox.Show("El codigo tiene 6 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }






        }

        private void textCodigo_Enter(object sender, EventArgs e)
        {
            if (textCodigo.Text != "")
            {
                E_Estudiante.Codigo = textCodigo.Text;
                DataTable DT = new DataTable();
                DT = N_Estudiante.N_Buscar_EstudianteMatriculado(E_Estudiante);
                if (DT.Rows.Count > 0)
                {

                    MessageBox.Show("El codigo ya fue registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    dataGridView1.DataSource = objetoCN_Matricula.N_Detalle_EstudianteMatriculado();
                }
            }

        }

        private void textCodigo_MouseEnter(object sender, EventArgs e)
        {

        }

        private void cnbCurso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }








        

        

        

        private void cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (textCodigo.Text != "" && textNroBoleta.Text != "" && textApMa.Text != "" && textApPa.Text != "" && textDNI.Text != "" && textEmail.Text != "" && textNombre.Text != "" && textNroSerie.Text != "" && textPago.Text != "" && textObs.Text != "" && TM.Text != "")
            {
                if (MessageBox.Show("¿Deseas modificar a " + textNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Mantenimiento_Matricula("1");
                    Limpiar_Datos();
                }
            }
            else { MessageBox.Show("Algunos Campos no se ingresaron", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

        }
        

        

        
        

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;


            textCodigo.Text = dataGridView1[0, fila].Value.ToString();
            textNombre.Text = dataGridView1[1, fila].Value.ToString();
            textApMa.Text = dataGridView1[3, fila].Value.ToString();
            textDNI.Text = dataGridView1[4, fila].Value.ToString();
            textApPa.Text = dataGridView1[2, fila].Value.ToString();
            textEmail.Text = dataGridView1[5, fila].Value.ToString();
            //textBuscar.Text = dataGridView1[2, fila].Value.ToString();
            //datetimeFechaEmision.Text = dataGridView1[2, fila].Value.ToString();
            cnbCurso.Text = dataGridView1[1, fila].Value.ToString();
            textNroSerie.Text = dataGridView1[6, fila].Value.ToString();
            cnbTipoDscto.Text = dataGridView1[9, fila].Value.ToString();
            textNroBoleta.Text = dataGridView1[7, fila].Value.ToString();
            //textCosto.Text = dataGridView1[12, fila].Value.ToString();
            textPago.Text = dataGridView1[8, fila].Value.ToString();
            textObs.Text = dataGridView1[11, fila].Value.ToString();
            /*
            if (cnbTipoDscto.Text == "DCTO1")
            {
                textCosto.Text = (float.Parse(textPago.Text) - 20.00).ToString();
            }
            else if(cnbTipoDscto.Text == "DCTO2")
                    {
                textCosto.Text = (float.Parse(textPago.Text) - 15.00).ToString();
            }
            */
        }

        private void TM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
