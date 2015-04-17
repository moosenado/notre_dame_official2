using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers
{
    public class navController : Controller
    {
        navigationClass objNav = new navigationClass();
        //
        // GET: /nav/

        //public ActionResult Index()
        //{
        //    return View();
        //}

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
        public ActionResult insertNav(navigation nav)
        {
            if(ModelState.IsValid)
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
        public ActionResult insertsubNav(subNavigation snav)
        {
            if (ModelState.IsValid)
            {
                var navid = (int)TempData["id"];
                snav.NavID = navid;
                snav.deletable = 1;
                objNav.InsertsubNav(snav);
                return RedirectToAction("navList");
            }

            return View();
        }

        public ActionResult popNav()
        {

            var nav = objNav.getpublicNav();
            return PartialView(nav);
            if(nav == null)
            {
                return View("NotFound");
            }
        }

        public ActionResult navUpdate(int id) //Update Controller
        {
            var nav = objNav.getNavByID(id);
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
        public ActionResult navUpdate(int id, navigation nav)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    objNav.navUpdate(id, nav.title, nav.controller, nav.pageView);
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

        public ActionResult subNavUpdate(int id) //Update Controller
        {
            var nav = objNav.getSubNavByID(id);
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
        public ActionResult subNavUpdate(int id, subNavigation nav)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    objNav.subNavUpdate(id, nav.title, nav.controller, nav.pageView);
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


        public ActionResult navDelete(int id)
        {
            var nav = objNav.getNavByID(id);
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
        public ActionResult navDelete(int id, navigation nav)
        {
            try
            {
                objNav.navDelete(id);
                return RedirectToAction("navList");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult subNavDelete(int id)
        {
            var nav = objNav.getSubNavByID(id);
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
        public ActionResult subNavDelete(int id, subNavigation nav)
        {
            try
            {
                objNav.subNavDelete(id);
                return RedirectToAction("navList");
            }
            catch
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
