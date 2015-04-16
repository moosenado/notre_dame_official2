using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers
{
    public class adminNavController : Controller
    {
        //
        // GET: /adminNav/

        adminNavigationClass objNav = new adminNavigationClass();


        public ActionResult navList()
        {
            var nav = objNav.getallNav();
            return View(nav);
        }

        public ActionResult navInfo(int id)
        {
            var nav = objNav.getallNavByID(id);
            if (nav == null)
            {
                return View("NotFound");
            }
            else
            {
                TempData["id"] = id;
                return View(nav);
            }
        }


        public ActionResult insertNav()
        {
            return View();
        }

        [HttpPost]
        public ActionResult insertNav(admin_navigation nav)
        {
            if (ModelState.IsValid)
            {
                nav.deletable = 1;
                objNav.InsertNav(nav);
                return RedirectToAction("navList");
            }

            return View();
        }

        public ActionResult insertsubNav()
        {
            return View();
        }

        [HttpPost]
        public ActionResult insertsubNav(admin_subNavigation snav)
        {
            if (ModelState.IsValid)
            {
                var navid = (int)TempData["id"];
                snav.navID = navid;
                snav.deletable = 1;
                objNav.InsertsubNav(snav);
                return RedirectToAction("navList");
            }

            return View();
        }

        public ActionResult popNav()
        {

            var nav = objNav.getAdminNav();


            return PartialView(nav);
        }

        public ActionResult adminNavUpdate(int id) //Update Controller
        {
            var nav = objNav.getadminNavByID(id);
            if (nav == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(nav);
            }
        }

        [HttpPost]
        public ActionResult adminNavUpdate(int id, admin_navigation nav)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    objNav.adminNavUpdate(id, nav.title, nav.controller, nav.pageView);
                    return RedirectToAction("navList");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return View();
            }

        }

        public ActionResult adminSubNavUpdate(int id) //Update Controller
        {
            var nav = objNav.getadminSubNavByID(id);
            if (nav == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(nav);
            }
        }

        [HttpPost]
        public ActionResult adminSubNavUpdate(int id, admin_subNavigation nav)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    objNav.adminSubNavUpdate(id, nav.title, nav.controller, nav.pageView);
                    return RedirectToAction("navList");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return View();
            }

        }



        public ActionResult NotFound() //Not found Controller
        {
            return View();
        }


    }
}
