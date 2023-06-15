using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Etickets_Platform.Data.ViewModels
{
    public class LoginVM

    {
        [Required(ErrorMessage = "Must enter your email address")]
        [Display(Name="Email Address")]
        public string EmailAddress { get; set; }


        [Required(ErrorMessage = "Must enter your Password")]
       [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
