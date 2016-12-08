using HelpOn.Dominio.Models;
using HelpOn.Persistencia.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpOn.Controllers
{
    public class FuncionarioController : Controller
    {

        UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Index()
        {
            ICollection<Nivel> nivel = _unit.NivelRepository.Listar();
            ViewBag.Nivel = nivel;
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Funcionario func)
        {
            if (ModelState.IsValid)
            {
                func.DataCadastro = DateTime.Now;
                _unit.FuncionarioRepository.Cadastrar(func);
                _unit.Salvar();
                return Content("Cadastro efetuado");
            }
            else
            {
                return View("Index");
            }
            
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}