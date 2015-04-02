using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace NotreDameReBuildOfficial.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
    // It is  used to create Staff and volunteer and SuperAdmin
    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string user_name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string confirmpassword { get; set; }

        //Add more fields
        [Required]
        [Display(Name = "First name")]
        public string first_name { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string last_name { get; set; }

        [Required]
        [Display(Name = "Date of birth (mm/dd/yyyy)")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [Required]
        [Display(Name = "Email")]
        [RegularExpression("^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Please enter a valid email.")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Phone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter a valid phone number.")]
        public string phone { get; set; }

      

        [Display(Name = "Postal")]
        [RegularExpression(@"^[ABCEGHJKLMNPRSTVXY]{1}\d{1}[A-Z]{1} *\d{1}[A-Z]{1}\d{1}$", ErrorMessage = "Please enter a valid postal code.")]
        public string postal_code { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Province")]
        public string province { get; set; }
    }

    public class UpdateStaff
    {
        [Required]
        [Display(Name = "First name")]
        public string first_name { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string last_name { get; set; }

        [Required]
        [Display(Name = "Date of birth (mm/dd/yyyy)")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [Required]
        [Display(Name = "Email")]
        [RegularExpression("^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Please enter a valid email.")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Phone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter a valid phone number.")]
        public string phone { get; set; }


        [Display(Name = "Postal")]
        [RegularExpression(@"^[ABCEGHJKLMNPRSTVXY]{1}\d{1}[A-Z]{1} *\d{1}[A-Z]{1}\d{1}$", ErrorMessage = "Please enter a valid postal code.")]
        public string postal_code { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Province")]
        public string province { get; set; }
    }

 

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
    // Registarion
    //public class UserRegistration
    //{
    //    [Required]
    //    [Display(Name = "User name")]
    //    public string user_name { get; set; }

    //    [Required]
    //    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    //    [DataType(DataType.Password)]
    //    [Display(Name = "Password")]
    //    public string password { get; set; }

    //    [DataType(DataType.Password)]
    //    [Display(Name = "Confirm password")]
    //    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    //    public string confirmpassword { get; set; }



    //    [Required]
    //    [Display(Name = "First Name")]
    //    public string first_name { get; set; }

    //    [Required]
    //    [Display(Name = "Last Name")]
    //    public string last_name { get; set; }

    //    [Required]
    //    [Display(Name = "gender")]
    //    public string gender { get; set; }

    //    [Required]
    //    [Display(Name = "Email")]
    //    [RegularExpression("^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Please enter a valid email.")]
    //    public string email { get; set; }

    //    [Required]
    //    [Display(Name = "Phone")]
    //    [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter a valid phone number.")]
    //    public string phone { get; set; }

    //    [Required]
    //    [Display(Name = "City")]
    //    public string city { get; set; }

    //    [Required]
    //    [Display(Name = "Province")]
    //    public string province { get; set; }

    //    [Display(Name = "postal Code")]
    //    [RegularExpression(@"^[ABCEGHJKLMNPRSTVXY]{1}\d{1}[A-Z]{1} *\d{1}[A-Z]{1}\d{1}$", ErrorMessage = "Please enter a valid postal code.")]
    //    public string postal_code { get; set; }

    //    [Display(Name = "Date")]
    //    public string date_registry { get; set; }

    //}

    //public class UpdateUserRegistration
    //{
    //    [Required]
    //    [Display(Name = "User name")]
    //    public string user_name { get; set; }

    //    [Required]
    //    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    //    [DataType(DataType.Password)]
    //    [Display(Name = "Password")]
    //    public string password { get; set; }

    //    [DataType(DataType.Password)]
    //    [Display(Name = "Confirm password")]
    //    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    //    public string confirmpassword { get; set; }



    //    [Required]
    //    [Display(Name = "First Name")]
    //    public string first_name { get; set; }

    //    [Required]
    //    [Display(Name = "Last Name")]
    //    public string last_name { get; set; }

    //    [Required]
    //    [Display(Name = "gender")]
    //    public string gender { get; set; }

    //    [Required]
    //    [Display(Name = "Email")]
    //    [RegularExpression("^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Please enter a valid email.")]
    //    public string email { get; set; }

    //    [Required]
    //    [Display(Name = "Phone")]
    //    [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter a valid phone number.")]
    //    public string phone { get; set; }

    //    [Required]
    //    [Display(Name = "City")]
    //    public string city { get; set; }

    //    [Required]
    //    [Display(Name = "Province")]
    //    public string province { get; set; }

    //    [Display(Name = "postal Code")]
    //    public string postal_code { get; set; }

    //    [Display(Name = "Date")]
    //    public string date_registry { get; set; }

    //}

}
