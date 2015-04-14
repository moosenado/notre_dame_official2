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
    [Bind(Exclude = "id")]
    public class PdfFilterValidation
    {
        //[DisplayName("Title*")]
        //[Required(ErrorMessage = "Please enter the PDF title")]
        [StringLength(300)]
        public string PdfTitle { get; set; } //auto properties

        //[DisplayName("Url*")]
        //[Required(ErrorMessage = "Please enter path to file")]
        public string PdfUrl { get; set; }

        [DisplayName("Category*")]
        [Required(ErrorMessage = "Please enter a category")]
        public string Category { get; set; }

        //[DisplayName("Image*")]
        public string Image { get; set; }

        [DisplayName("Description*")]
        [Required(ErrorMessage = "Please enter a description")]
        [StringLength(200)]
        public string Descr { get; set; }

        [DisplayName("Language*")]
        [Required(ErrorMessage = "Please choose an language")]
        public string Lang { get; set; }

        [DisplayName("Department*")]
        [Required(ErrorMessage = "Please choose a department")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")] 
        public string Department { get; set; }


        //[Required(ErrorMessage = "Please choose a file")]
        //public HttpPostedFileBase File { get; set; }

    }
}