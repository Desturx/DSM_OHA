using BookReViewGenNHibernate.CAD.BookReview;
using BookReViewGenNHibernate.CEN.BookReview;
using BookReViewGenNHibernate.EN.BookReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookReViewDSM.Assemblers;
using WebBookReViewDSM.Models;
namespace WebBookReViewDSM.Controllers
{
    public class ComentarioController :  BasicController
    {
        // GET: Comentario
        public ActionResult Index()
        {
            SessionInitialize();
            ComentarioCAD comCAD = new ComentarioCAD(session);
            ComentarioCEN comCEN = new ComentarioCEN(comCAD);

            IList<ComentarioEN> comEN = comCEN.ReadAll(0, -1);
            IEnumerable<ComentarioViewModel> listViewModel = new ComentarioAssembler().ConvertListENToModel(comEN).ToList();
            SessionClose();

            return View(listViewModel);
        }

        // GET: Comentario/Details/5
        public ActionResult Details(int id)
        {
            ComentarioViewModel art = null;
            SessionInitialize();
            ComentarioEN artEN = new ComentarioCAD(session).ReadOIDDefault(id);
            art = new ComentarioAssembler().ConvertEnToModelUI(artEN);
            SessionClose();
            return View(art);
            
        }

        // GET: Comentario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comentario/Create
        [HttpPost]
        public ActionResult Create(ComentarioViewModel com)
        {
            try
            {
                ComentarioCEN comCEN= new ComentarioCEN();
                comCEN.PublicarComentario(com.titulo, com.fecha, com.contenido, com.lectura, com.comentador, com.paginasLeidas);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comentario/Edit/5
        public ActionResult Edit(int id)
        {
            ComentarioViewModel com = null; // inicializamos el objeto a NULL


            SessionInitialize();

            ComentarioEN comEN = new ComentarioCAD(session).ReadOIDDefault(id);
            com = new ComentarioAssembler().ConvertEnToModelUI(comEN);

            SessionClose();

            return View(com);
        }

        // POST: Comentario/Edit/5
        [HttpPost]
        public ActionResult Edit(ComentarioViewModel com)
        {
            try
            {
                // TODO: Add update logic here
                ComentarioCEN comCEN = new ComentarioCEN();
                comCEN.Modify(com.comentario, com.titulo, com.fecha, com.contenido, com.paginasLeidas);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comentario/Delete/5
        public ActionResult Delete(int id)
        {
            int idCategoria = -1;
            SessionInitialize();
            ComentarioCAD comCAD = new ComentarioCAD(session);
            ComentarioCEN cen = new ComentarioCEN(comCAD);
            ComentarioEN comEN = cen.ReadOID(id);
            ComentarioViewModel art = new ComentarioAssembler().ConvertEnToModelUI(comEN);
            
            SessionClose();

            new ComentarioCEN().Destroy(id);

            return RedirectToAction("Index");
        }

        // POST: Comentario/Delete/5
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
