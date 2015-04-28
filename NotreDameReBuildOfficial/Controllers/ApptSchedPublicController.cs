using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NotreDameReBuildOfficial.Models; 

namespace NotreDameReBuildOfficial.Controllers
{
    public class ApptSchedPublicController : Controller
    {
        ApptSchedClass objApptSched = new ApptSchedClass(); //created instance

        public ActionResult createAppt()
        {
            return View();
        }
        [HttpPost] //Public Appointment form
        public ActionResult createAppt(Appt_Book appt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    appt.Tstamp = DateTime.Now; //automatically inserts datetime when form submitted 
                    objApptSched.insertAppt(appt);
                    //return RedirectToRoute("Home");
                    return RedirectToAction("Thanks");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        public ActionResult Thanks() //thank you page after user submits
        {
            //if (!ModelState.IsValid) //if no errors then goto thank you page
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("createAppt"); //if errors then go back to appointment form
            //}
            return View();
        }

        [HttpPost]  //carries over user input and displays a summary
        public ActionResult Thanks(ApptSchedValidation valid)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", valid);
            }
            else
            {
                return View();
            }
        }

    }
}
