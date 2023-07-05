using Microsoft.EntityFrameworkCore;
using SMS.WebApp.Core.IRepositories;
using SMSWebAppData;
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
        private readonly SMSDbContext _context;
        public TeacherRepositories(SMSDbContext context)
        {
            _context = context;
        }
        public async Task<DataResult> CreateTeacherAsync(Teacher teacherArgs)
        {
            DataResult result = new DataResult();
            try
            {
                await _context.Teachers.AddAsync(teacherArgs);
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Teacher created successfully";
            }
            catch(Exception e)
            {
                result.IsSuccess = false;
                result.Message= e.Message;
            }
            return result;
        }

        public async Task<DataResult> DeleteTeacherAsync(Guid TeacherId)
        {
            DataResult result = new DataResult();
            try
            {
                var user = await _context.Teachers.Where(w => w.Id == TeacherId).FirstOrDefaultAsync();
                if (user == null)
                {                    
                    result.IsSuccess = false;
                    result.Message = "No data found";
                }
                else
                {
                    user.IsDeleted = true;
                    await _context.SaveChangesAsync();
                    result.IsSuccess = true;
                    result.Message = "Teacher deleted successfully";
                }
            }
            catch(Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }

        public async Task<DataResult<Teacher>> GetAllTeacherAsync()
        {
            DataResult<Teacher> result = new DataResult<Teacher>();
            try
            {
                result.Data = await _context.Teachers.Where(x => x.IsDeleted == false).ToListAsync();
                result.IsSuccess = true;
                result.Message = "Teacher data fetched successfully";
            }
            catch(Exception e)
            {
                result.IsSuccess = false;
                result.Message= e.Message;
            }
            return result;
        }

        public async Task<DataResult<Teacher>> GetTeacherByIDAsync(Guid TeacherId)
        {
            DataResult<Teacher> result = new DataResult<Teacher>();
            try
            {
                result.Data = await _context.Teachers.Where(w => w.Id == TeacherId).ToListAsync();
                result.IsSuccess = true;
                result.Message = "Teacher data by Id fetched successfully";
            }
            catch(Exception e)
            {
                result.IsSuccess = false;
                result.Message= e.Message;
            }
            return result;
        }

        public async Task<DataResult> UpdateTeacherAsync(Teacher teacherArgs)
        {
            DataResult result = new DataResult();
            try
            {
                var data = await _context.Teachers.Where(w => w.Id == teacherArgs.Id).FirstAsync();
                data.FirstName = teacherArgs.FirstName;
                data.LastName = teacherArgs.LastName;
                data.Email = teacherArgs.Email;
                data.DOB = teacherArgs.DOB;
                data.Gender = teacherArgs.Gender;
                data.Phone = teacherArgs.Phone;
                data.Subject = teacherArgs.Subject;
                data.UpdateUserName = teacherArgs.UpdateUserName;
                data.CreateUserName = "";
                data.UpdatedDate = teacherArgs.UpdatedDate;
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Teacher data updated successfully";

            }
            catch(Exception e)
            {
                result.IsSuccess = false;
                result.Message= e.Message;
            }
            return result;
        }
    }
}
