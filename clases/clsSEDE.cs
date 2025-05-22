using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsSEDE
    {
        private INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public SEDE entidad { get; set; }

        public string Insertar()
        {
            try
            {
                db.Set<SEDE>().Add(entidad);
                db.SaveChanges();
                return "SEDE insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar SEDE: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            db.Set<SEDE>().AddOrUpdate(entidad);
            db.SaveChanges();
            return "SEDE actualizado correctamente";
        }

        public SEDE Consultar(int id)
        {
            return db.Set<SEDE>().Find(id);
        }

        public List<SEDE> ConsultarTodos()
        {
            return db.Set<SEDE>().ToList();
        }

        public string Eliminar()
        {
            try
            {
                var obj = db.Set<SEDE>().Find(entidad.ID_SEDE);
                if (obj != null)
                {
                    db.Set<SEDE>().Remove(obj);
                    db.SaveChanges();
                    return "SEDE eliminado correctamente";
                }
                return "No se encontró el SEDE";
            }
            catch (Exception ex)
            {
                return "Error al eliminar SEDE: " + ex.Message;
            }
        }
    }
}
