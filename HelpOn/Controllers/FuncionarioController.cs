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

        public ActionResult ListarFuncionarios()
        {
            var msg = TempData["mensagem"];
            ICollection<Funcionario> funcionario = _unit.FuncionarioRepository.Listar();

            return View(funcionario);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            ICollection<Nivel> nivel = _unit.NivelRepository.Listar();
            return View(nivel);
        }

        [HttpPost]
        public ActionResult Cadastrar(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                funcionario.DataCadastro = DateTime.Now;
                _unit.FuncionarioRepository.Cadastrar(funcionario);
                _unit.Salvar();
                TempData["mensagem"] = "Funcionário cadastrado com sucesso!";
                return RedirectToAction("ListarFuncionarios");
            }
            else
            {
                ICollection<Nivel> nivel = _unit.NivelRepository.Listar();
                return View("Cadastrar", nivel);
            }
            
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}