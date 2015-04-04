using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotreDameReBuildOfficial.Models
{
    public class rollClass
    {
        //creating an instance of Linq object
        ndLinqClassDataContext objRoll = new ndLinqClassDataContext();

        public IQueryable<role> getRolls()
        {
            var allRole = objRoll.roles.Select(x => x); //Creating an anonymous variable with its value beging the instance of Linq object
            return allRole; //return IQueryable Jobcategory for data bound control to bind
        }

        public role getRollByID(int _id)
        {
            var allRoll = objRoll.roles.SingleOrDefault(x => x.id == _id);
            return allRoll;
        }

        //creating an instance of roll table as parameter
        public bool commitInsert(role rolls)
        {
            //to ensure all data will be disposed of when finished
            using (objRoll)
            {
                objRoll.roles.InsertOnSubmit(rolls);  //using our model to set tabale columns to new values being passed and providing it to the insert command
                objRoll.SubmitChanges(); //commit insert to database
                return true;
            }
        }

        //update
        public bool commitUpdate(int _id, string _title)
        {
            using (objRoll)
            {
                var objUpdateRoll = objRoll.roles.Single(x => x.id == _id);
                objUpdateRoll.title = _title; //setting table columns to new values being passed

                objRoll.SubmitChanges();  //commit update to database
                return true;
            }
        }

        //Delete
        public bool commitDelete(int _id)
        {
            using (objRoll)
            {
                var objDeleteRole = objRoll.roles.Single(x => x.id == _id);
                objRoll.roles.DeleteOnSubmit(objDeleteRole); //delete command
                objRoll.SubmitChanges(); //commit delete against database
                return true;

            }
        }
    }
}