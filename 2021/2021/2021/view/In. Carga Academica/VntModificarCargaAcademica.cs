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
    public partial class VntModificarCargaAcademica : Form
    {
        /*Atributos*/
        private string aTipo;
        private string aAño;
        private string aPeriodo;
        private string aHora;
        private string aDias;
        private string aCodCurso;
        private string aCodCargaAcademica;
        private string aNombre;
        private string aGrupo;
        private string aCodDocente;
        private string aNombreDocente;

        private string aCodDocenteNuevo;
        private string aNombreDocenteNuevo;

        private CN_CargaAcademica objetoCN_CargaAcademica;
        public VntModificarCargaAcademica()
        {
            InitializeComponent();
            aTipo = null;
            aAño = null;
            aPeriodo = null;
            aHora = null;
            aDias = null;
            aCodCurso = null;
            aCodCargaAcademica = null;
            aNombre = null;
            aGrupo = null;
            aCodDocente = null;
            aNombreDocente = null;

            aCodDocenteNuevo = null;
            aNombreDocenteNuevo = null;

            objetoCN_CargaAcademica = new CN_CargaAcademica();
            //Ocultamos el boton para guardar y/o actualizar la carga academica
            btnGuardarCambios.Visible = false;
            pictureBoxGuardar.Visible = false;
            //Refrescar el datagridview que contiene las cargas academicas
            refreshDataGridView();
        }
        public void refreshDataGridView()
        {
            dataGridViewCargaAcademica2.DataSource = objetoCN_CargaAcademica.MostrarCargaAcademicaxTodosLosCamposxCategorias(comboBoxTipo.Text, comboBoxPeriodo.Text, comboBoxAnio.Text, txtboxBuscadorCargaAcademica.Text);
            dataGridViewCargaAcademica2.Columns[2].Visible = false;
        }

        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshDataGridView();
        }

        private void comboBoxAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshDataGridView();
        }

        private void comboBoxPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshDataGridView();
        }

        private void txtboxBuscadorCargaAcademica_TextChanged(object sender, EventArgs e)
        {
            if (txtboxBuscadorCargaAcademica.Text != "")
            {
                //cargar las cargas academicas que cumplan con las caracteristicas
                dataGridViewCargaAcademica2.DataSource = objetoCN_CargaAcademica.MostrarCargaAcademicaxTodosLosCamposxCategorias(comboBoxTipo.Text, comboBoxPeriodo.Text, comboBoxAnio.Text, txtboxBuscadorCargaAcademica.Text);

            }
            else if (txtboxBuscadorCargaAcademica.Text == "")
            {


            }
        }

        private void dataGridViewCargaAcademica2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)           //Si se selecciona una fila dentro del datagridview
            {
                //Se elimina los contenidos de los textbox
                txtboxCodCurso.Text = "";
                txtboxDocente.Text = "";
                txtboxGrupo.Text = "";
                txtboxNombre.Text = "";
                //Se asignan los nuevos valores a los atributos de este formulario
                dataGridViewCargaAcademica2.CurrentRow.Selected = true;
                aCodCurso = dataGridViewCargaAcademica2.Rows[e.RowIndex].Cells["Codigo_CursoActivo"].FormattedValue.ToString();
                aNombre = dataGridViewCargaAcademica2.Rows[e.RowIndex].Cells["Nombre"].FormattedValue.ToString();
                aGrupo = dataGridViewCargaAcademica2.Rows[e.RowIndex].Cells["Grupo"].FormattedValue.ToString();
                aNombreDocente = dataGridViewCargaAcademica2.Rows[e.RowIndex].Cells["Docentes"].FormattedValue.ToString();
                string pDescripcion = dataGridViewCargaAcademica2.Rows[e.RowIndex].Cells["Descripcion"].FormattedValue.ToString();
                aDias = pDescripcion.Substring(0, pDescripcion.IndexOf(":")).ToUpper();
                aHora = pDescripcion.Substring(pDescripcion.IndexOf(":") + 1);
                aAño = comboBoxAnio.Text;
                aCodCargaAcademica = dataGridViewCargaAcademica2.Rows[e.RowIndex].Cells["CodCargAcademica"].FormattedValue.ToString();

                if (e.ColumnIndex >= 0 && dataGridViewCargaAcademica2.Columns[e.ColumnIndex].Name == "Editar2")      //Si se selecciona la columna para editar
                {
                    dataGridViewCargaAcademica2.CurrentRow.Selected = true;
                    txtboxCodCurso.Text = aCodCurso;
                    txtboxNombre.Text = aNombre;
                    txtboxGrupo.Text = aGrupo;
                    txtboxDocente.Text = aNombreDocente;

                    //Deshabilitar los controles
                    txtboxCodCurso.Enabled = false;
                    txtboxNombre.Enabled = false;
                    txtboxGrupo.Enabled = false;
                }
                if (e.ColumnIndex >= 0 && dataGridViewCargaAcademica2.Columns[e.ColumnIndex].Name == "Eliminar2") //se selecciona la columna para eliminar
                {
                    dataGridViewCargaAcademica2.CurrentRow.Selected = true;

                    //mostrar un mensaje preguntando si esta seguro de eliminar la carga academica seleccionada
                    DialogResult dialogoEliminar = MessageBox.Show("¿Esta Seguro de Eliminar la asignacion de carga academica del curso " + aNombre + " con codigo " + aCodCurso + " ?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (dialogoEliminar == DialogResult.OK)//Eliminar la carga academica y refreshear el datagridview
                    {
                        objetoCN_CargaAcademica.ElimnarCargaAcademica(aCodCargaAcademica);
                        refreshDataGridView();
                    }
                    if (dialogoEliminar == DialogResult.Cancel)//No eliminar la carga academica
                    {
                        refreshDataGridView();
                    }

                }
            }

        }

        private void btnMostrarDocentes_Click(object sender, EventArgs e)
        {
            //Se abre una ventana que muestra una lista de docentes disponibles para un determinado horario
            aPeriodo = comboBoxPeriodo.Text.ToUpper();

            //Validar que se haya seleccionado una fila para editar
            if (txtboxCodCurso.Text != "")
            {
                //Se abre la ventana Docentes
                VntDocentes VentanaDocentes = new VntDocentes(aAño, aPeriodo.ToUpper(), aHora, aDias);
                VentanaDocentes.ShowDialog();

                //Se recupera el docente seleccionado y se almacena en los atributos de este formulario
                aCodDocenteNuevo = VentanaDocentes.CodDocenteSeleccionado();
                aNombreDocenteNuevo = VentanaDocentes.NombreCompletoDocenteSeleccionado();


                //Se verifica si el codigo del docente seleccionado es null
                if (aCodDocenteNuevo == null)      //Entonces no se selecciono ningun docente
                {
                    //Que la tecla guardar no se visualize
                    btnGuardarCambios.Visible = false;
                    pictureBoxGuardar.Visible = false;
                }
                else        //Se seleeciono un nuevo docente
                {
                    //Que la tecla guardar se visualize
                    btnGuardarCambios.Visible = true;
                    pictureBoxGuardar.Visible = true;
                    // Se actualliza el nombre del docente en el txtbox
                    txtboxDocente.Text = aNombreDocenteNuevo;
                }
            }
            else
            {
                DialogResult dialogoAsignar = MessageBox.Show("Para modificar una carga academica primero debe de pulsar sobre el icono de color verde", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            //mostrar un mensaje de confirmacion para la actualizacion de la carga Academica
            DialogResult dialogoActualizar = MessageBox.Show("¿Esta Seguro(a) de actualizar  la asignacion de carga Academica para el curso " + aNombre + " con codigo : " + aCodCurso + " del grupo : " + aGrupo + " para el periodo : " + aPeriodo + " Año : " + aAño + " ?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogoActualizar == DialogResult.OK)       //Actualizar la carga academica y refreshear el datagridview
            {
                // Se actualiza la carga academica con el nuevo docente selecionado
                objetoCN_CargaAcademica.ActualizarCargaAcademica(aCodCargaAcademica, aCodCurso, aGrupo, aCodDocenteNuevo, aPeriodo, aAño);
                refreshDataGridView();
            }
            if (dialogoActualizar == DialogResult.Cancel)   //No actualizar la carga academica
            {
                refreshDataGridView();
            }
        }



        /*Modulo para refrescar el datagridview de las cargas academicas*/
        
        /*Al ingresar al textbox Buscador de Carga Academica si el texto contiene la cadena Buscar, reemplazar por una cadena vacia*/
        private void txtboxBuscadorCargaAcademica_Enter(object sender, EventArgs e)
        {
            if (txtboxBuscadorCargaAcademica.Text == "Buscar...")
            {
                txtboxBuscadorCargaAcademica.Text = "";
                txtboxBuscadorCargaAcademica.ForeColor = Color.FromArgb(29, 29, 29);
            }
        }
        /*Al dejar el textbox Buscador de Carga Acadmeica si el texto contiene una cadena Vacia , cambiar por la cadena Buscar*/
        private void txtboxBuscadorCargaAcademica_Leave(object sender, EventArgs e)
        {
            if (txtboxBuscadorCargaAcademica.Text == "")
            {
                txtboxBuscadorCargaAcademica.Text = "Buscar...";
                txtboxBuscadorCargaAcademica.ForeColor = Color.FromArgb(29, 29, 29);
            }
        }

        /*Al excribir sobre el buscador*/
        


        private void btnVentanaAsignacionCarga_Click(object sender, EventArgs e)
        {
            VntAsignacionCargaAcademica ventanaSiguiente = new VntAsignacionCargaAcademica();
            ventanaSiguiente.Show();
            Close();
        }

        private void VntModificarCargaAcademica_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
