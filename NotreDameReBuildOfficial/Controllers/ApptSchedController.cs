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

        public ActionResult ApptSched() //method gets all apointments using model and displays it on ApptSched view  
        {
            var appt = objApptSched.getAppts(); //calls method getAppts from model
            return View(appt);
        }

        public ActionResult Details(int id)
        {
            var appt = objApptSched.getApptBookByID(id); //calls method getApptBookByID basied on specific id
            if (appt == null) //if nto appts found return page notFound
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
           
            if (ModelState.IsValid) //if no erros
            {
                

                    try //runs these methods(located in model class) and then return to the main view
                    {
                        appt.Tstamp = DateTime.Now; //automatically inserts datetime when form submitted 
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
        public ActionResult Update(int id) //update method
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
        [HttpPost] //post updated user input to server
        public ActionResult Update(int id, Appt_Book appt)
            {
                if (ModelState.IsValid)
                { 
                    
                    try
                    {
                        
                        appt.Tstamp = DateTime.Now; //auto insert date
                        objApptSched.updateAppt(id, appt.Fname, appt.Lname, appt.Email, appt.HealthNum, appt.BookDate,
                            appt.BookTime, appt.AdditionalInfo, appt.Speciality, appt.Phone, appt.Tstamp); 
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
