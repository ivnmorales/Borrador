using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsARRIENDO
    {
        public ARRIENDO entidad { get; set; }

        public string Insertar()
        {
            try
            {
                using (var db = new INMOBILIARIAEntities())
                {
                    if (entidad == null)
                        return "Datos de arriendo no válidos.";

                    // Validación de existencia por claves foráneas
                    if (!db.PROPIEDADES.Any(p => p.ID_PROPIEDAD == entidad.ID_PROPIEDAD))
                        return "La propiedad especificada no existe.";
                    if (!db.CLIENTES.Any(c => c.ID_CLIENTE == entidad.ID_INQUILINO))
                        return "El inquilino especificado no existe.";
                    if (!db.EMPLEADOS.Any(e => e.ID_EMPLEADO == entidad.ID_EMPLEADO))
                        return "El empleado especificado no existe.";

                    db.ARRIENDOS.Add(entidad);
                    db.SaveChanges();
                    return "Arriendo insertado correctamente";
                }
            }
            catch (Exception ex)
            {
                return "Error al insertar arriendo: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                using (var db = new INMOBILIARIAEntities())
                {
                    if (entidad == null || entidad.ID_ARRIENDO <= 0)
                        return "Datos de arriendo no válidos.";

                    var existente = db.ARRIENDOS.Find(entidad.ID_ARRIENDO);
                    if (existente == null)
                        return "No se encontró el arriendo.";

                    // Validaciones de claves foráneas
                    if (!db.PROPIEDADES.Any(p => p.ID_PROPIEDAD == entidad.ID_PROPIEDAD))
                        return "La propiedad especificada no existe.";
                    if (!db.CLIENTES.Any(c => c.ID_CLIENTE == entidad.ID_INQUILINO))
                        return "El inquilino especificado no existe.";
                    if (!db.EMPLEADOS.Any(e => e.ID_EMPLEADO == entidad.ID_EMPLEADO))
                        return "El empleado especificado no existe.";

                    db.Entry(entidad).State = EntityState.Modified;
                    db.SaveChanges();
                    return "Arriendo actualizado correctamente";
                }
            }
            catch (Exception ex)
            {
                return "Error al actualizar arriendo: " + ex.Message;
            }
        }

        public ARRIENDO Consultar(int id)
        {
            try
            {
                using (var db = new INMOBILIARIAEntities())
                {
                    return db.ARRIENDOS.Find(id);
                }
            }
            catch
            {
                return null;
            }
        }

        public List<ARRIENDO> ConsultarTodos()
        {
            try
            {
                using (var db = new INMOBILIARIAEntities())
                {
                    return db.ARRIENDOS
                             .Include(a => a.PROPIEDADE)
                             .Include(a => a.CLIENTE)
                             .Include(a => a.EMPLEADO)
                             .OrderBy(a => a.FECHA_INICIO)
                             .ToList();
                }
            }
            catch
            {
                return new List<ARRIENDO>();
            }
        }

        public string Eliminar()
        {
            try
            {
                using (var db = new INMOBILIARIAEntities())
                {
                    var existente = db.ARRIENDOS.Find(entidad.ID_ARRIENDO);
                    if (existente == null)
                        return "Arriendo no encontrado.";

                    db.ARRIENDOS.Remove(existente);
                    db.SaveChanges();
                    return "Arriendo eliminado correctamente";
                }
            }
            catch (Exception ex)
            {
                return "Error al eliminar arriendo: " + ex.Message;
            }
        }
    }
}
