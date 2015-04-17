using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace Mail.Controllers
//namespace NotreDameReBuildOfficial.ViewModels
{
    public class SendMailerController : Controller
    {
        //
        // GET: /SendMailer/

        public ActionResult Mail()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Mail(SendMail.Models.MailModel _objModelMail)
        {
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.To);
                mail.From = new MailAddress(_objModelMail.From);
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                    ("notredamehospital@outlook.com", "NotreDame1415"); // Enter seders User name and password  
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return View("Mail", _objModelMail);
            }
            else
            {
                return View();
            }
        }
    }
}
