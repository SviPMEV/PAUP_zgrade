using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PAUP_zgrade.Models;
using System.Threading;

namespace PAUP_zgrade.Views
{
    public class financijesController : Controller
    {
        private zgrade_dbEntities1 db = new zgrade_dbEntities1();

        // GET: financijes
        public ActionResult Index()
        {
            return View(db.financijes.ToList());
        }

        public ActionResult ListaFinancija()
        {
            return View(db.financijes.ToList());
        }

        public ActionResult ListaFinancijaPartial(string zgrada, string obavljenafinancija)
        {
            //simuliramo neki posao na serveru
            Thread.Sleep(2000);
            // EF - lista sa filtriranjem
            var lista = from s in db.financijes select s;
            // filtriranja
            if (!String.IsNullOrEmpty(zgrada))
                lista = lista.Where(st => st.zgradaFinancija.ToString().Equals(zgrada));
            if (!String.IsNullOrEmpty(obavljenafinancija))
                lista = lista.Where(st => st.obavljenPosao.ToString() == obavljenafinancija);
            // vraćamo view sa listom svih studenata kao ulaznim parametrom
            return PartialView(lista.ToList());
        }

        public ActionResult ListaFinancijaStanar()
        {
            return View(db.financijes.ToList());
        }

        public ActionResult ListaFinancijaStanarPartial(string zgrada, string obavljenafinancija)
        {
            //simuliramo neki posao na serveru
            Thread.Sleep(2000);
            // EF - lista sa filtriranjem
            var lista = from s in db.financijes select s;
            // filtriranja
            if (!String.IsNullOrEmpty(zgrada))
                lista = lista.Where(st => st.zgradaFinancija.ToString().Equals(zgrada));
            if (!String.IsNullOrEmpty(obavljenafinancija))
                lista = lista.Where(st => st.obavljenPosao.ToString() == obavljenafinancija);
            // vraćamo view sa listom svih studenata kao ulaznim parametrom
            return PartialView(lista.ToList());
        }

        // GET: financijes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            financije financije = db.financijes.Find(id);
            if (financije == null)
            {
                return HttpNotFound();
            }
            return View(financije);
        }

        // GET: financijes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: financijes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idfinancije,datumFinancije,vrijednostFinancije,zgradaFinancija,opisFinancije,obavljenPosao")] financije financije)
        {
            if (ModelState.IsValid)
            {
                db.financijes.Add(financije);
                db.SaveChanges();
                return RedirectToAction("ListaFinancija");
            }

            return View(financije);
        }

        // GET: financijes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            financije financije = db.financijes.Find(id);
            if (financije == null)
            {
                return HttpNotFound();
            }
            return View(financije);
        }

        // POST: financijes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idfinancije,datumFinancije,vrijednostFinancije,zgradaFinancija,opisFinancije,obavljenPosao")] financije financije)
        {
            if (ModelState.IsValid)
            {
                db.Entry(financije).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListaFinancija");
            }
            return View(financije);
        }

        // GET: financijes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            financije financije = db.financijes.Find(id);
            if (financije == null)
            {
                return HttpNotFound();
            }
            return View(financije);
        }

        // POST: financijes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            financije financije = db.financijes.Find(id);
            db.financijes.Remove(financije);
            db.SaveChanges();
            return RedirectToAction("ListaFinancija");
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
