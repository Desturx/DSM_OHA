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
    public class Club_lecController : BasicController
    {
        // GET: Club_lec
        public ActionResult Index()
        {
            SessionInitialize();
            Club_lecCAD clubCAD = new Club_lecCAD(session);
            Club_lecCEN clubCEN = new Club_lecCEN(clubCAD);

            IList<Club_lecEN> clubEN = clubCEN.ReadAll(0, -1);
            IEnumerable<Club_lecViewModel> listViewModel = new Club_lecAssembler().ConvertListENToModel(clubEN).ToList();
            SessionClose();

            return View(listViewModel);
        }

        // GET: Club_lec/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Club_lec/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Club_lec/Create
        [HttpPost]
        public ActionResult Create(Club_lecViewModel club)
        {
            try
            {
                // TODO: Add insert logic here
                Club_lecCEN clubCEN = new Club_lecCEN();
                clubCEN.New_(club.mensualidad, club.paginaActual, club.estado, club.lectura);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Club_lec/Edit/5
        public ActionResult Edit(int id)
        {
            Club_lecViewModel club = null; // inicializamos el objeto a NULL


            SessionInitialize();

            Club_lecEN clubEN = new Club_lecCAD(session).ReadOIDDefault(id);
            club = new Club_lecAssembler().ConvertEnToModelUI(clubEN);

            SessionClose();


            return View(club);
        }

        // POST: Club_lec/Edit/5
        [HttpPost]
        public ActionResult Edit(Club_lecViewModel clubView)
        {
            try
            {
                Club_lecCEN clubCEN = new Club_lecCEN();
                clubCEN.Modify(clubView.clubID, clubView.mensualidad, clubView.paginaActual, clubView.estado);

                return RedirectToAction("Index", new { id = clubView.clubID });
            }
            catch
            {
                return View();
            }
        }

        // GET: Club_lec/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                int idClub = -1;
                SessionInitialize();
                Club_lecCAD clubCad = new Club_lecCAD(session);
                Club_lecCEN cen = new Club_lecCEN(clubCad);
                Club_lecEN clubEN = cen.ReadOID(id);
                Club_lecViewModel clubView = new Club_lecAssembler().ConvertEnToModelUI(clubEN);
                idClub = clubView.clubID;
                SessionClose();

                new Club_lecCEN().Destroy(id);
                return RedirectToAction("Index", new { id = idClub });
            }
            catch
            {
                return View();
            }
            
        }

        // POST: Club_lec/Delete/5
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
