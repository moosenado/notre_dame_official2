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
        //get number of rows in the wait time table
        public int getWaitTimeStatus()
        {
            var waitTimeStatus = objER.ER_wait_times.Select(x => x).Count();
            return waitTimeStatus;
        }
        //calculate average wait time
        public int averageCalc()
        {
            var wait_time_count = objER.ER_wait_times.Select(x => x).Count();

            int sum = 0;
            foreach (var timeNum in objER.ER_wait_times.Select(x => x))
            {
                sum = sum + timeNum.waittime;
            }

            var new_wait_time = sum / wait_time_count;

            TimeSpan minute_time = TimeSpan.FromSeconds(new_wait_time);

            return minute_time.Minutes;
        }

        public string getWaitTime()
        {
            var averageUpdate = "";

            //check how many rows (patients) exist in the wait list table
            var waitlist_status = getWaitListStatus();

            //if  0 patients are in the room, delete all rows in wait time table
            if (waitlist_status == 0)
            {
                using (ndLinqClassDataContext objDeleteWaitTime = new ndLinqClassDataContext())
                {
                    var delete_wait_time = objDeleteWaitTime.ER_wait_times.Select(x => x);
                    objDeleteWaitTime.ER_wait_times.DeleteAllOnSubmit(delete_wait_time);
                    objDeleteWaitTime.SubmitChanges();
                }

                averageUpdate = "0 people currently waiting";
            }
            //if 1 patient is in the room, automatically add a value of 15 minutes to the average wait
            else if (waitlist_status == 1)
            {
                averageUpdate = "15 Minutes";
            }
            //if more than 1 patient is in the room, calculate the actual average wait time
            else
            {
                //get count of wait time table - if wait time count is greater than equal to 2, then do average calculation - if not, give an approximate wait of 30 minutes
                var waittime_status = getWaitTimeStatus();

                if (waittime_status >= 2)
                {
                    //calculate average wait time and convert to string
                    var new_wait_time = averageCalc();
                    string time_string = new_wait_time.ToString();
                    averageUpdate = time_string + " Minutes";
                }
                else
                {
                    averageUpdate = "30 Minutes";
                }
            }

            return averageUpdate;
        }

    }

}