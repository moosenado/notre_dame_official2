using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;


namespace NotreDameReBuildOfficial.Models
{
    [MetadataType(typeof(ApplicantValidation))]

    public partial class Applicants
    {
    }
    [Bind(Exclude = "id")]
    public partial class ApplicantValidation
    {
        [DisplayName("First Name:")]
        [Required(ErrorMessage = "Please Enter your First Name")]
        public string fisrt_name { get; set; }

        [DisplayName("Last Name:")]
        [Required(ErrorMessage = "Please Enter your Last Name")]
        public string last_name { get; set; }

        [Display(Name = "Email address:")]
        [Required(ErrorMessage = "The email address is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string email { get; set; }

        [DisplayName("Phone:")]
        [Required(ErrorMessage = "Please enter your phone")]
        [RegularExpression("^[2-9]\\d{2}-\\d{3}-\\d{4}$|^[2-9]\\d{2}\\d{3}\\d{4}$", ErrorMessage = "Please enter a valid phone number")]
        public string phone { get; set; }

        [DisplayName("City:")]
        [Required(ErrorMessage = "Please Enter your City")]
        public string city { get; set; }

        [DisplayName("Province:")]
        [Required(ErrorMessage = "Please Enter your Province")]
        public string province { get; set; }

        [DisplayName("Postal Code:")]
        [Required(ErrorMessage = "Please Enter your Postal Code")]
        public string postal_code { get; set; }

        [DisplayName("Resume:")]
        [Required(ErrorMessage = "Please Upload you resume")]
        public string resume { get; set; }

        [DisplayName("Cover letter:")]
        [Required(ErrorMessage = "Please Upload you Cover letter")]
        public string cover_letter { get; set; }

        
    }


}