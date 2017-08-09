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
                    return RedirectToAction("Index","Home");
                    }

            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["idstanar"] != null)
            {
                ViewBag.Message = "Dobrodošao " + Session["email"].ToString();
                return View();


            }
            else
            {
                return RedirectToAction("Prijava", "Prijava");
            }
        }

        public ActionResult Odjava()
        {
            Session["email"] = null;
            Session["idstanar"] = null;
            return View("UserDashBoard");
        }
    }
}