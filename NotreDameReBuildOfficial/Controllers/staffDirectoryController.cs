using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers
{
    public class staffDirectoryController : Controller
    {
        //
        // GET: /staffDirectory/

        staffDirectory objStaff = new staffDirectory();

        public ActionResult staffList()
        {
            var staff = objStaff.getStaff();
            return View(staff);
        }

        public ActionResult staffInfo(int id)
        {
            var staff = objStaff.getStaffByID(id);
            if (staff == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(staff);
            }
        }


    }
}
