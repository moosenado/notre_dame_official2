﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace NotreDameReBuildOfficial.Models
{
    [MetadataType(typeof(volunteerInfoValidate))]
    public partial class volunteerInfoValidate
    {

    }

    [Bind(Exclude = "id")] // Binde exclude, used to exclude ID from displaying
    public partial class volunteerInfoValidate
    {
        [DisplayName("ID:")] // Display name for employee Last Name
        [Required] // required Specified 
       public string id { get; set; } // get set method for Last Name

        [DisplayName("First Name:")] // Display name for employee Last Name
        [Required] // required Specified 
        public string firstname { get; set; } // get set method for First Name

        [DisplayName("Last Name:")] // Display name for employee Last Name
        [Required] // required Specified 
        public string lastname { get; set; } // get set method for Last Name

        [DisplayName("Department:")] // Display name for employee Department
        [Required] // required Specified 
        public string department { get; set; } // get set method for Department

        [DisplayName("Role:")] // Display name for employee ROle
        [Required] // required Specified 
        public string role { get; set; } // get set method for Role

        [DisplayName("Gender:")] // Display name for employee ROle
        [Required] // required Specified 
        public int gender { get; set; } // get set method for Role

        [DisplayName("Email:")] // Display name for employee ROle
        [Required] // required Specified 
        public string email { get; set; } // get set method for Role

        [DisplayName("Moblie No:")] // Display name for employee ROle
        [Required] // required Specified 
        public string mobile { get; set; } // get set method for Role

        [DisplayName("Street:")] // Display name for employee ROle
        [Required] // required Specified 
        public string street { get; set; } // get set method for Role

        [DisplayName("City:")] // Display name for employee ROle
        [Required] // required Specified 
        public string city { get; set; } // get set method for Role

        [DisplayName("Province:")] // Display name for employee ROle
        [Required] // required Specified 
        public string province { get; set; } // get set method for Role

        [DisplayName("Zip Code:")] // Display name for employee ROle
        [Required] // required Specified 
        public string zip_code { get; set; } // get set method for Role

        [DisplayName("jobID:")] // Display name for employee Last Name
        [Required] // required Specified 
        public int jobID { get; set; } // get set method for Last Name

        [DisplayName("Date Applied:")] // Display name for employee ROle
        [Required] // required Specified 
        public DateTime dateApplied { get; set; } // get set method for Role

    }
 


}