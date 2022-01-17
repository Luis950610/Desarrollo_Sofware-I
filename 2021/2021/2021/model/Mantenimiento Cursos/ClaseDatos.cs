using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//activamos referencias que necesitamos en esta capa
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using capa_Entidad;

namespace Capa_Datos
{
    public class ClaseDatos
    {
        //Creamos una variable que mantendra una coneccion con sql server
        SqlConnection CN = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        //Creamos tablas para los procedimientos del sql server
        //1 .-listar Manteniemientos de curso
        public DataTable D_listar_mCurso()
       {
            //Nos permitira obtener el procedimiento (nombre,variable)
            SqlCommand CMD = new SqlCommand("sp_listar_mCurso", CN);
            //hace puente entre la base de datos y la tabla del formulario 
            SqlDataAdapter DA = new SqlDataAdapter(CMD);//es como un filtro para q los datps se pueddan agregar auna tabla
            DataTable DT = new DataTable();
            //PARA LLENAR TABLA
            DA.Fill(DT);
            return DT;
       }

        //2.-Buscar Cursos
        public DataTable D_Buscar_mCurso(ClaseEntidad Obje)
        {
            //Nos permitira obtener el procedimiento (nombre,variable)
            SqlCommand CMD = new SqlCommand("sp_Buscar_mCurso", CN);
            //Nos permitira usar parametros o variables desl sql 
            CMD.CommandType = CommandType.StoredProcedure;
            //BUSCAR POR EL NOMBRE SE CURSO
            CMD.Parameters.AddWithValue("@Nombre", Obje.Nombre);
            //hace puente entre la base de datos y la tabla del formulario 
            SqlDataAdapter DA = new SqlDataAdapter(CMD);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            return DT;
        }
        //3.-Mantenimiento curso
         public String D_Mantenimiento_mCurso(ClaseEntidad Obje)
         {
             String accion = "";
             //Nos permitira obtener el procedimiento (nombre,variable)
             SqlCommand CMD = new SqlCommand("sp_Mantenimiento_mCurso", CN);
             //Nos permitira usar parametros o variables desl sql 
             CMD.CommandType = CommandType.StoredProcedure;
             //BUSCAR POR EL codigo,nombre,tipo,tema,horas
             CMD.Parameters.AddWithValue("@CodigoCurso", Obje.CodigoCurso);
             CMD.Parameters.AddWithValue("@Nombre", Obje.Nombre);
             CMD.Parameters.AddWithValue("@Tipo", Obje.Tipo);
             CMD.Parameters.AddWithValue("@Temas", Obje.Temas);
             CMD.Parameters.AddWithValue("@HorasxSemana", Obje.HorasxSemana);

             CMD.Parameters.Add("@accion",SqlDbType.VarChar, 50).Value=Obje.accion;
             CMD.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
             if (CN.State == ConnectionState.Open) CN.Close();
             CN.Open();
             CMD.ExecuteNonQuery();
             accion = CMD.Parameters["@accion"].Value.ToString();
             CN.Close();
             return accion;
         }
    }
}
