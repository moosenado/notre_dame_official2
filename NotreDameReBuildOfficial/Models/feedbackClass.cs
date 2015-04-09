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

        // --- GET FEEDBACK BY APPROVAL STATUS --- //
        public IQueryable<Feedback> getFeedbackByStatus(int status)
        {
            var getFeedback = (from a in objLinq.Feedbacks
                               where a.approved == status
                               orderby a.date ascending
                               select a);
            return getFeedback;
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

        // --- UPDATE LOGIC --- //
        public bool updateFeedback(Feedback feedback)
        {
            using (objLinq)
            {
                var objUpdate = objLinq.Feedbacks.Single(x => x.feedback_id == feedback.feedback_id);
                objUpdate.name = feedback.name;
                objUpdate.email = feedback.email;
                objUpdate.subject = feedback.subject;
                objUpdate.category = feedback.category;
                objUpdate.comments = feedback.comments;
                objUpdate.approved = feedback.approved;
                objLinq.SubmitChanges();
                return true;
            }
        }

        // --- DELETE LOGIC --- //
        public bool deleteFeedback(int feedback_id)
        {
            using (objLinq)
            {
                var objDelete = objLinq.Feedbacks.Single(x => x.feedback_id == feedback_id); //Delete table row where id of object equals id in database
                objLinq.Feedbacks.DeleteOnSubmit(objDelete);
                objLinq.SubmitChanges();
                return true;
            }
        }
    }
}