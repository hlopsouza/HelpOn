//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HelpOn.Dominio.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Andar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Andar()
        {
            this.Laboratorio = new HashSet<Laboratorio>();
            this.Monitor = new HashSet<Monitor>();
        }
    
        public int NumeroAndar { get; set; }
        public int IDUnidade { get; set; }
    
        public virtual Unidade Unidade { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Laboratorio> Laboratorio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Monitor> Monitor { get; set; }
    }
}
