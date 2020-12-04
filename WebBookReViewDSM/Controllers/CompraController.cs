﻿using BookReViewGenNHibernate.CAD.BookReview;
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
            return View();
        }

        // GET: Compra/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compra/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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
            return View();
        }

        // POST: Compra/Edit/5
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

        // GET: Compra/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
            catch
            {
                return View();
            }
        }
    }
}
