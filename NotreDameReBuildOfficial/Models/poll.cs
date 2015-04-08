using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotreDameReBuildOfficial.Models
{
    public partial class poll
    {
        ndLinqClassDataContext db = new ndLinqClassDataContext();

        public List<Poll_option> options { get; set; }

        public poll GetRandomQuestion()
        {
            poll res = new poll();

            int question_count = db.polls.Count();
            Random rnd = new Random();
            int qn = rnd.Next(1, question_count + 1);

            res = db.polls
                .OrderBy(x => x.id)
                .Skip(qn - 1)
                .Take(1)
                .SingleOrDefault();

            //res = db.polls.SingleOrDefault(x => x.isActive == true);

            res.options = new List<Poll_option>();
            res.options = db.Poll_options
                .Where(x => x.poll_id == res.id)
                .ToList();

            
            return res;
        }

        public IQueryable<poll> getPoll()
        {
            var allPolls = db.polls.Select(x => x); //Creating an anonymous variable with its value beging the instance of Linq object
            return allPolls; //return IQueryable Jobcategory for data bound control to bind
        }

        public poll getPollByID(int _id)
        {
            var Poll = db.polls.SingleOrDefault(x => x.id == _id);
            Poll.options = db.Poll_options.Where(x => x.poll_id == _id).ToList();
            return Poll;
        }

        //creating an instance of Poll table as parameter
        public bool commitInsert(poll Polls)
        {
            //to ensure all data will be disposed of when finished
            using (db)
            {
                db.polls.InsertOnSubmit(Polls);  //using our model to set tabale columns to new values being passed and providing it to the insert command
                db.SubmitChanges(); //commit insert to database
                return true;
            }
        }


        //update
        public bool commitUpdate(int _id,string _title, DateTime date, string _questionText )
        {
            using (db)
            {
                var objUpdatePoll = db.polls.Single(x => x.id == _id);
                objUpdatePoll.title = _title;
                objUpdatePoll.date = _date;
                objUpdatePoll._question_text = _questionText; //setting table columns to new values being passed

                db.SubmitChanges();  //commit update to database
                return true;
            }
        }

        //Delete
        public bool commitDelete(int _id)
        {
            using (db)
            {
                var objDeletePoll = db.polls.Single(x => x.id == _id);
                db.polls.DeleteOnSubmit(objDeletePoll); //delete command
                db.SubmitChanges(); //commit delete against database
                return true;

            }
        }
    }

}