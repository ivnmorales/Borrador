using System;
using System.Collections.Generic;
using System.Linq;
using Borrador.Models;

namespace Borrador.Clases
{
    public class clsIMAGENES_PROPIEDAD
    {
        private INMOBILIARIAEntities db = new INMOBILIARIAEntities();
        public string IdPropiedad { get; set; }
        public List<string> Archivos { get; set; }

        public string GrabarImagenes()
        {
            try
            {
                if (Archivos != null && Archivos.Count > 0)
                {
                    foreach (var archivo in Archivos)
                    {
                        IMAGENES_PROPIEDAD img = new IMAGENES_PROPIEDAD
                        {
                            ID_PROPIEDAD = Convert.ToInt32(IdPropiedad),
                            NOMBRE = archivo
                        };
                        db.IMAGENES_PROPIEDAD.Add(img);
                    }
                    db.SaveChanges();
                    return "Imágenes guardadas correctamente.";
                }
                return "No se enviaron archivos.";
            }
            catch (Exception ex)
            {
                return $"Error al guardar imágenes: {ex.Message}";
            }
        }
    }
}
