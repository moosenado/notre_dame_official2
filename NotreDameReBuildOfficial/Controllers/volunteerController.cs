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

        public ActionResult applyVol()
        {
            return View();
        }

        [HttpPost]
        public ActionResult apply(volunteer_info vol, int id)
        {
            var job = objInfo.getJobByID(id);
  
            if (ModelState.IsValid)
            {

                vol.dateApplied = DateTime.Now;
                objInfo.InsertVol(vol);
                return RedirectToAction("opportunities");
            }
            return View(job);
        }

    }
}
