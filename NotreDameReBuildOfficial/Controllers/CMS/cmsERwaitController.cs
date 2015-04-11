using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Linq;

//Imported Namespaces
using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers.CMS
{
    public class cmsERwaitController : Controller
    {
        erwaitClass objER = new erwaitClass();

        //Remove patient from waitlist and average wait time algorithm
        public ActionResult ERwait_Patients(erwaitClass waitclass, string remove_command, string wait_patient_id, ER_wait_list waitlist, ER_wait_time waittime, string current_time)
        {
            if (remove_command == "Remove")
            {
                try
                {
                    //grab id from hidden value on form - convert string to int
                    int id = Int32.Parse(waitclass.wait_patient_id);

                    //grab time from hidden value and subtract from current time
                    DateTime time_now_wait = DateTime.Now;
                    DateTime dateValue;
                    DateTime.TryParse(waitclass.current_time, out dateValue);
                    TimeSpan span = time_now_wait.Subtract(dateValue);

                    //set waittime in wait time table equal to span.totalseconds (amount of time patient has been waiting)
                    waittime.patientid = 1;
                    var timeseconds = span.TotalSeconds;
                    int timeseconds_int = Convert.ToInt32(timeseconds);
                    waittime.waittime = timeseconds_int;

                    //remove patient from waitlist table and add new values into wait time table
                    using (ndLinqClassDataContext objDelete_Insert = new ndLinqClassDataContext())
                    {
                        var delete_by_id = objDelete_Insert.ER_wait_lists.Single(x => x.Id == id);
                        objDelete_Insert.ER_wait_lists.DeleteOnSubmit(delete_by_id);
                        objDelete_Insert.ER_wait_times.InsertOnSubmit(waittime);
                        objDelete_Insert.SubmitChanges(); 
                    }

                    ViewBag.erTimeAdmin = objER.getWaitTime();

                    return RedirectToAction("ERwait_Patients");                  
                }

                catch (Exception ex)
                {
                    ViewBag.Message = "Error:" + ex.Message.ToString();
                }

            }

            ViewBag.erTimeAdmin = objER.getWaitTime();

            //reload patient list to view
            var patients = objER.getWaitingPatientInfo();
            return View(patients);
        }
        
        //add patient straight to ER or to the wait room
        public ActionResult ERwait_AddPatient(string form_command, ER_patient_info patientinfo, ER_wait_list waitlist)
        {
            if (form_command == "waitlist_add")
            {
                try
                {
                    //grab current time
                    DateTime time_now = DateTime.Now;
                    patientinfo.arrivaltime = time_now;

                    var wait_patientid = patientinfo.Id;
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

        public ActionResult ERwait_PatientHistory()
        {
            ViewBag.patientCount = objER.getPatientCount();
            var info = objER.getPatientInfo();
            return View(info);
        }
    }
}
