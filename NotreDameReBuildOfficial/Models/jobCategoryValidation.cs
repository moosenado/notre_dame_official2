using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace NotreDameReBuildOfficial.Models
{
    [MetadataType(typeof(jobCategoryValidation))]

    public partial class Job_category
    { 
    }

    [Bind (Exclude = "id")]
    public partial class jobCategoryValidation
    {
        [DisplayName("Category Name")]
        [Required]
        public string title { get; set; }
    }
}