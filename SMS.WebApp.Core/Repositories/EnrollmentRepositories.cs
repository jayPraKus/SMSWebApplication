using Microsoft.EntityFrameworkCore;
using SMS.WebApp.Core.IRepositories;
using SMSWebAppData;
using SMSWebAppData.Helper;
using SMSWebAppData.Models.DataModels;
using SMSWebAppData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Core.Repositories
{
    public class EnrollmentRepositories : IEnrollmentRepositories
    {
        private readonly SMSDbContext _context;
        public EnrollmentRepositories(SMSDbContext context)
        {
            _context = context;
        }
        public async Task<DataResult> CreateEnrollment(Enrollment enrollArgs)
        {
            DataResult result = new DataResult();
            try
            {
                await _context.Enrollments.AddAsync(enrollArgs);
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Enrollment Done Successfully";                
            }
            catch(Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }

        public async Task<DataResult> DeleteEnrollment(Guid enrollId)
        {
            DataResult result = new DataResult();
            try
            {
                var enrollment = await _context.Enrollments.FindAsync(enrollId);
                if(enrollment == null)
                {
                    result.IsSuccess = false;
                    result.Message = "No data found";
                }
                enrollment.IsDeleted = true;
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "enrollment removed successfully";
            }
            catch(Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult<EnrollmentViewModel>> GetAllEnrollments()
        {
            DataResult<EnrollmentViewModel> result = new DataResult<EnrollmentViewModel>();
            try
            {
                var data = await _context.Enrollments.Where(a => a.IsDeleted == false).ToListAsync();
                if(data.Count != 0)
                {
                    result.Data = data.Select(s => new EnrollmentViewModel
                    {
                        Id = s.Id,
                        StudentId= s.StudentId,
                        CourseId= s.CourseId,
                        StudentFullName =s.Student.FirstName+" "+s.Student.LastName,    
                        CourseName = s.Course.CourseName
                    }).ToList();
                }
                result.IsSuccess = true;
                result.Message = "Data fetched successfully";
            }
            catch(Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult<EnrollmentViewModel>> GetEnrollmentById(Guid enrollId)
        {
            DataResult<EnrollmentViewModel> result = new DataResult<EnrollmentViewModel>();
            try
            {
                result.Data = await _context.Enrollments.Where(a => a.IsDeleted == false && a.Id == enrollId).Select(s => new EnrollmentViewModel
                {
                    Id = s.Id,
                    StudentId = s.StudentId,
                    CourseId = s.CourseId
                }).ToListAsync();
                result.IsSuccess = true;
                result.Message = "Data fetched successfully";
            }
            catch(Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult> UpdateEnrollment(Enrollment enrollArgs)
        {
            DataResult result = new DataResult();
            try
            {
                var enrollment = await _context.Enrollments.FindAsync(enrollArgs.Id);
                if (enrollment == null)
                {
                    result.IsSuccess = false;
                    result.Message = "No data found";
                }
                enrollment.StudentId = enrollArgs.StudentId;
                enrollment.CourseId = enrollArgs.CourseId;
                enrollment.UpdatedDate = enrollArgs.UpdatedDate;                
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Data updated successfully";
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;

        }
    }
}
