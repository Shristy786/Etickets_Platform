using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Etickets_Platform.Data.ViewModels
{
    public class RegisterVM
    {


        [Required(ErrorMessage = "Must enter your Full Name")]
        [Display(Name = "Users Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Must enter your email address")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }


        [Required(ErrorMessage = "Must enter your Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is Required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password do not match")]
        public string ConifrmPassword { get; set; }
    }
}
