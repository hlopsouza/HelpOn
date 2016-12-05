using HelpOn.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpOn.Web.ViewModel
{
    public class AndarViewModel
    {
        public ICollection<Laboratorio> Laboratorios { get; set; }
        public ICollection<Andar> Andares { get; set; }
        public int Id { get; set; }
        public Nullable<int> Numero { get; set; }
        public Nullable<int> UnidadeId { get; set; }
    }
}