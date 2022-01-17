using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace _2021
{
    public class CN_CargaAcademica
    {
        private CN_Docentes objetoCN_Docentes;
        private string aAño;
        private string aPeriodo;
        private string aHora;
        private string aDias;

        private string aCodDocente;
        private string aNombreDocente;

        /*Se Crea una instancia de la Clase CD_CargaAcademica*/
        CD_CargaAcademica objetoCD_CargaAcademica = new CD_CargaAcademica();

        //Metodo para Mostrar los registros de la carga Academica
        public DataTable MostrarCargaAcademica()
        {
            DataTable tablaCD = new DataTable();
            tablaCD = objetoCD_CargaAcademica.SelectCargaAcademica();
            return tablaCD;
        }

        //Metodo para mostrar y seleccionar los registros por categoria(Tipo, Periodo y el año) de la carga Academica
        public DataTable MostrarCargaAcademicaxCategorias(string Tipo, string Periodo, string Año)
        {
            DataTable tablaCD = new DataTable();
            tablaCD = objetoCD_CargaAcademica.SelectCargaAcademicaxCategorias(Tipo, Periodo.ToUpper(), Año);
            return tablaCD;
        }

        //Metodo para Mostrar y buscar los registros de la carga academica por categoria
        public DataTable MostrarCargaAcademicaxTodosLosCamposxCategorias(string Tipo, string Periodo, string Año, string cadena)
        {
            DataTable tablaCD = new DataTable();
            if (cadena == "Buscar...")
            {
                tablaCD = objetoCD_CargaAcademica.SelectCargaAcademicaxTodosLosCamposxCategorias(Tipo, Periodo.ToUpper(), Año, "");
            }
            else
            {
                if (cadena == "")
                    tablaCD = objetoCD_CargaAcademica.SelectCargaAcademicaxTodosLosCamposxCategorias(Tipo, Periodo.ToUpper(), Año, "");
                else
                    tablaCD = objetoCD_CargaAcademica.SelectCargaAcademicaxTodosLosCamposxCategorias(Tipo, Periodo.ToUpper(), Año, cadena);
            }

            return tablaCD;
        }

        //Metodo que sirve para agregar una carga Academica
        public void AgregarCargaAcademica(string CodCurso, string Grupo, string CodDocente, string Periodo, string Año)
        {

            objetoCD_CargaAcademica.AgregarCargaAcademica(CodCurso, Grupo, CodDocente, Periodo, Año);
        }

        //Metodo que sirve para Eliminar una carga academica
        public void ElimnarCargaAcademica(string CodCargaAcademica)
        {

            objetoCD_CargaAcademica.EliminarCargaAcademica(Convert.ToInt32(CodCargaAcademica));
        }

        //Metodo que sirve para Actualizar o Modificar una carga Academica
        public void ActualizarCargaAcademica(string CodCargaAcademica, string CodCurso, string Grupo, string CodDocenteNuevo, string Periodo, string Año)
        {

            objetoCD_CargaAcademica.ActualizarCargaAcademica(Convert.ToInt32(CodCargaAcademica), Convert.ToInt32(CodCurso), Grupo, Convert.ToInt32(CodDocenteNuevo), Periodo.ToUpper(), Año);
        }









        
        /*Constructor del formu VntDocentes*/
        

        //Metodo para devolver el codigo del docente seleccionado:
        public string CodDocenteSeleccionado()
        {
            return aCodDocente;
        }
        //Metodo para devolver el nombre completo del docente seleccionado:
        public string NombreCompletoDocenteSeleccionado()
        {
            return aNombreDocente;
        }
       



        private void VntDocentes_Load(object sender, EventArgs e)
        {

        }

        
    }
}
