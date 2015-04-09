using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotreDameReBuildOfficial.Models
{
    public class eventsListingClass
    {

        //Creating an object of the linq database class
        ndLinqClassDataContext objLinq = new ndLinqClassDataContext();

        // --- GET FIRST 3 UPCOMING EVENTS --- //
        public IQueryable<Event> getHomepageEvents()
        {
            var today = DateTime.Now;
            var homepageEvents = (from a in objLinq.Events
                                 where a.start_date > today && a.display == 1
                                 || a.start_date <= today && a.end_date > today && a.display == 1
                                 orderby a.start_date ascending
                                 select a).Take(3);
            return homepageEvents;
        }

        // --- GET TOTAL UPCOMING EVENTS --- //
        public int getTotalEvents()
        {
            var today = DateTime.Now;
            var totalEvents = (from a in objLinq.Events
                               where a.start_date > today && a.display == 1
                               || a.start_date <= today && a.end_date > today && a.display == 1
                               orderby a.start_date ascending
                               select a).Count();
            return totalEvents;
        }

        // --- GET EVENT BY ID --- //
        public Event getEventByID(int _event_id)
        {
            //Anonymous variable getAllEvents will get events where id of object equals the id in database 
            var getAllEvents = objLinq.Events.SingleOrDefault(x => x.event_id == _event_id);
            return getAllEvents;
        }

        // --- GET UPCOMING EVENTS --- //
        // select events with future start dates
        // select events with future end dates
        public IQueryable<Event> getUpcomingEvents()
        {
            var today = DateTime.Now;
            var upcomingEvents = from a in objLinq.Events
                              where a.start_date > today && a.display == 1
                              || a.start_date <= today && a.end_date > today && a.display == 1
                              orderby a.start_date ascending
                              select a;

            return upcomingEvents;
        }

        // --- GET ARCHIVED EVENTS --- //
        // select events with a start date and end date less than today
        public IQueryable<Event> getArchivedEvents()
        {
            var today = DateTime.Now;
            var archivedEvents = from a in objLinq.Events
                                 where a.start_date < today && a.end_date < today && a.display == 0 || a.display == 0
                                 orderby a.start_date descending
                                 select a;

            return archivedEvents;
        }

        // --- INSERT LOGIC --- //
        public bool insertEvent(Event events)
        {
            //Ensures all data will be disposed of when finished
            using (objLinq)
            {
                //if the end date is submitted as null, assign it the value of start date
                if(events.end_date == null){

                    events.end_date = events.start_date;

                }

                objLinq.Events.InsertOnSubmit(events);
                objLinq.SubmitChanges();
                return true;
            }
        }

        // --- UPDATE LOGIC --- //
        public bool updateEvent(Event events)
        {
            using (objLinq)
            {
                var objUpdate = objLinq.Events.Single(x => x.event_id == events.event_id);
                objUpdate.name = events.name;
                objUpdate.start_date = events.start_date;
                objUpdate.start_time = events.start_time;
                objUpdate.end_date = events.end_date;
                objUpdate.end_time = events.end_time;
                objUpdate.description = events.description;
                objUpdate.venue = events.venue;
                objUpdate.address = events.address;
                objUpdate.cost = events.cost;
                objUpdate.contact_name = events.contact_name;
                objUpdate.contact_email = events.contact_email;
                objUpdate.contact_phone = events.contact_phone;
                objUpdate.url = events.url;
                objUpdate.approved = events.approved;
                objUpdate.display = events.display;
                objLinq.SubmitChanges();
                return true;
            }
        }

        // --- DELETE LOGIC --- //
        public bool deleteEvent(int event_id)
        {
            using (objLinq)
            {
                var objDelete = objLinq.Events.Single(x => x.event_id == event_id); //Delete table row where id of object equals id in database
                objLinq.Events.DeleteOnSubmit(objDelete);
                objLinq.SubmitChanges();
                return true;
            }
        }
    }
}