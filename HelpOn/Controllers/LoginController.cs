﻿using HelpOn.Dominio.Models;
using HelpOn.Persistencia.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpOn.Web.Controllers
{
    public class LoginController : Controller
    {
       
        private UnitOfWork _unit = new UnitOfWork();

        #region GET
        // GET: Login
        [HttpGet]
        public ActionResult Index(string msg)
        {
            ViewBag.Mensagem = msg;
            return View();
        }

      
        #endregion

        #region POST
        [HttpPost]
        public ActionResult Index(string Email, string Senha)
        {
            var Funcionario = _unit.FuncionarioRepository.BuscarLogin(a => a.Email.Contains(Email) && a.Senha == Senha);
            if (Funcionario != null)
            {
                //Adicionar Filtro de chamados pra gerente, suporte e monitor
                Session["usuarioLogado"] = Funcionario;
                return RedirectToAction("Index", "Chamado");
            }
           return RedirectToAction("Index", new { msg = "Login ou Senha incorretos" });
        }

        public ActionResult Sair()
        {
            Session["usuarioLogado"] = null;
            return RedirectToAction("Index");
        }
        #endregion
    }
}