using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebInvManagement.Models;
using System.Threading.Tasks;
using MongoDB.Driver;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace WebInvManagement.Pages
{
    [Authorize]
    public class UpdateProductSubmissionModel : PageModel
    {
        private readonly MongoDBService _mongoDBService;

        public UpdateProductSubmissionModel(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Description { get; set; }

        [BindProperty(SupportsGet = true)]
        public double Price { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Quantity { get; set; }

        [BindProperty(SupportsGet = true)]
        public double Weight { get; set; }

        [BindProperty(SupportsGet = true)]
        public long Barcode { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // You can directly access the bound properties here
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var productCollection = _mongoDBService.GetCollection<Product>("products");
            var filter = Builders<Product>.Filter.Eq(p => p.Id, Id);

            var update = Builders<Product>.Update
                .Set(p => p.Name, Name)
                .Set(p => p.Description, Description)
                .Set(p => p.Price, Price)
                .Set(p => p.Quantity, Quantity)
                .Set(p => p.Weight, Weight)
                .Set(p => p.Barcode, Barcode);

            var result = await productCollection.UpdateOneAsync(filter, update);

            if (result.ModifiedCount == 0)
            {
                // Product not found or not updated
                return NotFound();
            }

            return RedirectToPage("/ViewInventory"); // Redirect to home page or wherever appropriate
        }

    }
}
