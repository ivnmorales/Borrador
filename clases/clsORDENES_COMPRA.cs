using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsORDENES_COMPRA
    {
        private INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public ORDENES_COMPRA entidad { get; set; }

        public string Insertar()
        {
            try
            {
                db.Set<ORDENES_COMPRA>().Add(entidad);
                db.SaveChanges();
                return "ORDENES_COMPRA insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar ORDENES_COMPRA: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            db.Set<ORDENES_COMPRA>().AddOrUpdate(entidad);
            db.SaveChanges();
            return "ORDENES_COMPRA actualizado correctamente";
        }

        public ORDENES_COMPRA Consultar(int id)
        {
            return db.Set<ORDENES_COMPRA>().Find(id);
        }

        public List<ORDENES_COMPRA> ConsultarTodos()
        {
            return db.Set<ORDENES_COMPRA>().ToList();
        }

        public string Eliminar()
        {
            try
            {
                var obj = db.Set<ORDENES_COMPRA>().Find(entidad.ID_ORDEN);
                if (obj != null)
                {
                    db.Set<ORDENES_COMPRA>().Remove(obj);
                    db.SaveChanges();
                    return "ORDENES_COMPRA eliminado correctamente";
                }
                return "No se encontró el ORDENES_COMPRA";
            }
            catch (Exception ex)
            {
                return "Error al eliminar ORDENES_COMPRA: " + ex.Message;
            }
        }
    }
}
