using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSWebAppData.Models.ViewModels
{
    public class LoginViewModel
    {
        //Using data anotation to denote that this property  is mandatory.
        [Required]
        [EmailAddress]
        [Display(Name ="Email")]
        public string Email { get; set;}   
        [Required]
        [StringLength(100, ErrorMessage ="The {0} must be at least {2} and at max {1} characters lonh.",MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string Password { get; set; }
    }
}
