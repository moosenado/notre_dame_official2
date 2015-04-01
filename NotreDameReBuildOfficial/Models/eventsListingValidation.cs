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
    [MetadataType(typeof(eventsListingValidation))]
    public partial class Event { }

    public class eventsListingValidation
    {

        [DisplayName("Event Name")]
        [Required(ErrorMessage = "Enter event name")]
        public string name { get; set; }

        [DisplayName("Start Date")]
        [Required(ErrorMessage = "Select start date")]
        public DateTime start_date { get; set; }

        [DisplayName("Start Time (e.g. 4:00 p.m.)")]
        [Required(ErrorMessage = "Enter start time")]
        public string start_time { get; set; }

        [DisplayName("End Date (if applicable)")]
        public DateTime end_date { get; set; }

        [DisplayName("End Time (if applicable, e.g. 4:00 p.m.)")]
        public string end_time { get; set; }

        [DisplayName("Event Descrtiption (650 character limit)")]
        [Required(ErrorMessage = "Enter event description")]
        public string description { get; set; }

        [DisplayName("Venue")]
        public string venue { get; set; }

        [DisplayName("Address")]
        public string address { get; set; }

        [DisplayName("Cost")]
        public string cost { get; set; }

        [DisplayName("Contact Name")]
        [Required(ErrorMessage = "Enter contact name")]
        public string contact_name { get; set; }

        [DisplayName("Contact Email")]
        [Required(ErrorMessage = "Enter contact email")]
        public string contact_email { get; set; }

        [DisplayName("Contact Phone")]
        public string contact_phone { get; set; }

        [DisplayName("Additional URL Resource:")]
        public string url { get; set; }

        public int approved { get; set; }

        public int display { get; set; }

    }
}