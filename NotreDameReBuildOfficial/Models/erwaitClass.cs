using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;

namespace NotreDameReBuildOfficial.Models
{
    public class erwaitClass
    {
        //get/set form_command
        public string form_command { get; set; }
        //get/set remove_command
        public string remove_command { get; set; }
        //get/set wait_patient_id
        public string wait_patient_id { get; set; }
        //get/set current time
        public string current_time { get; set; }

        //instance of Data Context
        ndLinqClassDataContext objER = new ndLinqClassDataContext(); 

        //get all patient info
        public IQueryable<ER_wait_list> getWaitingPatientInfo() 
        {
            var waitingPatients = objER.ER_wait_lists.Select(x => x); 
            return waitingPatients;
        }

        //get specific patient info by ID
        public ER_patient_info getPatientsByID(int _id)
        {
            var all_patients_id = objER.ER_patient_infos.SingleOrDefault(x => x.Id == _id);
            return all_patients_id;
        }

        //insert into patient info table
        public bool insertPatient(ER_patient_info patientinfo) 
        {
            using (objER) 
            {
                objER.ER_patient_infos.InsertOnSubmit(patientinfo);
                objER.SubmitChanges();
                return true;
            }
        }
        //get how many patients are in the waiting room
        public int getWaitListStatus()
        {
            var waitListStatus = objER.ER_wait_lists.Select(x => x).Count(); 
            return waitListStatus;
        }
        public int getWaitTimeStatus()
        {
            var waitTimeStatus = objER.ER_wait_times.Select(x => x).Count();
            return waitTimeStatus;
        }
        public int averageCalc()
        {
            var average = 1;
            //add all values in timespan and divide by row count
            return average;
        }

    }
}