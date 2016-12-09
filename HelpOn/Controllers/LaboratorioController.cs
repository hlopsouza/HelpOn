using HelpOn.Persistencia.UnitOfWork;
using HelpOn.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HelpOn.Controllers
{
    public class LaboratorioController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Laboratorio()
        {
            //ViewBag.IP = Request.UserHostAddress.ToString();
            //string IP = Request.UserHostAddress.ToString();

            string IP = "10.20.21.41";

            //Captura a substring do IP e constrói o número do Laboratório
            StringBuilder ips = new StringBuilder();
            ips.Append(IP.Substring(6, 1));
            ips.Append("0");
            ips.Append(IP.Substring(7, 1));
            IP = ips.ToString();
            var IPLab = Int32.Parse(IP);

            var viewModel = new ChamadoViewModel()
            {
                Lab = _unit.LaboratorioRepository.BuscarPorUnitario(lab => lab.NumeroLab == IPLab),
            };
            return View(viewModel);
        }



    }
}