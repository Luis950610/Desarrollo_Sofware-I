using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using capa_Entidad;
using Capa_Datos;

namespace Capa_Negocio
{
    public class ClaseNegocio
    {
        ClaseDatos objd = new ClaseDatos();
        public DataTable N_listar_mCurso()
        {
            return objd.D_listar_mCurso();
        }
        public DataTable N_Buscar_mCurso(ClaseEntidad obje)
        {
            return objd.D_Buscar_mCurso(obje);
        }
        public String N_Mantenimineto_mCurso(ClaseEntidad obje)
        {
            return objd.D_Mantenimiento_mCurso(obje);
        }
    }
}
