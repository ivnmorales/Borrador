using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsCLIENTE
    {
        private INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public CLIENTE entidad { get; set; }

        public string Insertar()
        {
            try
            {
                db.Set<CLIENTE>().Add(entidad);
                db.SaveChanges();
                return "CLIENTE insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar CLIENTE: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            db.Set<CLIENTE>().AddOrUpdate(entidad);
            db.SaveChanges();
            return "CLIENTE actualizado correctamente";
        }

        public CLIENTE Consultar(int id)
        {
            return db.Set<CLIENTE>().Find(id);
        }

        public List<CLIENTE> ConsultarTodos()
        {
            return db.Set<CLIENTE>().ToList();
        }

        public string Eliminar()
        {
            try
            {
                var obj = db.Set<CLIENTE>().Find(entidad.ID_CLIENTE);
                if (obj != null)
                {
                    db.Set<CLIENTE>().Remove(obj);
                    db.SaveChanges();
                    return "CLIENTE eliminado correctamente";
                }
                return "No se encontró el CLIENTE";
            }
            catch (Exception ex)
            {
                return "Error al eliminar CLIENTE: " + ex.Message;
            }
        }
    }
}
