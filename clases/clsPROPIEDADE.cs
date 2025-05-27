using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsPROPIEDADE
    {
        private readonly INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public PROPIEDADE entidad { get; set; }

        public string Insertar()
        {
            try
            {
                if (entidad == null || entidad.ID_TIPO_PROPIEDAD <= 0 || entidad.ID_CIUDAD <= 0 || entidad.ID_ESTADO_PROPIEDAD <= 0)
                    return "Datos de propiedad no válidos.";

                entidad.FECHA_REGISTRO = entidad.FECHA_REGISTRO == default(DateTime)
                    ? DateTime.Now
                    : entidad.FECHA_REGISTRO;

                db.PROPIEDADES.Add(entidad);
                db.SaveChanges();
                return "Propiedad insertada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al insertar propiedad: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                if (entidad == null || entidad.ID_PROPIEDAD <= 0)
                    return "ID de propiedad no válido para actualización.";

                var existente = db.PROPIEDADES.Find(entidad.ID_PROPIEDAD);
                if (existente == null)
                    return "Propiedad no encontrada.";

                // Actualizar campos uno a uno
                existente.TITULO = entidad.TITULO;
                existente.DESCRIPCION = entidad.DESCRIPCION;
                existente.ID_TIPO_PROPIEDAD = entidad.ID_TIPO_PROPIEDAD;
                existente.AREA_M2 = entidad.AREA_M2;
                existente.HABITACIONES = entidad.HABITACIONES;
                existente.BANOS = entidad.BANOS;
                existente.PARQUEADEROS = entidad.PARQUEADEROS;
                existente.ANIO_CONSTRUCCION = entidad.ANIO_CONSTRUCCION;
                existente.DIRECCION = entidad.DIRECCION;
                existente.ID_CIUDAD = entidad.ID_CIUDAD;
                existente.PRECIO_VENTA = entidad.PRECIO_VENTA;
                existente.PRECIO_ARRIENDO = entidad.PRECIO_ARRIENDO;
                existente.ID_ESTADO_PROPIEDAD = entidad.ID_ESTADO_PROPIEDAD;

                db.Entry(existente).State = EntityState.Modified;
                db.SaveChanges();
                return "Propiedad actualizada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al actualizar propiedad: " + ex.Message;
            }
        }

        public PROPIEDADE Consultar(int id)
        {
            try
            {
                return db.PROPIEDADES.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public List<PROPIEDADE> ConsultarTodos()
        {
            try
            {
                return db.PROPIEDADES
                         .OrderByDescending(p => p.FECHA_REGISTRO)
                         .ToList();
            }
            catch
            {
                return new List<PROPIEDADE>();
            }
        }

        public string Eliminar()
        {
            try
            {
                if (entidad == null || entidad.ID_PROPIEDAD <= 0)
                    return "ID de propiedad no válido para eliminación.";

                var propiedad = db.PROPIEDADES.Find(entidad.ID_PROPIEDAD);
                if (propiedad == null)
                    return "Propiedad no encontrada.";

                db.PROPIEDADES.Remove(propiedad);
                db.SaveChanges();
                return "Propiedad eliminada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar propiedad: " + ex.Message;
            }
        }
    }
}
