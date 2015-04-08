using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NotreDameReBuildOfficial.Models
{
    public class pollOptionsClass: Poll_option 
    {
        //creating an instance of Linq object
        ndLinqClassDataContext db = new ndLinqClassDataContext();
        
        [DisplayName("Questions")]
        public string questions { get; set; }

        //public IQueryable<pollOptionsClass> getOptions()
        //{
        //    //Creating an anonymous variable with its value beging the instance of Linq object
        //    var allOptions = from jp in jobObj.Job_postings
        //                  join cat in jobObj.Job_categories on jp.category_id equals cat.id
        //                  select new jobPosting()
        //                  {
        //                      id = jp.id,
        //                      title = jp.title,
        //                      department = jp.department,
        //                      posting_date = jp.posting_date,
        //                      catTitle = cat.title
        //                  };

        //    //return IQueryable Jobposting for data bound control to bind
        //    return allJobs;
        //}
    }


}