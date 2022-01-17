using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//activamos referencias que necesitamos en esta capa
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace _2021
{
    public class DEstudiante
    {
        conexion conexion = new conexion();                                   // crear un objeto para la conexion con la base de datos

        // ==================================================================================
        public void AgregarEstudiantes(EEstudiante obj)
        {
            // Crear objeto comando y pasar por parametro el storedprocedure a ejecutar
            // y establecer la conexion con la base de datos
            SqlCommand cmd = new SqlCommand("spInsertarEstudiante", conexion.LeerCadena());
            cmd.CommandType = CommandType.StoredProcedure;                          // establecer el tipo de procedimiento almacenado a ejecutar

            try
            {
                conexion.LeerCadena();                                                   // abrir conexion                                                                            
                cmd.Parameters.AddWithValue("@Codigo_Estudiante", obj.CODIGO);          // enviar los datos obtenidos de la capa de negocio a la base de datos
                cmd.Parameters.AddWithValue("@Apellido_Paterno", obj.APELLIDO_PATERNO);
                cmd.Parameters.AddWithValue("@Apellido_Materno", obj.APELLIDO_MATERNO);
                cmd.Parameters.AddWithValue("@Nombres", obj.NOMBRES);
                cmd.Parameters.AddWithValue("@DNI", obj.DOCUMENTO);
                cmd.Parameters.AddWithValue("@Sexo", obj.SEXO);
                cmd.Parameters.AddWithValue("@Direccion", obj.DIRECCION);
                cmd.Parameters.AddWithValue("@Telefono", obj.TELEFONO);
                cmd.Parameters.AddWithValue("@Email", obj.EMAIL);
                cmd.Parameters.AddWithValue("@Foto", obj.FOTO);
                cmd.ExecuteNonQuery();
                conexion.LeerCadena();                                                 // cerrar conexion

            }
            catch (Exception)
            {
                throw;
            }

        }
        // ==================================================================================
        public void ModificarEstudiante(EEstudiante obj)
        {
            try
            {
                // Crear objeto comando y pasar por parametro el storedprocedure a ejecutar
                // y establecer la conexion con la base de datos
                SqlCommand cmd = new SqlCommand("speditar_estudiante", conexion.LeerCadena());
                cmd.CommandType = CommandType.StoredProcedure;                          // establecer el tipo de procedimiento almacenado a ejecutar

                conexion.LeerCadena();                                                   // abrir conexion                                                                                    
                cmd.Parameters.AddWithValue("@Codigo_Estudiante", obj.CODIGO);          // enviar los datos obtenidos de la capa de negocio a la base de datos
                cmd.Parameters.AddWithValue("@Apellido_Paterno", obj.APELLIDO_PATERNO);
                cmd.Parameters.AddWithValue("@Apellido_Materno", obj.APELLIDO_MATERNO);
                cmd.Parameters.AddWithValue("@Nombres", obj.NOMBRES);
                cmd.Parameters.AddWithValue("@DNI", obj.DOCUMENTO);
                cmd.Parameters.AddWithValue("@Sexo", obj.SEXO);
                cmd.Parameters.AddWithValue("@Direccion", obj.DIRECCION);
                cmd.Parameters.AddWithValue("@Telefono", obj.TELEFONO);
                cmd.Parameters.AddWithValue("@Email", obj.EMAIL);
                cmd.Parameters.AddWithValue("@Foto", obj.FOTO);
                cmd.ExecuteNonQuery();                                                  // ejecutar query
                conexion.LeerCadena();                                                 // cerrar conexion
            }
            catch (Exception)
            {

                throw;
            }
        }
        // ==================================================================================
        public void EliminarEstudiante()
        {
            try
            {
                // Crear objeto comando y pasar por parametro el storedprocedure a ejecutar
                // y establecer la conexion con la base de datos
                SqlCommand cmd = new SqlCommand("speliminar_estudiante", conexion.LeerCadena());
                cmd.CommandType = CommandType.StoredProcedure;                          // establecer el tipo de procedimiento almacenado a ejecutar
                conexion.LeerCadena();                                               // cerrar conexion
            }
            catch (Exception)
            {

                throw;
            }
        }
        // ==================================================================================
        public DataTable BuscarEstudianteCodigo(EEstudiante obj)
        {
            DataTable dt = new DataTable();                                             // objeto datatable
            try
            {
                // Crear objeto comando y pasar por parametro el storedprocedure a ejecutar
                // y establecer la conexion con la base de datos
                SqlCommand cmd = new SqlCommand("spbuscar_estudiante_codigo", conexion.LeerCadena());
                cmd.CommandType = CommandType.StoredProcedure;                          // establecer el tipo de procedimiento almacenado a ejecutar

                conexion.LeerCadena();                                                  // abrir conexion
                cmd.Parameters.AddWithValue("@codigobuscar", obj.CODIGO);               // parametro a buscar en la base de datos
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);                                                            // recuperar registro
                conexion.LeerCadena();                                                 // cerrar conexion
            }
            catch (Exception)
            {

                throw;
            }

            return dt;                                                              // retornar registro
        }
        // ==================================================================================
        public void EliminarEstudiante(EEstudiante obj)
        {
            try
            {
                
                // Crear objeto comando y pasar por parametro el storedprocedure a ejecutar
                // y establecer la conexion con la base de datos
                SqlCommand cmd = new SqlCommand("speliminar_estudiante", conexion.LeerCadena());
                cmd.CommandType = CommandType.StoredProcedure;                          // establecer el tipo de procedimiento almacenado a ejecutar

                conexion.LeerCadena();                                                  // abrir conexion
                cmd.Parameters.AddWithValue("@Codigo_Estudiante", obj.CODIGO);          // pasar por parametro dato a modificar sobre el campo codigo
                cmd.ExecuteNonQuery();                                                  // ejecutar query
                cmd.Parameters.Clear();                                                 // limpiar los parametros
                conexion.LeerCadena();                                                 // cerrar conexion
            }
            catch (Exception)
            {

                throw;
            }
        }
        // ==================================================================================
        public DataTable MostrarEstudiantes()
        {
            try
            {
                // objetos que nos permitiran recuperar registros de la base de datos
                DataTable tabla = new DataTable();
                SqlDataReader Leer;
                // Crear objeto comando y pasar por parametro el storedprocedure a ejecutar
                // y establecer la conexion con la base de datos
                SqlCommand cmd = new SqlCommand("spmostrar_estudiante", conexion.LeerCadena());
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.LeerCadena();                                                // abrir conexion
                Leer = cmd.ExecuteReader();                                             // extraer los registros de la tabla estudiante
                tabla.Load(Leer);                                                       // cargar los registros en el objeto tabla
                conexion.LeerCadena();                                                  // cerrar conexion
                return tabla;                                                           // retornar la tabla con los registros obtenidos
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
