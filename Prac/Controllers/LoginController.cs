using Prac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prac.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult BeforeLogin()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            UserManager um = new UserManager();
            um.AddUser(user);
            return RedirectToAction("UserLandingPage", "Landing");
        }
    }
}