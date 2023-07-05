using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.WebApp.Services.IServices;
using SMS.WebApp.Services.Services;
using SMSWebAppData.Helper;
using SMSWebAppData.Models.Enums;
using SMSWebAppData.Models.ViewModels;

namespace SMSWebAppHost.Pages.Teacher
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<TeacherViewModel> TeacherList { get; set; }
        [BindProperty]
        public TeacherViewModel TeacherVM { get; set; }
        [BindProperty]
        public List<GenderEnums> GenderList { get; set; }
        [BindProperty]
        public DataResult Response { get; set; }
        private readonly ITeacherServices _teacherServices;
        public IndexModel(ITeacherServices teacherServices)
        {
            _teacherServices = teacherServices;
        }

        public async Task<IActionResult> OnGet(DataResult resp=null)
        {
            var response = await _teacherServices.GetAllTeacherAsync();
            TeacherList = response.Data;
            GenderList = Enum.GetValues<GenderEnums>().ToList();
            Response = resp;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            DataResult response = new DataResult();
            if (TeacherVM.TeacherId.Equals(Guid.Empty))
            {
                 response = await _teacherServices.CreateTeacherAsync(TeacherVM);
            }
            else
            {
                 response = await _teacherServices.UpdateTeacherAsync(TeacherVM);
            }
            
            return RedirectToAction("Index", response);
            
        }
        public async Task<IActionResult> OnGetDeleteTeacher(Guid id)
        {
            var result = await _teacherServices.DeleteTeacherAsync(id);
            return RedirectToAction("Index", result);            
        }
        public async Task<IActionResult> OnGetUpdateTeacher(Guid Id)
        {
            var response = await _teacherServices.GetTeacherByID(Id);
            return new OkObjectResult(response.Data.First());
        }

    }
}
