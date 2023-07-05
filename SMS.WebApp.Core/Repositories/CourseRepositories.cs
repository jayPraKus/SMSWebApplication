﻿using Microsoft.EntityFrameworkCore;
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
                result.Message = "Courses created successfully";
            }
            catch(Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult<Course>> GetAllCourse()
        {
            DataResult<Course> result = new DataResult<Course>();
            try
            {
                result.Data = await _context.Courses.Where(a => a.IsDeleted == false).ToListAsync();
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

        public async Task<DataResult<Course>> GetCourseById(Guid courseId)
        {
            DataResult<Course> result = new DataResult<Course>();
            try
            {
                result.Data = await _context.Courses.Where(a => a.IsDeleted == false && a.Id == courseId).ToListAsync();
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
