using Prac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Prac.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult BeforeLogin(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        public ActionResult SignIn(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(User user, string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            UserManager um = new UserManager();
            if (um.VerifyLogin(user))
            {
                user = um.GetUser(user);
                Session["ActiveUser"]=user;

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.EmailId, DateTime.Now, DateTime.Now.AddMinutes(30), false, user.UserType, FormsAuthentication.FormsCookiePath);
                string Hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, Convert.ToString(Hash));
                if (ticket.IsPersistent)
                {
                    cookie.Expires = ticket.Expiration;
                }
                Response.Cookies.Add(cookie);
                return Redirect(ReturnUrl);
                //return RedirectToAction("UserLandingPage", "Landing", um.GetUser(user));
            }
            else
            {
                @ViewBag.LoginText = "Incorrect emailId or password";
                return View(); ;
            }
            
        }

        public ActionResult SignUp(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user, string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            UserManager um = new UserManager();
            if (um.VerifyEmailId(user))
            {
                ViewBag.EmailAlert = "user exist on this email ID. try another";
                return View(user);
            }
            else
            {
                um.AddUser(user);
                Session["ActiveUser"] = user;

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.EmailId, DateTime.Now, DateTime.Now.AddMinutes(30), false, user.UserType, FormsAuthentication.FormsCookiePath);
                string Hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, Convert.ToString(Hash));
                if (ticket.IsPersistent)
                {
                    cookie.Expires = ticket.Expiration;
                }
                Response.Cookies.Add(cookie);
                return Redirect(ReturnUrl);
                //return RedirectToAction("UserLandingPage", "Landing", user);
            }

        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }


    }
}