using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
namespace _2021
{
    public class CD_CargaAcademica
    {

        /*Conectar el proyecto con la base de datos mediante la cadena de conexion que se establecio en el AppConfig */
         

        /*Metodo para ejecutar el procedimiento almacenado SP_SeleccionCargaAcademica de la base de datos*/
        public DataTable SelectCargaAcademica()
        {
            //Se crea una instancia para almacenar los registros al ejecutar el procedimiento almacenado
            SqlDataReader LeerFilas;
            //Se indica el nombre del procedimiento almacenado
            SqlCommand cmd = new SqlCommand("sql", conexion.LeerCadena());
            //Se indica que el comando es del tipo procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            //Se abre la conexion
            conexion.LeerCadena();

            //Se crea una instancia del DATATABLE
            DataTable tabla = new DataTable();

            try //Se ejecuta el comando si no existe ningun tipo de error
            {
                //Se ejecuta el procedimiento almacenado
                LeerFilas = cmd.ExecuteReader();

            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.ToString());
                throw;
            }
            //Se carga todos los registros a la tabla
            tabla.Load(LeerFilas);
            //Se cierra la conexion
            conexion.LeerCadena();
            //Retorna la tabla
            return tabla;

        }
        /*Metodo para ejecutar el procedimiento almacenado SP_SeleccionCargaAcademicaxCategorias de la base de datos*/
        public DataTable SelectCargaAcademicaxCategorias(string Tipo, string Periodo, string Año)
        {
            //Se crea una instancia para almacenar los registros al ejecutar el procedimiento almacenado
            SqlDataReader LeerFilas;
            //Se indica el nombre del procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_SeleccionCargaAcademicaxCategorias", conexion.LeerCadena());
            //Se indica que el comando es del tipo procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            //Se abre la conexion
            conexion.LeerCadena();
            //Paso de parametros:
            cmd.Parameters.AddWithValue("@Tipo", Tipo);
            cmd.Parameters.AddWithValue("@Periodo", Periodo);
            cmd.Parameters.AddWithValue("@Año", Año);

            //Se crea una instancia del DATATABLE
            DataTable tabla = new DataTable();

            try //Se ejecuta el comando si no existe ningun tipo de error
            {
                //Se ejecuta el procedimiento almacenado
                LeerFilas = cmd.ExecuteReader();

            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.ToString());
                throw;
            }
            //Se carga todos los registros a la tabla
            tabla.Load(LeerFilas);
            //Se cierra la conexion
            conexion.LeerCadena();
            //Retorna la tabla
            return tabla;

        }

        /*Metodo para ejecutar el procedimiento almacenado SP_BuscarCargaAcademicaxTodosLosCamposxCategorias de la base de datos*/
        public DataTable SelectCargaAcademicaxTodosLosCamposxCategorias(string Tipo, string Periodo, string Año, string cadena)
        {
            //Se crea un objeto de la clase SqlDataAdapter, para almacenar la tabla del procedimiento almacenado
            SqlDataReader LeerFilas;
            //Se indica el nombre del procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_BuscarCargaAcademicaxTodosLosCamposxCategorias", conexion.LeerCadena());
            //Se indica que el comando es del tipo procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            //Se abre la conexion
            conexion.LeerCadena();
            //Paso de parametros:
            cmd.Parameters.AddWithValue("@Tipo", Tipo);
            cmd.Parameters.AddWithValue("@Periodo", Periodo);
            cmd.Parameters.AddWithValue("@Año", Año);
            cmd.Parameters.AddWithValue("@cadena", cadena);

            //Se crea una instancia del DATATABLE
            DataTable tabla = new DataTable();

            try //Se ejecuta el comando si no existe ningun tipo de error
            {
                //Se ejecuta el procedimiento almacenado
                LeerFilas = cmd.ExecuteReader();

            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.ToString());
                throw;
            }
            //Se carga todos los registros a la tabla
            tabla.Load(LeerFilas);
            //Se cierra la conexion
            conexion.LeerCadena();
            //Retorna la tabla
            return tabla;

        }
        /*Metodo para ejecutar el procedimiento almacenado SP_AgregarCargaAcademica de la base de datos*/
        public void AgregarCargaAcademica(string CodCurso, string Grupo, string CodDocente, string Periodo, string Año)
        {
            //Se indica el nombre del procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_AgregarCargaAcademica", conexion.LeerCadena());
            //Se indica que el comando es del tipo procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            //Se abre la conexion
            conexion.LeerCadena();
            //Paso de parametros:
            cmd.Parameters.AddWithValue("@CodCurso", CodCurso);
            cmd.Parameters.AddWithValue("@Grupo", Grupo);
            cmd.Parameters.AddWithValue("@CodDocente", CodDocente);
            cmd.Parameters.AddWithValue("@Periodo", Periodo);
            cmd.Parameters.AddWithValue("@Año", Año);

            //Verificar algun tipo de error al ejecutar el procedimiento

            try //El comando se ejecuta de forma exitosa
            {
                cmd.ExecuteReader();
            }
            catch (SqlException EX) //Existe algun tipo de error al ejecutar el procedimiento almacenado
            {
                MessageBox.Show(EX.ToString());
                throw;
            }
            conexion.LeerCadena();

        }

        /*Metodo para ejecutar el procedimiento almacenado SP_EliminarCargaAcademica de la base de datos*/
        public void EliminarCargaAcademica(int CodCargaAcademica)
        {
            //Se indica el nombre del procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_EliminarCargaAcademica", conexion.LeerCadena());
            //Se indica que el comando es del tipo procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            //Se abre la conexion
            conexion.LeerCadena();
            //Paso de parametros:
            cmd.Parameters.AddWithValue("@CodCargaAcademica", CodCargaAcademica);

            //Verificar algun tipo de error al ejecutar el procedimiento
            try //El comando se ejecuta de forma exitosa
            {
                cmd.ExecuteReader();
            }
            catch (SqlException EX) //Existe algun tipo de error al ejecutar el procedimiento almacenado
            {
                MessageBox.Show(EX.ToString());
                throw;
            }
            conexion.LeerCadena();
        }

        /*Metodo para ejecutar el procedimiento almacenado SP_ActualizarCargaAcademica de la base de datos*/
        public void ActualizarCargaAcademica(int CodCargaAcademica, int CodCurso, string Grupo, int CodDocenteNuevo, string Periodo, string Año)
        {
            //Se indica el nombre del procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_ActualizarCargaAcademica", conexion.LeerCadena());
            //Se indica que el comando es del tipo procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            //Se abre la conexion
            conexion.LeerCadena();
            //Paso de parametros:
            cmd.Parameters.AddWithValue("@CodCargaAcademica", CodCargaAcademica);
            cmd.Parameters.AddWithValue("@CodCurso", CodCurso);
            cmd.Parameters.AddWithValue("@Grupo", Grupo);
            cmd.Parameters.AddWithValue("@CodDocente", CodDocenteNuevo);
            cmd.Parameters.AddWithValue("@Periodo", Periodo);
            cmd.Parameters.AddWithValue("@Año", Año);

            //Verificar algun tipo de error al ejecutar el procedimiento
            try //El comando se ejecuta de forma exitosa
            {
                cmd.ExecuteReader();
            }
            catch (SqlException EX) //Existe algun tipo de error al ejecutar el procedimiento almacenado
            {
                MessageBox.Show(EX.ToString());
                throw;
            }
            conexion.LeerCadena();
        }
    }
}
