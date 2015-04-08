using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace NotreDameReBuildOfficial.Models
{
    [MetadataType(typeof(pollValidationClass))]

    public partial class poll { 
    }

    [Bind (Exclude="id")]
    public partial class pollValidationClass
    {
       [DisplayName("Question")]
       [Required(ErrorMessage= "Please enter you question!")]
        public string question_text { get; set; }

    }
}