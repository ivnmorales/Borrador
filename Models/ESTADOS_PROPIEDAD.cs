//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Borrador.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ESTADOS_PROPIEDAD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ESTADOS_PROPIEDAD()
        {
            this.PROPIEDADES = new HashSet<PROPIEDADE>();
        }
    
        public int ID_ESTADO_PROPIEDAD { get; set; }
        public string DESCRIPCION { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROPIEDADE> PROPIEDADES { get; set; }
    }
}
