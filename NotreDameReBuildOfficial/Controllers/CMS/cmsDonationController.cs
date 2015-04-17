using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Imported Namespaces
using NotreDameReBuildOfficial.Models;
using NotreDameReBuildOfficial.Infrastructure;

namespace NotreDameReBuildOfficial.Controllers.CMS
{
    public class cmsDonationController : Controller
    {

        donationClass objDonation = new donationClass();

        //General list of donations
        [CustomAuthorize("Admin", "Staff")]
        public ActionResult Manage()
        {
            var list = objDonation.getDonations();
            return View(list);
        }

        //Details view when admin wants to see the entire donation record
        [CustomAuthorize("Admin", "Staff")]
        public ActionResult Details(int donation_id)
        {
            var donate = objDonation.getDonationByID(donation_id);
            if (donate == null)
            {
                return View("NotFound");
                //same as saying return NotFound();
            }
            else
            {
                return View(donate);
            }
        }

        // --- INSERT ACTION --- //
        [CustomAuthorize("Admin", "Staff")]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Donation donation)
        { 

            if (ModelState.IsValid)
            {
                try
                {
                    //if the form is submitted and the date is null, get the date as its value
                    if (donation.date == null)
                    {
                        donation.date = DateTime.Now;
                    }

                    objDonation.insertDonation(donation);
                    return RedirectToAction("Manage"); //On sucessful insert, return to Donate page
                }
                catch
                {
                    //Error handling, return to Donation view if something goes wrong
                    return View();
                }
            }

            return View();
        }

        // --- UPDATE ACTION --- //
        //Reads the request to update
        [CustomAuthorize("Admin", "Staff")]
        public ActionResult Update(int donation_id)
        {
            var donate = objDonation.getDonationByID(donation_id);
            if (donate == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(donate);
            }
        }

        //Executes the update when submit button is clicked
        [HttpPost]
        public ActionResult Update(int donation_id, Donation donation)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    objDonation.updateDonation(donation_id, donation);
                    return RedirectToAction("Details", new { donation_id = donation_id }); //After successful update, return to index
                }
                catch
                {
                    //Error handling, return Update view if something goes wrong
                    return View(donation);
                }
           }

            return View(donation);
        }

        // --- DELETE ACTION --- //
        //Reads the request to delete
        [CustomAuthorize("Admin", "Staff")]
        public ActionResult Delete(int donation_id)
        {
            var donate = objDonation.getDonationByID(donation_id);
            //if trail record can't be found, return Not Found page
            if (donate == null)
            {
                return View("NotFound"); 
            }
            else
            {
                return View(donate);
            }
        }

        //Executes the delete when yes (submit) button is clicked
        [HttpPost]
        public ActionResult Delete(int donation_id, Donation donation)
        {
            try
            {
                objDonation.deleteDonation(donation_id);
                return RedirectToAction("Manage"); //On successful delete, return to donation list page
            }
            catch
            {
                return View();
            }
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}
