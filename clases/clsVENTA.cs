using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsVENTA
    {
        private INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public VENTA entidad { get; set; }

        public string Insertar()
        {
            try
            {
                db.Set<VENTA>().Add(entidad);
                db.SaveChanges();
                return "VENTA insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar VENTA: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            db.Set<VENTA>().AddOrUpdate(entidad);
            db.SaveChanges();
            return "VENTA actualizado correctamente";
        }

        public VENTA Consultar(int id)
        {
            return db.Set<VENTA>().Find(id);
        }

        public List<VENTA> ConsultarTodos()
        {
            return db.Set<VENTA>().ToList();
        }

        public string Eliminar()
        {
            try
            {
                var obj = db.Set<VENTA>().Find(entidad.ID_VENTA);
                if (obj != null)
                {
                    db.Set<VENTA>().Remove(obj);
                    db.SaveChanges();
                    return "VENTA eliminado correctamente";
                }
                return "No se encontró el VENTA";
            }
            catch (Exception ex)
            {
                return "Error al eliminar VENTA: " + ex.Message;
            }
        }
    }
}
