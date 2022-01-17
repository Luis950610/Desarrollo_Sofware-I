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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Close();
        }

        

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void docente_Click(object sender, EventArgs e)
        {
            InDocente a = new InDocente();
            a.ShowDialog();
        }

        private void Estudiante_Click(object sender, EventArgs e)
        {
            FormMantenimientoEstudiante t = new FormMantenimientoEstudiante();
            t.ShowDialog();
        }

        private void curso_Click(object sender, EventArgs e)
        {
            InterfazMantenimientoCurso t = new InterfazMantenimientoCurso();
            //InMC t = new InMC();
            t.Show();

        }

        private void activacion_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Interfaz_Activar nuevo = new Interfaz_Activar();
            nuevo.Show();
        }

        private void matricula_Click(object sender, EventArgs e)
        {
            VntMatriculaEstudiantes vntnAsignacion = new VntMatriculaEstudiantes();
            vntnAsignacion.Show();
        }

        private void Asignacion_Click(object sender, EventArgs e)
        {
            FormPadre Formulario = new FormPadre();
            Formulario.Show();
        }

        private void ButtonTM_Click(object sender, EventArgs e)
        {
            InTipoMatricula tm = new InTipoMatricula();
            tm.ShowDialog();
        }
    }
}
