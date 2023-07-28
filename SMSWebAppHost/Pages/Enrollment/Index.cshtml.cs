using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SMS.WebApp.Services.IServices;
using SMS.WebApp.Services.Services;
using SMSWebAppData.Models.RequestModels;
using SMSWebAppData.Models.ViewModels;

namespace SMSWebAppHost.Pages.Enrollment
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<EnrollmentViewModel> EnrollmentList { get; set; }
        private readonly IEnrollmentServices _enrollService;
        private readonly IStudentServices _studentService;
        private readonly ICourseServices _courseService;
        public IndexModel(IEnrollmentServices enrollmentService, IStudentServices studentServices, ICourseServices courseServices)
        {
            _enrollService = enrollmentService;
            _studentService = studentServices;
            _courseService = courseServices;
        }
        public async Task OnGet()
        {
            var result = await _enrollService.GetAllEnrollment();
            if (result.Data != null)
            {
                EnrollmentList = result.Data;
            }
        }
        public async Task<PartialViewResult> OnGetCreateEnrollment()
        {
            var studentList = await _studentService.GetAllStudentAsync();
            RequestQueryParams queryParams = new RequestQueryParams
            {
                PageSize = 1,
                CurrentPage = 2
            };
            var courseList = await _courseService.GetAllCourse(queryParams);            
            EnrollmentViewModel enrollModel = new EnrollmentViewModel
            {
                Students = studentList.Data,
                Courses = courseList.Data                
            };
            return new PartialViewResult
            {
                ViewName = "_CreateEnrollment",
                ViewData = new ViewDataDictionary<EnrollmentViewModel>(ViewData, enrollModel)
            };
        }
        public async Task<IActionResult> OnPostAddEnrollment(EnrollmentViewModel enrollArgs)
        {
            var response = await _enrollService.CreateEnrollment(enrollArgs);
            if (response.IsSuccess)
            {
                return RedirectToAction("/Enrollment/Index");
            }
            return Page();
        }
        public async Task<PartialViewResult> OnGetUpdateEnrollment(Guid id)
        {
            var studentList = await _studentService.GetAllStudentAsync();
            var enrollment = await _enrollService.GetEnrollmentById(id);
            var enrollModel = enrollment.Data.First();
            enrollModel.Students = studentList.Data;
            return new PartialViewResult
            {
                ViewName = "_Update",
                ViewData = new ViewDataDictionary<CourseViewModel>(ViewData, enrollModel)
            };
        }
    }
}
