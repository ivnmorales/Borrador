using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsTIPOS_PROVEEDOR
    {
        private INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public TIPOS_PROVEEDOR entidad { get; set; }

        public string Insertar()
        {
            try
            {
                db.Set<TIPOS_PROVEEDOR>().Add(entidad);
                db.SaveChanges();
                return "TIPOS_PROVEEDOR insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar TIPOS_PROVEEDOR: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            db.Set<TIPOS_PROVEEDOR>().AddOrUpdate(entidad);
            db.SaveChanges();
            return "TIPOS_PROVEEDOR actualizado correctamente";
        }

        public TIPOS_PROVEEDOR Consultar(int id)
        {
            return db.Set<TIPOS_PROVEEDOR>().Find(id);
        }

        public List<TIPOS_PROVEEDOR> ConsultarTodos()
        {
            return db.Set<TIPOS_PROVEEDOR>().ToList();
        }

        public string Eliminar()
        {
            try
            {
                var obj = db.Set<TIPOS_PROVEEDOR>().Find(entidad.ID_TIPO_PROVEEDOR);
                if (obj != null)
                {
                    db.Set<TIPOS_PROVEEDOR>().Remove(obj);
                    db.SaveChanges();
                    return "TIPOS_PROVEEDOR eliminado correctamente";
                }
                return "No se encontró el TIPOS_PROVEEDOR";
            }
            catch (Exception ex)
            {
                return "Error al eliminar TIPOS_PROVEEDOR: " + ex.Message;
            }
        }
    }
}
