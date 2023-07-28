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
    public class ImageRepositories : IImageRepositories
    {
        private readonly SMSDbContext _context;
        public ImageRepositories(SMSDbContext context)
        {
            _context = context;
        }

        public async Task<DataResult> CreateImage(Image imageArgs)
        {
            DataResult result = new DataResult();
            try
            {
                await _context.Images.AddAsync(imageArgs);
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Image created successfully";

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;

            }
            return result;
        }

        public async Task<DataResult> DeleteImage(Guid ImageId)
        {
            DataResult result = new DataResult();
            try
            {
                var course = await _context.Images.FindAsync(ImageId);
                if (course == null)
                {
                    result.IsSuccess = false;
                    result.Message = "No Image found";
                }
                course.IsDeleted = true;
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Image deleted successfully";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public Task<DataResult<Image>> GetAllImages()
        {
            throw new NotImplementedException();
        }

        public Task<DataResult<Image>> GetImageById(Guid ImageId)
        {
            throw new NotImplementedException();
        }
    }
}
