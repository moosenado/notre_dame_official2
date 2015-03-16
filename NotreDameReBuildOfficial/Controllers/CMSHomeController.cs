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
                return View("Not Found"); // go to Not Found Page
            }
            else
            {
                return View(news_article_id); // go to index
            }
        }

        public ActionResult News_Update(int id, newsfeedClass nfc)
        {
            var news_article_id = objNews.getArticlesByID(id);
            news_article_id.image = nfc.file_update;

            if (news_article_id == null)
            {
                return View("Not Found");
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
                    string path = Path.Combine(Server.MapPath("~/Images/News_Feed"), Path.GetFileName(file_update.FileName));
                    file_update.SaveAs(path);

                    img_update.file = file_update.FileName;

                    newsarticle.image = img_update.file;

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

    }
}
