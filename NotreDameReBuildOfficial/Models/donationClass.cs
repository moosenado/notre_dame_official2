﻿using System;
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

        //Get donation by its record number
        public Donation getDonationByID(int _donation_id)
        {
            //Anonymous variable getAllDonations will get donations where id of object equals the id in database 
            var getAllDonations = objLinq.Donations.SingleOrDefault(x => x.donation_id == _donation_id);
            return getAllDonations;
        }

        // --- INSERT LOGIC --- //
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

        // --- UPDATE LOGIC --- //
        public bool updateDonation(int _id, Donation donation)
        {
            using (objLinq)
            {
                var objUpdate = objLinq.Donations.Single(x => x.donation_id == donation.donation_id);
                objUpdate.in_memory = donation.in_memory;
                objUpdate.type = donation.type;
                objUpdate.first_name = donation.first_name;
                objUpdate.last_name = donation.last_name;
                objUpdate.organization = donation.organization;
                objUpdate.address = donation.address;
                objUpdate.city = donation.city;
                objUpdate.province = donation.province;
                objUpdate.country = donation.country;
                objUpdate.postal = donation.postal;
                objUpdate.phone = donation.phone;
                objUpdate.email = donation.email;
                objLinq.SubmitChanges();
                return true;
            }
        }

        // --- DELETE LOGIC --- //
        public bool deleteDonation(int _donation_id)
        {
            using (objLinq)
            {
                var objDelDonation = objLinq.Donations.Single(x => x.donation_id == _donation_id); //Delete table row where id of object equals id in database
                objLinq.Donations.DeleteOnSubmit(objDelDonation);
                objLinq.SubmitChanges();
                return true;
            }
        }
    }
}