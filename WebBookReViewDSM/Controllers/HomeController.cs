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