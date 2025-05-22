using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsCONSIGNACIONE
    {
        private INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public CONSIGNACIONE entidad { get; set; }

        public string Insertar()
        {
            try
            {
                db.Set<CONSIGNACIONE>().Add(entidad);
                db.SaveChanges();
                return "CONSIGNACIONE insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar CONSIGNACIONE: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            db.Set<CONSIGNACIONE>().AddOrUpdate(entidad);
            db.SaveChanges();
            return "CONSIGNACIONE actualizado correctamente";
        }

        public CONSIGNACIONE Consultar(int id)
        {
            return db.Set<CONSIGNACIONE>().Find(id);
        }

        public List<CONSIGNACIONE> ConsultarTodos()
        {
            return db.Set<CONSIGNACIONE>().ToList();
        }

        public string Eliminar()
        {
            try
            {
                var obj = db.Set<CONSIGNACIONE>().Find(entidad.ID_CONSIGNACION);
                if (obj != null)
                {
                    db.Set<CONSIGNACIONE>().Remove(obj);
                    db.SaveChanges();
                    return "CONSIGNACIONE eliminado correctamente";
                }
                return "No se encontró el CONSIGNACIONE";
            }
            catch (Exception ex)
            {
                return "Error al eliminar CONSIGNACIONE: " + ex.Message;
            }
        }
    }
}
