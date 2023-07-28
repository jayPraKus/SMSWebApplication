using SMSWebAppData.Helper;
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
    public interface IImageRepositories
    {
        Task<DataResult> CreateImage(Image imageArgs);
        
        Task<DataResult> DeleteImage(Guid ImageId);
        Task<DataResult<Image>> GetAllImages();
        Task<DataResult<Image>> GetImageById(Guid ImageId);

    }
}
