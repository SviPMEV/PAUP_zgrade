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
    public class porukasController : Controller
    {
        private zgrade_dbEntities1 db = new zgrade_dbEntities1();

        // GET: porukas
        public ActionResult Index()
        {
            return View(db.porukas.OrderByDescending(x => x.datumPoruke).ToList());
            //pregled poruka po datumu
        }

        // GET: porukas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            poruka poruka = db.porukas.Find(id);
            if (poruka == null)
            {
                return HttpNotFound();
            }
            return View(poruka);
        }
        public ActionResult poslano()
        {
            return View();
        }

        // GET: porukas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: porukas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idporuka,temaPoruke,tijeloPoruke,datumPoruke,posiljateljPoruke")] poruka poruka)
        {
            if (ModelState.IsValid)
            {
                int noviId = (from st in db.porukas select st).Max(x => x.idporuka) + 1;
                poruka.idporuka = noviId;
                db.porukas.Add(poruka);
                db.SaveChanges();
                return RedirectToAction("poslano", "porukas");
            }
            return View(poruka);
        }

        // GET: porukas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            poruka poruka = db.porukas.Find(id);
            if (poruka == null)
            {
                return HttpNotFound();
            }
            return View(poruka);
        }

        // POST: porukas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idporuka,temaPoruke,tijeloPoruke,datumPoruke,posiljateljPoruke")] poruka poruka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poruka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "");
            }
            return View(poruka);
        }

        // GET: porukas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            poruka poruka = db.porukas.Find(id);
            if (poruka == null)
            {
                return HttpNotFound();
            }
            return View(poruka);
        }

        // POST: porukas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            poruka poruka = db.porukas.Find(id);
            db.porukas.Remove(poruka);
            db.SaveChanges();
            return RedirectToAction("Index", "");
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
