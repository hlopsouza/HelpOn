using HelpOn.Dominio.Models;
using HelpOn.Persistencia.UnitOfWork;
using HelpOn.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpOn.Controllers
{
    public class HomeController : Controller
    {

        UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult ListarUnidades()
        {
            var msg = TempData["mensagem"];
            ICollection<Unidade> unidades = _unit.UnidadeRepository.Listar();

            return View(unidades);
        }

        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Cadastrar(Unidade unidade)
        {
            if (ModelState.IsValid)
            {
                unidade.DataCadastro = DateTime.Now;
                _unit.UnidadeRepository.Cadastrar(unidade);
                _unit.Salvar();
                TempData["mensagem"] = "Unidade cadastrada com sucesso!";
                return RedirectToAction("ListarUnidades");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult Editar(Unidade unidade)
        {
            _unit.UnidadeRepository.Atualizar(unidade);
            _unit.Salvar();
            TempData["mensagem"] = "Unidade editada com sucesso!";
            return View("ListarUnidades");
        }

        [HttpPost]
        public ActionResult Excluir(int IDUnidade)
        {
            _unit.UnidadeRepository.Remover(IDUnidade);
            _unit.Salvar();
            TempData["mensagem"] = "Unidade removida com sucesso!";
            return RedirectToAction("ListarUnidades");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var unidade = _unit.UnidadeRepository.BuscarPorId(id);
            var viewmodel = new UnidadeViewModel()
            {
                Nome = unidade.Nome,
                IDUnidade = unidade.IDUnidade,
                CEP = unidade.CEP,
                Logradouro = unidade.Logradouro,
                Numero = unidade.Numero,
                Complemento = unidade.Complemento,
                Bairro = unidade.Bairro,
                Cidade = unidade.Cidade,
                DataCadastro = unidade.DataCadastro
            };
            return View(viewmodel);
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}