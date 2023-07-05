using Microsoft.Data.SqlClient;
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
    public class StudentRepositories : IStudentRepositories
    {
        private readonly SMSDbContext _context;
        public StudentRepositories(SMSDbContext context)
        {
            _context = context;
        }

        public async Task<DataResult> CreateStudentAsync(Students studentArgs)
        {
            DataResult result = new DataResult();            
            try
            {
                await _context.Students.AddAsync(studentArgs);  //methods provided by the Entity Framework
                await _context.SaveChangesAsync();    // saves in database
                result.IsSuccess = true;
                result.Message= "Student created successfully";
            }
            catch(Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }            
            return result;
        }

        public async Task<DataResult> DeleteStudentAsync(Guid studentId)
        {
            DataResult result = new DataResult();
            try
            {
                //await _context.Students.Where(x=>x.Id==studentId).ExecuteDeleteAsync();
                var user = await _context.Students.Where(x => x.Id == studentId).FirstOrDefaultAsync();
                if (user == null)
                {
                    result.IsSuccess = false;
                    result.Message = "No user found";
                }
                user.IsDeleted = true;                  
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Student deleted successfully";
            }
            catch(Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;            
        }
        public async Task<DataResult<Students>> GetAllStudentAsync()
        {
            DataResult<Students> result= new DataResult<Students>();
            try
            {
                //var dat = _context.Students.Select(s => s.DOB);
                //dat.Where(w => w.Year > 2018);
                result.Data = await _context.Students.Where(w => w.IsDeleted == false).ToListAsync();
                result.IsSuccess = true;
                result.Message = "Students data fetched successfully";
            } 
            catch(Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }

        public async Task<DataResult<Students>> GetStudentsByIDAsync(Guid studentID)
        {
            DataResult<Students> result = new DataResult<Students>();
            try
            {
                result.Data = await _context.Students.Where(w => w.Id == studentID).ToListAsync();
                result.IsSuccess = true;
                result.Message = "Get Student By ID Successful";
            }
            catch(Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }

        public async Task<DataResult> UpdateStudentAsync(Students studentArgs)
        {
            DataResult result= new DataResult();
            try
            {
                var data = await _context.Students.Where(x => x.Id == studentArgs.Id).FirstAsync();
                data.FirstName = studentArgs.FirstName;
                data.LastName = studentArgs.LastName;
                data.PhoneNumber = studentArgs.PhoneNumber;
                data.Gender = studentArgs.Gender;
                data.GradeLevel = studentArgs.GradeLevel;
                data.DOB = studentArgs.DOB;
                data.UpdateUserName = studentArgs.UpdateUserName;
                data.UpdatedDate = studentArgs.UpdatedDate;
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Student updated successfully";
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
