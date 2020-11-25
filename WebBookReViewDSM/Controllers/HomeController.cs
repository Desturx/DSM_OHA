using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookReViewGenNHibernate.CEN.BookReview;
using BookReViewGenNHibernate.EN.BookReview;


namespace WebBookReViewDSM.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            LibroCEN libCEN = new LibroCEN();
            IEnumerable<LibroEN> listaArt = libCEN.ReadAll(0, -1).ToList();
            return View(listaArt);
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