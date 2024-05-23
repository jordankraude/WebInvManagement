using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Threading.Tasks;

[AllowAnonymous]
public class ExternalLoginModel : PageModel
{
    public async Task<IActionResult> OnGetAsync(string returnUrl = "/dashboard")
    {
        var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        if (!authenticateResult.Succeeded)
            return RedirectToPage("/");

        // You can process user info here and create custom claims if needed.
        var claimsIdentity = new ClaimsIdentity(authenticateResult.Principal.Identity);

        // Adding roles (you can fetch roles from your database)
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

        // return LocalRedirect(returnUrl ?? "/dashboard");
        return RedirectToPage("https://localhost:7289/dashboard");
    }
}
