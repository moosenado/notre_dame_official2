﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotreDameReBuildOfficial.Models
{
    public class volunteerInfo
    {
        ndLinqClassDataContext objLinq = new ndLinqClassDataContext();

        public IQueryable<volunteer_info>getVolunteers()
        {
            var allVol = objLinq.volunteer_infos.Select(x => x);
            return allVol;
        }

        public IQueryable<volunteer_info> getVolByID(int id)
        {
            var allvol = (from x in objLinq.volunteer_infos
                                   where x.jobID == id
                                   select x);
            return allvol;
        }

        public volunteer_info getVolInfoByID(int _id)
        {
            var selectVol = objLinq.volunteer_infos.SingleOrDefault(x => x.id == _id);
            return selectVol;
        }


        public volunteerJob getJobByID(int _id)
        {
            var selectJob = objLinq.volunteerJobs.SingleOrDefault(x => x.id == _id);
            return selectJob;
        }


        public bool InsertVol(volunteer_info vol)
        {
            using(objLinq)
            {
                objLinq.volunteer_infos.InsertOnSubmit(vol);
                objLinq.SubmitChanges();
                return true;
            }
        }

/*        public bool InsertVol(int _id, string _firstname, string _lastname, string gender, string _email, string _mobile, string _street, string _city, string _province, string _zip_code, string _jobID, DateTime _dateApplied)
        {
            using(objLinq)
            {
                var upVol = objLinq.volunteer_infos.Single(x => x.JobID = _jobID);

                _date = DateTime.Now;

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
        */
        public string jobID { get; set; } // get set method for Role
    }

}