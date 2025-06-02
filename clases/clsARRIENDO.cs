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

        public object Consultar(int id)
        {
            try
            {
                using (var db = new INMOBILIARIAEntities())
                {
                    var resultado = db.ARRIENDOS
                        .Where(a => a.ID_ARRIENDO == id)
                        .Select(a => new
                        {
                            a.ID_ARRIENDO,
                            a.FECHA_INICIO,
                            a.FECHA_FIN,
                            a.CANON_MENSUAL,
                            a.DEPOSITO,
                            PROPIEDAD = new { a.PROPIEDADE.ID_PROPIEDAD, a.PROPIEDADE.TITULO },
                            CLIENTE = new { a.CLIENTE.ID_CLIENTE, a.CLIENTE.NOMBRES },
                            EMPLEADO = new { a.EMPLEADO.ID_EMPLEADO, a.EMPLEADO.NOMBRES }
                        }).FirstOrDefault();

                    if (resultado == null)
                        return "Arriendo no encontrado, verifique el ID.";
                    return resultado;
                }
            }
            catch (Exception ex) 
            {
                return "Error al consultar arriendo: " + ex.Message;
            }
        }

        public List<object> ConsultarTodos()
        {
            try
            {
                using (var db = new INMOBILIARIAEntities())
                {
                    return db.ARRIENDOS
                        .OrderBy(a => a.FECHA_INICIO)
                        .Select(a => new
                        {
                            a.ID_ARRIENDO,
                            a.ID_PROPIEDAD,
                            a.ID_INQUILINO,
                            a.ID_EMPLEADO,
                            a.FECHA_INICIO,
                            a.FECHA_FIN,
                            a.CANON_MENSUAL,
                            a.DEPOSITO,
                            PROPIEDAD = new { a.PROPIEDADE.ID_PROPIEDAD, a.PROPIEDADE.TITULO },
                            CLIENTE = new { a.CLIENTE.ID_CLIENTE, a.CLIENTE.NOMBRES },
                            EMPLEADO = new { a.EMPLEADO.ID_EMPLEADO, a.EMPLEADO.NOMBRES }
                        }).ToList<object>();
                }
            }
            catch
            {
                return new List<object>();
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
