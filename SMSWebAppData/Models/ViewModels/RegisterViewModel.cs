using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSWebAppData.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; } 
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage ="Confirm password didn't match with origional password")]
        public string ConfirmPassword { get; set; }
    }
}
