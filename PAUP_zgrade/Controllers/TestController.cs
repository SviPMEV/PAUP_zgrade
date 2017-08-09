using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAUP_zgrade.Models;

namespace PAUP_zgrade.Controllers
{


    public class TestController : Controller
    {
        private zgrade_dbEntities1 db = new zgrade_dbEntities1();

        public ActionResult testViewPage1()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult testViewPage1(stanar objUser)
        {
                    var obj = db.stanars.SingleOrDefault(a => a.email.Equals(objUser.email) && a.password_stanara.Equals(objUser.password_stanara));
                    if (obj != null)
                    {
                    Session["idstanar"] = obj.idstanar;
                    Session["email"] = obj.email;
                        return RedirectToAction("UserDashBoard");
                    }

            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            //if (Session["idstanar"] != null)
            //{
                return View();
            //}
            //else
            //{
            //    return RedirectToAction("testViewPage1", "Test");
            //}
        }
    }
}