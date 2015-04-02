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
        // creating an instance of Applicant class
        JobApplicants AppObj = new JobApplicants(); 
     
        public ActionResult Index()
        {
            return View();
        }
        

        public ActionResult Applicants()
        {
            var App = AppObj.getApplicants();
            return View(App);
        }

        public ActionResult Insert_Applicant(int id)
        {
            ViewBag.JobPosting = new jobPosting().getJobByID(id);

            return View();
        }

        //Add Applicants to the database
        [HttpPost] 
        public ActionResult Insert_Applicant(int id, Applicant App, HttpPostedFileBase file1)
        {
            ViewBag.JobPosting = new jobPosting().getJobByID(id);


            if (ModelState.IsValid)
            {
                if (file1 != null)
                {
                    //string fileName1 = file1 + japp.id.ToString();
                    file1.SaveAs(HttpContext.Server.MapPath("~/Content/applicant/resume/") + file1.FileName);
                    App.resmue = file1.FileName;                                    
                   
                }
                App.job_posting_id = id;
                AppObj.commitInsert(App);
                return RedirectToAction("Success");
                
            }

            return View(App);
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}
