using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsPROPIEDADES_MODELO
    {
        private readonly INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public PROPIEDADES_MODELO entidad { get; set; }

        public string Insertar()
        {
            try
            {
                if (entidad == null || entidad.ID_PROPIEDAD <= 0 || entidad.ID_PROYECTO <= 0)
                    return "Datos incompletos para insertar.";

                if (db.PROPIEDADES_MODELO.Any(p => p.ID_PROPIEDAD == entidad.ID_PROPIEDAD))
                    return "Ya existe un modelo para esta propiedad.";

                entidad.FECHA_DECORACION = entidad.FECHA_DECORACION == default
                    ? DateTime.Now
                    : entidad.FECHA_DECORACION;

                db.PROPIEDADES_MODELO.Add(new PROPIEDADES_MODELO
                {
                    ID_PROPIEDAD = entidad.ID_PROPIEDAD,
                    ID_PROYECTO = entidad.ID_PROYECTO,
                    COSTO_DECORACION = entidad.COSTO_DECORACION,
                    FECHA_DECORACION = entidad.FECHA_DECORACION
                });

                db.SaveChanges();
                return "Propiedad modelo insertada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al insertar propiedad modelo: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                if (entidad == null || entidad.ID_PROPIEDAD <= 0)
                    return "ID de propiedad no válido para actualizar.";

                var existente = db.PROPIEDADES_MODELO.Find(entidad.ID_PROPIEDAD);
                if (existente == null)
                    return "No se encontró la propiedad modelo.";

                existente.ID_PROYECTO = entidad.ID_PROYECTO;
                existente.COSTO_DECORACION = entidad.COSTO_DECORACION;
                existente.FECHA_DECORACION = entidad.FECHA_DECORACION;

                db.Entry(existente).State = EntityState.Modified;
                db.SaveChanges();
                return "Propiedad modelo actualizada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al actualizar propiedad modelo: " + ex.Message;
            }
        }

        public object Consultar(int id)
        {
            try
            {
                return db.PROPIEDADES_MODELO
                    .Where(p => p.ID_PROPIEDAD == id)
                    .Select(p => new
                    {
                        p.ID_PROPIEDAD,
                        p.ID_PROYECTO,
                        p.COSTO_DECORACION,
                        p.FECHA_DECORACION
                    })
                    .FirstOrDefault();
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
                return db.PROPIEDADES_MODELO
                         .OrderByDescending(p => p.FECHA_DECORACION)
                         .Select(p => new
                         {
                             p.ID_PROPIEDAD,
                             p.ID_PROYECTO,
                             p.COSTO_DECORACION,
                             p.FECHA_DECORACION
                         })
                         .ToList<object>();
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
                if (entidad == null || entidad.ID_PROPIEDAD <= 0)
                    return "ID de propiedad no válido para eliminación.";

                var modelo = db.PROPIEDADES_MODELO.Find(entidad.ID_PROPIEDAD);
                if (modelo == null)
                    return "Propiedad modelo no encontrada.";

                db.PROPIEDADES_MODELO.Remove(modelo);
                db.SaveChanges();
                return "Propiedad modelo eliminada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar propiedad modelo: " + ex.Message;
            }
        }
    }
}
