//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel;
//using System.Web.Mvc;

//namespace NotreDameReBuildOfficial.Models
//{
//    [MetadataType(typeof(SearchValidation))]
//    public partial class Search //DB table name
//    {

//    }
//    [Bind(Exclude = "id")]
//    public class SearchValidation
//    {
//        [DisplayName("Search Term")]
//        //[Required(ErrorMessage = "Please enter your first name")]
//        [StringLength(100)]
//        public string Keyword { get; set; }

//        [DisplayName("Date Searched")]
//        //[Required(ErrorMessage = "Please choose an date")]
//        [DataType(DataType.Date)]
//        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
//        public DateTime Tstamp { get; set; }

//    }
//}