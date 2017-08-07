using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PAUP_zgrade.Models;

namespace PAUP_zgrade.Views
{
    public class stanarsController : Controller
    {
        private zgrade_dbEntities1 db = new zgrade_dbEntities1();

        // GET: stanars
        public ActionResult Index()
        {
            return View(db.stanars.ToList());
        }

        // GET: stanars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stanar stanar = db.stanars.Find(id);
            if (stanar == null)
            {
                return HttpNotFound();
            }
            return View(stanar);
        }

        // GET: stanars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: stanars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idstanar,Ime,Prezime,OIB,email,telefon,mobitel,zgrada")] stanar stanar)
        {
            if (ModelState.IsValid)
            {
                int noviId = (from st in db.stanars select st).Max(x => x.idstanar) + 1;
                stanar.idstanar = noviId;
                db.stanars.Add(stanar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stanar);
        }

        // GET: stanars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stanar stanar = db.stanars.Find(id);
            if (stanar == null)
            {
                return HttpNotFound();
            }
            return View(stanar);
        }

        // POST: stanars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idstanar,Ime,Prezime,OIB,email,telefon,mobitel,zgrada")] stanar stanar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stanar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stanar);
        }

        // GET: stanars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stanar stanar = db.stanars.Find(id);
            if (stanar == null)
            {
                return HttpNotFound();
            }
            return View(stanar);
        }

        // POST: stanars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            stanar stanar = db.stanars.Find(id);
            db.stanars.Remove(stanar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
