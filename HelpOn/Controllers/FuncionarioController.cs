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

        [HttpGet]
        public ActionResult Details(int id)
        {
            var funcionario = _unit.FuncionarioRepository.BuscarPorId(id);
            var viewmodel = new FuncionarioViewModel()
            {
                IDFuncionario = funcionario.IDFuncionario,
                Nome = funcionario.Nome,
                CPF = funcionario.CPF,
                Email = funcionario.Email,
                Senha = funcionario.Senha,
                DataCadastro = funcionario.DataCadastro,
                Nivel = funcionario.Nivel
            };
            return View(viewmodel);

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

        [HttpPost]
        public ActionResult Excluir(int IDFuncionario)
        {
            _unit.FuncionarioRepository.Remover(IDFuncionario);
            _unit.Salvar();
            TempData["mensagem"] = "Funcionário removido com sucesso!";
            return RedirectToAction("ListarFuncionarios");
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}