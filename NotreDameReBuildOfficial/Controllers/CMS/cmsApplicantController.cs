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
        //Delet Applicant from database
        [HttpPost] // restirict an action method by only post requests
        public ActionResult Delete_Applicant(int id, Applicant App)
        {
            Applicant obj = new JobApplicants().getApplicantByID(id);
            if (obj == null)
                return View();
            
            try
            {
                if (obj.resmue != null && obj.resmue.Trim() != "")
                {

                    string fullPath1 = Path.Combine(Server.MapPath("~/Content/applicant/resume"), obj.resmue);

                    if (System.IO.File.Exists(fullPath1))
                    {
                        System.IO.File.Delete(fullPath1);
                        //Session["DeleteSuccess"] = "Yes";
                    }
                }

                AppObj.commitDelete(id);
                return RedirectToAction("Applicants");
            }
            catch
            {
                return View();
            }

        }

    }
}
