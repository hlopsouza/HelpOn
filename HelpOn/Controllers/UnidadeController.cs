﻿using HelpOn.Dominio.Models;
using HelpOn.Persistencia.UnitOfWork;
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


        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}