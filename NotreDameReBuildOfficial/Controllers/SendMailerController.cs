using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail; //namespace required for mail

namespace Mail.Controllers
//namespace NotreDameReBuildOfficial.ViewModels
{
    public class SendMailerController : Controller
    {
        public ActionResult Mail()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Mail(SendMail.Models.MailModel _objModelMail)
        {
            if (ModelState.IsValid) //if no problems then proceed to process email
            {
                MailMessage mail = new MailMessage(); //class for sending email
                mail.To.Add(_objModelMail.To);  
                mail.From = new MailAddress(_objModelMail.From);
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp-mail.outlook.com"; //used outlook.com smtp
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("notredamehospital@outlook.com", "NotreDame1415"); // Username/Password credentials 
                smtp.EnableSsl = true;
                smtp.Send(mail);
                //return View("Mail", _objModelMail);
                return View("Thanks"); //goes to confirmation page after email is sent
            }
            else
            {
                return View();
            }
        }
    }

}
//Source: http://www.c-sharpcorner.com/UploadFile/sourabh_mishra1/sending-an-e-mail-using-Asp-Net-mvc/