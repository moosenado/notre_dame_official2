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

        // ------------------------------------- //
        // ------- ARTICLE LIST by Mina ------ //
        // ------------------------------------- //


        public JsonResult InsertVote(int pollid, int optionid)
        {
            Vote vote = new Vote();
            vote.poll_id = pollid;
            vote.poll_options_id = optionid;
            vote.IP_address = "0.0.0.0";
            vote.Insert(vote);

            List<PollOptionResult> Options = vote.GetPollOptionResult(pollid);

            List<pieChartValue> res = new List<pieChartValue>();

            int i = 0;
            foreach(PollOptionResult option in Options)
            {
                pieChartValue obj = new pieChartValue();
                obj.value = option.OptionCount;
                obj.label = option.Option.options;
                obj.color = pieChartValue.colors[i];
                obj.highlight = pieChartValue.highlights[i];
                res.Add(obj);
                i++;
            }
            return Json(new { result = res });
        }
    }

    public class pieChartValue
    {
        public static string[] colors = { "#F7464A", "#46BFBD", "#FDB45C" };
        public static string[] highlights = { "#FF5A5E", "#5AD3D1", "#FFC870" };

        public int value { get; set; }
        public string color { get; set; }
        public string highlight { get; set; }
        public string label { get; set; }
    }
}
