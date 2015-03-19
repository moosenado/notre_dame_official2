using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Imported Namespaces
using NotreDameReBuildOfficial.Models;

namespace notre_dame_rebuild.Controllers
{
    public class HomeController : Controller
    {
        // ------------------------------------- //
        // ------------- INDEX PAGE ------------ //
        // ------------------------------------- //

        newsfeedClass objNews = new newsfeedClass();
        public ActionResult Index()
        {
            var articles = objNews.getTopArticles();
            return View(articles);
        }

        // ------------------------------------- //
        // ----- ARTICLE DETAILS by ELLIOT ----- //
        // ------------------------------------- //

        public ActionResult Article_Details(int id)
        {
            var news_article_id = objNews.getArticlesByID(id);

            if (news_article_id == null)
            {
                return View("Index"); // go to index
            }
            else
            {
                return View(news_article_id);
            }
        }

        // ------------------------------------- //
        // ------- ARTICLE LIST by ELLIOT ------ //
        // ------------------------------------- //

        public ActionResult Article_List()
        {
            var all_articles = objNews.getArticles();
            return View(all_articles);
        }


        // ---------------------------- //
        // ----- DONATIONS by GEN ----- //
        // ---------------------------- //

        ////Instantiates an object of the donationClass
        //donationClass objDonate = new donationClass();

        ////Donation Form Page Method
        //public ActionResult Donate()
        //{
        //    return View();
        //}

        ////Inserts donation into db
        //[HttpPost]
        //public ActionResult Donate(Donation donation)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            objDonate.insertDonation(donation);
        //            return RedirectToAction("Index"); //On sucessful insert, return to Donate page
        //        }
        //        catch
        //        {
        //            //Error handling, return to Donation view if something goes wrong
        //            return View();
        //        }
        //    }

        //    return View();
        //}
     
    
    }
}
