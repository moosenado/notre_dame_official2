using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Imported Namespaces
using NotreDameReBuildOfficial.Models;
using System.Web.Services;

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
            ViewBag.Poll = new poll().GetRandomQuestion();
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

        [WebMethod]
        public static string InsertVote(poll_vote param)
        {
            Vote vote = new Vote();
            vote.poll_id = param.pollid;
            vote.poll_options_id = param.optionid;
            vote.Insert(vote);
            return "success";
        }
    }

    [Serializable]
    public class poll_vote
    {
        public int pollid { get; set; }
        public int optionid { get; set; }
    }
}
