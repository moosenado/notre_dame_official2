using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotreDameReBuildOfficial.Models;
using SendMail.Models;

namespace NotreDameReBuildOfficial.ViewModels
{
    public class MailApptModel
    {
        //public Appt_Book ApptBooks { get; set; }
        public MailModel MailModels { get; set; }
        public List<Appt_Book> ApptBooks { get; set; }
    }
}


  
