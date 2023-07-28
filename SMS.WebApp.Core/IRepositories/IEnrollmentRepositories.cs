using SMSWebAppData.Helper;
using SMSWebAppData.Models.DataModels;
using SMSWebAppData.Models.RequestModels;
using SMSWebAppData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Core.IRepositories
{
    public interface IEnrollmentRepositories
    {
        Task<DataResult> CreateEnrollment(Enrollment enrollArgs);
        Task<DataResult> UpdateEnrollment(Enrollment enrollArgs);
        Task<DataResult> DeleteEnrollment(Guid enrollId);
        Task<DataResult<EnrollmentViewModel>> GetAllEnrollments();
        Task<DataResult<EnrollmentViewModel>> GetEnrollmentById(Guid enrollId);

    }
}
