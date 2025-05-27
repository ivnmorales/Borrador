// Clase de lógica de negocio optimizada para CONSIGNACIONE
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsCONSIGNACIONE
    {
        private readonly INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public CONSIGNACIONE entidad { get; set; }

        public string Insertar()
        {
            try
            {
                if (entidad == null)
                    return "Entidad vacía";

                // Validar llaves foráneas
                bool propiedadExiste = db.PROPIEDADES.Any(p => p.ID_PROPIEDAD == entidad.ID_PROPIEDAD);
                bool propietarioExiste = db.PROPIETARIOS.Any(p => p.ID_PROPIETARIO == entidad.ID_PROPIETARIO);

                if (!propiedadExiste)
                    return "La propiedad asociada no existe.";

                if (!propietarioExiste)
                    return "El propietario asociado no existe.";

                db.CONSIGNACIONES.Add(entidad);
                db.SaveChanges();
                return "Consignación insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar consignación: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                if (entidad == null || entidad.ID_CONSIGNACION <= 0)
                    return "Datos inválidos para actualizar.";

                var existente = db.CONSIGNACIONES.Find(entidad.ID_CONSIGNACION);
                if (existente == null)
                    return "Consignación no encontrada.";

                bool propiedadExiste = db.PROPIEDADES.Any(p => p.ID_PROPIEDAD == entidad.ID_PROPIEDAD);
                bool propietarioExiste = db.PROPIETARIOS.Any(p => p.ID_PROPIETARIO == entidad.ID_PROPIETARIO);

                if (!propiedadExiste)
                    return "La propiedad asociada no existe.";

                if (!propietarioExiste)
                    return "El propietario asociado no existe.";

                db.Entry(entidad).State = EntityState.Modified;
                db.SaveChanges();
                return "Consignación actualizada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar consignación: " + ex.Message;
            }
        }

        public CONSIGNACIONE Consultar(int id)
        {
            return db.CONSIGNACIONES.Include(c => c.PROPIEDADE)
                                     .Include(c => c.PROPIETARIO)
                                     .FirstOrDefault(c => c.ID_CONSIGNACION == id);
        }

        public List<CONSIGNACIONE> ConsultarTodos()
        {
            return db.CONSIGNACIONES
                     .Include(c => c.PROPIEDADE)
                     .Include(c => c.PROPIETARIO)
                     .OrderBy(c => c.FECHA_INICIO)
                     .ToList();
        }

        public string Eliminar()
        {
            try
            {
                if (entidad == null || entidad.ID_CONSIGNACION <= 0)
                    return "ID inválido para eliminar.";

                var obj = db.CONSIGNACIONES.Find(entidad.ID_CONSIGNACION);
                if (obj == null)
                    return "Consignación no encontrada.";

                db.CONSIGNACIONES.Remove(obj);
                db.SaveChanges();
                return "Consignación eliminada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar consignación: " + ex.Message;
            }
        }
    }
}
