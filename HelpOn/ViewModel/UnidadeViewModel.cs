using HelpOn.Dominio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelpOn.Web.ViewModel
{
    public class UnidadeViewModel
    {


        public int IDUnidade { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string CEP { get; set; }
        [Required]
        public string Logradouro { get; set; }
        [Required]
        public int Numero { get; set; }
        public string Complemento { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Cidade { get; set; }
        public Nullable<System.DateTime> DataCadastro { get; set; }
    }
}