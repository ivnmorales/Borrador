using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsPROYECTO
    {
        private INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public PROYECTO entidad { get; set; }

        public string Insertar()
        {
            try
            {
                db.Set<PROYECTO>().Add(entidad);
                db.SaveChanges();
                return "PROYECTO insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar PROYECTO: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            db.Set<PROYECTO>().AddOrUpdate(entidad);
            db.SaveChanges();
            return "PROYECTO actualizado correctamente";
        }

        public PROYECTO Consultar(int id)
        {
            return db.Set<PROYECTO>().Find(id);
        }

        public List<PROYECTO> ConsultarTodos()
        {
            return db.Set<PROYECTO>().ToList();
        }

        public string Eliminar()
        {
            try
            {
                var obj = db.Set<PROYECTO>().Find(entidad.ID_PROYECTO);
                if (obj != null)
                {
                    db.Set<PROYECTO>().Remove(obj);
                    db.SaveChanges();
                    return "PROYECTO eliminado correctamente";
                }
                return "No se encontró el PROYECTO";
            }
            catch (Exception ex)
            {
                return "Error al eliminar PROYECTO: " + ex.Message;
            }
        }
    }
}
