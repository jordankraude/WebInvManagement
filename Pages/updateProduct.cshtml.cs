using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using System.Threading.Tasks;
using WebInvManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace WebInvManagement.Pages
{
    [Authorize]
    public class UpdateProductModel : PageModel
    {
        private readonly MongoDBService _mongoDBService;

        public UpdateProductModel(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
            Products = new List<Product>(); // Initialize Products list
        }

        public List<Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            var productCollection = _mongoDBService.GetCollection<Product>("products");
            Products = await productCollection.Find(_ => true).ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(string productId)
        {
            var productCollection = _mongoDBService.GetCollection<Product>("products");
            var filter = Builders<Product>.Filter.Eq(p => p.Id, productId);
            var product = await productCollection.Find(filter).FirstOrDefaultAsync();

            if (product == null)
            {
                // Handle case where product is not found
                return NotFound();
            }

            // Redirect to the UpdateProductSubmission page with product data as query parameters
            return RedirectToPage("/updateProductSubmission", new
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                Weight = product.Weight,
                Barcode = product.Barcode
            });
        }
    }
}
