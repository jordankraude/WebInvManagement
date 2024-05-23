using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class LoginModel : PageModel
{
    public IActionResult OnGet(string returnUrl = "/")
    {
        // Display the login page
        return Page();
    }

    public IActionResult OnPost(string returnUrl = "/dashboard")
    {
        // Redirect to the external authentication provider (Google)
        var redirectUrl = Url.Page("./ExternalLogin", pageHandler: null, values: new { ReturnUrl = returnUrl });
        var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
        return new ChallengeResult(GoogleDefaults.AuthenticationScheme, properties);
    }
}

