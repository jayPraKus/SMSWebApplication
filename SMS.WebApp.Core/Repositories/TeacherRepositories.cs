using SMS.WebApp.Core.IRepositories;
using SMSWebAppData.Helper;
using SMSWebAppData.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Core.Repositories
{
    public class TeacherRepositories : ITeacherRepositories
    {
        public Task<DataResult> CreateTeacherAsync(Teacher teacherArgs)
        {
            throw new NotImplementedException();
        }

        public Task<DataResult> DeleteTeacherAsync(Guid TeacherId)
        {
            throw new NotImplementedException();
        }

        public Task<DataResult<Teacher>> GetAllTeacherAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DataResult<Teacher>> GetTeacherByIDAsync(Guid TeacherId)
        {
            throw new NotImplementedException();
        }

        public Task<DataResult> UpdateTeacherAsync(Teacher teacherArgs)
        {
            throw new NotImplementedException();
        }
    }
}
