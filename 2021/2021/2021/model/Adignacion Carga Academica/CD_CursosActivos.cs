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
    public class CD_CursosActivos
    {
        /*Conectar el proyecto con la base de datos mediante la cadena de conexion que se establecio en el AppConfig */
        

        /*Metodo para ejecutar el procedimiento almacenado SP_SeleccionCursos de la base de datos*/
        public DataTable SelectCursos()
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
        /*Metodo para ejecutar el procedimiento almacenado SP_SeleccionCursosxCategorias de la base de datos*/
        public DataTable SelectCursosxCategorias(string Tipo, string Periodo, string Año)
        {
            //Se crea una instancia para almacenar los registros al ejecutar el procedimiento almacenado
            SqlDataReader LeerFilas;
            //Se indica que el comando es del tipo procedimiento almacenado
            SqlCommand cmd = new SqlCommand("SP_SeleccionCursosxCategorias", conexion.LeerCadena());
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

        /*Metodo para ejecutar el procedimiento almacenado SP_BuscarCursosxTodosLosCampos de la base de datos*/
        public DataTable BuscarCursosxTodosLosCampos(string cadena)
        {
            //Esta variable almacenara los registros del procedimiento almacenado
            SqlDataReader LeerFilas;
            //Se indica el nombre del procedimieto almacenado y la cadena de conexion
            SqlCommand cmd = new SqlCommand("SP_BuscarCursosxTodosLosCampos", conexion.LeerCadena());
            //Se indica el tipo del procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            //Se abre la conexion
            conexion.LeerCadena();
            //Paso de parametros:
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

        /*Metodo para ejecutar el procedimiento almacenado SP_BuscarCursosSinCargaxTodosLosCamposxCategorias de la base de datos*/
        public DataTable BuscarCursosLibresxTodosLosCamposxCategorias(string Tipo, string Periodo, string Año, string cadena)
        {
            //Esta variable almacenara los registros del procedimiento almacenado
            SqlDataReader LeerFilas;
            //Se indica el nombre del procedimieto almacenado y la cadena de conexion
            SqlCommand cmd = new SqlCommand("SP_BuscarCursosSinCargaxTodosLosCamposxCategorias", conexion.LeerCadena());
            //Se indica el tipo del procedimiento almacenado
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
    }
}
