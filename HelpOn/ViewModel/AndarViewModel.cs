using HelpOn.Dominio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpOn.ViewModel
{
    public class AndarViewModel
    {
        public SelectList ListaUnidade { get; set; }

        public string Mensagem { get; set; }

        public ICollection<Andar> Andares { get; set; }

        [Display(Name = "Número do andar")]
        [Required]
        public int NumeroAndar { get; set; }

        [Display(Name = "Unidade")]
        [Required]
        public int IDUnidade { get; set; }
        public virtual Unidade Unidade { get; set; }
        public virtual ICollection<Laboratorio> Laboratorio { get; set; }
    }
}