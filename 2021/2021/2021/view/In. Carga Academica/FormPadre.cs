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
    public partial class FormPadre : Form
    {
        bool VntAsignacion_Abierta;
        bool VntModificacion_Abierta;
        public FormPadre()
        {
            InitializeComponent();
            AbrirFormularioHijo(new VntAsignacionCargaAcademica());

            //Inicializamos los valores booleanos(estados de las ventanas)
            VntAsignacion_Abierta = true;
            VntModificacion_Abierta = false;
        }
        private void AbrirFormularioHijo(Form FrmHijo)
        {
            FrmHijo.TopLevel = false;
            FrmHijo.FormBorderStyle = FormBorderStyle.None;
            FrmHijo.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(FrmHijo);
            panelContenido.Tag = FrmHijo;
            FrmHijo.BringToFront();
            FrmHijo.Show();
        }

        

        private void buttonMenuAsignacion_Click(object sender, EventArgs e)
        {

            //Se verifica el estado en el que se encuentra la Ventana de Asignacion Carga Academica
            if (!VntAsignacion_Abierta)
            {
                if (VntModificacion_Abierta)
                    panelContenido.Controls.Clear();
                VntAsignacionCargaAcademica ventanaAsignacionCargaAcademica = new VntAsignacionCargaAcademica();
                AbrirFormularioHijo(ventanaAsignacionCargaAcademica);

                VntAsignacion_Abierta = true;
                VntModificacion_Abierta = false;

            }
        }

        private void buttonMenuModificar_Click(object sender, EventArgs e)
        {
            //Se verifica el estado en el que se encuentra la Ventana de Modificacion Carga Academica
            if (!VntModificacion_Abierta)
            {
                if (VntAsignacion_Abierta)
                    panelContenido.Controls.Clear();
                VntModificarCargaAcademica ventanaModificacionCargaAcademica = new VntModificarCargaAcademica();
                AbrirFormularioHijo(ventanaModificacionCargaAcademica);

                VntModificacion_Abierta = true;
                VntAsignacion_Abierta = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panelContenido_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
