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
    public class CompraController : BasicController
    {
        // GET: Compra
        public ActionResult Index()
        {
            SessionInitialize();
            CompraCAD compCAD = new CompraCAD(session);
            CompraCEN compCEN = new CompraCEN(compCAD);

            IList<CompraEN> compEN = compCEN.ReadAll(0, -1);
            IEnumerable<CompraViewModel> listViewModel = new CompraAssembler().ConvertListENToModel(compEN).ToList();
            SessionClose();

            return View(listViewModel);
        }

        // GET: Compra/Details/5
        public ActionResult Details(int id)
        {
            CompraViewModel comp = null;
            SessionInitialize();
            CompraEN compEN = new CompraCAD(session).ReadOIDDefault(id);
            comp = new CompraAssembler().ConvertEnToModelUI(compEN);
            SessionClose();
            return View(comp);
        }

        // GET: Compra/Create
        public ActionResult Create()
        {
            return View();
        }


        public ActionResult index_user()
        {
            return View();
        }

        // POST: Compra/Create
        [HttpPost]
        public ActionResult Create(CompraViewModel com)
        {
            try
            {

                CompraCEN comCEN = new CompraCEN();
                comCEN.CreaCompra(com.compradorId, com.LibroId, com.tipo_pago, com.infoTarjeta, com.fecha, com.terminal, com.comercio);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult index_user(CompraViewModel com)
        {
            try
            {
                string id = Request.QueryString["libro"];
                int variablelibro = Int32.Parse(id);
                string id2 = Request.QueryString["user"];
                int variableuser = Int32.Parse(id2);
                CompraCEN comCEN = new CompraCEN();
                comCEN.CreaCompra(variableuser,variablelibro, com.tipo_pago, com.infoTarjeta, com.fecha, com.terminal, com.comercio);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compra/Edit/5
        public ActionResult Edit(int id)
        {
            CompraViewModel compra = null;

            SessionInitialize();
            CompraEN cpEN = new CompraCAD(session).ReadOIDDefault(id);
            compra = new CompraAssembler().ConvertEnToModelUI(cpEN);
            SessionClose();

            return View(compra);
        }

        // POST: Compra/Edit/5
        [HttpPost]
        public ActionResult Edit(CompraViewModel compView)
        {
            try
            {
                CompraCEN compCEN = new CompraCEN();
                compCEN.Modify(compView.CompraId, compView.tipo_pago, compView.infoTarjeta, compView.fecha, compView.terminal, compView.comercio);
                return RedirectToAction("PorCompra", new { id = compView.CompraId});
            }
            catch
            {
                return View();
            }
        }

        // GET: Compra/Delete/5
        public ActionResult Delete(int id)
        {
            int idCategoria = -1;
            SessionInitialize();
            CompraCAD compCAD = new CompraCAD(session);
            CompraCEN cen = new CompraCEN(compCAD);
            CompraEN compEN = cen.ReadOID(id);
            CompraViewModel comp = new CompraAssembler().ConvertEnToModelUI(compEN);
            idCategoria = comp.CompraId;
            SessionClose();

            new CompraCEN().Destroy(id);

            return RedirectToAction("Index");

        }

        // POST: Compra/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
