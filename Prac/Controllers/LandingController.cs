using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prac.Controllers
{
    public class LandingController : Controller
    {
        // GET: Landing
        public ActionResult UserLandingPage()
        {
            return View();
        }
    }
}