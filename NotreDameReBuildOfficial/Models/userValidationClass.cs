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
        [RegularExpression("^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Please enter a valid email.")]
        public string email { get; set; }

        [Required]
        [DisplayName("Phone")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter a valid phone number.")]
        public string phone { get; set; }

        [DisplayName("city")]
        [Required]
        public string city { get; set; }

        [DisplayName("province")]
        [Required]
        public string province { get; set; }

        [DisplayName("Postal Code")]
        //[RegularExpression(@"^[ABCEGHJKLMNPRSTVXY]{1}\d{1}[A-Z]{1} *\d{1}[A-Z]{1}\d{1}$", ErrorMessage = "Please enter a valid postal code.")]
        public string postal_code { get; set; }

        [Required]
        [DisplayName("Date of birth (mm/dd/yyyy)")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [Required]
        [DisplayName("User name")]
        public string user_name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string password { get; set; }

       



    }
}