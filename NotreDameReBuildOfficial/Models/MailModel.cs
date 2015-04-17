using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NotreDameReBuildOfficial.Models;

namespace SendMail.Models
    //namespace NotreDameReBuildOfficial.ViewModels
//namespace NotreDameReBuildOfficial.Models
{
    public class MailModel //validation for email
    {
        [Required(ErrorMessage = "Sender Email Required")]
        public string From { get; set; }

        [Required(ErrorMessage = "Receiver Email Required")]
        public string To { get; set; }

        [Required(ErrorMessage = "Please enter a subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please enter body content")]
        public string Body { get; set; }
        
        //public List<Appt_Book> ApptBooks { get; set; }
    }
}