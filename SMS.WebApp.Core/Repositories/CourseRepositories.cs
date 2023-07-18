using Microsoft.EntityFrameworkCore;
using SMS.WebApp.Core.IRepositories;
using SMSWebAppData;
using SMSWebAppData.Helper;
using SMSWebAppData.Models.DataModels;
using SMSWebAppData.Models.RequestModels;
using SMSWebAppData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Core.Repositories
{
    public class CourseRepositories : ICourseRepositories
    {
        private readonly SMSDbContext _context;
        public CourseRepositories(SMSDbContext context)
        {
            _context = context;
        }

        public async Task<DataResult> CreateCourse(Course courseArgs)
        {
            DataResult result = new DataResult();
            try
            {
                await _context.Courses.AddAsync(courseArgs);
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Student created successfully";

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;

            }
            return result;
        }

        public async Task<DataResult> DeleteCourse(Guid courseId)
        {
            DataResult result = new DataResult();
            try
            {
                var course = await _context.Courses.FindAsync(courseId);
                if (course == null)
                {
                    result.IsSuccess = false;
                    result.Message = "No data found";
                }
                course.IsDeleted = true;
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Courses deleted successfully";
            }
            catch(Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult<CourseViewModel>> GetAllCourse(RequestQueryParams queryParams)
        {
            DataResult<CourseViewModel> result = new DataResult<CourseViewModel>();
            try
            {
                var data = await _context.Courses.Where(a => a.IsDeleted == false).OrderBy(o => o.Id).ToListAsync();
                if (data.Count != 0)
                {
                    result.Data = data.Select(s => new CourseViewModel
                                       {
                                            Id = s.Id,
                                            CourseName = s.CourseName,
                                            TeacherId = s.TeacherId,
                                        //TotalCount = data.Count(),
                                            TeacherFullName = s.Teacher.FirstName + " " + s.Teacher.LastName
                                       })
                                        .OrderBy(o=>o.Id)
                                        .Skip((queryParams.CurrentPage-1) * queryParams.PageSize)
                                        .Take(queryParams.PageSize)
                                        .ToList();
                }

                //result.Data = await _context.Courses.Where(a => a.IsDeleted == false).Select(s=> new Course { CourseName=s.courseName, TeacherId=s.teacherId });   ==LINQ Query
                //select courseName, TeacherId from Courses Where IsDeleted = false;  ===SQL Query
                result.TotalCount = data.Count;
                result.IsSuccess = true;
                result.Message = "GetAll courses successfully";

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult<CourseViewModel>> GetCourseById(Guid courseId)
        {
            DataResult<CourseViewModel> result = new DataResult<CourseViewModel>();
            try
            {
                result.Data = await _context.Courses.Where(a => a.IsDeleted == false && a.Id == courseId).Select(s => new CourseViewModel
                {
                    Id = s.Id,
                    CourseName = s.CourseName,
                    TeacherId = s.TeacherId,
                    TeacherFullName = s.Teacher.FirstName + " " + s.Teacher.LastName
                }).ToListAsync();
                result.IsSuccess = true;
                result.Message = "GetAll courses successfully";

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;

        }

        public async Task<DataResult> UpdateCourse(Course courseArgs)
        {
            DataResult result = new DataResult();
            try
            {
                var course = await _context.Courses.FindAsync(courseArgs.Id);
                if (course == null)
                {
                    result.IsSuccess = false;
                    result.Message = "No data found";
                }
                course.CourseName = courseArgs.CourseName;
                course.UpdateUserName = courseArgs.UpdateUserName;
                course.TeacherId = courseArgs.TeacherId;
                course.UpdatedDate = courseArgs.UpdatedDate;
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Data updated successfully";
            }
            catch(Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
            
        }
    }
}
