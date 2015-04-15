using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers
{
    public class createPageController : Controller
    {
        //
        // GET: /createPage/

        createPageClass objPage = new createPageClass();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult pageList()
        {
            var nav = objPage.getallNav();
            return View(nav);
        }

        public ActionResult pageInfo(int id)
        {
            var nav = objPage.getallNavByID(id);
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

        public ActionResult insertsubPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult insertsubPage(subNavigation snav)
        {
            if (ModelState.IsValid)
            {
                var navid = (int)TempData["id"];
                snav.NavID = navid;
                snav.controller = "createPage";
                snav.pageView = "page";
                objPage.InsertPage(snav);
                return RedirectToAction("pageList");
            }

            return View();
        }

        public ActionResult page()
        {
            return View();
        }

    }
}
