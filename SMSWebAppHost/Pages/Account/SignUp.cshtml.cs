using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.WebApp.Services.IServices;
using SMSWebAppData.Models.ViewModels;

namespace SMSWebAppHost.Pages.Account
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public RegisterViewModel RegisterAccount { get; set; }
        private readonly IAccountServices _accountServices;
        public SignUpModel(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
               var result =await _accountServices.RegisterAsync(this.RegisterAccount);
                if (result.IsSuccess)
                {
                    return RedirectToPage("/Account/SignIn");
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
