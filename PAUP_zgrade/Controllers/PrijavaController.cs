using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAUP_zgrade.Models;

namespace PAUP_zgrade.Controllers
{


    public class PrijavaController : Controller
    {
        private zgrade_dbEntities1 db = new zgrade_dbEntities1();

        public ActionResult Prijava()
        {
            //if (pokusan_password == true) { ViewBag.Message = "Kriva lozinka"; }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Prijava(stanar objUser)
        {

                    var obj = db.stanars.SingleOrDefault(a => a.email.Equals(objUser.email) && a.password_stanara.Equals(objUser.password_stanara));
                    if (obj != null)
                    {
                    Session["idstanar"] = obj.idstanar;
                    Session["email"] = obj.email;
                    Session["zgrada"] = obj.zgrada;
                        return RedirectToAction("Index","Home");
                    } else { ViewBag.Message = " Unesli ste krivu lozinku, pokušajte ponovo"; }

            return View(objUser);
        }

        //public ActionResult UserDashBoard()
        //{
        //    if (Session["idstanar"] != null)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        public bool pokusan_password = true;
        //        return RedirectToAction("Prijava", "Prijava");
              
        //    }
        //}

        public ActionResult Odjava()
        {
            Session["email"] = null;
            Session["idstanar"] = null;
            Session["zgrada"] = null;
            return View("Odjavna_poruka");
        }
    }
}