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
            var viewModel = new ChamadoViewModel()
            {
                Andares = _unit.AndarRepository.Listar(),
                ListaAndar = ListaAndar(),
                Chamados = _unit.ChamadoRepository.BuscarChamadosAbertos()
               

                
            };
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Buscar(string Processo, int? NumeroLab)
        {
            ICollection<Chamado> lista;

            lista = _unit.ChamadoRepository.BuscarPor(c => c.Processo.Contains(Processo) &&
            (c.NumeroLab == NumeroLab || Processo == null));


            return PartialView("_listaChamado", lista);
        }

        public SelectList ListaAndar()
        {
            var lista = _unit.AndarRepository.Listar();
            return new SelectList(lista, "NumeroAndar", "IDUnidade");
        }
       

    }
}