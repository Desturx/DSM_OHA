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
        public ActionResult Shared_comentarios()
        {
            SessionInitialize();
            ComentarioCAD comCAD = new ComentarioCAD(session);
            ComentarioCEN comCEN = new ComentarioCEN(comCAD);

            IList<ComentarioEN> comEN = comCEN.ReadAll(0, -1);
            IEnumerable<ComentarioViewModel> listViewModel = new ComentarioAssembler().ConvertListENToModel(comEN).ToList();
            SessionClose();

            return View(listViewModel);
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

        public ActionResult libro_user(int id)
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
            IList<UsuarioEN> listaCreadores = new UsuarioCEN().ReadAll(0, -1);
            IList<SelectListItem> creadoresItems = new List<SelectListItem>();

            foreach (UsuarioEN usu in listaCreadores) {
                creadoresItems.Add(new SelectListItem { Text = usu.Nombre, Value = usu.UsuarioID.ToString() });
            }

            ViewData["IdCreador"] = creadoresItems;


            IList<AutorEN> listaAutores = new AutorCEN().ReadAll(0, -1);
            IList<SelectListItem> autoresItems = new List<SelectListItem>();

            foreach (AutorEN au in listaAutores)
            {
                creadoresItems.Add(new SelectListItem { Text = au.Nombre, Value = au.AutorID.ToString() });
            }

            ViewData["IdAutor"] = autoresItems;
            return View();
        }

        // POST: Libro/Create
        [HttpPost]
        public ActionResult Create(LibroViewModel lib)
        {
            try
            {
                LibroCEN libCEN = new LibroCEN();
                libCEN.PublicarLibro(lib.nombre, lib.genero, lib.fechapubli,lib.portada, lib.idioma, lib.puntuacion, lib.elacecompra, lib.paginas, lib.precio, lib.creador, lib.compras, lib.idautor);

                
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
                libCEN.Modify(lib.libroID,lib.nombre,lib.genero,lib.fechapubli,lib.idioma,lib.portada,lib.puntuacion,lib.elacecompra,lib.paginas,lib.precio,lib.compras);
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
