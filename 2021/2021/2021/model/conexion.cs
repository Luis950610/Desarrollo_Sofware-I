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
    public class conexion
    {

        
        public static SqlConnection LeerCadena()
        {
            //Creamos una variable que mantendra una coneccion con sql server
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
            else
            {
                cn.Open();
            }

            return cn;
        }
        

        //Creamos una variable que mantendra una coneccion con sql server
        //SqlConnection CN = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        //Creamos tablas para los procedimientos del sql server
        //1 .-listar Manteniemientos de curso

    }
}
