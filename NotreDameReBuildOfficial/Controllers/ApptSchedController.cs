using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using NotreDameReBuildOfficial.Infrastructure;

using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.Controllers
{
    public class ApptSchedController : Controller
    {
        ApptSchedClass objApptSched = new ApptSchedClass(); //created instance

        [CustomAuthorize("Admin", "Staff")]
        public ActionResult ApptSched() //method gets all apointments using model and displays it on ApptSched view  
        {
            var appt = objApptSched.getAppts(); //calls method getAppts from model
            return View(appt);
        }

        [CustomAuthorize("Admin", "Staff")]
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
        //Pass values to Mail form
        //public ActionResult Mail(int id)
        //{
        //    var appt = objApptSched.getApptBookByID(id); //calls method getApptBookByID basied on specific id
        //    if (appt == null) //if nto appts found return page notFound
        //    {
        //        return View("NotFound");
        //    }
        //    else
        //    {
        //        return View(appt);
        //    }
        //}

        //********Mail form END********//
            
            [CustomAuthorize("Admin", "Staff")]
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

        [CustomAuthorize("Admin", "Staff")]
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

        [CustomAuthorize("Admin", "Staff")]
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

        public ActionResult Mail()
        {
            return PartialView();
        }
        }

}
//namespace Mail.Controllers
////namespace NotreDameReBuildOfficial.ViewModels
//{
//    public class SendMailerController : Controller
//    {
//        //
//        // GET: /SendMailer/

//        public ActionResult Mail()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ViewResult Mail(SendMail.Models.MailModel _objModelMail)
//        {
//            if (ModelState.IsValid)
//            {
//                MailMessage mail = new MailMessage();
//                mail.To.Add(_objModelMail.To);
//                mail.From = new MailAddress(_objModelMail.From);
//                mail.Subject = _objModelMail.Subject;
//                string Body = _objModelMail.Body;
//                mail.Body = Body;
//                mail.IsBodyHtml = true;
//                SmtpClient smtp = new SmtpClient();
//                smtp.Host = "smtp-mail.outlook.com";
//                smtp.Port = 587;
//                smtp.UseDefaultCredentials = false;
//                smtp.Credentials = new System.Net.NetworkCredential
//                    ("notredamehospital@outlook.com", "NotreDame1415"); // Enter seders User name and password  
//                smtp.EnableSsl = true;
//                smtp.Send(mail);
//                return View("Mail", _objModelMail);
//            }
//            else
//            {
//                return View();
//            }
//        }
//    }
//}
