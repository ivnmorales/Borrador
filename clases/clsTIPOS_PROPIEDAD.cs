using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsTIPOS_PROPIEDAD
    {
        private readonly INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public TIPOS_PROPIEDAD entidad { get; set; }

        public string Insertar()
        {
            try
            {
                if (db.TIPOS_PROPIEDAD.Any(t => t.DESCRIPCION.Trim().ToUpper() == entidad.DESCRIPCION.Trim().ToUpper()))
                    return "Ya existe un tipo de propiedad con esa descripción.";

                db.TIPOS_PROPIEDAD.Add(entidad);
                db.SaveChanges();
                return "Tipo de propiedad insertado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al insertar tipo de propiedad: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                if (entidad == null || entidad.ID_TIPO_PROPIEDAD <= 0)
                    return "Datos inválidos para actualizar.";

                bool duplicado = db.TIPOS_PROPIEDAD.Any(t =>
                    t.DESCRIPCION.Trim().ToUpper() == entidad.DESCRIPCION.Trim().ToUpper() &&
                    t.ID_TIPO_PROPIEDAD != entidad.ID_TIPO_PROPIEDAD);

                if (duplicado)
                    return "Ya existe otro tipo de propiedad con la misma descripción.";

                db.TIPOS_PROPIEDAD.AddOrUpdate(entidad);
                db.SaveChanges();
                return "Tipo de propiedad actualizado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al actualizar tipo de propiedad: " + ex.Message;
            }
        }

        public TIPOS_PROPIEDAD Consultar(int id)
        {
            try
            {
                return db.TIPOS_PROPIEDAD.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public List<TIPOS_PROPIEDAD> ConsultarTodos()
        {
            try
            {
                return db.TIPOS_PROPIEDAD.OrderBy(t => t.DESCRIPCION).ToList();
            }
            catch
            {
                return new List<TIPOS_PROPIEDAD>();
            }
        }

        public string Eliminar()
        {
            try
            {
                var obj = db.TIPOS_PROPIEDAD.Find(entidad.ID_TIPO_PROPIEDAD);
                if (obj == null)
                    return "Tipo de propiedad no encontrado.";

                db.TIPOS_PROPIEDAD.Remove(obj);
                db.SaveChanges();
                return "Tipo de propiedad eliminado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar tipo de propiedad: " + ex.Message;
            }
        }
    }
}
