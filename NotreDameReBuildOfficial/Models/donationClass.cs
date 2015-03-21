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
        public bool updateDonation(int _donation_id, decimal? _amount, string _in_memory, int? _type, string _first_name, string _last_name, string _organization, string _address, string _city, string _province, string _country, string _postal, string _phone, string _email)
        {
            using (objLinq)
            {
                var objUpDelete = objLinq.Donations.Single(x => x.donation_id == _donation_id);
                objUpDelete.donation_id = _donation_id;
                objUpDelete.amount = _amount;
                objUpDelete.in_memory = _in_memory;
                objUpDelete.type = _type;
                objUpDelete.first_name = _first_name;
                objUpDelete.last_name = _last_name;
                objUpDelete.address = _address;
                objUpDelete.city = _city;
                objUpDelete.city = _province;
                objUpDelete.city = _country;
                objUpDelete.city = _postal;
                objUpDelete.city = _phone;
                objUpDelete.city = _email;
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