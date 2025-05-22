using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsARRIENDO
    {
        private INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public ARRIENDO entidad { get; set; }

        public string Insertar()
        {
            try
            {
                db.Set<ARRIENDO>().Add(entidad);
                db.SaveChanges();
                return "ARRIENDO insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar ARRIENDO: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            db.Set<ARRIENDO>().AddOrUpdate(entidad);
            db.SaveChanges();
            return "ARRIENDO actualizado correctamente";
        }

        public ARRIENDO Consultar(int id)
        {
            return db.Set<ARRIENDO>().Find(id);
        }

        public List<ARRIENDO> ConsultarTodos()
        {
            return db.Set<ARRIENDO>().ToList();
        }

        public string Eliminar()
        {
            try
            {
                var obj = db.Set<ARRIENDO>().Find(entidad.ID_ARRIENDO);
                if (obj != null)
                {
                    db.Set<ARRIENDO>().Remove(obj);
                    db.SaveChanges();
                    return "ARRIENDO eliminado correctamente";
                }
                return "No se encontró el ARRIENDO";
            }
            catch (Exception ex)
            {
                return "Error al eliminar ARRIENDO: " + ex.Message;
            }
        }
    }
}
