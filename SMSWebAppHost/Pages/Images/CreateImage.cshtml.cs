using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.WebApp.Core.Repositories;
using SMSWebAppData.Models.DataModels;

namespace SMSWebAppHost.Pages.Images
{
    public class CreateImageModel : PageModel
    {
        [BindProperty]
        public Image Img { get; set; }
        private readonly ImageRepositories _imageRepo;
        public CreateImageModel(ImageRepositories imageRepo)
        {
            _imageRepo = imageRepo;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            if(Img.ImageFile.Length > 0)
            {
                using(var memoryStream = new  MemoryStream())
                {
                    await Img.ImageFile.CopyToAsync(memoryStream);
                    if(memoryStream.Length < 20971152)
                    {
                        var newphoto = new Image()
                        {
                            ImageName = Img.ImageName,
                            Title = Img.Title,
                            CreatedDate = DateTime.Now,
                            CreateUserName = "",
                            ImageData = memoryStream.ToArray()
                        };
                        await _imageRepo.CreateImage(newphoto);
                    }
                    else
                    {
                        ModelState.AddModelError("File", "The file is too large");
                    }
                }
            }
            return RedirectToPage("/Images/Index");
        }
    }
}
