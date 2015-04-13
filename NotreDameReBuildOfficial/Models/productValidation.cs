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
    [MetadataType(typeof(productValidation))]
    public partial class product { }
    public class productValidation
    {

        [DisplayName("Product Name")]
        [Required(ErrorMessage = "Please enter a product name")]
        public string name { get; set; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "Please enter a price")]
        [RegularExpression(@"^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$", ErrorMessage = "Invalid Price (ex. 5.00)")]
        public string price { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Please enter a description")]
        public string description { get; set; }

        [DisplayName("Image")]
        public string image { get; set; }
    }
}