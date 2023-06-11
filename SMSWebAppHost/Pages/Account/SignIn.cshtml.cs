using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.WebApp.Services.IServices;
using SMSWebAppData.Models.ViewModels;

namespace SMSWebAppHost.Pages
{
    public class SignInModel : PageModel
    {
        [BindProperty]    //maps the email & password provided in view page with LoginViewModel 
        public LoginViewModel Account { get; set; }
        private readonly IAccountServices _services;
        public SignInModel(IAccountServices services)
        {
            _services = services;
        }   
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            var result =await _services.LoginAsync(this.Account);
            if (result.IsSuccess)
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
