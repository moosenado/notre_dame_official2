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

        // ---  GET ALL EVENTS --- //
        //Executes SELECT query against the db, gets all events and puts them in a list
        public IQueryable<Event> getEvents()
        {
            var allEvents = objLinq.Events.Select(x => x);
            return allEvents;
        }

        // --- GET EVENT BY ID --- //
        public Event getEventByID(int _event_id)
        {
            //Anonymous variable getAllEvents will get events where id of object equals the id in database 
            var getAllEvents = objLinq.Events.SingleOrDefault(x => x.event_id == _event_id);
            return getAllEvents;
        }

        // --- INSERT LOGIC --- //
        public bool insertEvent(Event events)
        {
            //Ensures all data will be disposed of when finished
            using (objLinq)
            {
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
        public bool deleteEvent(int _event_id)
        {
            using (objLinq)
            {
                var objDelete = objLinq.Events.Single(x => x.event_id == _event_id); //Delete table row where id of object equals id in database
                objLinq.Events.DeleteOnSubmit(objDelete);
                objLinq.SubmitChanges();
                return true;
            }
        }
    }
}