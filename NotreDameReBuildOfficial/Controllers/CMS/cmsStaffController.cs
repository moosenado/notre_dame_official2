using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers.CMS
{
    public class cmsStaffController : Controller
    {
        
        //
        // GET: /cmsStaff/
        staffDirectory objStaff = new staffDirectory();

        
        public ActionResult staffList()
        {
            var staff = objStaff.getStaff();
            return View(staff);
        }

        public ActionResult InsertStaff()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertStaff(staff_info staff)
        {
            if(ModelState.IsValid)
            {
                objStaff.insertStaff(staff);
                return RedirectToAction("staffList");
            }
            return View();
        }
    }
}
