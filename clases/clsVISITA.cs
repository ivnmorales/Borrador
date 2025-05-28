using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsVISITA
    {
        private readonly INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public VISITA entidad { get; set; }

        public string Insertar()
        {
            try
            {
                if (entidad == null)
                    return "Entidad no válida para inserción.";

                db.VISITAS.Add(entidad);
                db.SaveChanges();
                return "VISITA insertada correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al insertar VISITA: {ex.Message}";
            }
        }

        public string Actualizar()
        {
            try
            {
                if (entidad == null || entidad.ID_VISITA <= 0)
                    return "Entidad no válida para actualización.";

                var existente = db.VISITAS.Find(entidad.ID_VISITA);
                if (existente == null)
                    return "VISITA no encontrada para actualizar.";

                db.Entry(existente).CurrentValues.SetValues(entidad);
                db.SaveChanges();
                return "VISITA actualizada correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al actualizar VISITA: {ex.Message}";
            }
        }

        public object Consultar(int id)
        {
            try
            {
                var v = db.VISITAS.Find(id);
                if (v == null) return null;

                return new
                {
                    v.ID_VISITA,
                    v.ID_PROPIEDAD,
                    v.ID_CLIENTE,
                    v.ID_EMPLEADO,
                    v.ID_TIPO_VISITA,
                    v.FECHA_HORA,
                    v.COMENTARIOS
                };
            }
            catch
            {
                return null;
            }
        }

        public List<object> ConsultarTodos()
        {
            try
            {
                return db.VISITAS
                    .OrderBy(v => v.ID_VISITA)
                    .Select(v => new
                    {
                        v.ID_VISITA,
                        v.ID_PROPIEDAD,
                        v.ID_CLIENTE,
                        v.ID_EMPLEADO,
                        v.ID_TIPO_VISITA,
                        v.FECHA_HORA,
                        v.COMENTARIOS
                    }).ToList<object>();
            }
            catch
            {
                return new List<object>();
            }
        }

        public string Eliminar()
        {
            try
            {
                if (entidad == null || entidad.ID_VISITA <= 0)
                    return "Entidad no válida para eliminación.";

                var obj = db.VISITAS.Find(entidad.ID_VISITA);
                if (obj == null)
                    return "VISITA no encontrada.";

                db.VISITAS.Remove(obj);
                db.SaveChanges();
                return "VISITA eliminada correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar VISITA: {ex.Message}";
            }
        }
    }
}
