using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Imported Namespaces
using NotreDameReBuildOfficial.Models;
using System.Web.Services;
using NotreDameReBuildOfficial.ViewModels;

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
        // ------- WEEKLY POLL by MINA ------ //
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
            foreach (PollOptionResult option in Options)
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

        public class pieChartValue
        {
            public static string[] colors = { "#fe890a", "#accf13", "#019ab8" };
            public static string[] highlights = { "#FEB10A", "#BDE21B", "#14B7D7" };

            public int value { get; set; }
            public string color { get; set; }
            public string highlight { get; set; }
            public string label { get; set; }
        }

        // -------------------------------- //
        // ----- EVENTS LISTING by GEN ----- //
        // -------------------------------- //

        eventsListingClass objEvents = new eventsListingClass();

        public ActionResult _EventsPartial(Event events)
        {
            //Passing count of total upcoming events through the ViewBag so it's accessible in the view
            ViewBag.Total = objEvents.getTotalEvents();

            //Get upcoming events for homepage
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

        // ----- INSERT/SUBMIT YOUR EVENT ----- //
        public ActionResult SubmitEvent()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SubmitEvent(Event events)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    objEvents.insertEvent(events);
                    return RedirectToAction("Thanks"); //On sucessful insert, return to Events Listing page
                }
                catch
                {
                    //Error handling, return to Events Listing view if something goes wrong
                    return View();
                }
            }

            return View();
        }

        public ActionResult Thanks()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Thanks(eventsListingValidation valid)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", valid);
            }
            else 
            {
                return View();
            }
        }
        // ------------------------------------- //
        // ------- Search by Lukasz ------ //
        // ------------------------------------- //

        //*****ability to search jobs and events***///
        ndLinqClassDataContext objLinq = new ndLinqClassDataContext();
        ndLinqClassDataContext jobObj = new ndLinqClassDataContext();

        public ActionResult Search(string q)
        {
            var model = new SearchModel();

            //searches job postings by title based on search string
            model.Job_postings = jobObj.Job_postings.Where(x => x.title.Contains(q)).Take(10).ToList();

            //searches events by name based on search string
            model.Events = objLinq.Events.Where(x => x.name.Contains(q)).Take(10).ToList();

            //switch statement used to display all jobs
            switch (q)
            {
                case "job":
                case "jobs":
                case "Jobs":
                case "Job":
                case "Job's":
                case "Career":
                case "careers":
                case "career":
                case "career's":

                    model.Job_postings = jobObj.Job_postings.Select(x => x).ToList();
                    break;
            }

            return View(model);
            //var query = objLinq.Events.Where(x => x.name.Contains(q)).Take(10);
            //return View(query);
        }

       

       
        }


    }

