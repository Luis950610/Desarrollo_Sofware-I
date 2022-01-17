using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021
{
    public class CE_Boleta
    {
        public String Codigo { get; set; }
        public String NroSerie { get; set; }
        public String FechaEmision { get; set; }
        public float Costo { get; set; }
        public String TipoDscto { get; set; }
        public float Pago { get; set; }
        public String CodCursoActivo { get; set; }
        public String CodEstudiante { get; set; }

        public String Observacion { get; set; }
        
        public String accion { get; set; }
    }
}
