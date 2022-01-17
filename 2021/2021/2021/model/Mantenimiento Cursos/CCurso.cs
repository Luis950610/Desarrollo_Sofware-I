using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021
{
    public class CCurso
    {

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Temas { get; set; }
        public string Grupo { get; set; }
        public string Estado { get; set; }
        public int Horas { get; set; }
        public string Horario { get; set; }
        
        public CCurso()
        {

        }
        public CCurso(string pCodigo, string pNombre, string pTipo, string pTemas, string pGrupo, string pEstado, int pHoras, string pHorario)
        {
            this.Codigo = pCodigo;
            this.Nombre = pNombre;
            this.Tipo = pTipo;
            this.Temas = pTemas;
            this.Grupo = pGrupo;
            this.Estado = pEstado;
            this.Horas = pHoras;
            this.Horario = pHorario;
        }
        public CCurso(string pCodigo)
        {
            this.Codigo = pCodigo;
        }
    }
}
