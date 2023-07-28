using SMSWebAppData.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSWebAppData.Models.DataModels
{
    public class Enrollment:BaseModel
    {
        public Guid Id { get; set; }
        [ForeignKey("StudentId")]
        public Guid StudentId { get; set; }
        public virtual Students Student { get; set; }
        [ForeignKey("CourseId")]
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }


    }
}
