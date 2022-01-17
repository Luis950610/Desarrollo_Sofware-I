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
    public partial class VntAsignacionCargaAcademica : Form
    {
        /*Atributos*/
        private string aCodCurso;
        private string aNombre;
        private string aGrupo;
        private string aDescripcion;
        private string aPeriodo;
        private string aAño;

        private string aCodDocente;
        private string aNombreDocente;

        private int aSeparadorDiasHoras;

        private CN_CursosActivos objetoCN_CursosActivos;
        private CN_Docentes objetoCN_Docentes;
        private CN_CargaAcademica objetoCN_CargaAcademica;

        public VntAsignacionCargaAcademica()
        {
            InitializeComponent();
            //Se inicializa los atributos con valores nulos
            aCodCurso = null;
            aNombre = null;
            aGrupo = null;
            aCodDocente = null;
            aNombreDocente = null;
            aPeriodo = null;
            aAño = null;
            aDescripcion = null;

            objetoCN_CursosActivos = new CN_CursosActivos();
            objetoCN_Docentes = new CN_Docentes();
            objetoCN_CargaAcademica = new CN_CargaAcademica();

            refreshDataGridView();
        }
        public void refreshDataGridView()
        {
            // Cargar al data gridview los cursos que no fueron asignados
            dataGridViewCursosActivos.DataSource = objetoCN_CursosActivos.MostrarBuscarCursosxTodosLosCamposxCategorias(comboBoxTipo.Text, comboBoxPeriodo.Text, comboBoxAnio.Text, txtboxBuscadorCurso.Text);

            //Se deshabilita el buscador de docentes
            txtboxBuscadorDocente.Enabled = false;

            //Se carga la lista de todos los docentes
            dataGridViewDocentes2.DataSource = objetoCN_Docentes.MostrarBuscarDocentesDisponiblesxApellidosNombres("", "", "", "", txtboxBuscadorDocente.Text);

            //Se oculta la columna que contiene los codigos de los docentes
            dataGridViewDocentes2.Columns[0].Visible = false;

        }
        /*================ Textbox para Buscar Curso Activo =========================*/
        //Evento que realiza una accion cuando se entra al textbuscadorCurso
        

        private void btnMostrarHorario_Click(object sender, EventArgs e)
        {
            //Verificar si se seleccionaron filas de ambos datagridviews
            if (aCodCurso != null)//hay una fila seleccionada del datagridview cursos
            {
                if (aCodDocente != null)//hay una fila seleccionada de los docentes 
                {

                    //mostrar un mensaje de confirmacion de la carga academica
                    DialogResult dialogoAsignar = MessageBox.Show("Se Asignara el curso de " + aNombre + " para el(la) docente " + aNombreDocente + " ¿Desea Continuar?", "Asignar Carga Academica", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogoAsignar == DialogResult.Yes)                 //Se Asigna la Carga Academica
                    {
                        //Guardar Carga Academica
                        objetoCN_CargaAcademica.AgregarCargaAcademica(aCodCurso, aGrupo, aCodDocente, aPeriodo, aAño);
                        //Se muestra un mensaje de confirmacion
                        DialogResult dialogoAsignarCarga = MessageBox.Show("Asignacion Exitosa", "Mensaje de Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Actualizar los datagridviews
                        refreshDataGridView();
                        txtboxBuscadorCurso.Text = "Buscar...";
                        txtboxBuscadorDocente.Text = "Buscar...";
                    }




                }
                else   //no se selecciono una fila del datagridview docentes
                    MessageBox.Show("Por favor debe de seleccionar a un docente para Asignar la carga Academica", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
            else//no se selcciono una fila del datagridview cursos
            {
                MessageBox.Show("Por favor debe de seleccionar un curso para Asignar la Carga Academica", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridViewDocentes2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si se selecciona una fila dentro del datagridview
            if (e.RowIndex >= 0)
            {

                aCodDocente = dataGridViewDocentes2.Rows[e.RowIndex].Cells["Codigo_Docente"].FormattedValue.ToString();
                aNombreDocente = dataGridViewDocentes2.Rows[e.RowIndex].Cells["Docentes_Disponibles"].FormattedValue.ToString();
            }
        }

        private void txtboxBuscadorDocente_TextChanged(object sender, EventArgs e)
        {
            if (txtboxBuscadorDocente.Text != "")
            {

                //Buscar todos los docentes disponibles para ese horario
                dataGridViewDocentes2.DataSource = objetoCN_Docentes.MostrarBuscarDocentesDisponiblesxApellidosNombres(aDescripcion.Substring(aSeparadorDiasHoras + 1), aPeriodo, aAño, aDescripcion.Substring(0, aSeparadorDiasHoras), txtboxBuscadorDocente.Text);
            }
            else if (txtboxBuscadorDocente.Text == "")
            {
                //Buscar todos los docentes disponibles para ese horario
                dataGridViewDocentes2.DataSource = objetoCN_Docentes.MostrarBuscarDocentesDisponiblesxApellidosNombres(aDescripcion.Substring(aSeparadorDiasHoras + 1), aPeriodo, aAño, aDescripcion.Substring(0, aSeparadorDiasHoras), txtboxBuscadorDocente.Text);

            }
        }

        private void dataGridViewCursosActivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //Al seleccionar un celda tambien se debe de seleccionar el check

            if (e.RowIndex >= 0)
            {
                //Al seleccionar una fila se autoselecciona el checkbutton y se deseleccionan los otros checkbuttons
                for (int i = 0; i < dataGridViewCursosActivos.RowCount; i++)
                {
                    dataGridViewCursosActivos.Rows[i].Cells[0].Value = false;
                }
                // Se inicializan las variables
                dataGridViewCursosActivos.Rows[e.RowIndex].Cells[0].Value = true;
                aCodCurso = dataGridViewCursosActivos.Rows[e.RowIndex].Cells["Codigo_CursoActivo"].FormattedValue.ToString();
                aGrupo = dataGridViewCursosActivos.Rows[e.RowIndex].Cells["Grupo"].FormattedValue.ToString();
                aPeriodo = dataGridViewCursosActivos.Rows[e.RowIndex].Cells["Periodo"].FormattedValue.ToString();
                aAño = dataGridViewCursosActivos.Rows[e.RowIndex].Cells["Año"].FormattedValue.ToString();
                aDescripcion = dataGridViewCursosActivos.Rows[e.RowIndex].Cells["DescripcionHorario"].FormattedValue.ToString();
                aNombre = dataGridViewCursosActivos.Rows[e.RowIndex].Cells["Nombre"].FormattedValue.ToString();

                //Agregado:
                //Extraer los dias y la Hora
                aSeparadorDiasHoras = aDescripcion.IndexOf(":");

                //Se habilita el buscador de docentes
                txtboxBuscadorDocente.Enabled = true;

                //Mostrar Docentes disponibles para ese curso seleccionado
                dataGridViewDocentes2.DataSource = objetoCN_Docentes.MostrarBuscarDocentesDisponiblesxApellidosNombres(aDescripcion.Substring(aSeparadorDiasHoras + 1), aPeriodo, aAño, aDescripcion.Substring(0, aSeparadorDiasHoras), txtboxBuscadorDocente.Text);

            }

        }

        private void txtboxBuscadorCurso_TextChanged(object sender, EventArgs e)
        {
            if (txtboxBuscadorCurso.Text != "")
            {
                //Buscar los cursos sin carga academica
                dataGridViewCursosActivos.DataSource = objetoCN_CursosActivos.MostrarBuscarCursosxTodosLosCamposxCategorias(comboBoxTipo.Text, comboBoxPeriodo.Text, comboBoxAnio.Text, txtboxBuscadorCurso.Text);
            }
            else if (txtboxBuscadorCurso.Text == "")
            {
                //Buscar los cursos sin carga academica
                dataGridViewCursosActivos.DataSource = objetoCN_CursosActivos.MostrarBuscarCursosxTodosLosCamposxCategorias(comboBoxTipo.Text, comboBoxPeriodo.Text, comboBoxAnio.Text, txtboxBuscadorCurso.Text);
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }


        






        /*Modulo para refrescar los datagridviews*/
       

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }


        /*================ Textbox para Buscar Curso Activo =========================*/
        //Evento que realiza una accion cuando se entra al textbuscadorCurso
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtboxBuscadorCurso.Text == "Buscar...")
            {
                txtboxBuscadorCurso.Text = "";
                txtboxBuscadorCurso.ForeColor = Color.FromArgb(29, 29, 29);
            }
        }

        //Evento que realiza una accion cuando el cursor sale del textbuscadorCurso
        private void txtboxBuscadorCurso_Leave(object sender, EventArgs e)
        {
            if (txtboxBuscadorCurso.Text == "")
            {
                txtboxBuscadorCurso.Text = "Buscar...";
                txtboxBuscadorCurso.ForeColor = Color.FromArgb(29, 29, 29);
            }
        }




        /*================Textbox para Buscar Docente=========================*/
        //Evento que realiza una accion cuando se entra al textboxBuscadorDocente
        private void txtboxBuscadorDocente_Enter(object sender, EventArgs e)
        {
            //Si el txtbox contiene la cadena Buscar que se cambie por una cadena vacia
            if (txtboxBuscadorDocente.Text == "Buscar...")
            {
                txtboxBuscadorDocente.Text = "";
                txtboxBuscadorDocente.ForeColor = Color.FromArgb(29, 29, 29);
            }

        }

        //Evento que realiza una accion cuando el cursor sale del textbox BuscadorDocente
        private void txtboxBuscadorDocente_Leave(object sender, EventArgs e)
        {
            //Si el txtbox contiene la cadena vacia al dejar el cuadro que se cambie por la cadena Buscar
            if (txtboxBuscadorDocente.Text == "")
            {
                txtboxBuscadorDocente.Text = "Buscar...";
                txtboxBuscadorDocente.ForeColor = Color.FromArgb(29, 29, 29);
            }
        }



        /*========================== Textbox para el buscador de los cursos ========================*/
        //Evento que realiza una accion cuando cambian los caracteres dentro del textbox BuscadorCurso
        

        //Evento que realiza una accion cuando cambian los caracteres dentro del textbox BuscadorDocente
       
        
        //boton de modificar carga academica
        private void button3_Click(object sender, EventArgs e)
        {
            VntModificarCargaAcademica ventanaSiguiente = new VntModificarCargaAcademica();
            ventanaSiguiente.Show();
            Close();
        }

        

        //al cambiar el valor del combobox se debe de refrescar la tabla
        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshDataGridView();
        }
        //Al cambiar el valor del combobox Año se refresaca la tabla
        private void comboBoxAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshDataGridView();
        }
        //Al cambiar el valor del combobox Perido se refresaca la tabla
        private void comboBoxPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshDataGridView();
        }


        
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
