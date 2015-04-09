using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotreDameReBuildOfficial.Models
{
    public class volunteerJobs
    {
        ndLinqClassDataContext objLinq = new ndLinqClassDataContext();

        public IQueryable<volunteerJob>getJobs()
        {
            var allJobs = objLinq.volunteerJobs.Select(x => x);
            return allJobs;
        }

        public volunteerJob getJobByID(int _id)
        {
            var selectJob = objLinq.volunteerJobs.SingleOrDefault(x => x.id == _id);
            return selectJob;
        }

        public bool InsertJob(volunteerJob job)
        {
            using(objLinq)
            {
                objLinq.volunteerJobs.InsertOnSubmit(job);
                objLinq.SubmitChanges();
                return true;
            }
        }

        public bool updateJob(int _id, string _jobTitle, string _jobDescription, string _street, string _city, string _province, string _zip, DateTime _date, DateTime _startDate, DateTime _endDate)
        {
            using(objLinq)
            {
                var upJob = objLinq.volunteerJobs.Single(x => x.id == _id);

                upJob.jobTitle = _jobTitle;
                upJob.jobDescription = _jobDescription;
                upJob.street = _street;
                upJob.city = _city;
                upJob.province = _province;
                upJob.zip_code = _zip;
                upJob.date = _date;
                upJob.dateStart = _startDate;
                upJob.dateEnd = _endDate;
                objLinq.SubmitChanges();
                return true;
            }
        }

        public bool deleteJob(int _id)
        {
            using(objLinq)
            {
                var delJob = objLinq.volunteerJobs.Single(x => x.id == _id);

                objLinq.volunteerJobs.DeleteOnSubmit(delJob);
                objLinq.SubmitChanges();
                return true;
            }
        }
    }
}