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
                    return RedirectToAction("createAppt");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

    }
}
