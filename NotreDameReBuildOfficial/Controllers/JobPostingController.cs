using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO; //for uploading file path

//Imported Namespaces
using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers
{
    public class JobPostingController : Controller
    {
        //
        // GET: /JobPosting/

        public ActionResult Index()
        {
            return View();
        }

        jobPosting JobPosObj = new jobPosting(); // creating an instance of jobPosting class

        //Get all Jobs
        public ActionResult JobPosting()
        {
            var JobPost = JobPosObj.getJobs();
            return View(JobPost);
        }

        //Get Job by id
        public ActionResult JobPosting_Details(int id)
        {
            var JobPost = JobPosObj.getJobByID(id);
            if (JobPost == null)
            {
                return View("Not Found");
            }
            else
            {
                return View(JobPost);
            }
        }

    }
}
