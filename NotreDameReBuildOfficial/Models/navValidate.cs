using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace NotreDameReBuildOfficial.Models
{
    [MetadataType(typeof(navValidate))]
    public partial class navValidate
    {

    }

    [Bind(Exclude = "id")] // Binde exclude, used to exclude ID from displaying
    public partial class navValidate
    {

        [DisplayName("Title:")] // Display name for employee Last Name
        [Required] // required Specified 
        public string title { get; set; } // get set method for Last Name

        [DisplayName("Folder:")] // Display name for employee Last Name
        [Required] // required Specified 
        public string controller { get; set; } // get set method for Last Name

        [DisplayName("Page:")] // Display name for employee Last Name
        [Required] // required Specified 
        public string pageView { get; set; } // get set method for Last Name


    }
}