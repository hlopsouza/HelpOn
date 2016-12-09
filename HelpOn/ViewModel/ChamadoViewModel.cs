using HelpOn.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpOn.Web.ViewModel
{
    public class ChamadoViewModel
    {
        public SelectList ListaAndar { get; set; }
        public ICollection<Laboratorio> Laboratorios { get; set; }
        public ICollection<Andar> Andares { get; set; }
        public ICollection<Chamado> Chamados { get; set; }
        public ICollection<Descricao> Descricoes { get; set; }
        public Laboratorio Lab { get; set; }
        public int IDDescricao { get; set; }
        public int IDNivel { get; set; }

        

        #region CHAMADO PROPERTIES

        public string Descricao { get; set; }
        public string Processo { get; set; }
        public int NumeroLab { get; set; }
        public int NumeroAndar { get; set; }
        public DateTime DataChamado { get; set; }
        public int IDUnidade { get; set; }
        public string Mensagem { get; set; }


        #endregion
    }
}