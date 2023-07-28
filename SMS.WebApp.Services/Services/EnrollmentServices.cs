using SMS.WebApp.Core.IRepositories;
using SMS.WebApp.Services.IServices;
using SMSWebAppData.Helper;
using SMSWebAppData.Models.DataModels;
using SMSWebAppData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Services.Services
{
    public class EnrollmentServices : IEnrollmentServices
    {
        private readonly IEnrollmentRepositories _enrollmentRepo;
        public EnrollmentServices(IEnrollmentRepositories enrollmentRepo)
        {
            _enrollmentRepo = enrollmentRepo;
        }
        public async Task<DataResult> CreateEnrollment(EnrollmentViewModel enrollArgs)
        {
            Enrollment enrollment = new Enrollment
            {
                StudentId = enrollArgs.StudentId,
                CourseId = enrollArgs.CourseId,
                CreatedDate = DateTime.Now,
                CreateUserName = "",
            };
            return await _enrollmentRepo.CreateEnrollment(enrollment);
        }

        public async Task<DataResult> DeleteEnrollment(Guid enrollId)
        {
            return await _enrollmentRepo.DeleteEnrollment(enrollId);
        }

        public async Task<DataResult<EnrollmentViewModel>> GetAllEnrollment()
        {
            return await _enrollmentRepo.GetAllEnrollments();
        }

        public async Task<DataResult<EnrollmentViewModel>> GetEnrollmentById(Guid enrollId)
        {
            return await _enrollmentRepo.GetEnrollmentById(enrollId);
        }

        public async Task<DataResult> UpdateEnrollment(EnrollmentViewModel enrollArgs)
        {
            Enrollment enrollment = new Enrollment
            {
                Id = enrollArgs.Id,
                StudentId = enrollArgs.StudentId,
                CourseId = enrollArgs.CourseId,
                UpdatedDate = DateTime.Now,
                UpdateUserName = ""
            };
            return await _enrollmentRepo.UpdateEnrollment(enrollment);
        }
    }
}
