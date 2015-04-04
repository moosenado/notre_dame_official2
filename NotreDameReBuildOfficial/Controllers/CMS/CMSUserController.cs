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
    public class CMSUserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        userClass objUser = new userClass(); // creating an instance of UserClass 

        //Get all Users
        public ActionResult allUsers()
        {
            var users = objUser.getAllUsers();
            return View(users);
        }

        //Get Job by id
        public ActionResult User_Details(int id)
        {
            var User = objUser.getUserByID(id);
            if (User == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(User);
            }
        }

        public ActionResult Insert_User()
        {
            ViewBag.Rolls = new rollClass().getRolls();

            return View();
        }
        [HttpPost]// restirict an action method by only post requests 
        public ActionResult Insert_User(User users)
        {
            ViewBag.rolls = new rollClass().getRolls();

            if (ModelState.IsValid)
            {
                try
                {
                    objUser.commitInsert(users); // if the state of the model is  valid the commitInsert function will be called and new value will be commited to database.
                    return RedirectToAction("allUsers"); //after inserting values in database, page will redirect to the index page and show all data
                }
                catch
                {
                    return View(users);
                }
            }
            return View(users);
        }

        public ActionResult Update_Users(int id)
        {
            ViewBag.rolls = new rollClass().getRolls();
            var user = objUser.getUserByID(id);
            if (user == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(user);
            }

        }

        [HttpPost]// restirict an action method by only post requests
        public ActionResult Update_Users(int id, User users)
        {
            ViewBag.rolls = new rollClass().getRolls();
            if (ModelState.IsValid)
            {
                try
                {
                    // get the new values and passed them to fields by these parameter
                    objUser.commitUpdateByAdmin(id, users.first_name, users.last_name, users.email, users.phone, users.city, users.province, users.postal_code, users.DOB, users.role_id);
                    return RedirectToAction("role_Details/" + id);// the page will redirect to the users details
                }
                catch
                {
                    return View(users);
                }
            }
            return View(users);
        }

        public ActionResult Delete_user(int id)
        {
            var user = objUser.getUserByID(id);
            if (user == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(user);
            }
        }

        [HttpPost] // restirict an action method by only post requests
        public ActionResult Delete_user(int id, User users)
        {
            try
            {
                objUser.commitDelete(id);
                return RedirectToAction("allUsers");
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
