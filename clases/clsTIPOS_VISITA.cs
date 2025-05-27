using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsTIPOS_VISITA
    {
        private readonly INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public TIPOS_VISITA entidad { get; set; }

        public string Insertar()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(entidad.DESCRIPCION))
                    return "La descripción no puede estar vacía.";

                bool existe = db.TIPOS_VISITA.Any(t => t.DESCRIPCION.Trim().ToUpper() == entidad.DESCRIPCION.Trim().ToUpper());
                if (existe)
                    return "Ya existe un tipo de visita con esa descripción.";

                db.TIPOS_VISITA.Add(entidad);
                db.SaveChanges();
                return "Tipo de visita insertado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al insertar tipo de visita: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                if (entidad == null || entidad.ID_TIPO_VISITA <= 0)
                    return "Datos inválidos para actualizar.";

                if (string.IsNullOrWhiteSpace(entidad.DESCRIPCION))
                    return "La descripción no puede estar vacía.";

                bool duplicado = db.TIPOS_VISITA.Any(t =>
                    t.DESCRIPCION.Trim().ToUpper() == entidad.DESCRIPCION.Trim().ToUpper() &&
                    t.ID_TIPO_VISITA != entidad.ID_TIPO_VISITA);

                if (duplicado)
                    return "Ya existe otro tipo de visita con la misma descripción.";

                db.TIPOS_VISITA.AddOrUpdate(entidad);
                db.SaveChanges();
                return "Tipo de visita actualizado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al actualizar tipo de visita: " + ex.Message;
            }
        }

        public TIPOS_VISITA Consultar(int id)
        {
            try
            {
                return db.TIPOS_VISITA.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public List<TIPOS_VISITA> ConsultarTodos()
        {
            try
            {
                return db.TIPOS_VISITA.OrderBy(t => t.DESCRIPCION).ToList();
            }
            catch
            {
                return new List<TIPOS_VISITA>();
            }
        }

        public string Eliminar()
        {
            try
            {
                var obj = db.TIPOS_VISITA.Find(entidad.ID_TIPO_VISITA);
                if (obj == null)
                    return "Tipo de visita no encontrado.";

                db.TIPOS_VISITA.Remove(obj);
                db.SaveChanges();
                return "Tipo de visita eliminado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar tipo de visita: " + ex.Message;
            }
        }
    }
}
