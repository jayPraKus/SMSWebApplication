using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SMS.WebApp.Services.IServices;
using SMSWebAppData.Models.ViewModels;

namespace SMSWebAppHost.Pages.Course
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<CourseViewModel>? CourseList { get; set; }
        private readonly ICourseServices _courseService;
        private readonly ITeacherServices _teacherService;
        public IndexModel(ICourseServices courseService, ITeacherServices teacherService)
        {
            _courseService = courseService;
            _teacherService = teacherService;
        }
        public async void OnGet()
        {
            var response = await _courseService.GetAllCourse();
            if(response.Data != null)
            {
                CourseList = response.Data;
            }
        }
        public async Task<PartialViewResult> OnGetCreateCourse()
        {
            var teacherList = await _teacherService.GetAllTeacherAsync();
            CourseViewModel courseModel = new CourseViewModel
            {
                Teachers = teacherList.Data
            };
            return new PartialViewResult
            {
                ViewName = "_CreateCourse",
                ViewData = new ViewDataDictionary<CourseViewModel>(ViewData, courseModel)                
            };
            
        }
        public async Task<IActionResult> OnPostAddCourse(CourseViewModel courseArgs)
        {
            var response = await _courseService.CreateCourse(courseArgs);
            if (response.IsSuccess)
            {
                return RedirectToAction("/Course/Index");
            }
            return Page();
        }
    }
}
