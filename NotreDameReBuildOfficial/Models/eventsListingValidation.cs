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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dddd MMMM d, yyyy}")]
        [Required(ErrorMessage = "Select start date")]
        public DateTime start_date { get; set; }

        [DisplayName("Start Time (e.g. 4:00 pm)")]
        [Required(ErrorMessage = "Enter start time")]
        public string start_time { get; set; }

        [DisplayName("End Date (if applicable)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dddd MMMM d, yyyy}")]
        public DateTime end_date { get; set; }

        [DisplayName("End Time (if applicable, e.g. 4:00 pm)")]
        public string end_time { get; set; }

        [DisplayName("Event Descrtiption (650 character limit)")]
        [Required(ErrorMessage = "Enter event description")]
        public string description { get; set; }

        [DisplayName("Venue")]
        public string venue { get; set; }

        [DisplayName("Address")]
        public string address { get; set; }

        [DisplayName("Cost (e.g. 5.00)")]
        [RegularExpression(@"^\$?(\d{1,3}(\,\d{3})*|(\d+))(\.\d{0,2})?$", ErrorMessage = "Invalid cost")]
        public string cost { get; set; }

        [DisplayName("Contact Name")]
        [Required(ErrorMessage = "Enter contact name")]
        public string contact_name { get; set; }

        [DisplayName("Contact Email")]
        [Required(ErrorMessage = "Enter contact email")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email address")]
        public string contact_email { get; set; }

        [DisplayName("Contact Phone (e.g. 2126661234)")]
        [RegularExpression(@"^([0-9]*)$", ErrorMessage = "Invalid phone number")]
        public string contact_phone { get; set; }

        [DisplayName("Additional URL Resource: (e.g. google.ca)")]
        [RegularExpression(@"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$", ErrorMessage = "Invalid URL")]
        public string url { get; set; }

        [DisplayName("Approve Event?")]
        public int approved { get; set; }

        [DisplayName("Display on Homepage?")]
        public int display { get; set; }

    }
}