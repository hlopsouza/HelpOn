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
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.IP = Request.UserHostAddress.ToString();
            //string IP = Request.UserHostAddress.ToString();

            //String para usar no test - Deve ser um IP que esteja cadastrado no Banco para chamar Laboratorio
            string IP = "10.20.22.41";

            var listaLab = _unit.LaboratorioRepository.Listar();

            foreach (var lab in listaLab)
            {
                if (IP.Equals(lab.IPMaquinaProf))
                {
                    return RedirectToAction("Solicitacao", "Laboratorio");
                }

            }

            return RedirectToAction("Index","Login");
        }
    }
}