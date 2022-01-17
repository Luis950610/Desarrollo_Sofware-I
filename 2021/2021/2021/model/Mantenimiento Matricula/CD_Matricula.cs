using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;



namespace _2021
{
    public class CD_Matricula
    {
        SqlConnection conexion1 = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        public DataTable D_Detalle_EstudianteMatriculado()
        {
            try
            {
                //Nos permitira obtener el procedimiento (nombre,variable)
                SqlCommand CMD = new SqlCommand("SP_DetalleMatriculaEstudiante", conexion1);
                //hace puente entre la base de datos y la tabla del formulario 
                SqlDataAdapter DA = new SqlDataAdapter(CMD);//es como un filtro para q los datps se pueddan agregar auna tabla
                DataTable DT = new DataTable();
                //PARA LLENAR TABLA
                DA.Fill(DT);
                return DT;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
