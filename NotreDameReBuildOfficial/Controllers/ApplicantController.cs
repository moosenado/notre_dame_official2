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
    public class ApplicantController : Controller
    {
        //
        // GET: /Applicant/
        JobApplicants AppObj = new JobApplicants(); // creating an instance of Applicant class
     
        public ActionResult Index()
        {
            return View();
        }
        

        public ActionResult Applicants()
        {
            var App = AppObj.getApplicants();
            return View(App);
        }

        public ActionResult Insert_Applicant(int jobID)
        {
            ViewBag.JobPostingTitle = new jobPosting().getJobByID(jobID).title;

            return View();
        }
        [HttpPost]// restirict an action method by only post requests 
        public ActionResult Insert_Applicant(Applicant App, HttpPostedFileBase resume)
        {
            ViewBag.JobPosting = new jobPosting().getJobs();

            if (ModelState.IsValid)
            {
                try
                {
                    AppObj.commitInsert(App); // if the state of the model is  valid the commitInsert function will be called and new value will be commited to database.
                    return RedirectToAction("Success"); //after inserting values in database, page will show the success page
                }
                catch
                {
                    return View(App);
                }
            }
            return View(App);
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}
