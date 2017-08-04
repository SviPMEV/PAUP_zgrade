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
    public class zgradasController : Controller
    {
        private zgrade_dbEntities1 db = new zgrade_dbEntities1();

        // GET: zgradas
        public ActionResult Index()
        {
            return View(db.zgradas.ToList());
        }

        // GET: zgradas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zgrada zgrada = db.zgradas.Find(id);
            if (zgrada == null)
            {
                return HttpNotFound();
            }
            return View(zgrada);
        }

        // GET: zgradas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: zgradas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idzgrada,ulica,grad,postanskibroj")] zgrada zgrada)
        {
            if (ModelState.IsValid)
            {
                db.zgradas.Add(zgrada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zgrada);
        }

        // GET: zgradas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zgrada zgrada = db.zgradas.Find(id);
            if (zgrada == null)
            {
                return HttpNotFound();
            }
            return View(zgrada);
        }

        // POST: zgradas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idzgrada,ulica,grad,postanskibroj")] zgrada zgrada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zgrada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zgrada);
        }

        // GET: zgradas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zgrada zgrada = db.zgradas.Find(id);
            if (zgrada == null)
            {
                return HttpNotFound();
            }
            return View(zgrada);
        }

        // POST: zgradas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            zgrada zgrada = db.zgradas.Find(id);
            db.zgradas.Remove(zgrada);
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
