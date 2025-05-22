using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsDETALLES_ORDEN
    {
        private INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public DETALLES_ORDEN entidad { get; set; }

        public string Insertar()
        {
            try
            {
                db.Set<DETALLES_ORDEN>().Add(entidad);
                db.SaveChanges();
                return "DETALLES_ORDEN insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar DETALLES_ORDEN: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            db.Set<DETALLES_ORDEN>().AddOrUpdate(entidad);
            db.SaveChanges();
            return "DETALLES_ORDEN actualizado correctamente";
        }

        public DETALLES_ORDEN Consultar(int id)
        {
            return db.Set<DETALLES_ORDEN>().Find(id);
        }

        public List<DETALLES_ORDEN> ConsultarTodos()
        {
            return db.Set<DETALLES_ORDEN>().ToList();
        }

        public string Eliminar()
        {
            try
            {
                var obj = db.Set<DETALLES_ORDEN>().Find(entidad.ID_DETALLE);
                if (obj != null)
                {
                    db.Set<DETALLES_ORDEN>().Remove(obj);
                    db.SaveChanges();
                    return "DETALLES_ORDEN eliminado correctamente";
                }
                return "No se encontró el DETALLES_ORDEN";
            }
            catch (Exception ex)
            {
                return "Error al eliminar DETALLES_ORDEN: " + ex.Message;
            }
        }
    }
}
