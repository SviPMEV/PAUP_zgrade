using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAUP_zgrade.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult testViewPage1()
        {
            ViewBag.Pozdrav = "bbla bla";
            return View();
        }
    }
}