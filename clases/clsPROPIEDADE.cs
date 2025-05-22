using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsPROPIEDADE
    {
        private INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public PROPIEDADE entidad { get; set; }

        public string Insertar()
        {
            try
            {
                db.Set<PROPIEDADE>().Add(entidad);
                db.SaveChanges();
                return "PROPIEDADE insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar PROPIEDADE: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            db.Set<PROPIEDADE>().AddOrUpdate(entidad);
            db.SaveChanges();
            return "PROPIEDADE actualizado correctamente";
        }

        public PROPIEDADE Consultar(int id)
        {
            return db.Set<PROPIEDADE>().Find(id);
        }

        public List<PROPIEDADE> ConsultarTodos()
        {
            return db.Set<PROPIEDADE>().ToList();
        }

        public string Eliminar()
        {
            try
            {
                var obj = db.Set<PROPIEDADE>().Find(entidad.ID_PROPIEDAD);
                if (obj != null)
                {
                    db.Set<PROPIEDADE>().Remove(obj);
                    db.SaveChanges();
                    return "PROPIEDADE eliminado correctamente";
                }
                return "No se encontró el PROPIEDADE";
            }
            catch (Exception ex)
            {
                return "Error al eliminar PROPIEDADE: " + ex.Message;
            }
        }
    }
}
