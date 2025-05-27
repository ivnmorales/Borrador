using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsVENTA
    {
        private readonly INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public VENTA entidad { get; set; }

        public string Insertar()
        {
            try
            {
                if (entidad == null)
                    return "Entidad no válida.";

                db.VENTAS.Add(entidad);
                db.SaveChanges();
                return "Venta insertada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al insertar venta: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                if (entidad == null || entidad.ID_VENTA <= 0)
                    return "Entidad no válida para actualizar.";

                var existente = db.VENTAS.Find(entidad.ID_VENTA);
                if (existente == null)
                    return "Venta no encontrada.";

                db.VENTAS.AddOrUpdate(entidad);
                db.SaveChanges();
                return "Venta actualizada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al actualizar venta: " + ex.Message;
            }
        }

        public VENTA Consultar(int id)
        {
            try
            {
                return db.VENTAS.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public List<VENTA> ConsultarTodos()
        {
            try
            {
                return db.VENTAS.OrderBy(v => v.ID_VENTA).ToList();
            }
            catch
            {
                return new List<VENTA>();
            }
        }

        public string Eliminar()
        {
            try
            {
                var obj = db.VENTAS.Find(entidad.ID_VENTA);
                if (obj == null)
                    return "Venta no encontrada.";

                db.VENTAS.Remove(obj);
                db.SaveChanges();
                return "Venta eliminada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar venta: " + ex.Message;
            }
        }
    }
}
