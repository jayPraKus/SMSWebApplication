using SMSWebAppData.Helper;
using SMSWebAppData.Models.Enums;
using SMSWebAppData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Services.IServices
{
    public interface ITeacherServices
    {
        Task<DataResult> CreateTeacherAsync(TeacherViewModel teacherArgs);
        Task<DataResult> UpdateTeacherAsync(TeacherViewModel teacherArgs);
        Task<DataResult> DeleteTeacherAsync(Guid teacherId);
        Task<DataResult<TeacherViewModel>> GetAllTeacherAsync();        
        Task<DataResult<TeacherViewModel>> GetTeacherByID(Guid TeacherId);


    }
}
