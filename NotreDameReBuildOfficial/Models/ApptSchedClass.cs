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

        public IQueryable<Appt_Book> getAppts() //query to get all appointment info from db
        {
            var allAppts = objApptSched.Appt_Books.Select(x => x); //select everything from Appt_book table
            return allAppts; //store result set in AllAppts
        }
        public Appt_Book getApptBookByID(int _id) //get specific appointment by id
        {
            var allAppt = objApptSched.Appt_Books.SingleOrDefault(x => x.id == _id); //gets all appts by id and stores it in allAppt variable
            return allAppt; //returns the result set and allows it to be displayed
        }

        public bool insertAppt(Appt_Book appt) //created instance of appt_book table 
        {
            using (objApptSched) //using makes sure data disposed after its used
            {
                objApptSched.Appt_Books.InsertOnSubmit(appt); //inserts input into db
                objApptSched.SubmitChanges(); //saves changes to db
                return true;
                
            }
        }
        //updates appointment based on parameters 
        public bool updateAppt(int _id, string _Fname, string _Lname, string _Email, string _HealthNum, DateTime _BookDate, DateTime _BookTime, string _AdditionalInfo, string _Speciality, string _Phone, DateTime _Tstamp)
        {
            using (objApptSched)
            {
                var apptUpd = objApptSched.Appt_Books.Single(x => x.id == _id); //takes single appointment
                //passing new values into each table column
                apptUpd.Fname = _Fname;
                apptUpd.Lname = _Lname;
                apptUpd.Email = _Email;
                apptUpd.HealthNum = _HealthNum;
                apptUpd.BookDate = _BookDate;
                apptUpd.BookTime = _BookTime;
                apptUpd.AdditionalInfo = _AdditionalInfo;
                apptUpd.Tstamp = _Tstamp;
                apptUpd.Speciality = _Speciality;
                apptUpd.Phone = _Phone;
                objApptSched.SubmitChanges(); //saves changes to db
                return true;
            }
        }
        public bool apptDelete(int _id)
        {
            using (objApptSched)
            {
                var apptDel = objApptSched.Appt_Books.Single(x => x.id == _id);
                objApptSched.Appt_Books.DeleteOnSubmit(apptDel);
                objApptSched.SubmitChanges();
                return true;
            }
        }

    }
}