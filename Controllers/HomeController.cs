using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Post()
        {
            return View();
        }

        public ActionResult Angajat()
        {
            return View();
        }
        public ActionResult Profil()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Organigrama()
        {
            return View();
        }
        public ActionResult OrganigramaCompartiment()
        {
            return View();
        }

        public ActionResult Comunicare()
        {
            return View();
        }

        public ActionResult Documente()
        {
            return View();
        }

        public ActionResult Gestiune(string utilizator, string parola)
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}