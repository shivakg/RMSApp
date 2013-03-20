using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rmsapp.Models;

namespace Rmsapp.Controllers
{
    public class CmsesController : Controller
    {
        private CmseDBContext db = new CmseDBContext();

        //
        // GET: /Cmses/
       

        public ActionResult Index()
        {
            return View(db.Cmses.ToList());
        }

        //
        // GET: /Cmses/Details/5

        public ActionResult Details(int id = 0)
        {
            Cmse cmse = db.Cmses.Find(id);
            if (cmse == null)
            {
                return HttpNotFound();
            }
            return View(cmse);
        }

        //
        // GET: /Cmses/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cmses/Create

        [HttpPost]
        public ActionResult Create(Cmse cmse)
        {
            if (ModelState.IsValid)
            {
                db.Cmses.Add(cmse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cmse);
        }

        //
        // GET: /Cmses/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cmse cmse = db.Cmses.Find(id);
            if (cmse == null)
            {
                return HttpNotFound();
            }
            return View(cmse);
        }

        //
        // POST: /Cmses/Edit/5

        [HttpPost]
        public ActionResult Edit(Cmse cmse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cmse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cmse);
        }

        //
        // GET: /Cmses/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cmse cmse = db.Cmses.Find(id);
            if (cmse == null)
            {
                return HttpNotFound();
            }
            return View(cmse);
        }

        //
        // POST: /Cmses/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cmse cmse = db.Cmses.Find(id);
            db.Cmses.Remove(cmse);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}