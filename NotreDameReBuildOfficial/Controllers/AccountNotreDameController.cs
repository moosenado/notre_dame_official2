using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using NotreDameReBuildOfficial.Models;
using System.Web.Security;
using NotreDameReBuildOfficial.Infrastructure;


namespace NotreDameReBuildOfficial.Controllers
{
    public class AccountNotreDameController : Controller
    {
        //
        // GET: /AccountNotreDame/

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User Login)
        {
            userClass user = new userClass().login(Login.user_name, Login.password);
            if (user != null)
            {
                //FormsAuthentication.SetAuthCookie(user.UserName, false);
                Util.CurrentUser = user;
                FormsAuthentication.RedirectFromLoginPage(user.user_name, false);
                //return RedirectToAction("Index", "Home");
            }


            ViewBag.Message = "Invalid user name or password.";
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Util.CurrentUser = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AccessDenied()
        {
            return View();
        }

    }
}
