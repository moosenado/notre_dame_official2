using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations; // set of ASP.Net attributes
using System.ComponentModel;
using System.Web.Mvc;

namespace NotreDameReBuildOfficial.Models
{
    [MetadataType(typeof(userValidationClass))] // specifies metadata class to associate model class
    public partial class User
    {

    }
    [Bind(Exclude = "id")]// set this property that binding is not allowed   
    public class userValidationClass
    {
        //creating fields and write validation for each field

        [DisplayName("First Name")]
        [Required]
        public string first_name { get; set; }

        [DisplayName("Last Name")]
        [Required]
        public string last_name { get; set; }

        [DisplayName("Email")]
        [Required]
        public string email { get; set; }

        [Required]
        [Display(Name = "Phone")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter a valid phone number.")]
        public string phone { get; set; }

        [DisplayName("city")]
        [Required]
        public decimal city { get; set; }

        [Display(Name = "Postal")]
        [RegularExpression(@"^[ABCEGHJKLMNPRSTVXY]{1}\d{1}[A-Z]{1} *\d{1}[A-Z]{1}\d{1}$", ErrorMessage = "Please enter a valid postal code.")]
        public string postal_code { get; set; }

        [Required]
        [Display(Name = "Date of birth (mm/dd/yyyy)")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        //[Required]
        //[Display(Name = "User name")]
        //public string UserName { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        //public string Password { get; set; }

        //[Display(Name = "Remember me?")]
        //public bool RememberMe { get; set; }



    }
}