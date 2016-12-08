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

        public string Nome { get; set; }

        public string CEP { get; set; }

        public string Logradouro { get; set; }

        public int Numero { get; set; }
        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }
        public Nullable<System.DateTime> DataCadastro { get; set; }
    }
}