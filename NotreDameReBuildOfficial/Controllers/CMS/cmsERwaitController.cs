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

                    var wait_patientid = 1;
                    var wait_fname = patientinfo.fname;
                    var wait_lname = patientinfo.lname;

                    waitlist.patientid = wait_patientid;
                    waitlist.arrivaltime = time_now;
                    waitlist.fname = wait_fname;
                    waitlist.lname = wait_lname;

                    //add form data to both patient info and wait list tables
                    using (ndLinqClassDataContext objER = new ndLinqClassDataContext())
                    {
                        objER.ER_patient_infos.InsertOnSubmit(patientinfo);
                        objER.ER_wait_lists.InsertOnSubmit(waitlist);
                        objER.SubmitChanges();
                    }

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
                    //grab current time
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
