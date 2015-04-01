using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace NotreDameReBuildOfficial.Models
{
    [MetadataType(typeof(PdfFilterValidation))]
    public partial class PDF_Filter //DB table name
    { 
        
    }
    [Bind(Exclude="id")]
    public class PdfFilterValidation
    {
        [DisplayName("Title*")]
        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(100)]
        public string PdfTitle { get; set; }

        [DisplayName("Url*")]
        [Required(ErrorMessage = "Please enter your last name")]
        [StringLength(100)]
        public string PdfUrl { get; set; }

        [DisplayName("Category*")]
        [Required(ErrorMessage = "Please enter a phone number")]
        //[RegularExpression("[A-Za-z0-9._%+-]+@[A-Za-z0-9.-][A-Za-z]{2,4}", ErrorMessage = "Please enter a valid email")]
        public string Category { get; set; }

        [DisplayName("Image*")]
        //[Required(ErrorMessage = "Please enter a valid email")]
        //[RegularExpression("[A-Za-z0-9._%+-]+@[A-Za-z0-9.-][A-Za-z]{2,4}", ErrorMessage = "Please enter a valid email")]
        public string Image { get; set; }

        [DisplayName("Description*")]
        [Required(ErrorMessage = "Please enter your health card number")]
        [StringLength(12)]
        public string Descr { get; set; }

        [DisplayName("Language*")]
        [Required(ErrorMessage = "Please choose an date")]
        public string Lang { get; set; }

        [DisplayName("Department*")]
        [Required(ErrorMessage = "Please choose a time")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")] 
        public string Department { get; set; }

    } 
}