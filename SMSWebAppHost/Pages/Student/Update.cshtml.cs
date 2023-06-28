using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.WebApp.Services.IServices;
using SMSWebAppData.Models.Enums;
using SMSWebAppData.Models.ViewModels;

namespace SMSWebAppHost.Pages.Student
{
    public class UpdateModel : PageModel
    {
        private readonly IStudentServices _studentServices;
        [BindProperty]
        public StudentViewModel StudentViewModel { get; set; }
        [BindProperty]
        public List<GenderEnums> GenderList { get; set; }
        public UpdateModel(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }
        public async Task<IActionResult> OnGet(Guid Id)
        {
            //Get student by ID
            var response = await _studentServices.GetStudentByID(Id);
            //var resp = await _studentServices.GetGenderList();
            if(response.Data != null)
            {
                StudentViewModel = response.Data.First();
            }
            GenderList = Enum.GetValues<GenderEnums>().ToList();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            var response = await _studentServices.UpdateStudentAsync(StudentViewModel);
            if (response.IsSuccess)
            {
                return RedirectToPage("/Student/Index");
            }
            return Page();
        }
    }
}
