using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NotreDameReBuildOfficial.Infrastructure;

using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers
{
    public class createPageController : Controller
    {
        //
        // GET: /createPage/

        //createPageClass model obj created

        createPageClass objPage = new createPageClass();

        [CustomAuthorize("admin")]
        public ActionResult pageList() // pageList actionresult for dispalying the list of pages created
        {
            var nav = objPage.getallNav(); // gets all the crated navigation links
            return View(nav);
        }

        [CustomAuthorize("admin")]
        public ActionResult pageInfo(int id) // page info returns list of sub navigations
        {
            var nav = objPage.getallNavByID(id); // getting nav ID 
            if (nav == null)
            {
                return View("NotFound");
            }
            else
            {
                TempData["id"] = id; // temp ID saving the id of the subpage
                return View(nav);
            }
        }

        [CustomAuthorize("admin")]
        public ActionResult insertsubPage() // create a new page
        {
            return View();
        }

        [CustomAuthorize("admin")]
        [HttpPost]
        public ActionResult insertsubPage(subNavigation snav) // Post method used to get the values and inserting the page
        {
            if (ModelState.IsValid)
            {
                var navid = (int)TempData["id"]; // setting the id of the navigation 
                snav.NavID = navid;
                snav.controller = "createPage"; // setting default values
                snav.pageView = "contentInfo"; // setting default value
                snav.deletable = 1; // setting default value
                objPage.InsertPage(snav);
                return RedirectToAction("pageList");  // redirect to page list
            }

            return View();
        }


        [CustomAuthorize("admin")]
        public ActionResult passID(int id) // passID actionresult
        {
            var nav = objPage.getallNavByID(id); // getting nav by id
            if (nav == null)
            {
                return View("NotFound");
            }
            else
            {
                TempData["id"] = id; // storing temp ID
                return RedirectToAction("pageData");
            }
        }

        [CustomAuthorize("admin")]
        public ActionResult pageData() // page Data action result for inserting content in new pages 
        {
            return View();
        }

        [CustomAuthorize("admin")]
        [HttpPost, ValidateInput(false)] // validation false because trying to insert HTML tags
        public ActionResult pageData(createPage page) 
        {
            if (ModelState.IsValid) //checking validation
            {
                var pid = (int)TempData["id"]; //retreiving ID
                page.subPageID = pid; //setting temp ID to sub page ID
                objPage.InsertData(page); //inserting data
                return RedirectToAction("pageList");
            }

            return View();

        }

        [CustomAuthorize("admin")]
        public ActionResult contentInfo(int id) // content info gives ID of the created page
        {

            var nav = objPage.getallNavByID(id); // get all nav by id
            if (nav == null)
            {
                return View("NotFound");
            }
            else
            {
                TempData["id"] = id; // temp ID 
                return RedirectToAction("page");
            }

        }

        [CustomAuthorize("admin")]
        public ActionResult page() // page Actionresult 
        {
            var pageid = (int)TempData["id"];
            //info.jobID = jobid;
            var vol = objPage.getDataByID(pageid);

            return View(vol);
        }

        [CustomAuthorize("admin")]
        public ActionResult pageDelete(int id)
        {
            var nav = objPage.getpageByID(id);
            if (nav == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(nav);
            }
        }

        [CustomAuthorize("admin")]
        [HttpPost]
        public ActionResult pageDelete(int id, subNavigation nav)
        {
            try
            {
                objPage.pageDelete(id);
                return RedirectToAction("pageList");
            }
            catch
            {
                return View();
            }
        }

        [CustomAuthorize("admin")]
        public ActionResult passpageID(subNavigation snav, int id)
        {
            var nav = objPage.getpageByID(id);
            if (nav == null)
            {
                return View("NotFound");
            }
            else
            {
                TempData["id"] = id;
                return RedirectToAction("pageUpdate");
            }
        }


        [CustomAuthorize("admin")]
        public ActionResult pageUpdate() //Update Controller
        {
            int id = (int)TempData["id"]; 
            var nav = objPage.getDataByID(id);
            if (nav == null)
            {
                return View("NotFound");
            }
            else
            {
                TempData["id"] = nav.id;
                return View(nav);
            }
        }

        [CustomAuthorize("admin")]
        [HttpPost, ValidateInput(false)]
        public ActionResult pageUpdate(createPage nav)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    nav.id = (int)TempData["id"];
                    objPage.pageDataUpdate(nav.id, nav.pageContent);
                    return RedirectToAction("pageList");
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
