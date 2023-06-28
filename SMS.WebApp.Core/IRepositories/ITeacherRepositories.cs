using SMSWebAppData.Helper;
using SMSWebAppData.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Core.IRepositories
{
    public interface ITeacherRepositories
    {
        Task<DataResult> CreateTeacherAsync(Teacher teacherArgs);
        Task<DataResult> UpdateTeacherAsync(Teacher teacherArgs);
        Task<DataResult> DeleteTeacherAsync(Guid TeacherId);
        Task<DataResult<Teacher>> GetAllTeacherAsync();
        Task<DataResult<Teacher>> GetTeacherByIDAsync(Guid TeacherId);
    }
}
