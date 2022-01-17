using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _2021
{
    public class CModulos
    {
        public DataTable Mostrar1()
        {
            // //Nos permitira obtener el procedimiento (nombre,variable)
            SqlDataAdapter da = new SqlDataAdapter("MostrarMantenimientoTipoMatricula", conexion.LeerCadena());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable Mostrar2()
        {
            // //Nos permitira obtener el procedimiento (nombre,variable)
            SqlDataAdapter da = new SqlDataAdapter("MostrarDetalles", conexion.LeerCadena());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static int Agregar(CTipoMatricula Obje)
        {

            int r = 0;
            //Nos permitira obtener el procedimiento (nombre,variable)
            SqlCommand CMD = new SqlCommand("AgregarTipoMatricula", conexion.LeerCadena());
            //Nos permitira usar parametros o variables desl sql 
            CMD.CommandType = CommandType.StoredProcedure;
            //BUSCAR POR EL codigo,nombre,tipo,tema,horas
            CMD.Parameters.AddWithValue("@CodMatricula", Obje.CodigoMatricula);
            CMD.Parameters.AddWithValue("@Descripcion", Obje.Descripcion);
            CMD.Parameters.AddWithValue("@Activo", Obje.Activo);
            CMD.Parameters.AddWithValue("@Convenio", Obje.Convenio);
            r = CMD.ExecuteNonQuery();
            return r;
        }
        public static int AgregarDetalles(CDetalles Obje)
        {

            int r = 0;
            //Nos permitira obtener el procedimiento (nombre,variable)
            SqlCommand CMD = new SqlCommand("AgregarDetalles", conexion.LeerCadena());
            //Nos permitira usar parametros o variables desl sql 
            CMD.CommandType = CommandType.StoredProcedure;
            //BUSCAR POR EL codigo,nombre,tipo,tema,horas
            CMD.Parameters.AddWithValue("@Año", Obje.Año);
            CMD.Parameters.AddWithValue("@Periodo", Obje.Periodo);
            CMD.Parameters.AddWithValue("@Documento", Obje.Documento);
            CMD.Parameters.AddWithValue("@Observaciones", Obje.Observaciones);
            r = CMD.ExecuteNonQuery();
            return r;


        }
        // MODULO EDITAR TIPO MATRICULA
        public static int Editar(CTipoMatricula Obje)
        {
            try
            {

                int r = 0;
                {
                    //SqlCommand t = new SqlCommand(string.Format("update Docentes set  Nombre = '{0}', ApellidoP = '{1}', ApellidoM = '{2}', TipoDocentes = '{3}', Direccion = '{4}', Correo = '{5}', Celular = '{6}', Sexo = '{7}' where CodDocente = '{8}'",
                    //   d.Nombre, d.Ap, d.Am, d.Tipo, d.Direccion, d.Email, d.Telefono, d.Sexo, d.Codigo), conexion.LeerCadena());
                    SqlCommand CMD = new SqlCommand("EditarTipoMatricula", conexion.LeerCadena());
                    //Nos permitira usar parametros o variables desl sql 
                    CMD.CommandType = CommandType.StoredProcedure;
                    //BUSCAR POR EL codigo,nombre,tipo,tema,horas
                    CMD.Parameters.AddWithValue("@CodMatricula", Obje.CodigoMatricula);
                    CMD.Parameters.AddWithValue("@Descripcion", Obje.Descripcion);
                    CMD.Parameters.AddWithValue("@Activo", Obje.Activo);
                    CMD.Parameters.AddWithValue("@Convenio", Obje.Convenio);
                    r = CMD.ExecuteNonQuery();

                }

                return r;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int EditarDetalles(CDetalles Obje)
        {
            try
            {

                int r = 0;
                {
                    //SqlCommand t = new SqlCommand(string.Format("update Docentes set  Nombre = '{0}', ApellidoP = '{1}', ApellidoM = '{2}', TipoDocentes = '{3}', Direccion = '{4}', Correo = '{5}', Celular = '{6}', Sexo = '{7}' where CodDocente = '{8}'",
                    //   d.Nombre, d.Ap, d.Am, d.Tipo, d.Direccion, d.Email, d.Telefono, d.Sexo, d.Codigo), conexion.LeerCadena());
                    SqlCommand CMD = new SqlCommand("EditarDetalles", conexion.LeerCadena());
                    //Nos permitira usar parametros o variables desl sql 
                    CMD.CommandType = CommandType.StoredProcedure;
                    //BUSCAR POR EL codigo,nombre,tipo,tema,horas
                    CMD.Parameters.AddWithValue("@Año", Obje.Año);
                    CMD.Parameters.AddWithValue("@Periodo", Obje.Periodo);
                    CMD.Parameters.AddWithValue("@Documento", Obje.Documento);
                    CMD.Parameters.AddWithValue("@Observaciones", Obje.Observaciones);
                    r = CMD.ExecuteNonQuery();

                }

                return r;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int Eliminar(CTipoMatricula Obje)
        {
            int r = 0;
            using (SqlConnection c = conexion.LeerCadena())
            {
                //SqlCommand t = new SqlCommand(string.Format("update Docentes set  Nombre = '{0}', ApellidoP = '{1}', ApellidoM = '{2}', TipoDocentes = '{3}', Direccion = '{4}', Correo = '{5}', Celular = '{6}', Sexo = '{7}' where CodDocente = '{8}'",
                //   d.Nombre, d.Ap, d.Am, d.Tipo, d.Direccion, d.Email, d.Telefono, d.Sexo, d.Codigo), conexion.LeerCadena());
                SqlCommand CMD = new SqlCommand("EliminarTipoMatricula", conexion.LeerCadena());
                //Nos permitira usar parametros o variables desl sql 
                CMD.CommandType = CommandType.StoredProcedure;
                //BUSCAR POR EL codigo,nombre,tipo,tema,horas
                CMD.Parameters.AddWithValue("@CodMatricula", Obje.CodigoMatricula);

                r = CMD.ExecuteNonQuery();

            }
            conexion.LeerCadena();
            return r;
        }
        public static int EliminarDocumento(CDetalles Obje)
        {
            int r = 0;
            using (SqlConnection c = conexion.LeerCadena())
            {
                //SqlCommand t = new SqlCommand(string.Format("update Docentes set  Nombre = '{0}', ApellidoP = '{1}', ApellidoM = '{2}', TipoDocentes = '{3}', Direccion = '{4}', Correo = '{5}', Celular = '{6}', Sexo = '{7}' where CodDocente = '{8}'",
                //   d.Nombre, d.Ap, d.Am, d.Tipo, d.Direccion, d.Email, d.Telefono, d.Sexo, d.Codigo), conexion.LeerCadena());
                SqlCommand CMD = new SqlCommand("EliminarDocumento", conexion.LeerCadena());
                //Nos permitira usar parametros o variables desl sql 
                CMD.CommandType = CommandType.StoredProcedure;
                //BUSCAR POR EL codigo,nombre,tipo,tema,horas
                CMD.Parameters.AddWithValue("@Documento", Obje.Documento);

                r = CMD.ExecuteNonQuery();

            }
            conexion.LeerCadena();
            return r;
        }
        public static DataTable BuscarDescripcion(CTipoMatricula Obje)
        {

            //Nos permitira obtener el procedimiento (nombre,variable)
            SqlCommand CMD = new SqlCommand("BuscarDescripcion", conexion.LeerCadena());
            //Nos permitira usar parametros o variables desl sql 
            CMD.CommandType = CommandType.StoredProcedure;
            //BUSCAR POR EL NOMBRE SE CURSO
            CMD.Parameters.AddWithValue("@Descripcion", Obje.Descripcion);
            //hace puente entre la base de datos y la tabla del formulario 
            SqlDataAdapter DA = new SqlDataAdapter(CMD);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            return DT;

        }
        public static DataTable BuscarCodigo(CTipoMatricula Obje)
        {

            //Nos permitira obtener el procedimiento (nombre,variable)
            SqlCommand CMD = new SqlCommand("BuscarCodigo1", conexion.LeerCadena());
            //Nos permitira usar parametros o variables desl sql 
            CMD.CommandType = CommandType.StoredProcedure;
            //BUSCAR POR EL NOMBRE SE CURSO
            CMD.Parameters.AddWithValue("@CodMatricula", Obje.CodigoMatricula);
            //hace puente entre la base de datos y la tabla del formulario 
            SqlDataAdapter DA = new SqlDataAdapter(CMD);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            return DT;

        }



    }
}
