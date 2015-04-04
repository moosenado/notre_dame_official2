using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace NotreDameReBuildOfficial.Models
{
    [MetadataType(typeof(roleValidationClass))]

    public partial class role { 
    }

    [Bind(Exclude = "id")]
    public class roleValidationClass
    {
        [DisplayName("Role Name:")]
        [Required(ErrorMessage = "Please Enter Role Name")]
        public string title { get; set; }
    }
}