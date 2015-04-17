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
         [CustomAuthorize("Admin", "Staff")]
        public ActionResult Applicants()
        {
            var App = AppObj.getApplicants();
            return View(App);
        }
        [CustomAuthorize("Admin", "Staff")]
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
        [CustomAuthorize("Admin", "Staff")]
        public ActionResult Delete_Applicant(int id)
        {

            var App = AppObj.getApplicantByID(id);
            if (App == null)
            {
                return View("NotFound");
            }
            else
            {
                TempData["id"] = id;
                return View(App);
            }
        }

        [HttpPost]
        public ActionResult Delete_Applicant(int id, Applicant App)
        {
            
            ////Applicant obj = new JobApplicants().getApplicantByID(id);
            //if (obj == null)
            //    return View();

            //try
            //{
            //    if (obj.resmue != null && obj.resmue.Trim() != "")
            //    {
            //         //Path.Combine

            //        string fullPath1 = Path.Combine(Server.MapPath("~/Content/applicant/resume/"), obj.resmue);

            //        if (System.IO.File.Exists(fullPath1))
            //        {
            //            System.IO.File.Delete(fullPath1);
            //            //Session["DeleteSuccess"] = "Yes";
            //        }
            //    }

            //    AppObj.commitDelete(id);
            //    return RedirectToAction("Applicants");
            //}
            //catch
            //{
            //    return View();
            //}
              var obj = AppObj.getApplicantByID(id);
            try
            {

                var resumeName = obj.resmue;


                string fullPath1 = Server.MapPath("~/Content/applicant/resume"
                + resumeName);


                if (System.IO.File.Exists(fullPath1))
                {
                    System.IO.File.Delete(Server.MapPath("~/Content/applicant/resume"
                + resumeName));
                }

                AppObj.commitDelete(id);
                return RedirectToAction("Applicants");
            }
            catch (Exception e)
            {
                var message = e.Message;
                return View(App);
            }

        }


        

    }
}
