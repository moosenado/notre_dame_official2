﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO; //for uploading file path
using NotreDameReBuildOfficial.Infrastructure;

//Imported Namespaces
using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers.CMS
{
    public class cmsJobPostingController : Controller
    {
        //
        // GET: /cmsJobPosting/

        public ActionResult Index()
        {
            return View();
        }
        jobPosting JobPosObj = new jobPosting(); // creating an instance of jobPosting class

        //Get all Jobs
        [CustomAuthorize("Admin", "Staff")]
        public ActionResult JobPosting()
        {
            var JobPost = JobPosObj.getJobs();
            return View(JobPost);
        }


        //Get Job by id
        [CustomAuthorize("Admin", "Staff")]
        public ActionResult JobPosting_Details(int id)
        {
            var JobPost = JobPosObj.getJobByID(id);
            if (JobPost == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(JobPost);
            }
        }
        [CustomAuthorize("Admin")]
        public ActionResult Insert_JobPosting()
        {
            ViewBag.Categories = new jobCategory().getJobCategory();

            return View();
        }
        [HttpPost]// restirict an action method by only post requests 
        public ActionResult Insert_JobPosting(Job_posting jobPost)
        {
            ViewBag.Categories = new jobCategory().getJobCategory();

            if (ModelState.IsValid)
            {
                try
                {
                    JobPosObj.commitInsert(jobPost); // if the state of the model is  valid the commitInsert function will be called and new value will be commited to database.
                    return RedirectToAction("JobPosting"); //after inserting values in database, page will redirect to the index page and show all data
                }
                catch
                {
                    return View(jobPost);
                }
            }
            return View(jobPost);
        }
        [CustomAuthorize("Admin")]
        public ActionResult Update_JobPosting(int id)
        {
            ViewBag.Categories = new jobCategory().getJobCategory();
            var JobPost = JobPosObj.getJobByID(id);
            if (JobPost == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(JobPost);
            }

        }

        [HttpPost]// restirict an action method by only post requests
        public ActionResult Update_JobPosting(int id, Job_posting JobPost)
        {
            ViewBag.Categories = new jobCategory().getJobCategory();
            if (ModelState.IsValid)
            {
                try
                {
                    // get the new values and passed them to fields by these parameter
                    JobPosObj.commitUpdate(id, JobPost.title, JobPost.type, JobPost.department, JobPost.description, JobPost.salary, JobPost.posting_date, JobPost.category_id);
                    return RedirectToAction("JobPosting_Details/" + id);// the page will redirect to the Job posting details
                }
                catch
                {
                    return View(JobPost);
                }
            }
            return View(JobPost);
        }
        [CustomAuthorize("Admin")]
        public ActionResult Delete_JobPosting(int id)
        {
            var JobPost = JobPosObj.getJobByID(id);
            if (JobPost == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(JobPost);
            }
        }

        [HttpPost] // restirict an action method by only post requests
        public ActionResult Delete_JobPosting(int id, Job_posting Jobcat)
        {
            try
            {
                JobPosObj.commitDelete(id);
                return RedirectToAction("JobPosting");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult NotFound()
        {
            return View();
        }

    }
}
