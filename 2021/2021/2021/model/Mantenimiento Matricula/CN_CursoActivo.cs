using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace _2021
{
    public class CN_CursoActivo
    {
        CD_CursoActivo objd = new CD_CursoActivo();

        public DataTable N_Mostrar_CursoActivo()
        {
            return objd.D_Mostrar_CursoActivo();
        }
        
    }
}
