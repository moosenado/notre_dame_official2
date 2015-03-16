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
            //Creating an anonymous variable with its value beging the instance of Linq object
            var allJobCategories = jobCategoryObj.Job_categories.Select(x => x);
            //return IQueryable Jobcategory for data bound control to bind
            return allJobCategories;
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
                //using our model to set tabale columns to new values being passed and providing it to the insert command
                jobCategoryObj.Job_categories.InsertOnSubmit(jobCat);

                //commit insert to database
                jobCategoryObj.SubmitChanges();
                return true;
            }
        }

        public bool commitUpdate(int _id, string _title)
        {
            using(jobCategoryObj)
            {
                var objUpJobCat = jobCategoryObj.Job_categories.Single(x => x.id == _id);
                //setting table columns to new values being passed
                objUpJobCat.title = _title;

                //commit update to database
                jobCategoryObj.SubmitChanges();
                return true;
            }
        }

        public bool coomitDelete(int _id)
        {
            using(jobCategoryObj)
            {
                var objDeleteJobCat = jobCategoryObj.Job_categories.Single(x => x.id == _id);
                //delete command
                jobCategoryObj.Job_categories.DeleteOnSubmit(objDeleteJobCat);
                //commit delete against database
                jobCategoryObj.SubmitChanges();
                return true;

            }
        }
    }
}