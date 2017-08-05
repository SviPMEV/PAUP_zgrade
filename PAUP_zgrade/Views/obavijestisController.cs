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
    public class obavijestisController : Controller
    {
        private zgrade_dbEntities1 db = new zgrade_dbEntities1();

        // GET: obavijestis - index
        //dodan kod za ispit na obrnuti nacin prema id-u
        public ActionResult Index()
        {
            return View(db.obavijestis.OrderByDescending(x => x.idobavijesti).ToList());
        }

        // GET: pregled obavijesti
        //dodan kod da bude vremenski obrnuti prikaz svih obavijesti
        public ActionResult pregledObavijesti()
        {
            return View(db.obavijestis.OrderByDescending(x => x.datumObavijest).ToList());
        }

        // GET: obavijestis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            obavijesti obavijesti = db.obavijestis.Find(id);
            if (obavijesti == null)
            {
                return HttpNotFound();
            }
            return View(obavijesti);
        }

        // GET: obavijestis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: obavijestis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idobavijesti,temaObavijest,tekstObavijest,datumObavijest")] obavijesti obavijesti)
        {
            if (ModelState.IsValid)
            {
                db.obavijestis.Add(obavijesti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obavijesti);
        }

        // GET: obavijestis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            obavijesti obavijesti = db.obavijestis.Find(id);
            if (obavijesti == null)
            {
                return HttpNotFound();
            }
            return View(obavijesti);
        }

        // POST: obavijestis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idobavijesti,temaObavijest,tekstObavijest,datumObavijest")] obavijesti obavijesti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(obavijesti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obavijesti);
        }

        // GET: obavijestis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            obavijesti obavijesti = db.obavijestis.Find(id);
            if (obavijesti == null)
            {
                return HttpNotFound();
            }
            return View(obavijesti);
        }

        // POST: obavijestis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            obavijesti obavijesti = db.obavijestis.Find(id);
            db.obavijestis.Remove(obavijesti);
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
