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
        private Funcionario _usuarioLogado;
        private UnitOfWork _unit = new UnitOfWork();

        // GET: Chamado
        public ActionResult Index()
        {
            _usuarioLogado = (Funcionario)Session["usuarioLogado"];
            var viewModel = new ChamadoViewModel()
            {
                Andares = _unit.AndarRepository.Listar(),
                ListaAndar = ListaAndar(),
                Chamados = _unit.ChamadoRepository.BuscarChamadosAbertos(_usuarioLogado.IDNivel)
               

                
            };
            return View("ListaChamados",viewModel);
        }

        [HttpGet]
        public ActionResult Buscar(string Processo, int? NumeroAndar)
        {
            ICollection<Chamado> lista;
            _usuarioLogado = (Funcionario)Session["usuarioLogado"];
            lista = _unit.ChamadoRepository.BuscarPor((c => c.Processo.Contains(Processo) &&
            (c.NumeroAndar == NumeroAndar || Processo == null) && c.IDNivel == _usuarioLogado.IDNivel));


            return PartialView("_listaChamado", lista);
        }

        [HttpPost]
        public ActionResult AtenderChamado(int IDChamado, String Processo)
        {
            _usuarioLogado = (Funcionario)Session["usuarioLogado"];
            var chamado = _unit.ChamadoRepository.BuscarPorId(IDChamado);
            chamado.Processo = Processo;
            _unit.ChamadoRepository.Atualizar(chamado);
            _unit.Salvar();
            ICollection<Chamado> lista = _unit.ChamadoRepository.BuscarChamadosAbertos(_usuarioLogado.IDNivel);
            return PartialView("_listaChamado", lista);
        }

        public SelectList ListaAndar()
        {
            var lista = _unit.AndarRepository.Listar();
            return new SelectList(lista, "NumeroAndar", "IDUnidade");
        }

        //Cadastrar Chamado Monitor
        [HttpPost]
        public ActionResult Cadastrar(ChamadoViewModel chamadoViewModel)
        {
            var chamado = new Chamado()
            {
                DataChamado = chamadoViewModel.DataChamado,
                Processo = chamadoViewModel.Processo,
                NumeroLab = chamadoViewModel.NumeroLab,
                NumeroAndar = chamadoViewModel.NumeroAndar,
                IDUnidade = chamadoViewModel.IDUnidade

            };

            _unit.ChamadoRepository.Cadastrar(chamado);
            _unit.Salvar();


            return RedirectToAction("Laboratorio", "HOME");
        }
    }
}