using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;


namespace NotreDameReBuildOfficial.Models
{
    public class populatePublicNav
    {
        [DisplayName("ID:")] // Display name for employee Last Name
        [Required] // required Specified 
        public int id { get; set; } // get set method for Last Name

        [DisplayName("Title:")] // Display name for employee Last Name
        [Required] // required Specified 
        public string title { get; set; } // get set method for Last Name

        public subNavigation subNav;

    }
}