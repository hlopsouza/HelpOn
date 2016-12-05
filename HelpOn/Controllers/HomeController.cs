using HelpOn.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpOn.Controllers
{
    public class HomeController : Controller
    {

        HelpOnEntities context = new HelpOnEntities();

        [HttpGet]
        public ActionResult ListarUnidades()
        {
            List<Unidade> unidades = context.Unidade.ToList();
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
            
                context.Unidade.Add(unidade);
                context.SaveChanges();
                return RedirectToAction("ListarUnidades");
         
        }
    }
}