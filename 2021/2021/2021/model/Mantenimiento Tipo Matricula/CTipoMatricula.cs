using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021
{
    public class CTipoMatricula
    {
        public string CodigoMatricula { get; set; }
        public string Descripcion { get; set; }
        public string Activo { get; set; }
        public string Convenio { get; set; }
        public CTipoMatricula()
        {

        }
        public CTipoMatricula(string pCodigoMatricula, string pDescripcion, string pActivo, string pConvenio)
        {
            this.CodigoMatricula = pCodigoMatricula;
            this.Descripcion = pDescripcion;
            this.Activo = pActivo;
            this.Convenio = pConvenio;
        }
        public CTipoMatricula(string pCodigoMatricula)
        {
            this.CodigoMatricula = pCodigoMatricula;
        }
    }
}
