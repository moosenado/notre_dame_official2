﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace NotreDameReBuildOfficial.Models
{

    [MetadataType(typeof(staffValidate))]
    public partial class staff_info
    {
    }

    [Bind(Exclude = "id")] // Binde exclude, used to exclude ID from displaying
    public partial class staffValidate
    {
        [DisplayName("Staff ID")] // Display name for employee ID
        [Required] // required Specified 
        public string sID { get; set; } // get set method for id

        [DisplayName("First Name")] // Display name for employee First Name
        [Required] // required Specified 
        public string fname { get; set; } // get set method for First Name

        [DisplayName("Last Name")] // Display name for employee Last Name
        [Required] // required Specified 
        public string lname { get; set; } // get set method for Last Name

        [DisplayName("Department")] // Display name for employee Department
        [Required] // required Specified 
        public string depart { get; set; } // get set method for Department

        [DisplayName("Role")] // Display name for employee ROle
        [Required] // required Specified 
        public string role { get; set; } // get set method for Role

        [DisplayName("Gender")] // Display name for employee ROle
        [Required] // required Specified 
        public string gen { get; set; } // get set method for Role

        [DisplayName("City")] // Display name for employee ROle
        [Required] // required Specified 
        public string city { get; set; } // get set method for Role

        [DisplayName("Province")] // Display name for employee ROle
        [Required] // required Specified 
        public string province { get; set; } // get set method for Role

        [DisplayName("Zip Code")] // Display name for employee ROle
        [Required] // required Specified 
        public string zip { get; set; } // get set method for Role

    }
}