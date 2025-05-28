using System;
using System.Collections.Generic;
using System.Linq;
using Borrador.Models;
using System.Data.Entity.Migrations;

namespace Borrador.Clases
{
    public class clsUSUARIO
    {
        private readonly INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public USUARIO entidad { get; set; }

        public string Insertar()
        {
            try
            {
                if (entidad == null || string.IsNullOrWhiteSpace(entidad.EMAIL) || string.IsNullOrWhiteSpace(entidad.CONTRASENA))
                    return "Datos incompletos para registrar usuario.";

                bool existe = db.USUARIOS.Any(u => u.EMAIL.Trim().ToLower() == entidad.EMAIL.Trim().ToLower());
                if (existe)
                    return "Ya existe un usuario registrado con ese email.";

                db.USUARIOS.Add(entidad);
                db.SaveChanges();
                return "Usuario registrado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al registrar usuario: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                if (entidad == null || entidad.ID_USUARIO <= 0)
                    return "ID inválido para actualizar.";

                var existente = db.USUARIOS.Find(entidad.ID_USUARIO);
                if (existente == null)
                    return "Usuario no encontrado.";

                existente.EMAIL = entidad.EMAIL;
                existente.CONTRASENA = entidad.CONTRASENA;
                existente.ROL = entidad.ROL;

                db.SaveChanges();
                return "Usuario actualizado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al actualizar usuario: " + ex.Message;
            }
        }

        public object Consultar(int id)
        {
            try
            {
                return db.USUARIOS
                    .Where(u => u.ID_USUARIO == id)
                    .Select(u => new
                    {
                        u.ID_USUARIO,
                        u.EMAIL,
                        u.ROL,
                        u.FECHA_REGISTRO
                    })
                    .FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public object ConsultarPorEmail(string email)
        {
            try
            {
                return db.USUARIOS
                    .Where(u => u.EMAIL == email)
                    .Select(u => new
                    {
                        u.ID_USUARIO,
                        u.EMAIL,
                        u.ROL,
                        u.FECHA_REGISTRO
                    })
                    .FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public List<object> ConsultarTodos()
        {
            try
            {
                return db.USUARIOS
                    .OrderBy(u => u.EMAIL)
                    .Select(u => new
                    {
                        u.ID_USUARIO,
                        u.EMAIL,
                        u.ROL,
                        u.FECHA_REGISTRO
                    })
                    .ToList<object>();
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
                var obj = db.USUARIOS.Find(entidad.ID_USUARIO);
                if (obj == null)
                    return "Usuario no encontrado.";

                db.USUARIOS.Remove(obj);
                db.SaveChanges();
                return "Usuario eliminado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar usuario: " + ex.Message;
            }
        }
    }
}
