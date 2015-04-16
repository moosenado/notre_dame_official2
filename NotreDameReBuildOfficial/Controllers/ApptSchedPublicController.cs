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
        [HttpPost]
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

        public ActionResult Thanks()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                return RedirectToAction("createAppt");
            }
        }

        [HttpPost]
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
