using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsPROVEEDORE
    {
        private readonly INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public PROVEEDORE entidad { get; set; }

        public string Insertar()
        {
            try
            {
                if (entidad == null || string.IsNullOrWhiteSpace(entidad.NIT))
                    return "Datos inválidos para insertar.";

                if (db.PROVEEDORES.Any(p => p.NIT == entidad.NIT))
                    return "Ya existe un proveedor con ese NIT.";

                db.PROVEEDORES.Add(entidad);
                db.SaveChanges();
                return "Proveedor insertado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al insertar proveedor: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                if (entidad == null || entidad.ID_PROVEEDOR <= 0)
                    return "Datos inválidos para actualizar.";

                var existente = db.PROVEEDORES.Find(entidad.ID_PROVEEDOR);
                if (existente == null)
                    return "Proveedor no encontrado.";

                if (db.PROVEEDORES.Any(p => p.NIT == entidad.NIT && p.ID_PROVEEDOR != entidad.ID_PROVEEDOR))
                    return "Ya existe otro proveedor con ese NIT.";

                existente.NOMBRE_COMERCIAL = entidad.NOMBRE_COMERCIAL;
                existente.NIT = entidad.NIT;
                existente.TELEFONO = entidad.TELEFONO;
                existente.EMAIL = entidad.EMAIL;
                existente.ID_TIPO_PROVEEDOR = entidad.ID_TIPO_PROVEEDOR;

                db.Entry(existente).State = EntityState.Modified;
                db.SaveChanges();
                return "Proveedor actualizado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al actualizar proveedor: " + ex.Message;
            }
        }

        public PROVEEDORE Consultar(int id)
        {
            try
            {
                return db.PROVEEDORES.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public List<PROVEEDORE> ConsultarTodos()
        {
            try
            {
                return db.PROVEEDORES.OrderBy(p => p.NOMBRE_COMERCIAL).ToList();
            }
            catch
            {
                return new List<PROVEEDORE>();
            }
        }

        public string Eliminar()
        {
            try
            {
                if (entidad == null || entidad.ID_PROVEEDOR <= 0)
                    return "ID inválido para eliminación.";

                var obj = db.PROVEEDORES.Find(entidad.ID_PROVEEDOR);
                if (obj == null)
                    return "Proveedor no encontrado.";

                db.PROVEEDORES.Remove(obj);
                db.SaveChanges();
                return "Proveedor eliminado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar proveedor: " + ex.Message;
            }
        }
    }
}
