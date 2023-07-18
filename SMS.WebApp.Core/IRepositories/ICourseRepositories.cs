﻿using SMSWebAppData.Helper;
using SMSWebAppData.Models.DataModels;
using SMSWebAppData.Models.RequestModels;
using SMSWebAppData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Core.IRepositories
{
    public interface ICourseRepositories
    {
        Task<DataResult> CreateCourse(Course courseArgs);
        Task<DataResult> UpdateCourse(Course courseArgs);
        Task<DataResult> DeleteCourse(Guid CourseId);
        Task<DataResult<CourseViewModel>> GetAllCourse(RequestQueryParams QueryParam);
        Task<DataResult<CourseViewModel>> GetCourseById(Guid courseId);

    }
}
