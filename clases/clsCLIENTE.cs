using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsCLIENTE
    {
        private  INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public CLIENTE entidad { get; set; }

        public string Insertar()
        {
            try
            {
                if (entidad == null)
                    return "Datos del cliente no válidos.";

                bool existe = db.CLIENTES.Any(c => c.IDENTIFICACION == entidad.IDENTIFICACION);
                if (existe)
                    return "Ya existe un cliente con la misma identificación.";

                // Asegurar que FECHA_REGISTRO esté presente
                if (entidad.FECHA_REGISTRO == default(DateTime))
                    entidad.FECHA_REGISTRO = DateTime.Now;

                db.CLIENTES.Add(entidad);
                db.SaveChanges();
                return "CLIENTE insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar CLIENTE: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                if (entidad == null || entidad.ID_CLIENTE <= 0)
                    return "Datos del cliente no válidos para actualizar.";

                var existente = db.CLIENTES.Find(entidad.ID_CLIENTE);
                if (existente == null)
                    return "Cliente no encontrado.";

                bool duplicado = db.CLIENTES.Any(c =>
                    c.IDENTIFICACION == entidad.IDENTIFICACION &&
                    c.ID_CLIENTE != entidad.ID_CLIENTE);

                if (duplicado)
                    return "Ya existe otro cliente con la misma identificación.";

                // Actualizar campos
                existente.IDENTIFICACION = entidad.IDENTIFICACION;
                existente.NOMBRES = entidad.NOMBRES;
                existente.APELLIDOS = entidad.APELLIDOS;
                existente.TELEFONO = entidad.TELEFONO;
                existente.EMAIL = entidad.EMAIL;
                existente.DIRECCION = entidad.DIRECCION;

                db.Entry(existente).State = EntityState.Modified;
                db.SaveChanges();
                return "CLIENTE actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar CLIENTE: " + ex.Message;
            }
        }

        public CLIENTE Consultar(int id)
        {
            try
            {
                return db.CLIENTES.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public List<CLIENTE> ConsultarTodos()
        {
            try
            {
                return db.CLIENTES.OrderBy(c => c.NOMBRES).ToList();
            }
            catch
            {
                return new List<CLIENTE>();
            }
        }

        public string Eliminar()
        {
            try
            {
                if (entidad == null || entidad.ID_CLIENTE <= 0)
                    return "ID de cliente no válido.";

                var cliente = db.CLIENTES.Find(entidad.ID_CLIENTE);
                if (cliente == null)
                    return "No se encontró el CLIENTE";

                db.CLIENTES.Remove(cliente);
                db.SaveChanges();
                return "CLIENTE eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar CLIENTE: " + ex.Message;
            }
        }
    }
}
