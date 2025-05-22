using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsESTADOS_PROPIEDAD
    {
        private INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public ESTADOS_PROPIEDAD entidad { get; set; }

        public string Insertar()
        {
            try
            {
                db.Set<ESTADOS_PROPIEDAD>().Add(entidad);
                db.SaveChanges();
                return "ESTADOS_PROPIEDAD insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar ESTADOS_PROPIEDAD: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            db.Set<ESTADOS_PROPIEDAD>().AddOrUpdate(entidad);
            db.SaveChanges();
            return "ESTADOS_PROPIEDAD actualizado correctamente";
        }

        public ESTADOS_PROPIEDAD Consultar(int id)
        {
            return db.Set<ESTADOS_PROPIEDAD>().Find(id);
        }

        public List<ESTADOS_PROPIEDAD> ConsultarTodos()
        {
            return db.Set<ESTADOS_PROPIEDAD>().ToList();
        }

        public string Eliminar()
        {
            try
            {
                var obj = db.Set<ESTADOS_PROPIEDAD>().Find(entidad.ID_ESTADO_PROPIEDAD);
                if (obj != null)
                {
                    db.Set<ESTADOS_PROPIEDAD>().Remove(obj);
                    db.SaveChanges();
                    return "ESTADOS_PROPIEDAD eliminado correctamente";
                }
                return "No se encontró el ESTADOS_PROPIEDAD";
            }
            catch (Exception ex)
            {
                return "Error al eliminar ESTADOS_PROPIEDAD: " + ex.Message;
            }
        }
    }
}
