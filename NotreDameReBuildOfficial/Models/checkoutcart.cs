using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace NotreDameReBuildOfficial.Models
{
    public class checkoutcart
    {

        public string name { get; set; }

        public int id { get; set; }
        public int prod_quantity { get; set; }
        public string sesssion_id { get; set; }

        public decimal price { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public string message { get; set; }

        public string session_id { get; set; }

        public string cardname { get; set; }

        public string cardtype { get; set; }

        public string cardnumber { get; set; }

        public string expirydate { get; set; }

        public string securitycode { get; set; }

        public string deliv_status { get; set; }

        public string patientname { get; set; }

        public string orderdate { get; set; }

        public string totalpaid { get; set; }

    }
}