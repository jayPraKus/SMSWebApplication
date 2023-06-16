using SMSWebAppData.Helper;
using SMSWebAppData.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Core.IRepositories
{
    public interface IStudentRepositories
    {
        Task<DataResult> CreateStudentAsync(Students studentArgs);
        Task<DataResult> UpdateStudentAsync(Students studentArgs);
        Task<DataResult> DeleteStudentAsync(Guid studentId);
        Task<DataResult<Students>> GetAllStudentAsync();
    }
}
