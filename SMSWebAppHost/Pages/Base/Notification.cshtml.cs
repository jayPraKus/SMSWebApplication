using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata;

namespace SMSWebAppHost.Pages.Base
{
    public class NotificationModel : PageModel
    {
        [BindProperty]
        public string ModalTitle { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public void OnGet(string modalTitle, String message)
        {
            modalTitle = ModalTitle;
            message = Message;
        }
    }
}
