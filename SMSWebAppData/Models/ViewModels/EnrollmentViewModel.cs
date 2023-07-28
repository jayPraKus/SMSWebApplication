using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSWebAppData.Models.ViewModels
{
    public class EnrollmentViewModel 
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid StudentId { get; set; }
        [Required]
        public Guid CourseId { get; set; }
        [Required]
        public string StudentFullName { get; set; }
        public List<StudentViewModel> Students { get; set; }
        public string CourseName { get; set; }
        public List<CourseViewModel> Courses { get; set; }

    }
}
