using Prac.Models;
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
        [Authorize(Roles ="Normal")]
        public ActionResult UserLandingPage(User user)
        {
            user=Session["ActiveUser"] as User;
            return View(user);
        }
    }
}