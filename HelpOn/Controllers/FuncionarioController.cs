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

        #region FIELD

        private UnitOfWork _unit = new UnitOfWork();

        #endregion

        #region GET

        [HttpGet]
        public ActionResult ListarFuncionarios()
        {
            var msg = TempData["mensagem"];
            var viewmodel = new FuncionarioViewModel()
            {
                Funcionarios = _unit.FuncionarioRepository.Listar()
            };


            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Cadastrar(string msg)
        {
            var viewModel = new FuncionarioViewModel()
            {
                Mensagem = msg,
                ListaNivel = ListarNivel()
            };
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var funcionario = _unit.FuncionarioRepository.BuscarPorId(id);
            var viewmodel = new FuncionarioViewModel()
            {
                Nome = funcionario.Nome,
                CPF = funcionario.CPF,
                Email = funcionario.Email,
                Senha = funcionario.Senha,
                DataCadastro = funcionario.DataCadastro,
                Nivel = funcionario.Nivel
            };
            return View(viewmodel);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ICollection<Nivel> nivel = _unit.NivelRepository.Listar();
            ViewBag.Niveis = nivel;
            var funcionario = _unit.FuncionarioRepository.BuscarPorId(id);
            var viewmodel = new FuncionarioViewModel()
            {
                IDFuncionario = funcionario.IDFuncionario,
                Nome = funcionario.Nome,
                CPF = funcionario.CPF,
                Email = funcionario.Email,
                Senha = funcionario.Senha,
                DataCadastro = funcionario.DataCadastro,
                Nivel = funcionario.Nivel,
                IDNivel = funcionario.IDNivel
            };
            return View(viewmodel);

        }

        #endregion

        #region POST

        [HttpPost]
        public ActionResult Cadastrar(FuncionarioViewModel funcionarioViewModel, string repeatsenha)
        {

            if (funcionarioViewModel.Senha != repeatsenha) ModelState.AddModelError("repeatsenha", "As senhas não correspondem.");

            if (ModelState.IsValid)
            {
                var funcionario = new Funcionario()
                {
                    Nome = funcionarioViewModel.Nome,
                    CPF = funcionarioViewModel.CPF,
                    Email = funcionarioViewModel.Email,
                    Senha = funcionarioViewModel.Senha,
                    DataCadastro = DateTime.Now,
                    IDNivel = funcionarioViewModel.IDNivel
                };

                _unit.FuncionarioRepository.Cadastrar(funcionario);

                try
                {
                    _unit.Salvar();
                }
                catch (Exception e)
                {
                    funcionarioViewModel.Mensagem = "Ocorreu um erro ao tentar cadastrar o funcionário, por favor tente mais tarde." + "Erro: " + e;
                    funcionarioViewModel.ListaNivel = ListarNivel();
                    return View(funcionarioViewModel);
                }

                TempData["mensagem"] = "Funcionário cadastrado com sucesso!";
                return RedirectToAction("ListarFuncionarios");
            }
            else
            {
                funcionarioViewModel.ListaNivel = ListarNivel();
                return View(funcionarioViewModel);
            }

        }

        [HttpPost]
        public ActionResult Editar(Funcionario funcionario, string novasenha)
        {
            if(novasenha != "") funcionario.Senha = novasenha;
         

            _unit.FuncionarioRepository.Atualizar(funcionario);

            try
            {
                _unit.Salvar();
            }
            catch (Exception e)
            {
                TempData["mensagem"] = "Ocorreu um erro ao tentar editar o funcionário, por favor tente mais tarde." + "Erro: " + e;
                return RedirectToAction("ListarFuncionarios");
            }

            TempData["mensagem"] = "Funcionário editado com sucesso!";
            return RedirectToAction("ListarFuncionarios");


        }

        [HttpPost]
        public ActionResult Excluir(int IDFuncionario)
        {
            _unit.FuncionarioRepository.Remover(IDFuncionario);

            try
            {
                _unit.Salvar();
            }
            catch (Exception e)
            {
                TempData["mensagem"] = "Ocorreu um erro ao tentar excluir o funcionário, por favor tente mais tarde." + "Erro: " + e;
                return RedirectToAction("ListarFuncionarios");
            }

            TempData["mensagem"] = "Funcionário removido com sucesso!";
            return RedirectToAction("ListarFuncionarios");
        }

        #endregion

        #region PRIVATE
        private SelectList ListarNivel()
        {
            var lista = _unit.NivelRepository.Listar();
            return new SelectList(lista, "IDNivel", "Nome");
        }

        #endregion

        #region DISPOSE

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }

        #endregion
    }
}