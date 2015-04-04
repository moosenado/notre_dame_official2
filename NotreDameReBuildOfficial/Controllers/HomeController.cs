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
        erwaitClass objER = new erwaitClass();


        public ActionResult Index()
        {
            ViewBag.erTime = objER.getWaitTime();
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


        // -------------------------------- //
        // ----- EVENTS LISTING by GEN ----- //
        // -------------------------------- //

        eventsListingClass objEvents = new eventsListingClass();

        public ActionResult EventsPartial(Event events)
        {
            //Passing count of total upcoming events through the ViewBag so it's accessible in the view
            ViewBag.Total = objEvents.getTotalEvents();

            //Upcoming Events
            var upcoming = objEvents.getHomepageEvents();

            return PartialView(upcoming);

        }

        public ActionResult AllEvents()
        {

            //Upcoming Events
            var upcoming = objEvents.getUpcomingEvents();

            return View(upcoming);
        }

        //When admin wants to see the event details
        public ActionResult EventDetails(int event_id)
        {
            var events = objEvents.getEventByID(event_id);

            if (events == null)
            {
                return View("NotFound");

            }
            else
            {
                return View(events);
            }
        }
    
    }
}
