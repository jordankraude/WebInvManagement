using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebInvManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebInvManagement.Pages
{
    [Authorize]
    public class RemoveProductModel : PageModel
    {
        private readonly MongoDBService _mongoDBService;
        private readonly ILogger<RemoveProductModel> _logger;

        public RemoveProductModel(MongoDBService mongoDBService, ILogger<RemoveProductModel> logger)
        {
            _mongoDBService = mongoDBService;
            _logger = logger;
            Products = new List<Product>();
        }

        public List<Product> Products { get; set; }

        [BindProperty]
        public List<string> SelectedProducts { get; set; } // Property to bind selected product IDs

        public async Task OnGetAsync()
        {
            var productCollection = _mongoDBService.GetCollection<Product>("products");
            Products = await productCollection.Find(_ => true).ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (SelectedProducts == null || SelectedProducts.Count == 0)
            {
                ModelState.AddModelError(string.Empty, "No products selected for deletion.");
                return Page();
            }

            foreach (var productId in SelectedProducts)
            {
                var filter = Builders<Product>.Filter.Eq(p => p.Id, productId);

                try
                {
                    await _mongoDBService.DeleteProductAsync(filter, "products");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error deleting product with ID {productId}: {ex.Message}");
                    ModelState.AddModelError(string.Empty, $"Error deleting product with ID {productId}. Please try again later.");
                    return Page();
                }
            }

            return RedirectToPage("./RemoveProduct");
        }
    }
}
