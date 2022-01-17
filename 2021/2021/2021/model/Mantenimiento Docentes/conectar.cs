using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace _2021
{
    class conectar
    {
        //MODULO LISTAR DOCENTE

        public DataTable ListarDocentes()
        {
            // //Nos permitira obtener el procedimiento (nombre,variable)
            SqlDataAdapter da = new SqlDataAdapter("ListarDocentes", conexion.LeerCadena());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        // MODULO AGREGAR NUEVO DOCENTE
        public static int Agregar(CDocente Obje)
        {

            int r = 0;
            //Nos permitira obtener el procedimiento (nombre,variable)
            SqlCommand CMD = new SqlCommand("AgregarDocente", conexion.LeerCadena());
            //Nos permitira usar parametros o variables desl sql 
            CMD.CommandType = CommandType.StoredProcedure;
            //BUSCAR POR EL codigo,nombre,tipo,tema,horas
            CMD.Parameters.AddWithValue("@Codigo", Obje.Codigo);
            CMD.Parameters.AddWithValue("@Nombre", Obje.Nombre);
            CMD.Parameters.AddWithValue("@ApellidoP", Obje.Ap);
            CMD.Parameters.AddWithValue("@ApellidoM", Obje.Am);
            CMD.Parameters.AddWithValue("@TipoDocentes", Obje.Tipo);
            CMD.Parameters.AddWithValue("@Direccion", Obje.Direccion);
            CMD.Parameters.AddWithValue("@Correo", Obje.Email);
            CMD.Parameters.AddWithValue("@Celular", Obje.Telefono);
            CMD.Parameters.AddWithValue("@Sexo", Obje.Sexo);
            CMD.Parameters.AddWithValue("@Foto",Obje.foto);
            r= CMD.ExecuteNonQuery();
            return r;
         

        }
        

        
       
        // MODULO BUSCAR DOCENTE
        public static DataTable BuscarDocente(CDocente Obje)
        {
           
            //Nos permitira obtener el procedimiento (nombre,variable)
            SqlCommand CMD = new SqlCommand("BuscarDocente", conexion.LeerCadena());
            //Nos permitira usar parametros o variables desl sql 
            CMD.CommandType = CommandType.StoredProcedure;
            //BUSCAR POR EL NOMBRE SE CURSO
            CMD.Parameters.AddWithValue("@Codigo", Obje.Codigo);
            //hace puente entre la base de datos y la tabla del formulario 
            SqlDataAdapter DA = new SqlDataAdapter(CMD);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            return DT;
            
        }
        
        // MODULO EDITAR DOCENTE
        public static int Editar(CDocente Obje)
        {
            try
            {

                int r = 0;
                using (SqlConnection c = conexion.LeerCadena())
                {
                    //SqlCommand t = new SqlCommand(string.Format("update Docentes set  Nombre = '{0}', ApellidoP = '{1}', ApellidoM = '{2}', TipoDocentes = '{3}', Direccion = '{4}', Correo = '{5}', Celular = '{6}', Sexo = '{7}' where CodDocente = '{8}'",
                    //   d.Nombre, d.Ap, d.Am, d.Tipo, d.Direccion, d.Email, d.Telefono, d.Sexo, d.Codigo), conexion.LeerCadena());
                    SqlCommand CMD = new SqlCommand("EditarDocente", conexion.LeerCadena());
                    //Nos permitira usar parametros o variables desl sql 
                    CMD.CommandType = CommandType.StoredProcedure;
                    //BUSCAR POR EL codigo,nombre,tipo,tema,horas
                    CMD.Parameters.AddWithValue("@Codigo", Obje.Codigo);
                    CMD.Parameters.AddWithValue("@Nombre", Obje.Nombre);
                    CMD.Parameters.AddWithValue("@ApellidoP", Obje.Ap);
                    CMD.Parameters.AddWithValue("@ApellidoM", Obje.Am);
                    CMD.Parameters.AddWithValue("@TipoDocentes", Obje.Tipo);
                    CMD.Parameters.AddWithValue("@Direccion", Obje.Direccion);
                    CMD.Parameters.AddWithValue("@Correo", Obje.Email);
                    CMD.Parameters.AddWithValue("@Celular", Obje.Telefono);
                    CMD.Parameters.AddWithValue("@Sexo", Obje.Sexo);
                    CMD.Parameters.AddWithValue("@Foto", Obje.foto);
                    r = CMD.ExecuteNonQuery();

                }

                return r;

            }
            catch (Exception) 
            { 
                throw; 
            }
        }


        /// MODULO ELIMINAR DOCENTE
        public static int Eliminar(CDocente Obje)
        {
            int r = 0;
            using (SqlConnection c = conexion.LeerCadena())
            {
                //SqlCommand t = new SqlCommand(string.Format("update Docentes set  Nombre = '{0}', ApellidoP = '{1}', ApellidoM = '{2}', TipoDocentes = '{3}', Direccion = '{4}', Correo = '{5}', Celular = '{6}', Sexo = '{7}' where CodDocente = '{8}'",
                //   d.Nombre, d.Ap, d.Am, d.Tipo, d.Direccion, d.Email, d.Telefono, d.Sexo, d.Codigo), conexion.LeerCadena());
                SqlCommand CMD = new SqlCommand("EliminarDocente", conexion.LeerCadena());
                //Nos permitira usar parametros o variables desl sql 
                CMD.CommandType = CommandType.StoredProcedure;
                //BUSCAR POR EL codigo,nombre,tipo,tema,horas
                CMD.Parameters.AddWithValue("@Codigo", Obje.Codigo);
                
                r = CMD.ExecuteNonQuery();

            }
            conexion.LeerCadena();
            return r;
        }


        


    }
}
