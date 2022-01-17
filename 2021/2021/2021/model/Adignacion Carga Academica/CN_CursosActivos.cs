using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace _2021
{
    public class CN_CursosActivos
    {
        /*Se Crea una instancia de la Clase CD_CursosActivos*/
        CD_CursosActivos objetoCD_CursosActivos = new CD_CursosActivos();
        //Metodo para Mostrar los registros de los Cursos Activos de la base de datos
        public DataTable MostrarCursos()
        {
            DataTable tablaCD = new DataTable();
            tablaCD = objetoCD_CursosActivos.SelectCursos();
            return tablaCD;
        }
        //Metodo para mostrar y seleccionar los registros por categoria(Tipo, Periodo y año) de los Cursos Activos
        public DataTable MostrarCursosxCategorias(string Tipo, string Periodo, string Año)
        {
            DataTable tablaCD = new DataTable();
            tablaCD = objetoCD_CursosActivos.SelectCursosxCategorias(Tipo, Periodo.ToUpper(), Año);
            return tablaCD;
        }
        //Metodo para Mostrar y buscar por todos los campos a los registros de los crusos activos
        public DataTable MostrarBuscarCursosxTodosLosCampos(string cadena)
        {
            DataTable tablaCD = new DataTable();
            if (cadena == "Buscar...")
            {
                tablaCD = objetoCD_CursosActivos.BuscarCursosxTodosLosCampos("");
            }
            else
            {
                if (cadena == "")
                    tablaCD = objetoCD_CursosActivos.BuscarCursosxTodosLosCampos("");
                else
                    tablaCD = objetoCD_CursosActivos.BuscarCursosxTodosLosCampos(cadena.ToLower());

            }
            return tablaCD;
        }

        //Metodo para mostrar y buscar por categoria y por todos los campos de la tabla Cursos Activos
        public DataTable MostrarBuscarCursosxTodosLosCamposxCategorias(string Tipo, string Periodo, string Año, string cadena)
        {
            DataTable tablaCD = new DataTable();

            if (cadena == "Buscar...")
            {
                tablaCD = objetoCD_CursosActivos.BuscarCursosLibresxTodosLosCamposxCategorias(Tipo, Periodo, Año, "");
            }
            else
            {
                if (cadena == "")
                    tablaCD = objetoCD_CursosActivos.BuscarCursosLibresxTodosLosCamposxCategorias(Tipo, Periodo, Año, "");
                else
                    tablaCD = objetoCD_CursosActivos.BuscarCursosLibresxTodosLosCamposxCategorias(Tipo, Periodo, Año, cadena.ToLower());

            }
            return tablaCD;
        }

    }
}
