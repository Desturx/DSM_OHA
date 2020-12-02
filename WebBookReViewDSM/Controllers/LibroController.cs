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
    public class LibroController : BasicController //hereda el basic para la sesion
    {
        // GET: Libro
        public ActionResult Index()
        {
            SessionInitialize(); //no se navega por en EN pero se hace por si se mueve por ens
            LibroCAD libCAD = new LibroCAD(session); //el session se crea dentro del initialize por herencia del basic
            LibroCEN libCEN = new LibroCEN(libCAD);

            IList<LibroEN> listEN = libCEN.ReadAll(0, -1);
            IEnumerable<LibroViewModel> listviewmodel = new LibroAssembler().ConvertListENToModel(listEN).ToList();
            SessionClose();

            return View(listviewmodel); //cuando nos vamos a la vista
        }

        // GET: Libro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Libro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Libro/Create
        [HttpPost]
        public ActionResult Create(LibroViewModel lib)
        {
            try
            {
                LibroCEN libCEN = new LibroCEN();
               // libCEN.PublicarLibro(lib.autor,lib.) <-- declarar todos en el viewmodel y en algun otro sitio
               //cambiar entre todos los csHTML de LAYOUT
               //Todas las entidades o solo esas 5?
               //agregar plantilla de create
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Libro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Libro/Edit/5
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

        // GET: Libro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Libro/Delete/5
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
