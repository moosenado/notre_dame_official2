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
                    //if the form is submitted and the date is null, get the date as its value
                    if (donation.date == null)
                    {
                        donation.date = DateTime.Now;
                    }

                    //these strings make up the url to redirect to PayPal
                    string url = "https://www.sandbox.paypal.com/cgi-bin/webscr";
                    string cmd = "?cmd=";
                    string value = "_donations";
                    string business = "&business=admin@notredame.ca";
                    string itm = "&item_name=Donation";
                    string currency = "&currency_code=CAD";
                    string amt = "&amount=" + donation.amount.Value.ToString();

                    string path = url + cmd + value + business + itm + currency + amt;

                    objDonation.insertDonation(donation);
                    return Redirect(path); //On sucessful insert, return to PayPal page
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

