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
using BookReViewGenNHibernate.Enumerated.BookReview;
namespace WebBookReViewDSM.Controllers
{
    public class ListaController : BasicController
    {
        // GET: Lista
        public ActionResult Index()
        {
            SessionInitialize(); //no se navega por en EN pero se hace por si se mueve por ens
            ListaCAD liCAD = new ListaCAD(session); //el session se crea dentro del initialize por herencia del basic
            ListaCEN liCEN = new ListaCEN(liCAD);

            IList<ListaEN> listEN = liCEN.ReadAll(0, -1);
            IEnumerable<ListaViewModel> listviewmodel = new ListaAssembler().ConvertListENToModel(listEN).ToList();
            SessionClose();

            return View(listviewmodel);
        }

        // GET: Lista/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Lista/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lista/Create
        [HttpPost]
        public ActionResult Create(ListaViewModel lista)
        {
            try
            {
                // TODO: Add insert logic here
                ListaCEN listaCEN = new ListaCEN();
                //Enum.
                listaCEN.New_(lista.Tipolista, lista.duenyoLista);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Lista/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Lista/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Lista/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lista/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
