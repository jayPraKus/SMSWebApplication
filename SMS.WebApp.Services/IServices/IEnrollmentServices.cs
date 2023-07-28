using SMSWebAppData.Helper;
using SMSWebAppData.Models.RequestModels;
using SMSWebAppData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Services.IServices
{
    public interface IEnrollmentServices
    {
        Task<DataResult> CreateEnrollment(EnrollmentViewModel enrollArgs);
        Task<DataResult> UpdateEnrollment(EnrollmentViewModel enrollArgs);
        Task<DataResult> DeleteEnrollment(Guid enrollId);
        Task<DataResult<EnrollmentViewModel>> GetAllEnrollment();
        Task<DataResult<EnrollmentViewModel>> GetEnrollmentById(Guid enrollId);

    }
}
