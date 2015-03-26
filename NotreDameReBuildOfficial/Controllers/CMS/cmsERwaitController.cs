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

                    //set waittime in wait time table equal to span.ticks (amount of time patient has been waiting)
                    waittime.patientid = 1;
                    waittime.waittime = span.Ticks;

                    //remove patient from waitlist table and add new values into wait time table
                    using (ndLinqClassDataContext objDelete_Insert = new ndLinqClassDataContext())
                    {
                        var delete_by_id = objDelete_Insert.ER_wait_lists.Single(x => x.Id == id);
                        objDelete_Insert.ER_wait_lists.DeleteOnSubmit(delete_by_id);
                        objDelete_Insert.ER_wait_times.InsertOnSubmit(waittime);
                        objDelete_Insert.SubmitChanges(); 
                    }
                    return RedirectToAction("ERwait_Patients");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error:" + ex.Message.ToString();
                }
            }

            //check how many rows (patients) exist in the wait list table
            var waitlist_status = objER.getWaitListStatus();

            //if  0 patients are in the room, delete all rows in wait time table
            if (waitlist_status == 0)
            {       
                using (ndLinqClassDataContext objDeleteWaitTime = new ndLinqClassDataContext())
                {
                    var delete_wait_time = objDeleteWaitTime.ER_wait_times.Select(x => x);
                    objDeleteWaitTime.ER_wait_times.DeleteAllOnSubmit(delete_wait_time);
                    objDeleteWaitTime.SubmitChanges();
                }
                Response.Write("No One is In the ER - delete er wait time table");
            }
            //if 1 patient is in the room, automatically add a value of 15 minutes to the average wait
            else if (waitlist_status == 1)
            {
                Response.Write("15 mins");
            }
            //if more than 1 patient is in the room, calculate the actual average wait time
            else
            {
                Response.Write("make calculation here");
            }
            var patients = objER.getWaitingPatientInfo();
            return View(patients);
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
