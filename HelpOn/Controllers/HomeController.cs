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
        public ActionResult Index()
        {

            List<Unidade> lista = context.Unidades.ToList();
            ViewBag.Unidades = lista;
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Unidade unidade)
        {
            if (ModelState.IsValid)
            {
                context.Unidades.Add(unidade);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
               // Tratar aqui return View("Index");
            }
        }
    }
}