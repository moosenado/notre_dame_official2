using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace NotreDameReBuildOfficial.Models
{
    [MetadataType(typeof(PdfFilterValidation))]
    public partial class PDF_Filter //DB table name
    {

    }
    [Bind(Exclude = "id")]
    public class PdfFilterValidation //Pdf Validation class for admin and public side
    {
        //[DisplayName("Title*")]
        //[Required(ErrorMessage = "Please enter the PDF title")]
        [StringLength(300)]
        public string PdfTitle { get; set; } //auto properties

        [DisplayName("Category*")]
        [Required(ErrorMessage = "Please enter a category")]
        public string Category { get; set; }

        [DisplayName("Description*")]
        [Required(ErrorMessage = "Please enter a description")]
        [StringLength(200)]
        public string Descr { get; set; }

        [DisplayName("Language*")]
        [Required(ErrorMessage = "Please choose an language")]
        public string Lang { get; set; }

        [DisplayName("Department*")]
        [Required(ErrorMessage = "Please choose a department")]
        public string Department { get; set; }
    }
}