using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//activamos referencias que necesitamos en esta capa
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace _2021
{
    public partial class Interfaz_Activar : Form
    {
        conexion conexion = new conexion();
        public Interfaz_Activar()
        {
            InitializeComponent();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BActivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(TBNroAlumnos.Text) < 10)
                {
                    MessageBox.Show("Verifique el número de alumnos antes de ACTIVAR");
                }
                else
                {
                    conexion conexion = new conexion();

                    string EstadoCodigo;
                    EstadoCodigo = TBCodigo.Text;
                    //Consulta en base de datos

                    //string consulta = "exec pActulizarEstado '" + EstadoCodigo + "', 'ACTIVADO'";      ///   ACTUALIZAR
                    string consulta = "INSERT INTO CursoActivo VALUES('" + TBCodigo.Text + "','" + TBGrupo.Text + "','" + TBNombre.Text + "','" + TBTema.Text + "','" + TBTipo.Text + "','" + TBHoras.Text + "','" + CBDia.SelectedItem.ToString() + "','" + TBHorario.Text + "','" + CBPeriodo.SelectedItem.ToString() + "','" + CBAnio.SelectedItem.ToString() + "')";
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.LeerCadena());
                    DataTable DT = new DataTable();
                    adaptador.Fill(DT);
                    dataGridView1.DataSource = DT;
                    //Segunda consulta
                    string consulta2 = "exec pActulizarEstado '" + EstadoCodigo + "', 'ACTIVADO'";      ///   ACTUALIZAR
                    SqlDataAdapter adaptador2 = new SqlDataAdapter(consulta2, conexion.LeerCadena());
                    DataTable DT2 = new DataTable();
                    adaptador2.Fill(DT2);
                    dataGridView1.DataSource = DT2;

                    MessageBox.Show("Curso ACTIVADO Exitosamente");
                    //Completar TextBox con datos de curso
                    CompletarTextBoxCodigo();
                    //Completar lista de alumnos
                    CompletarListaAlumnos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void CompletarTextBoxCodigo()
        {
            //conexion conexion = new conexion();
            string consulta2 = "exec pRecuperarCursoCodigo '" + TBBuscar.Text + "'";
            SqlCommand comando = new SqlCommand(consulta2, conexion.LeerCadena());
            SqlDataReader lector;
            lector = comando.ExecuteReader();

            if (lector.Read())
            {
                CompletarCampos(lector);
            }
            conexion.LeerCadena();
        }

        public void CompletarTextBoxNombre()
        {
            conexion.LeerCadena();
            string consulta2 = "exec pRecuperarCursoNombre '" + TBBuscar.Text + "', '" + CBGrupo.SelectedItem.ToString() + "'";
            SqlCommand comando = new SqlCommand(consulta2, conexion.LeerCadena());
            SqlDataReader lector;

            lector = comando.ExecuteReader();

            if (lector.Read())
            {
                CompletarCampos(lector);
            }
            conexion.LeerCadena();
        }

        public void CompletarListaAlumnos()
        {

            string consulta = "exec pListaAlumnos '" + TBCodigo.Text + "'";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.LeerCadena());
            DataTable DT = new DataTable();
            adaptador.Fill(DT);
            dataGridView1.DataSource = DT;
            conexion.LeerCadena();
        }
        public void CompletarCampos(SqlDataReader lector)
        {
            TBCodigo.Text = lector["Codigo_Curso"].ToString();
            TBNombre.Text = lector["Nombre_Curso"].ToString();
            TBTipo.Text = lector["Tipo_Curso"].ToString();
            TBGrupo.Text = lector["Grupo"].ToString();
            TBHorario.Text = lector["Horario"].ToString();
            TBEstado.Text = lector["Estado"].ToString();
            TBHoras.Text = lector["Horas"].ToString();
            TBTema.Text = lector["Temas"].ToString();
            TBNroAlumnos.Text = lector["NroAlumno"].ToString();


        }

        private void BDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(TBNroAlumnos.Text) > 10)
                {
                    MessageBox.Show("Verifique el número de alumnos antes de DESACTIVAR");
                }
                else
                {
                    
                    string EstadoCodigo;
                    EstadoCodigo = TBCodigo.Text;
                    //Consulta en base de datos
                    string consulta = "exec pActulizarEstado '" + EstadoCodigo + "', 'DESACTIVADO'";  /// ACTUALIZAR FORNA DE ACCESO A SQL SERVER
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.LeerCadena());
                    DataTable DT = new DataTable();
                    adaptador.Fill(DT);
                    dataGridView1.DataSource = DT;
                    MessageBox.Show("Curso DESACTIVADO Exitosamente");

                    //Completar TextBox con datos de curso
                    CompletarTextBoxCodigo();
                    //Completar lista de alumnos
                    CompletarListaAlumnos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BCActivados_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar_Campos();
                //Consulta en base de datos
                string consulta = "select * from CursoActivo";  /// ACTUALIZAR A MODULO
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.LeerCadena());
                DataTable DT = new DataTable();
                adaptador.Fill(DT);
                dataGridView1.DataSource = DT;
                conexion.LeerCadena();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void Limpiar_Campos()
        {
            TBNombre.Clear();
            TBCodigo.Clear();
            TBTema.Clear();
            TBTipo.Clear();
            TBGrupo.Clear();
            TBHorario.Clear();
            TBEstado.Clear();
            TBHoras.Clear();
            TBBuscar.Clear();
            TBNroAlumnos.Clear();
            TBBuscar.Focus();
            dataGridView1.DataSource = null;

            CBDia.SelectedIndex = 0;
            CBPeriodo.SelectedIndex = 0;
            CBAnio.SelectedIndex = 0;
            CBGrupo.SelectedIndex = 0;

        }

        private void BCDesactivados_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar_Campos();

                //Consulta en base de datos
                string consulta = "exec pListarCursos 'DESACTIVADO'";   /// ACTUALIZAR A MODULO
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.LeerCadena());
                DataTable DT = new DataTable();
                adaptador.Fill(DT);
                dataGridView1.DataSource = DT;
                conexion.LeerCadena();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Operaciones operaciones = new Operaciones();
                if (TBBuscar.Text != "")
                {
                    if (RBCodigo.Checked == true)
                    {
                        if (operaciones.VerificarCodigo(TBBuscar.Text))
                        {
                            //Completar TextBox con datos de curso
                            CompletarTextBoxCodigo();
                            //Completar lista de alumnos
                            CompletarListaAlumnos();
                        }
                        else
                        {
                            MessageBox.Show("ERROR!, Ingrese un código válido");
                        }
                    }
                    else
                    {
                        if (RBNombre.Checked == true)
                        {
                            //Completar TextBox con datos de curso
                            CompletarTextBoxNombre();
                            //Completar lista de alumnos
                            CompletarListaAlumnos();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Complete el campo de búsqueda");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar_Campos();
        }

        private void TBNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void Interfaz_Activar_Load_1(object sender, EventArgs e)
        {
            CBGrupo.DropDownStyle = ComboBoxStyle.DropDownList;

            //Inicializar combobox grupo
            CBGrupo.Items.Add("A");
            CBGrupo.Items.Add("B");
            CBGrupo.Items.Add("C");
            CBGrupo.SelectedIndex = 0;

            //ComboBox periodo
            CBPeriodo.Items.Add("Enero");
            CBPeriodo.Items.Add("Febrero");
            CBPeriodo.Items.Add("Marzo");
            CBPeriodo.Items.Add("Abril");
            CBPeriodo.Items.Add("Mayo");
            CBPeriodo.Items.Add("Junio");
            CBPeriodo.Items.Add("Julio");
            CBPeriodo.Items.Add("Agosto");
            CBPeriodo.Items.Add("Setiembre");
            CBPeriodo.Items.Add("Octubre");
            CBPeriodo.Items.Add("Noviembre");
            CBPeriodo.Items.Add("Diciembre");
            CBPeriodo.SelectedIndex = 0;

            //ComboBox Año
            CBAnio.Items.Add("2022");
            CBAnio.Items.Add("2021");
            CBAnio.Items.Add("2020");
            CBAnio.Items.Add("2019");
            CBAnio.Items.Add("2018");
            CBAnio.SelectedIndex = 0;

            //ComboBox Dia
            CBDia.Items.Add("Lunes");
            CBDia.Items.Add("Martes");
            CBDia.Items.Add("Miercoles");
            CBDia.Items.Add("Jueves");
            CBDia.Items.Add("Viernes");
            CBDia.Items.Add("Sabado");
            CBDia.SelectedIndex = 0;

            RBCodigo.Checked = true;
        }
    }
}
