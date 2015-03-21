using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotreDameReBuildOfficial.Models
{
    public class ApptSchedClass
    {
        //create instance of ndLinqClass object
        ndLinqClassDataContext objApptSched = new ndLinqClassDataContext();

        public IQueryable<Appt_Book> getAppts()
        {
            var allAppts = objApptSched.Appt_Books.Select(x => x);
            return allAppts;
        }
        public Appt_Book getApptBookByID(int _id)
        {
            var allAppt = objApptSched.Appt_Books.SingleOrDefault(x => x.id == _id);
            return allAppt;
        }

        public bool insertAppt(Appt_Book appt)
        {
            using (objApptSched)
            {
                objApptSched.Appt_Books.InsertAllOnSubmit(appt);
                objApptSched.SubmitChanges();
                return true;
            }
        }

        public bool updateAppt(int _id, string _First_Name, string _Last_Name, string _Email, string _Health_Num, //////)

    }
}