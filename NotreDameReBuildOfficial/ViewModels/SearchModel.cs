using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NotreDameReBuildOfficial.Models;

namespace NotreDameReBuildOfficial.ViewModels

//ViewModel created to combine 2 models: job postings and Events.
//used for search function. allows multiple models to be displayed on view
{
    public class SearchModel
    {
        public List<Job_posting> Job_postings { get; set; }

        public List<Event> Events { get; set; }

    }
}