using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsORDENES_COMPRA
    {
        private readonly INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public ORDENES_COMPRA entidad { get; set; }

        public string Insertar()
        {
            try
            {
                if (entidad == null || entidad.ID_PROVEEDOR <= 0 || entidad.ID_EMPLEADO <= 0 || entidad.TOTAL <= 0)
                    return "Datos de orden no válidos.";

                entidad.FECHA_ORDEN = entidad.FECHA_ORDEN == default(DateTime)
                    ? DateTime.Now.Date
                    : entidad.FECHA_ORDEN;

                db.ORDENES_COMPRA.Add(entidad);
                db.SaveChanges();
                return "Orden de compra insertada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al insertar orden de compra: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                if (entidad == null || entidad.ID_ORDEN <= 0)
                    return "ID de orden no válido para actualización.";

                var existente = db.ORDENES_COMPRA.Find(entidad.ID_ORDEN);
                if (existente == null)
                    return "Orden no encontrada.";

                existente.ID_PROVEEDOR = entidad.ID_PROVEEDOR;
                existente.ID_EMPLEADO = entidad.ID_EMPLEADO;
                existente.FECHA_ORDEN = entidad.FECHA_ORDEN;
                existente.TOTAL = entidad.TOTAL;

                db.Entry(existente).State = EntityState.Modified;
                db.SaveChanges();
                return "Orden de compra actualizada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al actualizar orden de compra: " + ex.Message;
            }
        }

        public ORDENES_COMPRA Consultar(int id)
        {
            try
            {
                return db.ORDENES_COMPRA.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public List<ORDENES_COMPRA> ConsultarTodos()
        {
            try
            {
                return db.ORDENES_COMPRA
                         .OrderByDescending(o => o.FECHA_ORDEN)
                         .ToList();
            }
            catch
            {
                return new List<ORDENES_COMPRA>();
            }
        }

        public string Eliminar()
        {
            try
            {
                if (entidad == null || entidad.ID_ORDEN <= 0)
                    return "ID no válido para eliminación.";

                var orden = db.ORDENES_COMPRA.Find(entidad.ID_ORDEN);
                if (orden == null)
                    return "Orden no encontrada.";

                db.ORDENES_COMPRA.Remove(orden);
                db.SaveChanges();
                return "Orden de compra eliminada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar orden de compra: " + ex.Message;
            }
        }
    }
}
