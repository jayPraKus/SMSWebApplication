using SMSWebAppData.Helper;
using SMSWebAppData.Models.DataModels;
using SMSWebAppData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Services.IServices
{
    public interface IStudentServices
    {
        Task<DataResult> CreateStudentAsync(StudentViewModel studentArgs);
        Task<DataResult> UpdateStudentAsync(StudentViewModel studentArgs);
        Task<DataResult> DeleteStudentAsync(Guid studentId);
        Task<DataResult<StudentViewModel>> GetAllStudentAsync();
    }
}
