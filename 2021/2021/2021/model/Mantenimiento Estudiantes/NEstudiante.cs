using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//activamos referencias que necesitamos en esta capa
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace _2021
{
    public class NEstudiante
    {
        // ===============================================================
        public DataTable Mostrar_Estudiante()
        {
            DEstudiante obj = new DEstudiante();
            DataTable tabla = new DataTable();
            tabla = obj.MostrarEstudiantes();
            return tabla;
        }
        // ===============================================================
        public void Agregar_Estudiante(EEstudiante ObjEstudiante)
        {
            DEstudiante obj = new DEstudiante();
            obj.AgregarEstudiantes(ObjEstudiante);
        }
        // ===============================================================
        public void Modificar_Estudiante(EEstudiante ObjEstudiante)
        {
            DEstudiante obj = new DEstudiante();
            obj.ModificarEstudiante(ObjEstudiante);
        }
        // ===============================================================
        public DataTable Buscar_Estudiante(EEstudiante ObjEstudiante)
        {
            DEstudiante obj = new DEstudiante();
            return obj.BuscarEstudianteCodigo(ObjEstudiante);
        }
        // ===============================================================
        public void EliminarRegistro(EEstudiante ObjEstudiante)
        {
            DEstudiante obj = new DEstudiante();
            obj.EliminarEstudiante(ObjEstudiante);
        }
    }
}
