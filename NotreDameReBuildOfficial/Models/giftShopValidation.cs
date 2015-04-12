using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Imported namespaces
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace NotreDameReBuildOfficial.Models
{
    [MetadataType(typeof(giftShopValidation))]
    public partial class checkout { }
    public class giftShopValidation
    {

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Please enter your first name")]
        public string firstname { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Please enter your last name")]
        public string lastname { get; set; }

        [DisplayName("Patient Delivery or Customer Pickup")]
        [Required(ErrorMessage = "Please select delivery or pickup")]
        public string deliv_status { get; set; }

        [DisplayName("Patient Name (for delivery)")]
        public string patientname { get; set; }

        [DisplayName("Message to Patient (for delivery)")]
        public string message { get; set; }

        [DisplayName("Credit Card")]
        [Required(ErrorMessage = "Please select your credit card")]
        public string cardtype { get; set; }

        [DisplayName("Credit Card Number")]
        [Required(ErrorMessage = "Please enter your credit card number")]
        public string cardnumber { get; set; }

        [DisplayName("Name On Card")]
        [Required(ErrorMessage = "Please enter the name on the chosen card")]
        public string cardname { get; set; }

        [DisplayName("Expiry Date")]
        [Required(ErrorMessage = "Please enter the cards expiry date")]
        public string expirydate { get; set; }

        [DisplayName("Security Code")]
        [Required(ErrorMessage = "Please enter the cards security code")]
        public string securitycode { get; set; }


    }
}