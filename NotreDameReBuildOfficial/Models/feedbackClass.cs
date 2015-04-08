using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotreDameReBuildOfficial.Models
{
    public class feedbackClass
    {
        //Creating an object of the linq database class
        ndLinqClassDataContext objLinq = new ndLinqClassDataContext();

        //Executes SELECT query against the db, gets all donations and puts them in a list
        public IQueryable<Feedback> getFeedback()
        {
            var allFeedback = objLinq.Feedbacks.Select(x => x);
            return allFeedback;
        }

        //Get feedback by its record number
        public Feedback getFeedbackByID(int _feedback_id)
        {
            //Anonymous variable getAllFeedback will get feedback where id of object equals the id in database 
            var getAllFeedback = objLinq.Feedbacks.SingleOrDefault(x => x.feedback_id == _feedback_id);
            return getAllFeedback;
        }

        // --- INSERT LOGIC --- //
        public bool insertFeedback(Feedback feedback)
        {

            //Ensures all data will be disposed of when finished
            using (objLinq)
            {

                objLinq.Feedbacks.InsertOnSubmit(feedback);
                objLinq.SubmitChanges();
                return true;
            }
        }


    }
}