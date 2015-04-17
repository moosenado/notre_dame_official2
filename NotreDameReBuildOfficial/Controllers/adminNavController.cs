using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NotreDameReBuildOfficial.Infrastructure;

using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers
{
    public class adminNavController : Controller
    {
        //
        // GET: /adminNav/
        // model class of admin navigation, object created
        adminNavigationClass objNav = new adminNavigationClass();


        public ActionResult navList() //acionresult for navigation list on admin side
        {
            var nav = objNav.getallNav(); // getallNav() object called from model to get all the main navigation
            return View(nav);
        }

        [CustomAuthorize("Admin")]
        public ActionResult navInfo(int id) // actionresut navInfo is to show subPags 
        {
            var nav = objNav.getallNavByID(id); //gettiing subpages accoeding to bav ID
            if (nav == null)
            {
                return View("NotFound"); // not found view if there is no voew
            }
            else
            {
                TempData["id"] = id; // temporary ID used to save the ID of the main Navigation
                return View(nav);
            }
        }

        [CustomAuthorize("Admin")]
        public ActionResult insertNav() // Actionresult for creating a new main navigation
        {
            return View();
        }

        [CustomAuthorize("Admin")]
        [HttpPost]
        public ActionResult insertNav(admin_navigation nav) // httpost actionresult for inserting a new navigation in main menu
        {
            if (ModelState.IsValid)
            {
                nav.deletable = 1; // new navigation will be deletable by default, other important are not deletable 
                objNav.InsertNav(nav); // Calling InsertNav() model for inserting
                return RedirectToAction("navList"); //redirectig to navigation list after inserting
            }

            return View();
        }
        [CustomAuthorize("Admin")]
        public ActionResult insertsubNav() //actionresult for inserting subnav
        {
            return View(); //returning view, form for insrrting value
        }

        [CustomAuthorize("Admin")]
        [HttpPost] // http post method used to get the form value
        public ActionResult insertsubNav(admin_subNavigation snav) //actionresult for the subnavigation
        {
            if (ModelState.IsValid) // checking if everything is fine
            {
                var navid = (int)TempData["id"]; //ID of navigation saved in tempID is applied to NavID of other table as foreign key
                snav.navID = navid; 
                snav.deletable = 1; //making this nav deletable
                objNav.InsertsubNav(snav); //Inserting the sub Naviagtion value
                return RedirectToAction("navList"); // rediret to main page of navigation list
            }

            return View();
        }

        public ActionResult popNav() //actionresult used to populate the navigation from database
        {

            var nav = objNav.getAdminNav(); //geting admin navigation through database


            return PartialView(nav); // returning partial view which is used in _layout of CMS
        }

        [CustomAuthorize("Admin")]
        public ActionResult adminNavUpdate(int id) //Update Controller // update actionresult
        {
            var nav = objNav.getadminNavByID(id); //getiing nav by id to updated specific field
            if (nav == null)
            {
                return View("NotFound"); //view not found for errors
            }
            else
            {
                return View(nav); // returning update view if no errors
            }
        }

        [CustomAuthorize("Admin")]
        [HttpPost] //post method to get the values
        public ActionResult adminNavUpdate(int id, admin_navigation nav) // admon nav update actionresult
        {
            if (ModelState.IsValid) //check modelstate valid
            {
                try
                {
                    objNav.adminNavUpdate(id, nav.title, nav.controller, nav.pageView); //adminNavUpdate object called from model
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

        [CustomAuthorize("Admin")]
        public ActionResult adminSubNavUpdate(int id) //sub nav Update actionresult
        {
            var nav = objNav.getadminSubNavByID(id); //get admin sub navigation ID to update it
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
        [HttpPost] // HTTPPOST method used to get value
        public ActionResult adminSubNavUpdate(int id, admin_subNavigation nav)
        {
            if (ModelState.IsValid) //check if value valid
            {
                try
                {
                    objNav.adminSubNavUpdate(id, nav.title, nav.controller, nav.pageView); // update maodel called to update the content
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

        [CustomAuthorize("Admin")]
        public ActionResult adminNavDelete(int id) //admin nav delete
        {
            var nav = objNav.getadminNavByID(id); //get admin navigation ID
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
        public ActionResult adminNavDelete(int id, admin_navigation nav)
        {
            try
            {
                objNav.adminNavDelete(id); //delete method called from model
                return RedirectToAction("navList");
            }
            catch
            {
                return View();
            }
        }

        [CustomAuthorize("Admin")]
        public ActionResult adminSubNavDelete(int id) //sub navigation delete action reslut
        {
            var nav = objNav.getadminSubNavByID(id); //get sub navigation by ID
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
        public ActionResult adminsubNavDelete(int id, admin_subNavigation nav) // HTTPOST admin sub nav delete actionresult
        { 
            try
            {
                objNav.adminsubNavDelete(id); // admin sub nav delete method called
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
