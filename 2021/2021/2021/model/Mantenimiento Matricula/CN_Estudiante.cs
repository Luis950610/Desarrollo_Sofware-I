using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace _2021
{
    public class CN_Estudiante
    {
        CD_Estudiante objd = new CD_Estudiante();

        public String N_Manteniemiento_EstudianteMatriculado(CE_Estudiante obje)
        {
            return objd.D_Mantenimiento_EstudianteMatriculado(obje);
        }
        public DataTable N_Buscar_EstudianteMatriculado(CE_Estudiante obje)
        {
            return objd.D_Buscar_EstudianteMatriculado(obje);
        }
    }
}
