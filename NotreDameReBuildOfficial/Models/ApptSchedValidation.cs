using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace NotreDameReBuildOfficial.Models
{
    [MetadataType(typeof(ApptSchedValidation))]
    public partial class Appt_Book //DB table name
    { 
        
    }
    [Bind(Exclude="id")]
    public class ApptSchedValidation
    {
        [DisplayName("First Name*")]
        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(100)]
        public string Fname { get; set; }

        [DisplayName("Last Name*")]
        [Required(ErrorMessage = "Please enter your last name")]
        [StringLength(100)]
        public string Lname { get; set; }

        [DisplayName("Phone*")]
        [Required(ErrorMessage = "Please enter a phone number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter a valid Phone Number")]
        public string Phone { get; set; }

        [DisplayName("Email*")]
        [Required(ErrorMessage = "Please enter a valid email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }

        [DisplayName("Health Card#*")]
        [Required(ErrorMessage = "Please enter your health card number")]
        [StringLength(12)]
        public string HealthNum { get; set; }

        [DisplayName("Preferred Appointment Date*")]
        [Required(ErrorMessage = "Please choose an date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime BookDate { get; set; }

        [DisplayName("Preferred Appointment Time*")]
        [Required(ErrorMessage = "Please choose a time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")] 
        public DateTime BookTime { get; set; }

        [DisplayName("Speciality*")]
        [Required(ErrorMessage = "Please choose a speciality")]
        [StringLength(100)]
        public string Speciality { get; set; }

        [DisplayName("Additional Information*")]
        [StringLength(300)]
        public string AdditionalInfo { get; set; }

        //[DisplayName("TSTAMP*")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        //public DateTime Tstamp { get; set; }
    } 
}