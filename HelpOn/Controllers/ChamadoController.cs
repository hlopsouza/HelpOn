using HelpOn.Dominio.Models;
using HelpOn.Persistencia.UnitOfWork;
using HelpOn.Web.Filtros;
using HelpOn.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpOn.Web.Controllers
{
    [AutorizacaoFilter]
    public class ChamadoController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        // GET: Chamado
        public ActionResult Index()
        {
            var viewModel = new AndarViewModel()
            {
                Andares = _unit.AndarRepository.Listar(),
                Laboratorios = _unit.LaboratorioRepository.Listar(),
                ListaAndar = ListaAndar()
                
            };
            return View(viewModel);
        }

        public ActionResult Buscar(string Processo, int? NumeroLab)
        {
            ICollection<Chamado> lista;

            lista = _unit.ChamadoRepository.BuscarPor(c => c.Processo.Contains(Processo) &&
            (c.NumeroLab == NumeroLab || Processo == null));


            return PartialView("_tabela", lista);
        }

        public SelectList ListaAndar()
        {
            var lista = _unit.AndarRepository.Listar();
            return new SelectList(lista, "NumeroAndar", "IDUnidade");
        }
    }
}