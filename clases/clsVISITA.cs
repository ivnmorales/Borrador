using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsVISITA
    {
        private INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public VISITA entidad { get; set; }

        public string Insertar()
        {
            try
            {
                db.Set<VISITA>().Add(entidad);
                db.SaveChanges();
                return "VISITA insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar VISITA: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            db.Set<VISITA>().AddOrUpdate(entidad);
            db.SaveChanges();
            return "VISITA actualizado correctamente";
        }

        public VISITA Consultar(int id)
        {
            return db.Set<VISITA>().Find(id);
        }

        public List<VISITA> ConsultarTodos()
        {
            return db.Set<VISITA>().ToList();
        }

        public string Eliminar()
        {
            try
            {
                var obj = db.Set<VISITA>().Find(entidad.ID_VISITA);
                if (obj != null)
                {
                    db.Set<VISITA>().Remove(obj);
                    db.SaveChanges();
                    return "VISITA eliminado correctamente";
                }
                return "No se encontró el VISITA";
            }
            catch (Exception ex)
            {
                return "Error al eliminar VISITA: " + ex.Message;
            }
        }
    }
}
