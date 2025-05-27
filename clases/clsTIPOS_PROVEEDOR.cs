using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsTIPOS_PROVEEDOR
    {
        private readonly INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public TIPOS_PROVEEDOR entidad { get; set; }

        public string Insertar()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(entidad.DESCRIPCION))
                    return "La descripción no puede estar vacía.";

                bool existe = db.TIPOS_PROVEEDOR.Any(tp => tp.DESCRIPCION.Trim().ToUpper() == entidad.DESCRIPCION.Trim().ToUpper());
                if (existe)
                    return "Ya existe un tipo de proveedor con esta descripción.";

                db.TIPOS_PROVEEDOR.Add(entidad);
                db.SaveChanges();
                return "Tipo de proveedor insertado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al insertar tipo de proveedor: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                if (entidad == null || entidad.ID_TIPO_PROVEEDOR <= 0)
                    return "ID inválido para actualizar.";

                if (string.IsNullOrWhiteSpace(entidad.DESCRIPCION))
                    return "La descripción no puede estar vacía.";

                bool duplicado = db.TIPOS_PROVEEDOR.Any(tp =>
                    tp.DESCRIPCION.Trim().ToUpper() == entidad.DESCRIPCION.Trim().ToUpper() &&
                    tp.ID_TIPO_PROVEEDOR != entidad.ID_TIPO_PROVEEDOR);

                if (duplicado)
                    return "Ya existe otro tipo de proveedor con la misma descripción.";

                db.TIPOS_PROVEEDOR.AddOrUpdate(entidad);
                db.SaveChanges();
                return "Tipo de proveedor actualizado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al actualizar tipo de proveedor: " + ex.Message;
            }
        }

        public TIPOS_PROVEEDOR Consultar(int id)
        {
            try
            {
                return db.TIPOS_PROVEEDOR.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public List<TIPOS_PROVEEDOR> ConsultarTodos()
        {
            try
            {
                return db.TIPOS_PROVEEDOR.OrderBy(tp => tp.DESCRIPCION).ToList();
            }
            catch
            {
                return new List<TIPOS_PROVEEDOR>();
            }
        }

        public string Eliminar()
        {
            try
            {
                var obj = db.TIPOS_PROVEEDOR.Find(entidad.ID_TIPO_PROVEEDOR);
                if (obj == null)
                    return "Tipo de proveedor no encontrado.";

                db.TIPOS_PROVEEDOR.Remove(obj);
                db.SaveChanges();
                return "Tipo de proveedor eliminado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar tipo de proveedor: " + ex.Message;
            }
        }
    }
}
