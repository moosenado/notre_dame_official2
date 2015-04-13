using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers
{
    public class volunteerController : Controller
    {
        //
        // GET: /volunteer/

        volunteerJobs objVol = new volunteerJobs();

        volunteerInfo objInfo = new volunteerInfo();

        volunteerInfoValidate objVolV = new volunteerInfoValidate();

        public ActionResult Opportunities()
        {
            var job = objVol.getJobs();
            return View(job);
        }

        public ActionResult oppInfo(int id)
        {
            var job = objVol.getJobByID(id);
            if (job == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(job);
            }
        }


        public ActionResult volInfo(int id)
        {
            var job = objVol.getJobByID(id);
            if (job == null)
            {
                return View("NotFound");
            }
            else
            {
                TempData["id"] = id;
                return RedirectToAction("apply");
            }
        }


        public ActionResult apply()
        {
            return View();
        }

        [HttpPost]
        public ActionResult apply(volunteer_info info)
        {
            if(ModelState.IsValid)
            {
                var jobid = (int)TempData["id"];
                info.dateApplied = DateTime.Now;
                info.jobID = jobid;
                objInfo.InsertVol(info);
                return RedirectToAction("opportunities");
            }

            return View();
        }

    }
}
