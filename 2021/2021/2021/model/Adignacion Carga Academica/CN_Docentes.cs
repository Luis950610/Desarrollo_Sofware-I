using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace _2021
{
    public class CN_Docentes
    {
        /*Se Crea una instancia de la Clase CD_CD_Docentes*/
        CD_Docentes objetoCD_Docentes = new CD_Docentes();
        //Metodo para Mostrar los registros de la tabla Docente
        public DataTable MostrarDocentes()
        {
            DataTable tablaCD = new DataTable();
            tablaCD = objetoCD_Docentes.SelectDocentes();
            return tablaCD;
        }
        //Metodo para mostrar los registros que contienen los nombres completos de los docentes
        public DataTable MostrarDocentes_SoloNombresCompletos()
        {
            DataTable tablaCD = new DataTable();
            tablaCD = objetoCD_Docentes.SelectDocentes_SoloNombresCompletos();
            return tablaCD;
        }
        //Metodo para mostrar y buscar entre os registros que contienen los nombres completos de  los docentes
        public DataTable MostrarBuscarDocentesxApellidosNombres(string cadena)
        {
            DataTable tablaCD = new DataTable();
            if (cadena == "Buscar...")
            {
                tablaCD = objetoCD_Docentes.BuscarDocentesxApellidosNombres("");
            }
            else
            {
                if (cadena == "")
                    tablaCD = objetoCD_Docentes.BuscarDocentesxApellidosNombres("");
                else
                    tablaCD = objetoCD_Docentes.BuscarDocentesxApellidosNombres(cadena);
            }
            return tablaCD;
        }

        //Metodo para Mostrary Buscar a los docentes disponibles en un determinado Horario
        public DataTable MostrarBuscarDocentesDisponiblesxApellidosNombres(string Hora, string Periodo, string Año, string Dias, string cadena)
        {
            DataTable tablaCD = new DataTable();
            if (cadena == "Buscar...")
            {
                tablaCD = objetoCD_Docentes.BuscarDocentesDisponiblesxApellidosNombres(Hora.ToUpper(), Periodo.ToUpper(), Año.ToUpper(), Dias.ToUpper(), "");
            }
            else
            {
                if (cadena == "")
                    tablaCD = objetoCD_Docentes.BuscarDocentesDisponiblesxApellidosNombres(Hora.ToUpper(), Periodo.ToUpper(), Año.ToUpper(), Dias.ToUpper(), "");
                else
                    tablaCD = objetoCD_Docentes.BuscarDocentesDisponiblesxApellidosNombres(Hora.ToUpper(), Periodo.ToUpper(), Año.ToUpper(), Dias.ToUpper(), cadena);
            }
            return tablaCD;
        }
        //Metodo para Mostrar y buscar los registros de los docentes disponibles y no disponibles para un determinado horario
        public DataTable MostrarBuscarDocentesDisponiblesyNoDisponiblesxApellidosNombres(string Hora, string Periodo, string Año, string Dias, string cadena)
        {
            DataTable tablaCD = new DataTable();
            if (cadena == "Buscar...")
            {
                tablaCD = objetoCD_Docentes.BuscarDocentesDisponiblesyNoDisponiblesxApellidosNombres(Hora, Periodo.ToUpper(), Año, Dias.ToUpper(), "");
            }
            else
            {
                if (cadena == "")
                    tablaCD = objetoCD_Docentes.BuscarDocentesDisponiblesyNoDisponiblesxApellidosNombres(Hora, Periodo.ToUpper(), Año, Dias.ToUpper(), "");
                else
                    tablaCD = objetoCD_Docentes.BuscarDocentesDisponiblesyNoDisponiblesxApellidosNombres(Hora, Periodo.ToUpper(), Año, Dias.ToUpper(), cadena);
            }
            return tablaCD;
        }
    }
}
