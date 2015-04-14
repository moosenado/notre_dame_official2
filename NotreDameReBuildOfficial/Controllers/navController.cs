﻿using System;
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
                objNav.InsertsubNav(snav);
                return RedirectToAction("navList");
            }

            return View();
        }


    }
}
