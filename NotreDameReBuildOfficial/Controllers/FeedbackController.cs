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

        //Inserts feedback into db
        [HttpPost]
        public ActionResult Feedback(Feedback feedback)
        {
            //if the form is submitted and the date is null, get the date as its value
            if (feedback.date == null)
            {
                feedback.date = DateTime.Now;
            }

            //if approval is submitted as null, value is 0
            if (feedback.approved == null)
            {
                feedback.approved = 0;
            }

            if (ModelState.IsValid)
            {
                try
                {

                    objFeedback.insertFeedback(feedback);
                    return RedirectToAction("Thanks"); //On sucessful insert, show thank you page
                }
                catch
                {

                    //Error handling, return to feedback view if something goes wrong
                    return View();

                }
            }

            return View();

        }

        public ActionResult Thanks()
        {
            if (ModelState.IsValid)
            {
                return View("Feedback");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Thanks(feedbackValidation valid)//passes form
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", valid);
            }
            else
            {
                return View();
            }
        }
    }
}
