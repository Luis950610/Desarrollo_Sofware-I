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
    public class CD_Boleta
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        public String D_Mantenimiento_BoletadeMatricula(CE_Boleta Obje)
        {
            try

            {
                String accion = "";
                //Nos permitira obtener el procedimiento (nombre,variable)
                SqlCommand CMD = new SqlCommand("SP_Mantenimiento_BoletadeMatricula", conexion);
                //Nos permitira usar parametros o variables desl sql 
                CMD.CommandType = CommandType.StoredProcedure;
                //BUSCAR POR EL codigo,nombre,tipo,tema,horas
                CMD.Parameters.AddWithValue("@CodBoleta", Obje.Codigo);
                CMD.Parameters.AddWithValue("@NroSerie", Obje.NroSerie);
                CMD.Parameters.AddWithValue("@FechaEmision", Obje.FechaEmision);
                CMD.Parameters.AddWithValue("@Costo", Obje.Costo);
                CMD.Parameters.AddWithValue("@TipoDsto", Obje.TipoDscto);
                CMD.Parameters.AddWithValue("@Pago", Obje.Pago);
                CMD.Parameters.AddWithValue("@CodCursoActivo", Obje.CodCursoActivo);
                CMD.Parameters.AddWithValue("@CodEstudiante", Obje.CodEstudiante);
                CMD.Parameters.AddWithValue("@Observacion", Obje.Observacion);


                CMD.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = Obje.accion;
                CMD.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
                if (conexion.State == ConnectionState.Open) conexion.Close();
                conexion.Open();
                CMD.ExecuteNonQuery();
                accion = CMD.Parameters["@accion"].Value.ToString();
                conexion.Close();
                return accion;

            }
            catch (Exception )
            {
               
                throw;
                
            }
            
            

        }
        public DataTable D_Mostrar_TipoDescuento()
        {
            try
            { 
                //Nos permitira obtener el procedimiento (nombre,variable)
                SqlCommand CMD = new SqlCommand("SP_Mostrar_TipoDescuento", conexion);
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
