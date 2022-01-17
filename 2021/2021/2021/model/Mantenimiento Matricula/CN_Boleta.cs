using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace _2021
{
    public class CN_Boleta
    {
        CD_Boleta objd = new CD_Boleta();

        public String N_Mantenimiento_BoletadeMatricula(CE_Boleta obje)
        {
            return objd.D_Mantenimiento_BoletadeMatricula(obje);
        }
        public DataTable N_Mostrar_TipoDescuento()
        {
            return objd.D_Mostrar_TipoDescuento();
        }
    }
}
