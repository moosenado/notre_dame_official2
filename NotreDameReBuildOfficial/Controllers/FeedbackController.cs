using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Imported Namespaces
using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers
{
    public class FeedbackController : Controller
    {

        feedbackClass objFeedback = new feedbackClass();

        //Feedback Form Page Method
        public ActionResult Feedback()
        {
            return View();
        }

  

    }
}
