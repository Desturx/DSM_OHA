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
    public class AutorController : BasicController
    {
        // GET: Autor
        public ActionResult Index()
        {
            SessionInitialize(); //no se navega por en EN pero se hace por si se mueve por ens
            AutorCAD auCAD = new AutorCAD(session); //el session se crea dentro del initialize por herencia del basic
            AutorCEN auCEN = new AutorCEN(auCAD);

            IList<AutorEN> auEN = auCEN.ReadAll(0, -1);
            IEnumerable<AutorViewModel> autviewmodel = new AutorAssembler().ConvertListENToModel(auEN).ToList();
            SessionClose();

            return View(autviewmodel);
        }

        // GET: Autor/Details/5
        public ActionResult Details(int id)
        {
            AutorViewModel aut = null;
            SessionInitialize();
            AutorEN autEN = new AutorCAD(session).ReadOIDDefault(id);
            aut = new AutorAssembler().ConvertEnToModelUI(autEN);
            SessionClose();
            return View(aut);
        }

        // GET: Autor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Autor/Create
        [HttpPost]
        public ActionResult Create(AutorViewModel autor)
        {
            try
            {
                // TODO: Add insert logic here
                AutorCEN autorCEN = new AutorCEN();
                //Enum.
                autorCEN.New_(autor.nombre, autor.numlibros, autor.nacimiento, autor.fotoautor);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Autor/Edit/5
        public ActionResult Edit(int id)
        {
            AutorViewModel autor = null; // inicializamos el objeto a NULL
            SessionInitialize();

            AutorEN autorEN = new AutorCAD(session).ReadOIDDefault(id);
            autor = new AutorAssembler().ConvertEnToModelUI(autorEN);

            SessionClose();
            return View(autor);
        }

        // POST: Autor/Edit/5
        [HttpPost]
        public ActionResult Edit(AutorViewModel autorVW)
        {
            try
            {
                AutorCEN autorCEN = new AutorCEN();
                autorCEN.Modify(autorVW.autorID, autorVW.nombre, autorVW.numlibros, autorVW.nacimiento, autorVW.fotoautor);

                return RedirectToAction("Index", new { id = autorVW.autorID });
            }
            catch
            {
                return View();
            }
        }

        // GET: Autor/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                int idAutor = -1;
                SessionInitialize();
                AutorCAD autorCad = new AutorCAD(session);
                AutorCEN cen = new AutorCEN(autorCad);
                AutorEN autorEN = cen.ReadOID(id);
                AutorViewModel autorView = new AutorAssembler().ConvertEnToModelUI(autorEN);
                idAutor = autorView.autorID;
                SessionClose();

                new AutorCEN().Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Autor/Delete/5
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
