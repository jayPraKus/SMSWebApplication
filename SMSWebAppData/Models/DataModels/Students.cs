using SMSWebAppData.Helper;
using SMSWebAppData.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSWebAppData.Models.DataModels
{
    public class Students:BaseModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public GenderEnums Gender { get; set; }
        public string GradeLevel { get; set; }
        public string  PhoneNumber { get; set; }


    }
}
