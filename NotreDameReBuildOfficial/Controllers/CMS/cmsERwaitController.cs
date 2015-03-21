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

        public ActionResult ERwait_AddPatient(string form_command, ER_patient_info patientinfo, ER_wait_list waitlist)
        {
            if (form_command == "waitlist_add")
            {
                try
                {
                    //grab current time
                    DateTime time_now = DateTime.Now;
                    patientinfo.arrivaltime = time_now;

                    //match field entries going into patient info table to waitlist table
                    waitlist.patientid = patientinfo.Id;
                    waitlist.arrivaltime = patientinfo.arrivaltime;
                    waitlist.fname = patientinfo.fname;
                    waitlist.fname = patientinfo.lname;

                    //insert data into both patientinfo and waitlist tables
                    objER.insertPatient(patientinfo);
                    objER.insertPatient_Wait(waitlist);

                    //output message
                    ViewBag.Message = "Patient Added to ER Wait Room";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error:" + ex.Message.ToString();
                }
            }
            else if (form_command == "patient_add")
            {
                try
                {
                    DateTime time_now = DateTime.Now;
                    patientinfo.arrivaltime = time_now;
                    //insert data into patientinfo table only
                    objER.insertPatient(patientinfo);

                    ViewBag.Message = "Patient Added To ER";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error:" + ex.Message.ToString();
                }
            }
            else
            {
                return View();
            }

            return View();
        }
    }
}
