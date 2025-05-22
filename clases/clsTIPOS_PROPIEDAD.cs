using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsTIPOS_PROPIEDAD
    {
        private INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public TIPOS_PROPIEDAD entidad { get; set; }

        public string Insertar()
        {
            try
            {
                db.Set<TIPOS_PROPIEDAD>().Add(entidad);
                db.SaveChanges();
                return "TIPOS_PROPIEDAD insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar TIPOS_PROPIEDAD: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            db.Set<TIPOS_PROPIEDAD>().AddOrUpdate(entidad);
            db.SaveChanges();
            return "TIPOS_PROPIEDAD actualizado correctamente";
        }

        public TIPOS_PROPIEDAD Consultar(int id)
        {
            return db.Set<TIPOS_PROPIEDAD>().Find(id);
        }

        public List<TIPOS_PROPIEDAD> ConsultarTodos()
        {
            return db.Set<TIPOS_PROPIEDAD>().ToList();
        }

        public string Eliminar()
        {
            try
            {
                var obj = db.Set<TIPOS_PROPIEDAD>().Find(entidad.ID_TIPO_PROPIEDAD);
                if (obj != null)
                {
                    db.Set<TIPOS_PROPIEDAD>().Remove(obj);
                    db.SaveChanges();
                    return "TIPOS_PROPIEDAD eliminado correctamente";
                }
                return "No se encontró el TIPOS_PROPIEDAD";
            }
            catch (Exception ex)
            {
                return "Error al eliminar TIPOS_PROPIEDAD: " + ex.Message;
            }
        }
    }
}
