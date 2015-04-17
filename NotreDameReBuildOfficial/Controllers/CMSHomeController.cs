using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO; //for uploading file path
using NotreDameReBuildOfficial.Infrastructure;

//Imported Namespaces
using NotreDameReBuildOfficial.Models;
using NotreDameReBuildOfficial.Infrastructure;

namespace notre_dame_rebuild.Controllers
{
    public class CMSHomeController : BaseController
    {
        [CustomAuthorize("Admin", "Staff")]
        public ActionResult Index()
        {
            return View();
        }

        // ------------------------------------- //
        // ----- NEWS FEED ADMIN by ELLIOT ----- //
        // ------------------------------------- //

        newsfeedClass objNews = new newsfeedClass();

        [CustomAuthorize("Admin", "Staff")]
        public ActionResult News()
        {
            var articles = objNews.getArticles();
            return View(articles);
        }

        [CustomAuthorize("Admin", "Staff")]
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

        // ------------------------------------- //
        // ----- JobPosting ADMIN by Mina ----- //
        // ------------------------------------- //

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

        public ActionResult Insert_JobPosting()
        {
            ViewBag.Categories = new jobCategory().getJobCategory();
           
            return View();
        }
        [HttpPost]// restirict an action method by only post requests 
        public ActionResult Insert_JobPosting(Job_posting jobPost)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    JobPosObj.commitInsert(jobPost); // if the state of the model is  valid the commitInsert function will be called and new value will be commited to database.
                    return RedirectToAction("JobPosting"); //after inserting values in database, page will redirect to the index page and show all data
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        public ActionResult Update_JobPosting(int id)
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

        [HttpPost]// restirict an action method by only post requests
        public ActionResult Update_JobPosting(int id, Job_posting JobPost)
        {
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
                    return View();
                }
            }
            return View();
        }

        public ActionResult Delete_JobPosting(int id)
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

        [HttpPost] // restirict an action method by only post requests
        public ActionResult Delete_JobCategory(int id, Job_posting Jobcat)
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

        [CustomAuthorize("Admin", "Staff")]
        public ActionResult News_Details(int id)
        {
            var news_article_id = objNews.getArticlesByID(id);

            if (news_article_id == null)
            {
                return View("News"); // go to news
            }
            else
            {
                return View(news_article_id); // go to page
            }
        }

        [CustomAuthorize("Admin", "Staff")]
        public ActionResult News_Update(int id)
        {
            var news_article_id = objNews.getArticlesByID(id);

            if (news_article_id == null)
            {
                return View("News");
            }
            else
            {
                return View(news_article_id);
            }
        }
        [HttpPost]
        public ActionResult News_Update(int id, newsfeedClass img_update, news_article newsarticle, HttpPostedFileBase file_update)
        {
            if (ModelState.IsValid) // Check if model is valid
            {
                try
                {
                    if (file_update != null) //if user uploads a new image
                    {
                        string path = Path.Combine(Server.MapPath("~/Images/News_Feed"), Path.GetFileName(file_update.FileName));
                        file_update.SaveAs(path);

                        img_update.file = file_update.FileName;

                        newsarticle.image = img_update.file;
                    }

                    //if the user does not upload a new image, this will execute using the hidden value on the page

                    objNews.articleUpdate(id, newsarticle.title, newsarticle.date, newsarticle.author, newsarticle.image, newsarticle.article);

                    return RedirectToAction("News_Details/" + id);
                }
                catch
                {
                    return View(); // return original view if there is an error
                }
            }

            return View(); // return view if model is not valid
        }

        [CustomAuthorize("Admin", "Staff")]
        public ActionResult News_Delete(int id)
        {
            // Check to see if user id exists and handle it
            var article_delete = objNews.getArticlesByID(id);

            if (article_delete == null)
            {
                return View("News");
            }
            else
            {
                return View(article_delete);
            }
        }

        [HttpPost]
        public ActionResult News_Delete(int id, news_article newsarticle)
        {
            try
            {
                objNews.articleDelete(id); // commit delete to the database
                return RedirectToAction("News"); //redirect to Index
            }
            catch
            {
                return View(); //return to original view if an error occurs
            }
        }

        // ------------------------------------- //
        // ----- Search ADMIN by Lukasz ----- //
        // ------------------------------------- //

        //SearchClass objSearch = new SearchClass(); //created instance

        //public ActionResult Search() //method gets all search terms using model and displays it on Search view  
        //{
        //    var search = objSearch.getSearchs(); //calls method getAppts from model
        //    return View(search);
        //}

        //public ActionResult Details(int id)
        //{
        //    var appt = objSearch.getSearchByID(id);
        //    if (appt == null)
        //    {
        //        return View("NotFound");
        //    }
        //    else
        //    {
        //        return View(); ///////Add search
        //    }
        //}

        //public ActionResult createSearch()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult createSearch(Search search)
        //{

        //    if (ModelState.IsValid)
        //    {


        //        try
        //        {
        //            search.Tstamp = DateTime.Now; //automatically inserts datetime when form submitted 
        //            objSearch.insertSearch(search);
        //            return RedirectToAction("Search");
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }
        //    return View();
        //}

    }
}
