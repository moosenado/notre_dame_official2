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

        

   
    }
}
