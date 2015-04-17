using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace NotreDameReBuildOfficial.Models
{
    [MetadataType(typeof(newsfeedValidation))] //partial class to bind to userValidation class
    public partial class news_article //refers to the name of the table
    {

    }

    [Bind(Exclude = "id")] //this excludes the column - id

    //VALIDATION
    public class newsfeedValidation
    {

        [DisplayName("Title")]
        [Required(ErrorMessage = "Please Enter A Title")]
        public string title { get; set; }

        [DisplayName("Date")]
        [Required(ErrorMessage = "Please Enter A Date")]
        [RegularExpression("[0-9]{2}/[0-9]{2}/[0-9]{4}", ErrorMessage = "Please Enter a Valid Date (DD/MM/YYYY)")]
        public string date { get; set; }

        [DisplayName("Author")]
        [Required(ErrorMessage = "Please Enter An Author")]
        public string author { get; set; }

        [DisplayName("Article")]
        [Required(ErrorMessage = "Please Enter An Article")]
        [AllowHtml]
        public string article { get; set; }

        [DisplayName("Image")]
        public string image { get; set; }

    }
}