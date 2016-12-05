using HelpOn.Dominio.Models;
using HelpOn.Persistencia.UnitOfWork;
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
            ICollection<Unidade> unidades = _unit.UnidadeRepository.Listar();
            ViewBag.Unidades = unidades;
            return View();
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
                _unit.UnidadeRepository.Cadastrar(unidade);
                _unit.Salvar();
                return RedirectToAction("ListarUnidades");
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