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

        //Executes SELECT query against the db, gets all events and puts them in a list
        public IQueryable<Event> getEvents()
        {
            var allEvents = objLinq.Events.Select(x => x);
            return allEvents;
        }

        //Get event by its id
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

    }
}