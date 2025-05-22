using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsCIUDADE
    {
        private INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public CIUDADE entidad { get; set; }

        public string Insertar()
        {
            try
            {
                db.Set<CIUDADE>().Add(entidad);
                db.SaveChanges();
                return "CIUDADE insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar CIUDADE: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            db.Set<CIUDADE>().AddOrUpdate(entidad);
            db.SaveChanges();
            return "CIUDADE actualizado correctamente";
        }

        public CIUDADE Consultar(int id)
        {
            return db.Set<CIUDADE>().Find(id);
        }

        public List<CIUDADE> ConsultarTodos()
        {
            return db.Set<CIUDADE>().ToList();
        }

        public string Eliminar()
        {
            try
            {
                var obj = db.Set<CIUDADE>().Find(entidad.ID_CIUDAD);
                if (obj != null)
                {
                    db.Set<CIUDADE>().Remove(obj);
                    db.SaveChanges();
                    return "CIUDADE eliminado correctamente";
                }
                return "No se encontró el CIUDADE";
            }
            catch (Exception ex)
            {
                return "Error al eliminar CIUDADE: " + ex.Message;
            }
        }
    }
}
