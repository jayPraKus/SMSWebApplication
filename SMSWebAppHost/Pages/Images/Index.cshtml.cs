using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.WebApp.Core.Repositories;
using SMSWebAppData.Models.DataModels;

namespace SMSWebAppHost.Pages.Images
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Image> imgs { get; set; }
        private readonly ImageRepositories _imageRepo;
        public IndexModel(ImageRepositories imageRepo)
        {
            _imageRepo = imageRepo;
        }
        public async Task<IActionResult> OnGet()
        {
            var result = await _imageRepo.GetAllImages();
            if (result.IsSuccess)
            {
                imgs = result.Data;
                return Page();
            }
            else
            {
                return NotFound();
            }
        }
        
    }
}
