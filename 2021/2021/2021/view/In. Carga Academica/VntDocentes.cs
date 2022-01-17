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
    public partial class VntDocentes : Form
    {
        /*Atributos*/
        private CN_Docentes objetoCN_Docentes;
        private string aAño;
        private string aPeriodo;
        private string aHora;
        private string aDias;

        private string aCodDocente;
        private string aNombreDocente;

        /*Constructor del formu VntDocentes*/
        public VntDocentes()
        {
            InitializeComponent();
            //Se oculta los panaeles de informacion 
            panelDescripcionEstados.Visible = false;
            panelNota.Visible = false;
            //Se inicializa los atributos de la clase
            aAño = null;
            aPeriodo = null;
            aHora = null;
            aDias = null;
            aCodDocente = null;
            aNombreDocente = null;

            objetoCN_Docentes = new CN_Docentes();

            //Se carga la tabla que contiene a los docentes
            refreshDataGridView();
        }

        /*Constructor de la ventan Docentes con parametros*/
        public VntDocentes(string pAño, string pPeriodo, string pHora, string pDias)
        {
            InitializeComponent();
            //Se oculta los panaeles de informacion 
            panelDescripcionEstados.Visible = false;
            panelNota.Visible = false;
            //asignacion de atributos
            aAño = pAño;
            aPeriodo = pPeriodo;
            aHora = pHora;
            aDias = pDias;

            aCodDocente = null;
            aNombreDocente = null;

            objetoCN_Docentes = new CN_Docentes();
            //Se carga la tabla que contiene a los docentes
            refreshDataGridView();
        }

        //Metodo para devolver el codigo del docente seleccionado:
        public string CodDocenteSeleccionado()
        {
            return aCodDocente;
        }
        //Metodo para devolver el nombre completo del docente seleccionado:
        public string NombreCompletoDocenteSeleccionado()
        {
            return aNombreDocente;
        }
        #region Metodos
        public void refreshDataGridView()
        {
            //Cargar la tabla que contiene a los docentes
            dataGridViewDocentes.DataSource = objetoCN_Docentes.MostrarBuscarDocentesDisponiblesyNoDisponiblesxApellidosNombres(aHora, aPeriodo, aAño, aDias, txtboxBuscadorDocente.Text);
            //Ocultar las columnas que contienen el codigo y el estado del docente
            dataGridViewDocentes.Columns[0].Visible = false;
            dataGridViewDocentes.Columns[2].Visible = false;

        }
        #endregion Metodos
        /*Evento que realiza la accion de cerrar la ventana Docentes*/
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /*Evento que realiza una accion cuando cambian los caracteres dentro del textbox BuscadorDocente*/
        private void txtboxBuscadorDocente_TextChanged(object sender, EventArgs e)
        {
            //Buscar docentes 
            dataGridViewDocentes.DataSource = objetoCN_Docentes.MostrarBuscarDocentesDisponiblesyNoDisponiblesxApellidosNombres(aHora, aPeriodo, aAño, aDias, txtboxBuscadorDocente.Text);

        }

        /*Evento que realiza la accion de mostrar a docentes disponibles y no disponibles*/
        private void comboBoxEstadoDocente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Si se selecciona en el combobox Todos
            if (comboBoxEstadoDocente.Text == "Todos")  //Mostrar las notas de aclaracion 
            {
                panelDescripcionEstados.Visible = true;
                panelNota.Visible = true;
            }
            else// Si se selecciona en el combobox Disponibles, ocultar las notas
            {
                panelDescripcionEstados.Visible = false;
                panelNota.Visible = false;
            }
        }

        /*Evento que realiza una accion al pulsar dos veces sobre el datagridview*/
        private void dataGridViewDocentes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //se asigna estos valores a los atributos para luego ser devueltos
            aCodDocente = dataGridViewDocentes.Rows[e.RowIndex].Cells["CodDocente"].FormattedValue.ToString();
            aNombreDocente = dataGridViewDocentes.Rows[e.RowIndex].Cells["Docentes"].FormattedValue.ToString();
            //Luego de haber realizado doble click, se cierra la ventana
            this.Close();
        }


        /*Evento que realiza la accion de modificar los colers de las filas del datagridview*/
        private void dataGridViewDocentes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /*Recorrer todas las filas del datagridview*/
            foreach (DataGridViewRow Myrow in dataGridViewDocentes.Rows)
            {
                if (Convert.ToString(Myrow.Cells[2].Value) == "CON CARGA") //Si el docente se encuentra con carga
                {
                    if (comboBoxEstadoDocente.Text == "Disponibles")//Si la opcion del combobox es "Disponibles" 
                    {
                        //Ocultar las filas que contienen carga academica

                        Myrow.Visible = false;
                    }

                    else //Si se selecciona la otra opcion "Todos"
                    {
                        //Mostrar las filas marcadas con color rojo
                        Myrow.DefaultCellStyle.BackColor = Color.Red;
                        Myrow.Visible = true;
                    }

                }
                else //Si el docente no se encuentra con carga academica pintar las filas de color blanco
                {
                    Myrow.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void VntDocentes_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxEstadoDocente_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //Si se selecciona en el combobox Todos
            if (comboBoxEstadoDocente.Text == "Todos")  //Mostrar las notas de aclaracion 
            {
                panelDescripcionEstados.Visible = true;
                panelNota.Visible = true;
            }
            else// Si se selecciona en el combobox Disponibles, ocultar las notas
            {
                panelDescripcionEstados.Visible = false;
                panelNota.Visible = false;
            }

        }

        private void txtboxBuscadorDocente_TextChanged_1(object sender, EventArgs e)
        {
            //Buscar docentes 
            dataGridViewDocentes.DataSource = objetoCN_Docentes.MostrarBuscarDocentesDisponiblesyNoDisponiblesxApellidosNombres(aHora, aPeriodo, aAño, aDias, txtboxBuscadorDocente.Text);

        }

        private void dataGridViewDocentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        

        private void panelNota_Paint(object sender, PaintEventArgs e)
        {

        }



        /*Evento que realiza una accion cuando se entra al textBuscadorDocente*/
        private void txtboxBuscadorDocente_Enter(object sender, EventArgs e)
        {
            if (txtboxBuscadorDocente.Text == "Buscar...")
            {
                txtboxBuscadorDocente.Text = "";
                txtboxBuscadorDocente.ForeColor = Color.FromArgb(29, 29, 29);
            }
        }

        /*Evento que realiza una accion cuando el cursor sale del textbuscadorCurso*/
        private void txtboxBuscadorDocente_Leave(object sender, EventArgs e)
        {
            if (txtboxBuscadorDocente.Text == "")
            {
                txtboxBuscadorDocente.Text = "Buscar...";
                txtboxBuscadorDocente.ForeColor = Color.FromArgb(29, 29, 29);
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void panelBarraBusqueda_Paint(object sender, PaintEventArgs e)
        {

        }
        
        
    }
}
