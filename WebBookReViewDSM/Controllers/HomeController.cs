using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookReViewGenNHibernate.CAD.BookReview;
using BookReViewGenNHibernate.CEN.BookReview;
using BookReViewGenNHibernate.EN.BookReview;
using WebBookReViewDSM.Assemblers;
using WebBookReViewDSM.Models;

namespace WebBookReViewDSM.Controllers
{
    public class HomeController : BasicController
    {
        public ActionResult Index()
        {
            SessionInitialize();
            LibroCAD libroCAD = new LibroCAD(session);
            LibroCEN libCEN = new LibroCEN(libroCAD);

            List<LibroEN> listaArt = libCEN.ReadAll(0, -1).ToList();
            LibroAssembler lass = new LibroAssembler();
            IEnumerable<LibroViewModel> list = lass.ConvertListENToModel(listaArt).ToList();
            SessionClose();
            return View(list);
        }
        public ActionResult ResBusqueda()
        {
            SessionInitialize();
            LibroCAD libroCAD = new LibroCAD(session);
            LibroCEN libCEN = new LibroCEN(libroCAD);

            List<LibroEN> listaArt = libCEN.ReadAll(0, -1).ToList();
            LibroAssembler lass = new LibroAssembler();
            IEnumerable<LibroViewModel> list = lass.ConvertListENToModel(listaArt).ToList();
            SessionClose();
            return View(list);
        }

        public ActionResult Shared_Clubs()
        {
            SessionInitialize();
            Club_lecCAD clubCAD = new Club_lecCAD(session);
            Club_lecCEN clubCEN = new Club_lecCEN(clubCAD);

            IList<Club_lecEN> clubEN = clubCEN.ReadAll(0, 1);
            IEnumerable<Club_lecViewModel> listViewModel = new Club_lecAssembler().ConvertListENToModel(clubEN).ToList();
            SessionClose();

            return View(listViewModel);
        }
        public ActionResult Busqueda() {

            return View();
        }
        public ActionResult About()
        {
            return View();
        }
    }
}