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

        //When admin wants to see the event details
        public ActionResult Details(int event_id)
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

        // --- UPDATE ACTION --- //
        //Reads the request to update
        public ActionResult Update(int event_id)
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

        //Executes the update when submit button is clicked
        [HttpPost]
        public ActionResult Update(Event events)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    objEvents.updateEvent(events);
                    return RedirectToAction("Manage", new { event_id = events.event_id }); //After successful update, return to index
                }
                catch
                {
                    //Error handling, return Update view if something goes wrong
                    return View();
                }
            }

            return View();
        }

        // --- DELETE ACTION --- //
        //Reads the request to delete
        public ActionResult Delete(int event_id)
        {
            var events = objEvents.getEventByID(event_id);
            //if record can't be found, return Not Found page
            if (events == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(events);
            }
        }

        //Executes the delete when yes (submit) button is clicked
        [HttpPost]
        public ActionResult Delete(int event_id, Event events)
        {
            try
            {
                objEvents.deleteEvent(event_id);
                return RedirectToAction("Manage"); //On successful delete, return to main event management page
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

    }
}
