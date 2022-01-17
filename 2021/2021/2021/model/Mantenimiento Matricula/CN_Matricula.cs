using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace _2021
{
    public class CN_Matricula
    {
        CD_Matricula objetoCD_Matricula = new CD_Matricula();
        public DataTable N_Detalle_EstudianteMatriculado()
        {
            return objetoCD_Matricula.D_Detalle_EstudianteMatriculado();
        }


    }
    
}
