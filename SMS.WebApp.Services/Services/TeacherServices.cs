using SMS.WebApp.Core.IRepositories;
using SMS.WebApp.Services.IServices;
using SMSWebAppData.Helper;
using SMSWebAppData.Models.DataModels;
using SMSWebAppData.Models.Enums;
using SMSWebAppData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Services.Services
{
    public class TeacherServices : ITeacherServices
    {
        private readonly ITeacherRepositories _teacherRepo;
        public TeacherServices(ITeacherRepositories teacherRepo)
        {
            _teacherRepo = teacherRepo;
        }

        public async Task<DataResult> CreateTeacherAsync(TeacherViewModel teacherArgs)
        {
            //assigning the user input data in teacher table; transferring TeacherViewModel to Teacher
            Teacher teach = new Teacher
            {
                FirstName = teacherArgs.FirstName,
                LastName = teacherArgs.LastName,
                DOB = teacherArgs.DOB,
                Gender = teacherArgs.Gender,
                Subject = teacherArgs.Subject,
                Email = teacherArgs.Email,
                Phone = teacherArgs.Phone,
                CreatedDate = DateTime.UtcNow,
                CreateUserName = Environment.UserName,
                UpdatedDate = null,
                UpdateUserName = null,
                IsDeleted = false
            };
            var user = await _teacherRepo.CreateTeacherAsync(teach);
            return user;
        }

        public async Task<DataResult> DeleteTeacherAsync(Guid teacherId)
        {
            return await _teacherRepo.DeleteTeacherAsync(teacherId);
        }

        public async Task<DataResult<TeacherViewModel>> GetAllTeacherAsync()
        {
            DataResult<TeacherViewModel> result = new DataResult<TeacherViewModel>();
            var response = await _teacherRepo.GetAllTeacherAsync();           
            //Transferring data from Teacher to TeacherViewModel
            result.Data = response.Data.Select(s => new TeacherViewModel
                                        {
                                            TeacherId = s.Id,
                                            FirstName = s.FirstName,
                                            LastName = s.LastName,
                                            DOB = s.DOB,
                                            Gender = s.Gender,
                                            Subject = s.Subject,
                                            Email = s.Email,
                                            Phone =s.Phone,
                                        }).ToList();
            result.IsSuccess = response.IsSuccess;
            result.Message = response.Message;
            return result;
        }        

        public async Task<DataResult<TeacherViewModel>> GetTeacherByID(Guid TeacherId)
        {
            DataResult<TeacherViewModel> result = new DataResult<TeacherViewModel>();
            var response = await _teacherRepo.GetTeacherByIDAsync(TeacherId);            
            result.Data = response.Data.Select(s => new TeacherViewModel
                                            {
                                                TeacherId = s.Id,
                                                FirstName = s.FirstName,
                                                LastName = s.LastName,
                                                DOB = s.DOB,
                                                Gender = s.Gender,
                                                Phone = s.Phone,
                                                Subject = s.Subject,
                                                Email = s.Email
                                            }).ToList();
            result.Message = response.Message;
            result.IsSuccess = response.IsSuccess;
            return result;
        }

        public async Task<DataResult> UpdateTeacherAsync(TeacherViewModel teacherArgs)
        {
            Teacher t = new Teacher
            {
                Id = teacherArgs.TeacherId,
                FirstName = teacherArgs.FirstName,
                LastName = teacherArgs.LastName,
                DOB = teacherArgs.DOB,
                Gender = teacherArgs.Gender,
                Subject = teacherArgs.Subject,
                Phone = teacherArgs.Phone,
                Email = teacherArgs.Email,
                IsDeleted = false,
                UpdatedDate = DateTime.UtcNow,                
                //TODO: implement method to get username
                UpdateUserName ="",
                
            };
            var result = await _teacherRepo.UpdateTeacherAsync(t);
            return result;
        }
    }
}
