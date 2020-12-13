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
            LibroViewModel lib = null;
            SessionInitialize();
            LibroEN libEN = new LibroCAD(session).ReadOIDDefault(id);
            lib = new LibroAssembler().ConvertENToModelUI(libEN);
            SessionClose();
            return View(lib);
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
                libCEN.PublicarLibro(lib.autor, lib.nombre, lib.genero, lib.fechapubli,lib.portada, lib.idioma, lib.puntuacion, lib.elacecompra, lib.paginas, lib.precio, lib.creador, lib.compras);

                
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
            LibroViewModel lib = null; // inicializamos el objeto a NULL


            SessionInitialize();

            LibroEN libEN = new LibroCAD(session).ReadOIDDefault(id);
            lib = new LibroAssembler().ConvertENToModelUI(libEN);

            SessionClose();
            return View(lib);
        }

        // POST: Libro/Edit/5
        [HttpPost]
        public ActionResult Edit(LibroViewModel lib)
        {
            try
            {
                // TODO: Add update logic here
                LibroCEN libCEN = new LibroCEN();
                libCEN.Modify(lib.libroID,lib.autor,lib.nombre,lib.genero,lib.fechapubli,lib.idioma,lib.portada,lib.puntuacion,lib.elacecompra,lib.paginas,lib.precio,lib.compras);
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
            int idCategoria = -1;
            SessionInitialize();
            LibroCAD artCAD = new LibroCAD(session);
            LibroCEN cen = new LibroCEN(artCAD);
            LibroEN libEN = cen.ReadOID(id);
            LibroViewModel lib = new LibroAssembler().ConvertENToModelUI(libEN);
            idCategoria = lib.libroID;
            SessionClose();

            new LibroCEN().BorrarLibro(id);


            return RedirectToAction("Index");
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
