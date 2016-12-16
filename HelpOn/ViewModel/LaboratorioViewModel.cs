using HelpOn.Dominio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpOn.ViewModel
{
    public class LaboratorioViewModel
    {
        public SelectList ListaUnidade { get; set; }

        public SelectList ListaAndar { get; set; }

        public string Mensagem { get; set; }

        public ICollection<Laboratorio> Laboratorios { get; set; }
        [Display(Name = "Número do laboratório")]
        [Required]
        public int NumeroLab { get; set; }
        [Display(Name = "Número do andar")]
        [Required]
        public int NumeroAndar { get; set; }
        [Display(Name = "Unidade")]
        [Required]
        public int IDUnidade { get; set; }
        [Display(Name = "IP Máquina do Professor")]
        [Required]
        public string IPMaquinaProf { get; set; }

        public virtual Andar Andar { get; set; }
    }
}