using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021
{
    class Operaciones
    {
        public bool VerificarCodigo(string pCodigo)
        {
            if (pCodigo.Length < 6 && pCodigo.All(char.IsDigit))
            {
                return true;
            }
            else
                return false;
        }

    }
}
