using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations; // set of ASP.Net attributes
using System.ComponentModel;
using System.Web.Mvc;


namespace NotreDameReBuildOfficial.Models
{
    [MetadataType(typeof(jobPostingValidation))] // specifies metadata class to associate model class
    public partial class Job_posting
    {
    }
    [Bind(Exclude = "id")]// set this property that binding is not allowed   
    public class jobPostingValidation
    {
        //creating fields and write validation for each field

        [DisplayName("Title")]
        [Required]
        public string title { get; set; }

        [DisplayName("Type")]
        [Required]
        public string type { get; set; }

        [DisplayName("Department")]
        [Required]
        public string department { get; set; }

        [DisplayName("Description")]
        [Required]
        public string description { get; set; }

        [DisplayName("Salary")]
        [Required]
        [RegularExpression("^\\$?\\d+(\\.(\\d{2}))?$")]
        public decimal salary { get; set; }
       
        [DisplayName("Posting_date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Required(ErrorMessage = "Please enter the date!")]
        public DateTime posting_date { get; set; }

        [DisplayName("Category")]
        [Required]
        public string category_id { get; set; }

    }
}