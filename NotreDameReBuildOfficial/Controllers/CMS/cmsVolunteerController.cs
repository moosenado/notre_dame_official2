using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NotreDameReBuildOfficial.Infrastructure;

using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers.CMS
{
    public class cmsVolunteerController : Controller
    {
        //
        // GET: /cmsVolunteer/

        volunteerJobs objVol = new volunteerJobs();

        volunteerInfo objInfo = new volunteerInfo();

        [CustomAuthorize("admin")]
        public ActionResult jobList()
        {
            var job = objVol.getJobs();
            return View(job);
        }

        [CustomAuthorize("admin")]
        public ActionResult passID(int id)
        {
            var job = objVol.getJobByID(id);
            if (job == null)
            {
                return View("NotFound");
            }
            else
            {
                TempData["id"] = id;
                return RedirectToAction("volList");
            }
        }

        [CustomAuthorize("admin")]
        public ActionResult volList()
        {
            var jobid = (int)TempData["id"];
            //info.jobID = jobid;
            var vol = objInfo.getVolByID(jobid);

            return View(vol);
        }

        [CustomAuthorize("admin")]
        public ActionResult jobInfo(int id)
        {
            var job = objVol.getJobByID(id);
            if(job == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(job);
            }
        }

        [CustomAuthorize("admin")]
        public ActionResult volInfo(int id)
        {
            var job = objInfo.getVolInfoByID(id);
            if (job == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(job);
            }
        }

        [CustomAuthorize("admin")]
        public ActionResult InsertJob()
        {
            return View();
        }

        [CustomAuthorize("admin")]
        [HttpPost]
        public ActionResult insertJob(volunteerJob jobs)
        {
            if(ModelState.IsValid)
            {
                
                jobs.date = DateTime.Now;
                objVol.InsertJob(jobs);
                return RedirectToAction("JobList");
            }
            return View();
        }

        [CustomAuthorize("admin")]
        public ActionResult deleteJob(int id)
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

        [CustomAuthorize("admin")]
        [HttpPost]
        public ActionResult deleteJob(int id, volunteerJob job)
        {
            try
            {
                objVol.deleteJob(id);
                return RedirectToAction("JobList");
            }
            catch
            {
                return View();
            }
        }

        [CustomAuthorize("admin")]
        public ActionResult updateJob(int id) //Update Controller
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

        [CustomAuthorize("admin")]
        [HttpPost]
        public ActionResult updateJob(int id, volunteerJob job)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    objVol.updateJob(id, job.jobTitle, job.jobDescription, job.street, job.city, job.province, job.zip_code, job.date, job.dateStart, job.dateEnd);
                    return RedirectToAction("JobInfo/" + id);
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return View();
            }

        }

        public ActionResult NotFound() //Not found Controller
        {
            return View();
        }
        
    }
}
