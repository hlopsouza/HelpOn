using HelpOn.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpOn.Web.ViewModel
{
    public class FuncionarioViewModel
    {
        public int IDFuncionario { get; set; }
     
        public string Nome { get; set; }
    
        public string CPF { get; set; }
       
        public string Email { get; set; }
       
        public string Senha { get; set; }
        public Nullable<System.DateTime> DataCadastro { get; set; }
      
        public int IDNivel { get; set; }

        public virtual Nivel Nivel { get; set; }
    }
}