using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Imported Namespaces
using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers.CMS
{
    public class cmsFeedbackController : Controller
    {
        feedbackClass objFeedback = new feedbackClass();

        //Feedback Form Page Method
        public ActionResult Feedback()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
