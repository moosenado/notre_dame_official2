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

    }
}
