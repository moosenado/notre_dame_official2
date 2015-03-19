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
    [MetadataType(typeof(donationValidation))]
    public partial class Donation { }

    public class donationValidation
    {

        [DisplayName("Amount: ")]
        [Required(ErrorMessage = "Please enter an amount")]
        public decimal amount { get; set; }

        [DisplayName("In Memory of: ")]
        public string in_memory { get; set; }

        [DisplayName("Where would you like to direct your donation?: ")]
        [Required(ErrorMessage = "Select one")]
        public int type { get; set; }

        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode=true)]
        public DateTime date { get; set; }

        [DisplayName("First Name: ")]
        [Required(ErrorMessage = "Please enter your first name")]
        public string first_name { get; set; }

        [DisplayName("Last Name: ")]
        [Required(ErrorMessage = "Please enter your last name")]
        public string last_name { get; set; }

        [DisplayName("Organization: ")]
        public string organization { get; set; }

        [DisplayName("Address: ")]
        [Required(ErrorMessage = "Please enter your mailing address")]
        public string address { get; set; }

        [DisplayName("City: ")]
        [Required(ErrorMessage = "Please enter your city")]
        public string city { get; set; }

        [DisplayName("Province: ")]
        public string province { get; set; }

        [DisplayName("Country: ")]
        [Required(ErrorMessage = "Please enter your country")]
        public string country { get; set; }

        [DisplayName("Postal Code: ")]
        [Required(ErrorMessage = "Please enter your postal code")]
        public string postal { get; set; }

        [DisplayName("Phone Number: ")]
        [Required(ErrorMessage = "Please enter your phone number")]
        public string phone { get; set; }

        [DisplayName("Email: ")]
        [Required(ErrorMessage = "Please enter your email")]
        public string email { get; set; }

    }
}