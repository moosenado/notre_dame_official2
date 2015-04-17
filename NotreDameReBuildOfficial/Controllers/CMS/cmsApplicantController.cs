using System;
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
    public class cmsApplicantController : BaseController
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

        

    }
}
