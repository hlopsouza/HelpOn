//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HelpOn.Dominio.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Laboratorio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Laboratorio()
        {
            this.Chamado = new HashSet<Chamado>();
        }
    
        public int NumeroLab { get; set; }
        public int NumeroAndar { get; set; }
        public int IDUnidade { get; set; }
        public string IPMaquinaProf { get; set; }
    
        public virtual Andar Andar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chamado> Chamado { get; set; }
    }
}
