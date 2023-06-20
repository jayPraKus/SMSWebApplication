using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.WebApp.Services.IServices;
using SMSWebAppData.Models.Enums;
using SMSWebAppData.Models.ViewModels;

namespace SMSWebAppHost.Pages.Student
{
    public class CreateModel : PageModel
    {
        private readonly IStudentServices _studentServices;
        [BindProperty]
        public StudentViewModel StudentViewModel { get; set; }
        [BindProperty]
        public List<GenderEnums> GenderList { get; set; }
        public CreateModel(IStudentServices studentservices)
        {
            _studentServices = studentservices;
        }
        public async Task<IActionResult> OnGet()
        {
            var result = await _studentServices.GetGenderList();
            if (result.Data != null)
            {
                GenderList = result.Data;
            }
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            StudentViewModel.UserName = User.Identity.Name;
            if (ModelState.IsValid)
            {                
                var response = await _studentServices.CreateStudentAsync(StudentViewModel);
                if (response.IsSuccess)
                {
                    return RedirectToPage("/Student/Index");
                }
                else
                {
                    return Page();
                }
            }
            return Page();
                        
        }
    }
}
