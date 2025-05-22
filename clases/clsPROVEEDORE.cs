using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsPROVEEDORE
    {
        private INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public PROVEEDORE entidad { get; set; }

        public string Insertar()
        {
            try
            {
                db.Set<PROVEEDORE>().Add(entidad);
                db.SaveChanges();
                return "PROVEEDORE insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar PROVEEDORE: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            db.Set<PROVEEDORE>().AddOrUpdate(entidad);
            db.SaveChanges();
            return "PROVEEDORE actualizado correctamente";
        }

        public PROVEEDORE Consultar(int id)
        {
            return db.Set<PROVEEDORE>().Find(id);
        }

        public List<PROVEEDORE> ConsultarTodos()
        {
            return db.Set<PROVEEDORE>().ToList();
        }

        public string Eliminar()
        {
            try
            {
                var obj = db.Set<PROVEEDORE>().Find(entidad.ID_PROVEEDOR);
                if (obj != null)
                {
                    db.Set<PROVEEDORE>().Remove(obj);
                    db.SaveChanges();
                    return "PROVEEDORE eliminado correctamente";
                }
                return "No se encontró el PROVEEDORE";
            }
            catch (Exception ex)
            {
                return "Error al eliminar PROVEEDORE: " + ex.Message;
            }
        }
    }
}
