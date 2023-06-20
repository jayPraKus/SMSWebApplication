using SMSWebAppData.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSWebAppData.Models.ViewModels
{
    public class StudentViewModel
    {
        public Guid StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public GenderEnums Gender { get; set; }
        public string GradeLevel { get; set; }
        public string PhoneNumber { get; set; }
        public string? UserName { get; set; }
    }
}
