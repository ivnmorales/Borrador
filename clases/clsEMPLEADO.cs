using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsEMPLEADO
    {
        private INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public EMPLEADO entidad { get; set; }

        public string Insertar()
        {
            try
            {
                db.Set<EMPLEADO>().Add(entidad);
                db.SaveChanges();
                return "EMPLEADO insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar EMPLEADO: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            db.Set<EMPLEADO>().AddOrUpdate(entidad);
            db.SaveChanges();
            return "EMPLEADO actualizado correctamente";
        }

        public EMPLEADO Consultar(int id)
        {
            return db.Set<EMPLEADO>().Find(id);
        }

        public List<EMPLEADO> ConsultarTodos()
        {
            return db.Set<EMPLEADO>().ToList();
        }

        public string Eliminar()
        {
            try
            {
                var obj = db.Set<EMPLEADO>().Find(entidad.ID_EMPLEADO);
                if (obj != null)
                {
                    db.Set<EMPLEADO>().Remove(obj);
                    db.SaveChanges();
                    return "EMPLEADO eliminado correctamente";
                }
                return "No se encontró el EMPLEADO";
            }
            catch (Exception ex)
            {
                return "Error al eliminar EMPLEADO: " + ex.Message;
            }
        }
    }
}
