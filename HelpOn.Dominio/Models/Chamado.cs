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
    
    public partial class Chamado
    {
        public int IDChamado { get; set; }
        public string Descricao { get; set; }
        public string Processo { get; set; }
        public int NumeroLab { get; set; }
        public int NumeroAndar { get; set; }
        public int IDUnidade { get; set; }
        public Nullable<int> IDFuncionario { get; set; }
        public Nullable<System.DateTime> DataChamado { get; set; }
    
        public virtual Funcionario Funcionario { get; set; }
        public virtual Laboratorio Laboratorio { get; set; }
    }
}
