using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Imported namespaces
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace NotreDameReBuildOfficial.Models
{
    [MetadataType(typeof(feedbackValidation))]
    public partial class Feedback { }

    public class feedbackValidation
    {

        [DisplayName("I would like to remain anonymous")]
        public bool anonymous { get; set; }

        [DisplayName("Date Created")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dddd MMMM d, yyyy}")]
        public DateTime? date { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Please enter name")]
        public string name { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Please enter your email")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email address")]
        public string email { get; set; }

        [DisplayName("What is the subject of your feedback? (e.g. website)")]
        [Required(ErrorMessage = "Enter subject")]
        public string subject { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "Select a category")]
        public string category { get; set; }

        [DisplayName("Comments")]
        [Required(ErrorMessage = "Enter feedback comments")]
        public string comments { get; set; }

        [DisplayName("Approval Status")]
        public string approved { get; set; }

    }
}