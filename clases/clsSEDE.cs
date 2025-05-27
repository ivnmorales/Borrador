using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsSEDE
    {
        private readonly INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public SEDE entidad { get; set; }

        public string Insertar()
        {
            try
            {
                if (entidad == null || string.IsNullOrWhiteSpace(entidad.NOMBRE))
                    return "Datos inválidos para insertar.";

                if (db.SEDES.Any(s => s.NOMBRE.Trim().ToUpper() == entidad.NOMBRE.Trim().ToUpper()))
                    return "Ya existe una sede con ese nombre.";

                db.SEDES.Add(entidad);
                db.SaveChanges();
                return "Sede insertada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al insertar sede: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                if (entidad == null || entidad.ID_SEDE <= 0)
                    return "Datos inválidos para actualizar.";

                var existente = db.SEDES.Find(entidad.ID_SEDE);
                if (existente == null)
                    return "Sede no encontrada.";

                if (db.SEDES.Any(s => s.NOMBRE.Trim().ToUpper() == entidad.NOMBRE.Trim().ToUpper() &&
                                      s.ID_SEDE != entidad.ID_SEDE))
                    return "Ya existe otra sede con ese nombre.";

                existente.NOMBRE = entidad.NOMBRE;
                existente.DIRECCION = entidad.DIRECCION;
                existente.CIUDADE = entidad.CIUDADE;

                db.Entry(existente).State = EntityState.Modified;
                db.SaveChanges();
                return "Sede actualizada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al actualizar sede: " + ex.Message;
            }
        }

        public SEDE Consultar(int id)
        {
            try
            {
                return db.SEDES.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public List<SEDE> ConsultarTodos()
        {
            try
            {
                return db.SEDES.OrderBy(s => s.NOMBRE).ToList();
            }
            catch
            {
                return new List<SEDE>();
            }
        }

        public string Eliminar()
        {
            try
            {
                if (entidad == null || entidad.ID_SEDE <= 0)
                    return "ID inválido para eliminar.";

                var obj = db.SEDES.Find(entidad.ID_SEDE);
                if (obj == null)
                    return "Sede no encontrada.";

                db.SEDES.Remove(obj);
                db.SaveChanges();
                return "Sede eliminada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar sede: " + ex.Message;
            }
        }
    }
}
