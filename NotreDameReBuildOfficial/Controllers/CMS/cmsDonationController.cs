﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Imported Namespaces
using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers.CMS
{
    public class cmsDonationController : Controller
    {

        donationClass objDonation = new donationClass();

        //Donation Form Page Method
        public ActionResult cmsDonationList()
        {
            var list = objDonation.getDonations();
            return View(list);
        }

        //Inserts donation into db
        //[HttpPost]
        //public ActionResult cmsDonationList(Donation donation)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            //if the form is submitted and the date is null, get the date as its value
        //            var date = donation.date;
        //            if (date == null)
        //            {
        //                date = DateTime.Now;
        //            } 
                    
        //            objDonation.insertDonation(donation);
        //            return RedirectToAction("Donate"); //On sucessful insert, return to Donate page
        //        }
        //        catch
        //        {
        //            //Error handling, return to Donation view if something goes wrong
        //            return View();
        //        }
        //    }

        //    return View();
        //}

    }
}
