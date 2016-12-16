using HelpOn.Dominio.Models;
using HelpOn.Persistencia.UnitOfWork;
using HelpOn.ViewModel;
using HelpOn.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpOn.Controllers
{
    public class UnidadeController : Controller
    {

        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult ListarUnidades()
        {
            var msg = TempData["mensagem"];
            ICollection<Unidade> unidades = _unit.UnidadeRepository.Listar();

            return View(unidades);
        }


        [HttpGet]
        public ActionResult Cadastrar()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Andares(string msg)
        {
            var viewmodel = new AndarViewModel()
            {
                Mensagem = msg,
                Andares = _unit.AndarRepository.Listar(),
                ListaUnidade = ListarUnidade()
            };
            return View(viewmodel);
        }

        private SelectList ListarAndar()
        {
            var lista = _unit.AndarRepository.Listar();
            return new SelectList(lista, "NumeroAndar", "NumeroAndar");
        }

        [HttpGet]
        public ActionResult Labs(string msg)
        {
            var viewmodel = new LaboratorioViewModel()
            {
                Mensagem = msg,
                Laboratorios = _unit.LaboratorioRepository.Listar(),
                ListaUnidade = ListarUnidade(),
                ListaAndar = ListarAndar()
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult CadastroLabs(LaboratorioViewModel labViewModel)
        {
            if (ModelState.IsValid)
            {
                var laboratorio = new Laboratorio()
                {
                    NumeroAndar = labViewModel.NumeroAndar,
                    IDUnidade = labViewModel.IDUnidade,
                    NumeroLab = labViewModel.NumeroLab
                };

                _unit.LaboratorioRepository.Cadastrar(laboratorio);

                try
                {
                    _unit.Salvar();
                }
                catch (Exception e)
                {
                    labViewModel.Mensagem = "Ocorreu um erro ao tentar cadastrar o laboratório, por favor tente mais tarde." + "Erro: " + e;
                    labViewModel.ListaUnidade = ListarUnidade();
                    labViewModel.ListaAndar = ListarAndar();
                    return View("Labs", new { msg = "Laboratório cadastrado com sucesso!" });
                }

                return RedirectToAction("Labs", new { msg = "Laboratório cadastrado com sucesso!" });
            }
            else
            {
                labViewModel.ListaUnidade = ListarUnidade();
                labViewModel.ListaAndar = ListarAndar();
                return View(labViewModel);
            }
        }


        [HttpPost]
        public ActionResult CadastroAndares(AndarViewModel andarViewModel)
        {
            if (ModelState.IsValid)
            {
                var andar = new Andar()
                {
                    NumeroAndar = andarViewModel.NumeroAndar,
                    IDUnidade = andarViewModel.IDUnidade
                };

                _unit.AndarRepository.Cadastrar(andar);

                try
                {
                    _unit.Salvar();
                }
                catch (Exception e)
                {
                    andarViewModel.Mensagem = "Ocorreu um erro ao tentar cadastrar o andar, por favor tente mais tarde." + "Erro: " + e;
                    andarViewModel.ListaUnidade = ListarUnidade();
                    return View(andarViewModel);
                }

                return RedirectToAction("Andares", new { msg = "Andar cadastrado com sucesso!" });
            }
            else
            {
                andarViewModel.ListaUnidade = ListarUnidade();
                return View(andarViewModel);
            }
        }

        [HttpPost]
        public ActionResult ExcluirAndar(int NumeroAndar)
        {
            _unit.AndarRepository.Remover(NumeroAndar);

            try
            {
                _unit.Salvar();
            }
            catch (Exception e)
            {
                return RedirectToAction("Andares", new { msg = "Ocorreu um erro ao tentar excluir o andar, por favor tente mais tarde." + "Erro: " + e });
            }

            return RedirectToAction("Andares", new { msg = "Andar removido com sucesso!" });
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var unidade = _unit.UnidadeRepository.BuscarPorId(id);
            var viewmodel = new UnidadeViewModel()
            {
                Nome = unidade.Nome,
                IDUnidade = unidade.IDUnidade,
                CEP = unidade.CEP,
                Logradouro = unidade.Logradouro,
                Numero = unidade.Numero,
                Complemento = unidade.Complemento,
                Bairro = unidade.Bairro,
                Cidade = unidade.Cidade,
                DataCadastro = unidade.DataCadastro
            };
            return View(viewmodel);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var unidade = _unit.UnidadeRepository.BuscarPorId(id);
            var viewmodel = new UnidadeViewModel()
            {
                IDUnidade = unidade.IDUnidade,
                Nome = unidade.Nome,
                CEP = unidade.CEP,
                Logradouro = unidade.Logradouro,
                Numero = unidade.Numero,
                Complemento = unidade.Complemento,
                Bairro = unidade.Bairro,
                Cidade = unidade.Cidade,
                DataCadastro = unidade.DataCadastro

            };
            return View(viewmodel);

        }

        [HttpPost]
        public ActionResult Cadastrar(Unidade unidade)
        {
            if (ModelState.IsValid)
            {
                unidade.DataCadastro = DateTime.Now;
                _unit.UnidadeRepository.Cadastrar(unidade);
                _unit.Salvar();
                TempData["mensagem"] = "Unidade cadastrada com sucesso!";
                return RedirectToAction("ListarUnidades");
            }
            else
            {
                return View("Cadastrar");
            }

        }

        [HttpPost]
        public ActionResult Editar(Unidade unidade)
        {

            _unit.UnidadeRepository.Atualizar(unidade);
            _unit.Salvar();
            TempData["mensagem"] = "Unidade editada com sucesso!";
            return RedirectToAction("ListarUnidades");


        }

        [HttpPost]
        public ActionResult Excluir(int IDUnidade)
        {
            _unit.UnidadeRepository.Remover(IDUnidade);
            _unit.Salvar();
            TempData["mensagem"] = "Unidade removida com sucesso!";
            return RedirectToAction("ListarUnidades");
        }

        private SelectList ListarUnidade()
        {
            var lista = _unit.UnidadeRepository.Listar();
            return new SelectList(lista, "IDUnidade", "Nome");
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}