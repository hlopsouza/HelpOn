using HelpOn.Dominio.Models;
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

        public ActionResult GetDescricao()
        {
            var lista = _unit.DescricaoRepository.Listar().Select(d => new { id = d.IDDescricao, descricao = d.Nome });
            return Json(lista,JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Solicitacao()
        {
            int IPLab = GetIp();

            var viewModel = new ChamadoViewModel()
            {
                Lab = _unit.LaboratorioRepository.BuscarPorUnitario(lab => lab.NumeroLab == IPLab),
                Descricoes = _unit.DescricaoRepository.Listar(),
                Chamados = _unit.ChamadoRepository.BuscarPor(c => c.NumeroLab == IPLab)

            };
            return View(viewModel);
        }

        
        [HttpGet]
        public PartialViewResult ListarSolicitacoes()
        {

            int IPLab = GetIp();
            var viewModel = new ChamadoViewModel()
            {
                Lab = _unit.LaboratorioRepository.BuscarPorUnitario(lab => lab.NumeroLab == IPLab),
                Descricoes = _unit.DescricaoRepository.Listar(),
                Chamados = _unit.ChamadoRepository.BuscarPor(c => c.NumeroLab == IPLab)

            };
            return PartialView(viewModel.Chamados);
        }

        private static int GetIp()
        {
            //string IP = Request.UserHostAddress.ToString();

            string IP = "10.20.21.41";

            //Captura a substring do IP e constrói o número do Laboratório
            StringBuilder ips = new StringBuilder();
            ips.Append(IP.Substring(6, 1));
            ips.Append("0");
            ips.Append(IP.Substring(7, 1));
            IP = ips.ToString();
            var IPLab = Int32.Parse(IP);
            return IPLab;
        }

    }
}