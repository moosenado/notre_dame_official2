using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotreDameReBuildOfficial.Models
{
    public class JobApplicants: Applicant

    {
        public string jobTitle { get; set; }
        //creating an instance of Linq object
        ndLinqClassDataContext jobApplicantObj = new ndLinqClassDataContext();

        public IQueryable<Applicant> getApplicants()
        {
            //var allApplicants = jobApplicantObj.Applicants.Select(x => x); //Creating an anonymous variable with its value beging the instance of Linq object
            //return allApplicants; //return IQueryable Applicants for data bound control to bind
            var allApplicants = from ap in jobApplicantObj.Applicants
                                join jp in jobApplicantObj.Job_postings on ap.job_posting_id equals jp.id
                          select new JobApplicants()
                          {
                              id = ap.id,
                              first_name = ap.first_name,
                              last_name = ap.last_name,
                              email = ap.email,
                              phone = ap.phone,
                              city = ap.city,
                              province = ap.province,
                              postal_code = ap.postal_code,
                              jobTitle = jp.title

                          };

            //return IQueryable Aoolicants for data bound control to bind
            return allApplicants;
        
        }


        public Applicant getApplicantByID(int _id)
        {
            var allApplicant = (from ap in jobApplicantObj.Applicants
                                join jp in jobApplicantObj.Job_postings on ap.job_posting_id equals jp.id
                           where ap.id == _id
                                select new JobApplicants()
                           {
                               id = ap.id,
                               first_name = ap.first_name,
                               last_name = ap.last_name,
                               email = ap.email,
                               phone = ap.phone,
                               city = ap.city,
                               province = ap.province,
                               postal_code = ap.postal_code,
                               jobTitle = jp.title,
                               resmue = ap.resmue
                           }).SingleOrDefault();

            //return IQueryable Applicants for data bound control to bind
            return allApplicant;
        }

        //creating an instance of Applicants table as parameter
        public bool commitInsert(Applicant App)
        {
            //to ensure all data will be disposed of when finished
            using (jobApplicantObj)
            {
                jobApplicantObj.Applicants.InsertOnSubmit(App);  //using our model to set tabale columns to new values being passed and providing it to the insert command
                jobApplicantObj.SubmitChanges(); //commit insert to database
                return true;
            }
        }


        //Delete
        public bool commitDelete(int _id)
        {
            using (jobApplicantObj)
            {
                var objDelApplicant = jobApplicantObj.Applicants.Single(x => x.id == _id);
                jobApplicantObj.Applicants.DeleteOnSubmit(objDelApplicant); //delete command
                jobApplicantObj.SubmitChanges(); //commit delete against database
                return true;

            }
        }
    }
}