using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotreDameReBuildOfficial.Models
{
    public class jobPosting
    {
        //creating an instance of Linq object
        ndLinqClassDataContext jobObj = new ndLinqClassDataContext();

        public IQueryable<Job_posting> getJobs()
        {
            //Creating an anonymous variable with its value beging the instance of Linq object
            var allJobs = jobObj.Job_postings.Select(x => x);
            //return IQueryable Jobposting for data bound control to bind
            return allJobs;
        }

        public Job_posting getJobByID(int _id)
        {
            var allJob = jobObj.Job_postings.SingleOrDefault(x => x.id == _id);
            return allJob;
        }

        //creating an instance of job_posting table as parameter
        public bool commitInsert(Job_posting jobPo)
        {
            //to ensure all data will be disposed of when finished
            using (jobObj)
            {

                jobObj.Job_postings.InsertOnSubmit(jobPo); //using our model to set tabale columns to new values being passed and providing it to the insert command
                jobObj.SubmitChanges();//commit insert to database
                return true;
            }
        }

        public bool commitUpdate(int _id, string _title, string _type, string _department, string _description, decimal _salary, DateTime _date, int _category_id)
        {
            using (jobObj)
            {
                var objUpdateJob = jobObj.Job_postings.Single(x => x.id == _id);
                //setting table columns to new values being passed
                objUpdateJob.title = _title;
                objUpdateJob.type = _type;
                objUpdateJob.department = _department;
                objUpdateJob.description = _description;
                objUpdateJob.salary = _salary;
                objUpdateJob.posting_date = _date;
                objUpdateJob.category_id = _category_id;
              
                jobObj.SubmitChanges(); //commit update to database
                return true;
            }
        }

        public bool commitDelete(int _id)
        {
            using (jobObj)
            {
                var objDeleteJob = jobObj.Job_postings.Single(x => x.id == _id);
                jobObj.Job_postings.DeleteOnSubmit(objDeleteJob);  //delete command
                jobObj.SubmitChanges(); //commit delete against database
                return true;

            }
        }
    }
}