using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsPROPIETARIO
    {
        private INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public PROPIETARIO entidad { get; set; }

        public string Insertar()
        {
            try
            {
                db.Set<PROPIETARIO>().Add(entidad);
                db.SaveChanges();
                return "PROPIETARIO insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar PROPIETARIO: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            db.Set<PROPIETARIO>().AddOrUpdate(entidad);
            db.SaveChanges();
            return "PROPIETARIO actualizado correctamente";
        }

        public PROPIETARIO Consultar(int id)
        {
            return db.Set<PROPIETARIO>().Find(id);
        }

        public List<PROPIETARIO> ConsultarTodos()
        {
            return db.Set<PROPIETARIO>().ToList();
        }

        public string Eliminar()
        {
            try
            {
                var obj = db.Set<PROPIETARIO>().Find(entidad.ID_PROPIETARIO);
                if (obj != null)
                {
                    db.Set<PROPIETARIO>().Remove(obj);
                    db.SaveChanges();
                    return "PROPIETARIO eliminado correctamente";
                }
                return "No se encontró el PROPIETARIO";
            }
            catch (Exception ex)
            {
                return "Error al eliminar PROPIETARIO: " + ex.Message;
            }
        }
    }
}
