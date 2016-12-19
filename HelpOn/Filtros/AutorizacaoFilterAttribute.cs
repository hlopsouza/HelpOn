using HelpOn.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HelpOn.Web.Filtros
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Funcionario usuarioLogado = (Funcionario)filterContext.HttpContext.Session["usuarioLogado"];
            if (usuarioLogado == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { action = "Index", controller = "Login" }));
            }
        }
    }
}