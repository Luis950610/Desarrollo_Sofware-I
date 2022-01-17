using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021
{
    public class CDetalles
    {
        public string Año { get; set; }
        public string Periodo { get; set; }
        public string Documento { get; set; }
        public string Observaciones { get; set; }
        public CDetalles()
        {

        }
        public CDetalles(string pAño, string pPeriodo, string pDocumento, string pObservaciones)
        {
            this.Año = pAño;
            this.Periodo = pPeriodo;
            this.Documento = pDocumento;
            this.Observaciones = pObservaciones;
        }
        
    }
}
