using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SMS.WebApp.Services.IServices;
using SMS.WebApp.Services.Services;
using SMSWebAppData.Models.RequestModels;
using SMSWebAppData.Models.ViewModels;

namespace SMSWebAppHost.Pages.Course
{
    //Allow annynomus | Authorization
    [Authorize]          //Adding authorization will prevent the data access from URL without sign in
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<CourseViewModel>? CourseList { get; set; }
        [BindProperty]
        public int PageCount { get; set; }
        private readonly ICourseServices _courseService;
        private readonly ITeacherServices _teacherService;
        public IndexModel(ICourseServices courseService, ITeacherServices teacherService)
        {
            _courseService = courseService;
            _teacherService = teacherService;
        }
        public async Task OnGet(int pageSize, int currentPage)
        {
            //Set session
            HttpContext.Session.SetString("SessionDemo", "Value stored in session");
            RequestQueryParams queryParams = new RequestQueryParams
            {
                PageSize = pageSize == 0 ? 1 : pageSize,
                CurrentPage = currentPage == 0 ? 1 : currentPage
            };
            var response = await _courseService.GetAllCourse(queryParams);
            if(response.Data != null)
            {
                CourseList = response.Data;
                PageCount = Convert.ToInt32(Math.Ceiling(response.TotalCount/(double)queryParams.PageSize));
            }
        }
        public async Task<PartialViewResult> OnGetCreateCourse()
        {
            //Get session
            var sess = HttpContext.Session.GetString("SessionDemo");
            var teacherList = await _teacherService.GetAllTeacherAsync();
            CourseViewModel courseModel = new CourseViewModel
            {
                Teachers = teacherList.Data,
                sessionExample = sess
            };
            return new PartialViewResult
            {
                ViewName = "_CreateCourse",
                ViewData = new ViewDataDictionary<CourseViewModel>(ViewData, courseModel)                
            };
            
        }
        public async Task<PartialViewResult> OnGetUpdateCourse(Guid id)
        {
            var teacherList = await _teacherService.GetAllTeacherAsync();
            var course = await _courseService.GetCourseById(id);
            var courseModel = course.Data.First();
            courseModel.Teachers = teacherList.Data;
            return new PartialViewResult
            {
                ViewName = "_Update",
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
        public async Task<IActionResult> OnGetDeleteCourse(Guid id)
        {
            var response = await _courseService.DeleteCourse(id);
            if (response.IsSuccess)
            {
                return RedirectToAction("/Course/Index");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostEditCourse(CourseViewModel courseArgs)
        {
            var response = await _courseService.UpdateCourse(courseArgs);
            if (response.IsSuccess)
            {
                return RedirectToAction("/Course/Index");
            }
            return Page();
        }
    }
}
