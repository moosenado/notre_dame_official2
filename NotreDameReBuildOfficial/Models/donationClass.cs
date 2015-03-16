using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotreDameReBuildOfficial.Models
{
    public class donationClass
    {
        //Creating an object of the linq database class
        ndLinqClassDataContext objLinq = new ndLinqClassDataContext();

        //Executes SELECT query against the db, gets all donations and puts them in a list
        public IQueryable<Donation> getDonations()
        {
            var allDonations = objLinq.Donations.Select(x => x);
            return allDonations;
        }

        public Donation getDonationByID(int _donation_id)
        {
            //Anonymous variable getAllDonations will get donations where id of object equals the id in database 
            var getAllDonations = objLinq.Donations.SingleOrDefault(x => x.donation_id == _donation_id);
            return getAllDonations;
        }

        //Insert Logic
        public bool insertDonation(Donation donation)
        {
            //Ensures all data will be disposed of when finished
            using (objLinq)
            {
                objLinq.Donations.InsertOnSubmit(donation);
                objLinq.SubmitChanges();
                return true;
            }
        }

    }
}