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
        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult _UnapprovedPartial()
        {
            //Unapproved feedback
            var unapproved = objFeedback.getFeedbackByStatus(0);

            return PartialView(unapproved);

        }

        public ActionResult _ApprovedPartial()
        {
            //Approved feedback
            var approved = objFeedback.getFeedbackByStatus(1);

            return PartialView(approved);

        }

        //When admin wants to see the feedback details
        public ActionResult Details(int feedback_id)
        {
            var feedback = objFeedback.getFeedbackByID(feedback_id);

            if (feedback == null)
            {
                return View("NotFound");

            }
            else
            {
                return View(feedback);
            }
        }

        // --- UPDATE ACTION --- //
        //Reads the request to update
        public ActionResult Update(int feedback_id)
        {
            var feedback = objFeedback.getFeedbackByID(feedback_id);
            if (feedback == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(feedback);
            }
        }

        //Executes the update when submit button is clicked
        [HttpPost]
        public ActionResult Update(Feedback feedback)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    objFeedback.updateFeedback(feedback);
                    return RedirectToAction("Manage", new { feedback_id = feedback.feedback_id }); //After successful update, return to main feedback management page
                }
                catch
                {
                    //Error handling, return Update view if something goes wrong
                    return View();
                }
            }

            return View();
        }

        // --- DELETE ACTION --- //
        //Reads the request to delete
        public ActionResult Delete(int feedback_id)
        {
            var feedback = objFeedback.getFeedbackByID(feedback_id);
            //if record can't be found, return Not Found page
            if (feedback == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(feedback);
            }
        }

        //Executes the delete when yes (submit) button is clicked
        [HttpPost]
        public ActionResult Delete(int feedback_id, Feedback feedback)
        {
            try
            {
                objFeedback.deleteFeedback(feedback_id);
                return RedirectToAction("Manage"); //On successful delete, return to main feedback management page
            }
            catch
            {
                return View();
            }
        }

        //Error handling page
        public ActionResult NotFound()
        {
            return View();
        }
    }
}
