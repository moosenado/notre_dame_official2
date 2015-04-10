using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;


namespace NotreDameReBuildOfficial.Models
{
    [MetadataType(typeof(volunteerValidate))]
    public partial class volunteerValidate
    {

    }

    [Bind(Exclude = "id")] // Binde exclude, used to exclude ID from displaying
    public partial class volunteerValidate
    {
        public IEnumerable<NotreDameReBuildOfficial.Models.volunteerJob> allJobs { get; set; }

        [DisplayName("Opportunity:")] // Display name for Job Title for Volunteer Oportunites
        [Required]
        public string jobTitle { get; set; }

        [DisplayName("Description:")]
        [Required]
        public string jobDescription { get; set; }

        [DisplayName("Street:")]
        [Required]
        public string street { get; set; }

        [DisplayName("city:")]
        [Required]
        public string city { get; set; }

        [DisplayName("Province:")]
        [Required]
        public string province { get; set; }

        [DisplayName("zip_code:")]
        [Required]
        public string zip_code { get; set; }

        [DisplayName("Date:")]
        public DateTime date { get; set; }

        [DisplayName("Start Date:")]
        [Required]
        public DateTime dateStart { get; set; }

        [DisplayName("End Date:")]
        [Required]
        public DateTime dateEnd { get; set; }
    }
}