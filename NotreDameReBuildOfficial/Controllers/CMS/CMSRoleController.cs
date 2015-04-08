using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO; //for uploading file path

//Imported Namespaces
using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers.CMS
{
    public class CMSRoleController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        rollClass objRoll = new rollClass(); // creating an instance of roll

        //Get all Rolls
        public ActionResult Roles()
        {
            var roll = objRoll.getRolls();
            return View(roll);
        }

        //Get roll by id
        public ActionResult role_Details(int id)
        {
            var rolls = objRoll.getRollByID(id);
            if (rolls == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(rolls);
            }
        }

        public ActionResult Insert_Roll()
        {
            return View();
        }
        [HttpPost]// restirict an action method by only post requests 
        public ActionResult Insert_Roll(role roles)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    objRoll.commitInsert(roles); // if the state of the model is  valid the commitInsert function will be called and new value will be commited to database.
                    return RedirectToAction("Roles"); //after inserting values in database, page will redirect to the index page and show all data
                }
                catch
                {
                    return View(roles);
                }
            }
            return View(roles);
        }

        public ActionResult Update_role(int id)
        {
            var roll = objRoll.getRollByID(id);
            if (roll == null)
            {
                return View("Not Found");
            }
            else
            {
                return View(roll);
            }

        }

        [HttpPost]// restirict an action method by only post requests
        public ActionResult Update_role(int id, role roles)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    objRoll.commitUpdate(id, roles.title); // get the new values and passed them to fields by these parameter
                    return RedirectToAction("Roles/" + id);// the page will redirect to the role Information
                }
                catch
                {
                    return View(roles);
                }
            }
            return View(roles);
        }

        public ActionResult Delete_role(int id)
        {
            var role = objRoll.getRollByID(id);
            if (role == null)
            {
                return View("Not Found");
            }
            else
            {
                return View(role);
            }
        }

        [HttpPost] // restirict an action method by only post requests
        public ActionResult Delete_role(int id, role role)
        {
            try
            {
                objRoll.commitDelete(id);
                return RedirectToAction("Roles");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult NotFound()
        {
            return View();
        }

    }
}
