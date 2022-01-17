using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021
{
    public class CDocente
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Ap { get; set; }
        public string Am { get; set; }
        public string Tipo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public byte[] foto { get; set; }
        public CDocente()
        {

        }
        public CDocente(string pCodigo, string pNombre, string pAp, string pAm, string pTipo, string pDireccion, string pTelefono, string pEmail, string pSexo, byte[] pFoto)
        {
            this.Codigo = pCodigo;
            this.Nombre = pNombre;
            this.Ap = pAp;
            this.Am = pAm;
            this.Tipo = pTipo;
            this.Direccion = pDireccion;
            this.Telefono = pTelefono;
            this.Email = pEmail;
            this.Sexo = pSexo;
            this.foto = pFoto;
        }
        public CDocente(string pCodigo)
        {
            this.Codigo = pCodigo;
        }
    }
}
