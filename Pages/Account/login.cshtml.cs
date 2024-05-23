using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace WebInvManagement.Pages.Account
{

    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/" }, "Google");
        }
    }
}
