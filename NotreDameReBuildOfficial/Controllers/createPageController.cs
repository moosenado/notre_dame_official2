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

        [CustomAuthorize("Admin")]
        public ActionResult pageList() // pageList actionresult for dispalying the list of pages created
        {
            var nav = objPage.getallNav(); // gets all the crated navigation links
            return View(nav);
        }

        [CustomAuthorize("Admin")]
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

        [CustomAuthorize("Admin")]
        public ActionResult insertsubPage() // create a new page
        {
            return View();
        }

        [CustomAuthorize("Admin")]
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
                return RedirectToAction("pageInfo/"+navid);  // redirect to page list
            }

            return View();
        }


        [CustomAuthorize("Admin")]
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

        [CustomAuthorize("Admin")]
        public ActionResult pageData() // page Data action result for inserting content in new pages 
        {
            return View();
        }

        [CustomAuthorize("Admin")]
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

        public ActionResult page() // page Actionresult 
        {
            var pageid = (int)TempData["id"];
            //info.jobID = jobid;
            var vol = objPage.getDataByID(pageid); // get data of the page

            return View(vol);
        }

        [CustomAuthorize("Admin")] // authorization 
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

        [CustomAuthorize("Admin")]
        [HttpPost]
        public ActionResult pageDelete(int id, subNavigation nav)
        {
            try
            {
                var navid = (int)TempData["id"];
                objPage.pageDelete(id); // delete the page
                return RedirectToAction("pageInfo/"+navid);
            }
            catch
            {
                return View();
            }
        }

        [CustomAuthorize("Admin")]
        public ActionResult passpageID(subNavigation snav, int id)
        {
            var nav = objPage.getpageByID(id); //pass page ID
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


        [CustomAuthorize("Admin")]
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

        [CustomAuthorize("Admin")]
        [HttpPost, ValidateInput(false)]
        public ActionResult pageUpdate(createPage nav)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    nav.id = (int)TempData["id"];
                    objPage.pageDataUpdate(nav.id, nav.pageContent); //page COntent changes from here
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
