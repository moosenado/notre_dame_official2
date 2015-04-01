using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Imported Namespaces
using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers
{
    public class EventsLisingController : Controller
    {

        donationClass objEvents = new donationClass();

        public ActionResult Events()
        {
            return View();
        }


    }
}
