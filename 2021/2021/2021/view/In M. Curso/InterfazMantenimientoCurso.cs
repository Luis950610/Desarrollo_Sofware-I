using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capa_Entidad;
using Capa_Negocio;
namespace _2021
{
    public partial class InterfazMantenimientoCurso : Form
    {
        ClaseEntidad oEnt = new ClaseEntidad();
        ClaseNegocio oNeg = new ClaseNegocio(); 
        public InterfazMantenimientoCurso()
        {
            InitializeComponent();
        }

        void mantenimiento(String accion)
        {
            oEnt.CodigoCurso = txtcodigo.Text;
            oEnt.Nombre = txtnombre.Text;
            oEnt.Tipo = cbtipo.Text;
            oEnt.Temas = txttemas.Text;
            oEnt.HorasxSemana = Convert.ToInt32(txthoras.Text);
            oEnt.accion = accion;
            String men;
            bool x = false;

            if (accion == "1")
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if ((dataGridView1.Rows[i].Cells[1].Value).ToString() == txtnombre.Text)
                    {
                        x = true;
                        break;
                    }
                }
                if (x == false)
                {
                    men = oNeg.N_Mantenimineto_mCurso(oEnt);
                    MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("El nombre del curso ya existe", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                men = oNeg.N_Mantenimineto_mCurso(oEnt);
        }
        void limpiar()
        {
            txtcodigo.Text = "";
            txtnombre.Text = "";
            cbtipo.Text = "";
            txttemas.Text = "";
            txthoras.Text = "";
            txtbuscar.Text = "";
            dataGridView1.DataSource = oNeg.N_listar_mCurso();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtbuscar.Text != "")
            {
                oEnt.Nombre = txtbuscar.Text;
                DataTable DT = new DataTable();
                DT = oNeg.N_Buscar_mCurso(oEnt);
                dataGridView1.DataSource = DT;
            }
            else
            {
                dataGridView1.DataSource = oNeg.N_listar_mCurso();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Guardar();
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtcodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas eliminar a" + txtnombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("3");
                    limpiar();
                }
            }
        }

        private void bttmodificar_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas modificar a" + txtnombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("2");
                    limpiar();
                }
            }
        }
        private void bttnuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;
            txtcodigo.Text = dataGridView1[0, fila].Value.ToString();
            txtnombre.Text = dataGridView1[1, fila].Value.ToString();
            cbtipo.Text = dataGridView1[2, fila].Value.ToString();
            txttemas.Text = dataGridView1[3, fila].Value.ToString();
            txthoras.Text = dataGridView1[4, fila].Value.ToString();

            
        }

        private void MantenimientoCurso_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = oNeg.N_listar_mCurso();
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


        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void txthoras_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitira en ingreso de numeros
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Formato incorrecto", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitira en ingreso de letras

            SoloLetras(sender, e);
        }

        private void txttemas_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitira en ingreso de letras
            SoloLetras(sender, e);
        }
        public Boolean ValidarFormulario(Control Objeto, ErrorProvider ErrorProvider)
        {
            Boolean HayErrores = false;
            int i = 0;
            // Se analizara cada item del objeto
            foreach (Control Item in Objeto.Controls)
            {
                i++;
                
                if (Item is TextBox)
                {
                    TextBox Obj = (TextBox)Item;
                    

                    if ((Obj.Text == "") && (Obj.Enabled == true))
                    {
                        if (string.IsNullOrEmpty(Obj.Text.Trim()))
                        {
                            ErrorProvider.SetError(Obj, "No puede estar vacio");
                            HayErrores = true;
                        }
                    }
                    else
                    {
                        ErrorProvider.SetError(Obj, "");
                    }
                }

                if (Item is ComboBox)
                {
                    ComboBox Obj = (ComboBox)Item;

                    if (Obj.Text == "")
                    {
                        if (string.IsNullOrEmpty(Obj.Text.Trim()))
                        {
                            ErrorProvider.SetError(Obj, "No puede estar vacio");
                            HayErrores = true;
                        }
                    }
                    else
                    {
                        ErrorProvider.SetError(Obj, "");
                    }
                }
            }
            return HayErrores;
        }
        public void Guardar()
        {
            if (ValidarFormulario(groupBox2, errorProvider1) == false)
            {
                if (txtcodigo.Text == "")
                {
                    if (MessageBox.Show("¿Deseas Registrar " + txtnombre.Text + "?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        mantenimiento("1");
                        limpiar();
                    }
                }
            }
        }
        public void SoloLetras(object sender, KeyPressEventArgs e)
        {
            // solo se permitira el ingreso de letras
            if ((e.KeyChar > 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Formato incorrecto", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtcodigo2_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txttemas_TextChanged(object sender, EventArgs e)
        { 

            errorProvider1.Clear();
        }

        private void txthoras_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txttemas_TextChanged_1(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txthoras_TextChanged_1(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtbuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void cbtipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        
    }
}
