using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NotreDameReBuildOfficial.Infrastructure;

using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers.CMS
{
    public class cmsStaffController : Controller
    {
        
        //
        // GET: /cmsStaff/
        staffDirectory objStaff = new staffDirectory();

        [CustomAuthorize("admin","staff")]
        public ActionResult staffList()
        {
            var staff = objStaff.getStaff();
            return View(staff);
        }

        [CustomAuthorize("admin","staff")]
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

        [CustomAuthorize("admin","staff")]
        public ActionResult InsertStaff()
        {
            return View();
        }

        [CustomAuthorize("admin","staff")]
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

        [CustomAuthorize("admin","staff")]
        public ActionResult deleteStaff(int id)
        {
            var staff = objStaff.getStaffByID(id);
            if(staff == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(staff);
            }
        }

        [CustomAuthorize("admin","staff")]
        [HttpPost]
        public ActionResult deleteStaff(int id, staff_info staff)
        {
            try
            {
                objStaff.deleteStaff(id);
                return RedirectToAction("staffList");
            }
            catch
            {
                return View();
            }
        }

        [CustomAuthorize("admin","staff")]
        public ActionResult updateStaff(int id) //Update Controller
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

        [CustomAuthorize("admin","staff")]
        [HttpPost]
        public ActionResult updateStaff(int id, staff_info staff)
        {
            if (ModelState.IsValid)
            {
                try
                {
                     objStaff.updateStaff(id, staff.staff_id, staff.firstname, staff.lastname, staff.gender, staff.department, staff.role, staff.city, staff.province, staff.zip_code);
                    return RedirectToAction("staffInfo/" + id);
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

        public ActionResult NotFound() //Not dound Controller
        {
            return View();
        }

    }
}
