using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SMS.WebApp.Services.IServices;
using SMSWebAppData.Models.ViewModels;

namespace SMSWebAppHost.Pages.Student
{
    public class IndexModel : PageModel
    {
        private readonly IStudentServices _studentServices;
        public List<StudentViewModel> Students { get; set; }
        public IndexModel(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }
        public async Task<IActionResult> OnGet()
        {
            var result = await _studentServices.GetAllStudentAsync();
            if(result.IsSuccess)
            {
                Students = result.Data;
                return Page();
            }
            else
            {
                return NotFound();
            }

        }
    }
}
