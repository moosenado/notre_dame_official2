using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Imported Namespaces
using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers
{
    public class DonationController : Controller
    {

        donationClass objDonation = new donationClass();

        //Donation Form Page Method
        public ActionResult Donate()
        {
            return View();
        }

        //Inserts donation into db
        [HttpPost]
        public ActionResult Donate(Donation donation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    objDonation.insertDonation(donation);
                    return RedirectToAction("Index"); //On sucessful insert, return to Donate page
                }
                catch
                {
                    //Error handling, return to Donation view if something goes wrong
                    return View();
                }
            }

            return View();
        }

    }
}
