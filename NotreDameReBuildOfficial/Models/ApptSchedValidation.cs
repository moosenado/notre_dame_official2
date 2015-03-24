﻿using System;
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
        //[RegularExpression("[A-Za-z0-9._%+-]+@[A-Za-z0-9.-][A-Za-z]{2,4}", ErrorMessage = "Please enter a valid email")]
        public string Phone { get; set; }

        [DisplayName("Email*")]
        [Required(ErrorMessage = "Please enter a valid email")]
        [RegularExpression("[A-Za-z0-9._%+-]+@[A-Za-z0-9.-][A-Za-z]{2,4}", ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }

        [DisplayName("Health Card#*")]
        [Required(ErrorMessage = "Please enter your health card number")]
        [StringLength(12)]
        public string HealthNum { get; set; }

        [DisplayName("Preferred Appointment Date*")]
        [Required(ErrorMessage = "Please choose an date")]
        public DateTime BookDate { get; set; }

        [DisplayName("Preferred Appointment Time*")]
        [Required(ErrorMessage = "Please choose a time")]
        [StringLength(100)]
        public DateTime BookTime { get; set; }

        [DisplayName("Speciality*")]
        [Required(ErrorMessage = "Please choose a speciality")]
        [StringLength(100)]
        public string Speciality { get; set; }

        [DisplayName("Additional Information*")]
        [StringLength(300)]
        public string AdditionalInfo { get; set; }
    } 
}