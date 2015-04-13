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
    [MetadataType(typeof(erwaitValidation))]
    public partial class ERwait_AddPatient { }
    public class erwaitValidation
    {

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Please a first name")]
        public string fname { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Please a last name")]
        public string lname { get; set; }

        [DisplayName("Date")]
        [Required(ErrorMessage = "Please enter the date")]
        [RegularExpression(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$", ErrorMessage = "Invalid Format (dd/mm/yyyy)")]
        public string date { get; set; }

        [DisplayName("ER Reason")]
        [Required(ErrorMessage = "Please an ER reason")]
        public string er_reason { get; set; }
    }
}