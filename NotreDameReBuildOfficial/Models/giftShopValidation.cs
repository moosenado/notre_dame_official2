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
        [RegularExpression(@"\d{16}", ErrorMessage = "Invalid Number")]
        public string cardnumber { get; set; }

        [DisplayName("Name On Card")]
        [Required(ErrorMessage = "Please enter the name on the chosen card")]
        public string cardname { get; set; }

        [DisplayName("Expiry Date")]
        [Required(ErrorMessage = "Please enter the cards expiry date")]
        [RegularExpression(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$", ErrorMessage = "Invalid Format (dd/mm/yyyy)")]
        public string expirydate { get; set; }

        [DisplayName("Security Code")]
        [Required(ErrorMessage = "Please enter the cards security code")]
        [RegularExpression(@"\d{3}", ErrorMessage = "Invalid Security Code")]
        public string securitycode { get; set; }


    }
}