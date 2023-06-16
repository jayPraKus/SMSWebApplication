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
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepositories _studentRepo;
        public StudentServices(IStudentRepositories studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public async Task<DataResult> CreateStudentAsync(StudentViewModel studentArgs)
        {
            //Creating the object of student and passing data in it
            Students student = new Students
            {
                FirstName = studentArgs.FirstName,
                LastName = studentArgs.LastName,
                DOB = studentArgs.DOB,
                Gender = studentArgs.Gender,
                GradeLevel = studentArgs.GradeLevel,
                PhoneNumber = studentArgs.PhoneNumber,
                IsDeleted = false,
                UpdatedDate=DateTime.Now,
                UpdateUserName=null,
                CreatedDate=DateTime.UtcNow,
                CreateUserName="",
            };            
            return await _studentRepo.CreateStudentAsync(student);
        }
        public async Task<DataResult> DeleteStudentAsync(Guid studentId)
        {
            var result = await _studentRepo.DeleteStudentAsync(studentId);
            return result;
        }

        public async Task<DataResult<StudentViewModel>> GetAllStudentAsync()
        {
            //Define return type variable 
            DataResult<StudentViewModel> result = new DataResult<StudentViewModel>();
            //Get data from student Repositories
            var response = await _studentRepo.GetAllStudentAsync();
            //Assign  vlaue to defined returned variabe (result) form repositories response
            result.Message = response.Message;
            result.IsSuccess = response.IsSuccess;
            //Map (assign) data from students datamodel to studentViewModel 
            result.Data = response.Data.Select(s => new StudentViewModel
                                            {
                                                FirstName=s.FirstName,
                                                LastName=s.LastName,
                                                DOB = s.DOB,
                                                Gender = s.Gender,
                                                GradeLevel=s.GradeLevel,
                                                PhoneNumber = s.PhoneNumber
                                            }).ToList();
            
            return result;
        }

        public async Task<DataResult> UpdateStudentAsync(StudentViewModel studentArgs)
        {
            Students student = new Students
            {
                FirstName = studentArgs.FirstName,
                LastName = studentArgs.LastName,
                DOB = studentArgs.DOB,
                Gender = studentArgs.Gender,
                GradeLevel = studentArgs.GradeLevel,
                PhoneNumber = studentArgs.PhoneNumber,
                IsDeleted = false,
                UpdatedDate = DateTime.Now,
                UpdateUserName = null,
                CreatedDate = DateTime.UtcNow,
                CreateUserName = "",
            };
            var result = await _studentRepo.UpdateStudentAsync(student);
            return result;
        }
    }
}
