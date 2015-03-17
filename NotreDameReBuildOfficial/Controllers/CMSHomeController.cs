using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO; //for uploading file path

//Imported Namespaces
using NotreDameReBuildOfficial.Models;

namespace notre_dame_rebuild.Controllers
{
    public class CMSHomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // ------------------------------------- //
        // ----- NEWS FEED ADMIN by ELLIOT ----- //
        // ------------------------------------- //

        newsfeedClass objNews = new newsfeedClass();

        public ActionResult News()
        {
            var articles = objNews.getArticles();
            return View(articles);
        }

        public ActionResult News_Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult News_Insert(newsfeedClass img, news_article newsarticle, HttpPostedFileBase file)
        {
            if (file != null)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images/News_Feed"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);

                    img.file = file.FileName;

                    newsarticle.image = img.file;

                    objNews.insertArticle(newsarticle);

                    ViewBag.Message = "Success";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "Please Select a File";
            }
            return View();
        }

        // ------------------------------------- //
        // ----- JobCategory ADMIN by Mina ----- //
        // ------------------------------------- //

        jobCategory JobCatObj = new jobCategory(); // creating an instance of jobCategory
        
        //Get all Job categories
        public ActionResult JobCategory()
        {
            var Jobcat = JobCatObj.getJobCategory();
            return View(Jobcat); 
        }

        //Get Job category by id
        public ActionResult JobCategory_Details(int id)
        {
            var JobCat = JobCatObj.getJobCategoryByID(id);
            if (JobCat == null) 
            {
                return View("Not Found");
            }
            else
            {
                return View(JobCat); 
            }
        }

        public ActionResult Insert_JobCategory()
        {
            return View();
        }
        [HttpPost]// restirict an action method by only post requests 
        public ActionResult Insert_JobCategory(Job_category jobCat)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    JobCatObj.commitInsert(jobCat); // if the state of the model is  valid the commitInsert function will be called and new value will be commited to database.
                    return RedirectToAction("JobCategory"); //after inserting values in database, page will redirect to the index page and show all data
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        public ActionResult Update_JobCategory(int id)
        {
            var JobCat = JobCatObj.getJobCategoryByID(id);
            if (JobCat == null) 
            {
                return View("Not Found");
            }
            else
            {
                return View(JobCat); 
            }

        }

        [HttpPost]// restirict an action method by only post requests
        public ActionResult Update_JobCategory(int id, Job_category JobCat)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    JobCatObj.commitUpdate(id, JobCat.title); // get the new values and passed them to fields by these parameter
                    return RedirectToAction("JobCategory_Details/" + id);// the page will redirect to the Job Category Information
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        public ActionResult Delete_JobCategory(int id)
        {
            var JobCat = JobCatObj.getJobCategoryByID(id);
            if (JobCat == null)
            {
                return View("Not Found");
            }
            else
            {
                return View(JobCat);
            }
        }

        [HttpPost] // restirict an action method by only post requests
        public ActionResult Delete_JobCategory(int id, Job_category Jobcat)
        {
            try
            {
                JobCatObj.commitDelete(id);
                return RedirectToAction("JobCategory");
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
