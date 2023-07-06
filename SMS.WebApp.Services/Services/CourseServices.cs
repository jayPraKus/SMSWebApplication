using Azure;
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
    public class CourseServices : ICourseServices
    {
        private readonly ICourseRepositories _courseRepo;
        public CourseServices(ICourseRepositories courseRepo)
        {
            _courseRepo = courseRepo;
        }
        public async Task<DataResult> CreateCourse(CourseViewModel courseArgs)
        {
            Course course = new Course
            {
                CourseName = courseArgs.CourseName,
                TeacherId = courseArgs.TeacherId,
                CreatedDate = DateTime.Now,
                CreateUserName = "",
                //IsDeleted = false,
                //UpdateUserName = null,
                //UpdatedDate = null,

            };
            var respone = await _courseRepo.CreateCourse(course);
            return respone;
        }

        public async Task<DataResult> DeleteCourse(Guid courseId)
        {
            var response = await _courseRepo.DeleteCourse(courseId);
            return response;
        }

        public async Task<DataResult<CourseViewModel>> GetAllCourse()
        {
            var response = await _courseRepo.GetAllCourse();            
            return response;
        }

        public async Task<DataResult<CourseViewModel>> GetCourseById(Guid courseId)
        {
            var response = await _courseRepo.GetCourseById(courseId);
            return response;
        }

        public async Task<DataResult> UpdateCourse(CourseViewModel courseArgs)
        {
            Course course = new Course
            {
                CourseName = courseArgs.CourseName,
                TeacherId = courseArgs.TeacherId,
                UpdateUserName = "",
                UpdatedDate = DateTime.Now
            };            
            return await _courseRepo.UpdateCourse(course);
        }
    }
}
