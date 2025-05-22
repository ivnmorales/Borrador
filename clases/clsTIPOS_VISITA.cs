using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsTIPOS_VISITA
    {
        private INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public TIPOS_VISITA entidad { get; set; }

        public string Insertar()
        {
            try
            {
                db.Set<TIPOS_VISITA>().Add(entidad);
                db.SaveChanges();
                return "TIPOS_VISITA insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar TIPOS_VISITA: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            db.Set<TIPOS_VISITA>().AddOrUpdate(entidad);
            db.SaveChanges();
            return "TIPOS_VISITA actualizado correctamente";
        }

        public TIPOS_VISITA Consultar(int id)
        {
            return db.Set<TIPOS_VISITA>().Find(id);
        }

        public List<TIPOS_VISITA> ConsultarTodos()
        {
            return db.Set<TIPOS_VISITA>().ToList();
        }

        public string Eliminar()
        {
            try
            {
                var obj = db.Set<TIPOS_VISITA>().Find(entidad.ID_TIPO_VISITA);
                if (obj != null)
                {
                    db.Set<TIPOS_VISITA>().Remove(obj);
                    db.SaveChanges();
                    return "TIPOS_VISITA eliminado correctamente";
                }
                return "No se encontró el TIPOS_VISITA";
            }
            catch (Exception ex)
            {
                return "Error al eliminar TIPOS_VISITA: " + ex.Message;
            }
        }
    }
}
