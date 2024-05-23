using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace WebInvManagement.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPostAddPhysicalProduct()
        {
            return RedirectToPage("/AddPhysicalProduct");
        }

        public IActionResult OnPostAddDigitalProduct()
        {
            return RedirectToPage("/AddDigitalProduct");
        }

        public IActionResult OnPostViewInventory()
        {
            return RedirectToPage("/ViewInventory");
        }

        public IActionResult OnPostEditProduct()
        {
            return RedirectToPage("/EditProduct");
        }

        public IActionResult OnPostDeleteProduct()
        {
            return RedirectToPage("/DeleteProduct");
        }
    }
}
