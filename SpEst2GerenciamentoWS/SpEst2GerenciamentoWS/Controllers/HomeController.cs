﻿using System.Web.Mvc;

namespace SpEst2GerenciamentoWS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Infra - Web Service";

            //return View();
            return new RedirectResult("~/swagger/ui/index");

        }

    }

}
