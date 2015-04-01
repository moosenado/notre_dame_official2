using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Imported Namespaces
using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers.CMS
{
    public class cmsEventsListingController : Controller
    {
        eventsListingClass objEvents = new eventsListingClass();

        //General list of events
        public ActionResult Manage()
        {
            var list = objEvents.getEvents();
            return View(list);
        }

        //General list of events
        public ActionResult cmsEventsListing()
        {
            var list = objEvents.getEvents();
            return View(list);
        }

        //When admin wants to see the event details
        public ActionResult Details(int event_id)
        {
            var events = objEvents.getEventByID(event_id);

            if (events == null)
            {
                return View("NotFound");
                //same as saying return NotFound();
            }
            else
            {
                return View(events);
            }
        }

        eventsListingViewModel objEventVM = new eventsListingViewModel();

        public ActionResult EventsViewModel()
        {
            return View(objEventVM);
        }


        // --- INSERT ACTION --- //
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Event events)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    objEvents.insertEvent(events);
                    return RedirectToAction("Manage"); //On sucessful insert, return to Events Listing page
                }
                catch
                {
                    //Error handling, return to Events Listing view if something goes wrong
                    return View();
                }
            }

            return View();
        }

    }
}
