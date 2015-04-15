using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace NotreDameReBuildOfficial.Models
{

//    [Bind(Exclude = "id")] // Binde exclude, used to exclude ID from displaying
    public class populateNav
    {

        [DisplayName("ID:")] // Display name for employee Last Name
        [Required] // required Specified 
        public int id { get; set; } // get set method for Last Name

        [DisplayName("Title:")] // Display name for employee Last Name
        [Required] // required Specified 
        public string title { get; set; } // get set method for Last Name

        [DisplayName("Icon:")] // Display name for employee Last Name
        [Required] // required Specified 
        public string icon { get; set; } // get set method for Last Name

        public admin_subNavigation subNav;
    }

}