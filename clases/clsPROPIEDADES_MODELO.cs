using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsPROPIEDADES_MODELO
    {
        private INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public PROPIEDADES_MODELO entidad { get; set; }

        public string Insertar()
        {
            try
            {
                db.Set<PROPIEDADES_MODELO>().Add(entidad);
                db.SaveChanges();
                return "PROPIEDADES_MODELO insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar PROPIEDADES_MODELO: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            db.Set<PROPIEDADES_MODELO>().AddOrUpdate(entidad);
            db.SaveChanges();
            return "PROPIEDADES_MODELO actualizado correctamente";
        }

        public PROPIEDADES_MODELO Consultar(int id)
        {
            return db.Set<PROPIEDADES_MODELO>().Find(id);
        }

        public List<PROPIEDADES_MODELO> ConsultarTodos()
        {
            return db.Set<PROPIEDADES_MODELO>().ToList();
        }

        public string Eliminar()
        {
            try
            {
                var obj = db.Set<PROPIEDADES_MODELO>().Find(entidad.ID_PROPIEDAD);
                if (obj != null)
                {
                    db.Set<PROPIEDADES_MODELO>().Remove(obj);
                    db.SaveChanges();
                    return "PROPIEDADES_MODELO eliminado correctamente";
                }
                return "No se encontró el PROPIEDADES_MODELO";
            }
            catch (Exception ex)
            {
                return "Error al eliminar PROPIEDADES_MODELO: " + ex.Message;
            }
        }
    }
}
