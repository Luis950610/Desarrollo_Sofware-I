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
    public class CD_Docentes
    {
        

        /*Metodo para ejecutar el procedimiento almacenado SP_SeleccionDocentes de la base de datos*/
        public DataTable SelectDocentes()
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_SeleccionDocentes", conexion.LeerCadena());
            cmd.CommandType = CommandType.StoredProcedure;
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

        /*Metodo para ejecutar el procedimiento almacenado SP_SeleccionDocentes_SoloNombresCompletos de la base de datos*/
        public DataTable SelectDocentes_SoloNombresCompletos()
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_SeleccionDocentes_SoloNombresCompletos", conexion.LeerCadena());
            cmd.CommandType = CommandType.StoredProcedure;
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

        /*Metodo para ejecutar el procedimiento almacenado SP_BuscarDocentesxApellidosNombres de la base de datos*/
        public DataTable BuscarDocentesxApellidosNombres(string cadena)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BuscarDocentesxApellidosNombres", conexion.LeerCadena());
            cmd.CommandType = CommandType.StoredProcedure;
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
        /*Metodo para ejecutar el procedimiento almacenado SP_BuscarDocentesDisponibles de la base de datos*/
        public DataTable BuscarDocentesDisponiblesxApellidosNombres(string Hora, string Periodo, string Año, string Dias, string cadena)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BuscarDocentesDisponibles", conexion.LeerCadena());
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.LeerCadena();
            //Paso de parametros:
            cmd.Parameters.AddWithValue("@Hora", Hora);
            cmd.Parameters.AddWithValue("@Periodo", Periodo);
            cmd.Parameters.AddWithValue("@Año", Año);
            cmd.Parameters.AddWithValue("@Dias", Dias);
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

        /*Metodo para ejecutar el procedimiento almacenado SP_MostrarDocentesDisponiblesyNoDisponibles de la base de datos*/
        public DataTable BuscarDocentesDisponiblesyNoDisponiblesxApellidosNombres(string Hora, string Periodo, string Año, string Dias, string cadena)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_MostrarDocentesDisponiblesyNoDisponibles", conexion.LeerCadena());
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.LeerCadena();
            //Paso de parametros:
            cmd.Parameters.AddWithValue("@Año", Año);
            cmd.Parameters.AddWithValue("@Periodo", Periodo);
            cmd.Parameters.AddWithValue("@Hora", Hora);
            cmd.Parameters.AddWithValue("@Dias", Dias);
            cmd.Parameters.AddWithValue("@cadena", cadena);
            DataTable tabla = new DataTable();
            try //El comando se ejecuta de forma exitosa
            {
                LeerFilas = cmd.ExecuteReader();

            }
            catch (SqlException EX) //Existe algun tipo de error al ejecutar el procedimiento almacenado
            {
                MessageBox.Show(EX.ToString());
                throw;
            }
            tabla.Load(LeerFilas);
            conexion.LeerCadena();

            return tabla;

        }

    }
}
