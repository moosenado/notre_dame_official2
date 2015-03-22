using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers
{
    public class ApptSchedController : Controller
    {
        ApptSchedClass objApptSched = new ApptSchedClass(); //created instance

        public ActionResult ApptSched()
        {
            var appt = objApptSched.getAppts();
            return View(appt);
        }

        public ActionResult Details(int id)
        {
            var appt = objApptSched.getApptBookByID(id);
            if (appt == null)
            {
                return View("NotFound");
            }
            else
            {           
                return View(appt); 
            }
        }

            public ActionResult createAppt()
            {
                return View();
            }
        [HttpPost]
        public ActionResult createAppt(Appt_Book appt)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        objApptSched.insertAppt(appt);
                        return RedirectToAction("ApptSched");
                    }
                    catch
                    {
                        return View();
                    }
                }
                return View();
            }
        public ActionResult Update(int id)
            {
                var appt = objApptSched.getApptBookByID(id);
                if (appt == null)
                {
                    return View("NotFound");
                }
                else
                {
                    return View(appt);
                }
            }
        [HttpPost]
        public ActionResult Update(int id, Appt_Book appt)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        objApptSched.updateAppt(id, appt.Fname, appt.Lname, appt.Email, appt.HealthNum, appt.BookDate,
                            appt.BookTime, appt.AdditionalInfo, appt.Tstamp, appt.Speciality, appt.Phone);
                        return RedirectToAction("Details/" + id);
                    }
                    catch
                    {
                        return View();
                    }
                }
                return View();
            }
        public ActionResult Delete(int id)
            {
            var appt = objApptSched.getApptBookByID(id);
            if (appt == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(appt);
            }
                
            }
        [HttpPost]
        public ActionResult Delete(int id, Appt_Book appt)
        {
            try
            {
                objApptSched.apptDelete(id);
                return RedirectToAction("ApptSched");
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
