using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotreDameReBuildOfficial.Models
{
    public class jobCategory
    {
        //creating an instance of Linq object
        ndLinqClassDataContext jobCategoryObj= new ndLinqClassDataContext();

        public IQueryable<Job_category> getJobCategory()
        {
            var allJobCategories = jobCategoryObj.Job_categories.Select(x => x); //Creating an anonymous variable with its value beging the instance of Linq object
            return allJobCategories; //return IQueryable Jobcategory for data bound control to bind
        }

        public Job_category getJobCategoryByID(int _id)
        {
            var allJobCategory = jobCategoryObj.Job_categories.SingleOrDefault(x => x.id == _id);
            return allJobCategory;
        }

        //creating an instance of job_category table as parameter
        public bool commitInsert(Job_category jobCat)
        {
            //to ensure all data will be disposed of when finished
            using(jobCategoryObj)
            {
                jobCategoryObj.Job_categories.InsertOnSubmit(jobCat);  //using our model to set tabale columns to new values being passed and providing it to the insert command
                jobCategoryObj.SubmitChanges(); //commit insert to database
                return true;
            }
        }

        //update
        public bool commitUpdate(int _id, string _title)
        {
            using(jobCategoryObj)
            {
                var objUpJobCat = jobCategoryObj.Job_categories.Single(x => x.id == _id);
                objUpJobCat.title = _title; //setting table columns to new values being passed

                jobCategoryObj.SubmitChanges();  //commit update to database
                return true;
            }
        }

        //Delete
        public bool commitDelete(int _id)
        {
            using(jobCategoryObj)
            {
                var objDeleteJobCat = jobCategoryObj.Job_categories.Single(x => x.id == _id);
                jobCategoryObj.Job_categories.DeleteOnSubmit(objDeleteJobCat); //delete command
                jobCategoryObj.SubmitChanges(); //commit delete against database
                return true;

            }
        }
    }
}