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
