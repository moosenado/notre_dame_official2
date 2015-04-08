using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO; //for uploading file path

//Imported Namespaces
using NotreDameReBuildOfficial.Models;


namespace NotreDameReBuildOfficial.Controllers.CMS
{
    public class CMSPollController : Controller
    {
        //
        // GET: /CMSPoll/

        public ActionResult Index()
        {
            return View();
        }

        // creating an instance of poll class
        poll objPoll = new poll(); 

        //Get all pollQuestions
        public ActionResult polls()
        {
            var poll = objPoll.getPoll();
            return View(poll);
        }

        //Get Job by id
        public ActionResult Poll_Details(int id)
        {
            var poll = objPoll.getPollByID(id);
            if (poll == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(poll);
            }
        }

        //Insert new  pollQuestion
        public ActionResult Insert_poll()
        {
            return View();
        }
        [HttpPost]// restirict an action method by only post requests 
        public ActionResult Insert_poll(poll polls)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    objPoll.commitInsert(polls); // if the state of the model is  valid the commitInsert function will be called and new value will be commited to database.
                    return RedirectToAction("polls"); //after inserting values in database, page will redirect to the index page and show all data
                }
                catch
                {
                    return View(polls);
                }
            }
            return View(polls);
        }

        public ActionResult Update_poll(int id)
        {
            
            var poll = objPoll.getPollByID(id);
            if (poll == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(poll);
            }

        }

        [HttpPost]// restirict an action method by only post requests
        public ActionResult Update_poll(int id, poll polls)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // get the new values and passed them to fields by these parameter
                    objPoll.commitUpdate(id, polls.title, polls.date, polls.question_text);
                    return RedirectToAction("Poll_Details/" + id);// the page will redirect to the Job posting details
                }
                catch
                {
                    return View(polls);
                }
            }
            return View(polls);
        }

        public ActionResult Delete_poll(int id)
        {
            var poll = objPoll.getPollByID(id);
            if (poll == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(poll);
            }
        }

        [HttpPost] // restirict an action method by only post requests
        public ActionResult Delete_poll(int id, poll polls)
        {
            try
            {
                objPoll.commitDelete(id);
                return RedirectToAction("polls");
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
