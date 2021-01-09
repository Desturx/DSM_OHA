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
    public class UsuarioController : BasicController
    {
        // GET: Usuario
        public ActionResult Index()
        {
            SessionInitialize(); //no se navega por en EN pero se hace por si se mueve por ens
            UsuarioCAD usuCAD = new UsuarioCAD(session); //el session se crea dentro del initialize por herencia del basic
            UsuarioCEN usuCEN = new UsuarioCEN(usuCAD);

            IList<UsuarioEN> usuEN = usuCEN.ReadAll(0, -1);
            IEnumerable<UsuarioViewModel> usuviewmodel = new UsuarioAssembler().ConvertListENToModel(usuEN).ToList();
            SessionClose();

            return View(usuviewmodel); //cuando nos vamos a la vista
        }

        // GET: Usuario/Details/id
        public ActionResult Details(int id)
        {
            UsuarioViewModel usu = null;

            SessionInitialize();
            UsuarioEN usuEN = new UsuarioCAD(session).ReadOIDDefault(id);
            usu = new UsuarioAssembler().ConvertENToModelUI(usuEN);
            SessionClose();

            return View(usu);
        }

        public ActionResult Details_User(string email)
        {
            SessionInitialize(); //no se navega por en EN pero se hace por si se mueve por ens
            UsuarioCAD usuCAD = new UsuarioCAD(session); //el session se crea dentro del initialize por herencia del basi
            IList<UsuarioEN> listaEn = new UsuarioCAD(session).GetUsuarioByEmail(email);
            UsuarioViewModel usu = null;
            if (listaEn.Count > 0)
            {
                usu = new UsuarioAssembler().ConvertENToModelUI(listaEn[0]);
            }

            SessionClose();

            return View(usu); //cuando nos vamos a la vista
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(UsuarioViewModel usu)
        {
            try
            {
                UsuarioCEN usuCEN = new UsuarioCEN();
                usuCEN.New_(usu.password, usu.mail, usu.fotoperfil, usu.nombre, usu.dineroventa);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            UsuarioViewModel usu = null; // inicializamos el objeto a NULL


            SessionInitialize();

            UsuarioEN usuEN = new UsuarioCAD(session).ReadOIDDefault(id);
            usu = new UsuarioAssembler().ConvertENToModelUI(usuEN);

            SessionClose();


            return View(usu);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(UsuarioViewModel usuView)
        {
            try
            {
                UsuarioCEN usuCEN = new UsuarioCEN();
                usuCEN.Modify(usuView.usuarioID, usuView.password, usuView.mail, usuView.fotoperfil, usuView.nombre, usuView.dineroventa);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/id
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                int idUsuario = -1;

                SessionInitialize();
                UsuarioCAD usuCAD = new UsuarioCAD(session);
                UsuarioCEN cen = new UsuarioCEN(usuCAD);
                UsuarioEN usuEN = cen.ReadOID(id);
                UsuarioViewModel art = new UsuarioAssembler().ConvertENToModelUI(usuEN);
                idUsuario = art.usuarioID;
                SessionClose();

                new UsuarioCEN().Destroy(id);

                return RedirectToAction("Index", new { id = idUsuario });
            }
            catch
            {
                return View();
            }
        }

        // POST: Usuario/Delete/id
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