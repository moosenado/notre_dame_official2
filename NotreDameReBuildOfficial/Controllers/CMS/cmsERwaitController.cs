using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Imported Namespaces
using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers.CMS
{
    public class cmsERwaitController : Controller
    {
        erwaitClass objER = new erwaitClass();

        public ActionResult ERwait_Patients()
        {
            return View();
        }

        public ActionResult ERwait_AddPatient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ERwait_AddPatient(ER_patient_info patientinfo, ER_wait_list waitlist)
        {
            if (ModelState.IsValid)
                try
                {
                    //match field entries going into patient info table to waitlist table
                    waitlist.patientid = patientinfo.Id;
                    waitlist.arrivaltime = patientinfo.arrivaltime;
                    waitlist.fname = patientinfo.fname;
                    waitlist.fname = patientinfo.lname;

                    //insert data into both patientinfo and waitlist tables
                    objER.insertPatient(patientinfo);
                    objER.insertPatient_Wait(waitlist);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "Please Select a File";
            }
            return View();
        }

    }
}
