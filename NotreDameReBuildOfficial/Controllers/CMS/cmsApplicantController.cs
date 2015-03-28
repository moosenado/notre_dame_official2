using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO; //for uploading file path

//Imported Namespaces
using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers.CMS
{
    public class cmsApplicantController : Controller
    {
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

        public ActionResult Applicant_Details(int id)
        {
            var App = AppObj.getApplicantByID(id);
            if (App == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(App);
            }
        }

        public ActionResult Delete_Applicant(int id)
        {
            var App = AppObj.getApplicantByID(id);
            if (App == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(App);
            }
        }

        [HttpPost] // restirict an action method by only post requests
        public ActionResult Delete_Applicant(int id, Applicant App)
        {
            try
            {
                AppObj.commitDelete(id);
                return RedirectToAction("Applicants");
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
