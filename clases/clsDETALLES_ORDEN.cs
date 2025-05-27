using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsDETALLES_ORDEN
    {
        private readonly INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public DETALLES_ORDEN entidad { get; set; }

        public string Insertar()
        {
            try
            {
                if (entidad == null)
                    return "Datos inválidos para inserción.";

                db.DETALLES_ORDEN.Add(entidad);
                db.SaveChanges();
                return "Detalle de orden insertado correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al insertar detalle de orden: {ex.Message}";
            }
        }

        public string Actualizar()
        {
            try
            {
                if (entidad == null || entidad.ID_DETALLE <= 0)
                    return "Datos inválidos para actualización.";

                var existente = db.DETALLES_ORDEN.Find(entidad.ID_DETALLE);
                if (existente == null)
                    return "No se encontró el detalle de orden.";

                db.Entry(entidad).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return "Detalle de orden actualizado correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al actualizar detalle de orden: {ex.Message}";
            }
        }

        public DETALLES_ORDEN Consultar(int id)
        {
            try
            {
                return db.DETALLES_ORDEN.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public List<DETALLES_ORDEN> ConsultarTodos()
        {
            try
            {
                return db.DETALLES_ORDEN.OrderBy(d => d.ID_DETALLE).ToList();
            }
            catch
            {
                return new List<DETALLES_ORDEN>();
            }
        }

        public string Eliminar()
        {
            try
            {
                if (entidad == null || entidad.ID_DETALLE <= 0)
                    return "ID inválido para eliminación.";

                var detalle = db.DETALLES_ORDEN.Find(entidad.ID_DETALLE);
                if (detalle == null)
                    return "No se encontró el detalle de orden.";

                db.DETALLES_ORDEN.Remove(detalle);
                db.SaveChanges();
                return "Detalle de orden eliminado correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar detalle de orden: {ex.Message}";
            }
        }
    }
}
